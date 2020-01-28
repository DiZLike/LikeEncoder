using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Vst;
using System.IO;
using Un4seen.Bass;
using System.Threading;
using System.Windows.Forms;

namespace lib
{
    public delegate void test(float val);
    public delegate void OnChange(float val);
    public delegate void SCANPROC(float targetDB, float peakRMS, int progress);
    public class Maximizer
    {
        private string maximazer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vst_plugins", "iZotope Ozone 5 Maximizer.dll");
        private int vh = 0;

        private int stream = 0;
        private int index;
        float qTargetStep = 0.005f;
        int tolerance = 5;
        private int curTolerance = 0;

        private Thread timeThread;
        private float curPercent = 0f;
        private TimeSpan time;

        public Maximizer(int stream, int index)
        {
            this.stream = stream;
            this.index = index;
        }
        private void SetParams()
        {
            BassVst.BASS_VST_SetParam(vh, 17, 1); // Mode 1

            BassVst.BASS_VST_SetParam(vh, 18, 1);
            BassVst.BASS_VST_SetParam(vh, 16, 1);
            BassVst.BASS_VST_SetParam(vh, 13, 0.5f);
            BassVst.BASS_VST_SetParam(vh, 0, 1f);
        }
        private float Float2DB(float value)
        {
            float v = value / 1 * 20 - 20;
            return (float)Math.Round(v, 1);
        }
        public float Scan(float targetRMS, ProgressHandler PROC, ref bool isCanceled)
        {
            vh = BassVst.BASS_VST_ChannelSetDSP(stream, maximazer, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            SetParams();
            BassVst.BASS_VST_SetParam(vh, 8, 0);

            int stepCount = 1;
            float finalTarget = 0;
            float target = 0;
            bool targetChanged = false;
            float len = (float)Bass.BASS_ChannelBytes2Seconds(stream, Bass.BASS_ChannelGetLength(stream));

            do
            {
                StartCalculateTime();
                List<float> peakList = new List<float>();
                float oldPeak = 0;
                targetChanged = false;

                while (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING && !isCanceled)
                {
                    int length = (int)Bass.BASS_ChannelSeconds2Bytes(stream, 0.01); // 10ms window
                    byte[] data = new byte[length]; // 8-bit are bytes
                    length = Bass.BASS_ChannelGetData(stream, data, length);

                    float[] value = Bass.BASS_ChannelGetLevels(stream, 0.01f, BASSLevel.BASS_LEVEL_RMS | BASSLevel.BASS_LEVEL_ALL);
                    float result = 0;
                    if (value != null)
                        result = value[0] > value[1] ? value[0] : value[1];


                    float f = (float)Utils.LevelToDB(result, 1);//32768
                    if (float.IsInfinity(f))
                        f = -100;
                    float rms = 0f;

                    float RMSsum = 0;
                    if (oldPeak == f)
                        continue;
                    if (peakList.Count < 100) // 1000ms
                    {
                        peakList.Add((float)Math.Round(f, 1));
                        oldPeak = (float)Math.Round(f, 1);
                    }
                    else
                    {
                        for (int i = 0; i < peakList.Count; i++)
                            RMSsum += peakList[i];
                        rms = (float)Math.Round(RMSsum / peakList.Count, 1);
                        peakList.RemoveAt(0);

                        long posb = Bass.BASS_ChannelGetPosition(stream);
                        double poss = Bass.BASS_ChannelBytes2Seconds(stream, posb);
                        var prog = poss / len * 100f;
                        curPercent = (float)prog;

                        if (rms > targetRMS)
                        {
                            if (curTolerance >= tolerance)
                            {
                                target += qTargetStep;
                                if (target >= 1)
                                    return 0;
                                BassVst.BASS_VST_SetParam(vh, 8, target);
                                targetChanged = true;

                                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, poss - 1));
                                curTolerance = 0;
                            }
                            else
                                curTolerance++;
                        }
                        peakList.Add((float)Math.Round(f, 1));

                        finalTarget = target;
                        PROC(index, (int)prog, time, ProcType.RMS_SCAN, stepCount);
                    }
                }
                Bass.BASS_ChannelStop(stream);
                Bass.BASS_ChannelSetPosition(stream, 0);
                stepCount++;
                peakList.Clear();
                StopCalculateTime();
            }
            while (targetChanged && !isCanceled);
            BassVst.BASS_VST_ChannelRemoveDSP(stream, vh);

            return finalTarget;

        }
        public void SetMaximizer(float value)
        {
            vh = BassVst.BASS_VST_ChannelSetDSP(stream, maximazer, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            SetParams();
            BassVst.BASS_VST_SetParam(vh, 8, value);
        }
        public void Show()
        {
            vh = BassVst.BASS_VST_ChannelSetDSP(stream, maximazer, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            SetParams();
            BassVst.BASS_VST_SetParam(vh, 8, 0.5880001f);
            BASS_VST_INFO vstInfo = new BASS_VST_INFO();
            Form f = new Form();
            f.Width = 640;
            f.Height = 480;
            //f.Closing += new CancelEventHandler(f_Closing);
            f.Text = vstInfo.effectName;
            f.Show();
            BassVst.BASS_VST_EmbedEditor(vh, f.Handle);
        }

        private void StartCalculateTime()
        {
            if (timeThread != null)
                timeThread.Abort();
            timeThread = new Thread(delegate()
                {
                    Ext.CalculateTime(ref curPercent, out time);
                });
            timeThread.IsBackground = false;
            timeThread.Start();
        }
        private void StopCalculateTime()
        {
            timeThread.Abort();
        }

    }
}
