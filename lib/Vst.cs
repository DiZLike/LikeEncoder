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
    public class Vst
    {
        private string maximazer = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vst_plugins", "iZotope Ozone 5 Maximizer.dll");
        private int vh = 0;

        private int stream = 0;
        private double oldPos = 0;

        public Vst(int stream)
        {
            this.stream = stream;
        }

        private void SetParams()
        {
            BassVst.BASS_VST_SetParam(vh, 17, 1); // Mode 1

            BassVst.BASS_VST_SetParam(vh, 18, 1);
            BassVst.BASS_VST_SetParam(vh, 16, 1);
            BassVst.BASS_VST_SetParam(vh, 13, 0.5f);
            BassVst.BASS_VST_SetParam(vh, 0, 0.5296182f);
        }

        public float Scan(float targetRMS)
        {
            vh = BassVst.BASS_VST_ChannelSetDSP(stream, maximazer, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            SetParams();
            BassVst.BASS_VST_SetParam(vh, 8, 0);

            float finalTarget = 0;
            float target = 0;
            bool targetChanged = false;

            do
            {
                List<float> peakList = new List<float>();
                float oldPeak = 0;
                targetChanged = false;

                Bass.BASS_ChannelPlay(stream, false);
                while (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    float[] value = Bass.BASS_ChannelGetLevels(stream, 0.02f, BASSLevel.BASS_LEVEL_RMS);
                    float result = 0;
                    if (value != null)
                        result = value[0] > value[1] ? value[0] : value[1];


                    float f = (float)Utils.LevelToDB(result, 1);//32768

                    float RMSsum = 0;
                    if (oldPeak == f)
                        continue;
                    if (peakList.Count < 100)
                    {
                        peakList.Add((float)Math.Round(f, 1));
                        oldPeak = (float)Math.Round(f, 1);
                    }
                    else
                    {
                        for (int i = 0; i < peakList.Count; i++)
                            RMSsum += peakList[i];
                        float rms = (float)Math.Round(RMSsum / peakList.Count, 1);
                        peakList.RemoveAt(0);

                        long posb = Bass.BASS_ChannelGetPosition(stream);
                        double poss = Bass.BASS_ChannelBytes2Seconds(stream, posb);

                        if (rms > targetRMS)
                        {


                            target += 0.0005f;
                            BassVst.BASS_VST_SetParam(vh, 8, target);
                            targetChanged = true;

                            if (poss > 10)
                                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, poss - 1));
                            else
                                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, 0));
                        }
                        else
                            oldPos = poss;

                        finalTarget = target;
                        //Thread.Sleep(10);
                    }

                }
                Bass.BASS_ChannelStop(stream);
                Bass.BASS_ChannelSetPosition(stream, 0);
            }
            while (targetChanged);

            return finalTarget;

        }


        public void Show()
        {
            vh = BassVst.BASS_VST_ChannelSetDSP(stream, maximazer, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            SetParams();
            BassVst.BASS_VST_SetParam(vh, 8, 0.72118634f);
            BASS_VST_INFO vstInfo = new BASS_VST_INFO();
            Form f = new Form();
            f.Width = 640;
            f.Height = 480;
            //f.Closing += new CancelEventHandler(f_Closing);
            f.Text = vstInfo.effectName;
            f.Show();
            BassVst.BASS_VST_EmbedEditor(vh, f.Handle);

        }

        public void GetRMS(OnChange onChanged, int sleep)
        {
            
            float targetGain = 0f;
            BassVst.BASS_VST_SetParam(vh, 17, 1); // Mode 1


            BassVst.BASS_VST_SetParam(vh, 8, targetGain);

            List<float> R = new List<float>();
            float old = 0;
            while (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                
                float[] v = Bass.BASS_ChannelGetLevels(stream, 0.02f, BASSLevel.BASS_LEVEL_RMS);
                float res = 0;
                if (v != null)
                    res = v[0] > v[1] ? v[0] : v[1];


                float f = (float)Utils.LevelToDB(res, 1);//32768

                float RMSsum = 0;
                if (old == f)
                    continue;
                if (R.Count < 100)
                {
                    R.Add((float)Math.Round(f, 1));
                    old = (float)Math.Round(f, 1);
                }
                else
                {
                    for (int i = 0; i < R.Count; i++)
                        RMSsum += R[i];
                    float rms = (float)Math.Round(RMSsum / R.Count, 1);
                    R.RemoveAt(0);
                    //R.Clear();

                    if (rms > -1.0f)
                    {
                        //targetGain += 0.0005f;
                        //BassVst.BASS_VST_SetParam(vh, 8, targetGain);
                    }


                    onChanged(rms);
                    Thread.Sleep(sleep);
                }
            }
        }

        List<string> ol = new List<string>();

        public void test()
        {
            
            //int vh = BassVst.BASS_VST_ChannelSetDSP(stream, maximazer, BASSVSTDsp.BASS_VST_DEFAULT, 1);
            int vp = BassVst.BASS_VST_GetParamCount(vh);
            BASS_VST_PARAM_INFO paramInfo = new BASS_VST_PARAM_INFO();

            List<float> pvlist = new List<float>();
            List<string> infolist = new List<string>();

            // MODE 17 = 1

            for (int i = 0; i < vp; i++)
            {
                float pv = BassVst.BASS_VST_GetParam(vh, i); // 8
                BassVst.BASS_VST_GetParamInfo(vh, i, paramInfo);

                pvlist.Add(pv);
                infolist.Add(paramInfo.ToString() + " " + pv);

            }

            
            string ok = "";

            for (int i = 0; i < ol.Count; i++)
            {
                if (ol[i] != infolist[i])
                    ok = infolist[i];
            }

            ol = infolist;
            //ontest((float)res);
        }
    }
}
