using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using lib.Encoders.Opus;
using lib.Encoders.Lame;
using System.Threading;
using IO = System.IO;
using Un4seen.Bass.Misc;
using System.Drawing;
using Un4seen.Bass.AddOn.Tags;
using System.Windows.Controls;
using System.Windows.Shapes;
using WPFM = System.Windows.Media;

namespace lib.Encoders
{
    public delegate void PossitionHandler(double pos, double max);

    public class TestCodec
    {
        private string file;
        private int[] streams;
        private int cStream;
        private bool isEncoded;

        private Bitmap bitmap = new Bitmap(360, 221);
        private int bitmapCount = 0;

        private AudioOpusValue _opusValue = new AudioOpusValue();
        private AudioLameValue _lameValue = new AudioLameValue();
        private Thread encThread;
        private Thread posThread;
        private Visuals visuals = new Visuals();
        private ProgressHandler onProgress;
        private PossitionHandler onPossition;

        public string TestOpusFile { get { return IO.Path.Combine(testDir, "t.opus"); } }
        public string TestLameFile { get { return IO.Path.Combine(testDir, "t.mp3"); } }

        private string testDir = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tmp");

        public TestCodec(string file, ProgressHandler onProgress, PossitionHandler onPossition)
        {
            this.onProgress = onProgress;
            this.onPossition = onPossition;
            streams = new int[3];
            this.file = file;
            if (!IO.Directory.Exists(testDir))
                IO.Directory.CreateDirectory(testDir);

            encThread = new Thread(StartEncoding);
            posThread = new Thread(GetPosition);
            encThread.Start();
        }
        private void GetPosition()
        {
            while (Bass.BASS_ChannelIsActive(streams[0]) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                long posByte = Bass.BASS_ChannelGetPosition(streams[0]);
                long lenByte = Bass.BASS_ChannelGetLength(streams[0]);
                double pos = Bass.BASS_ChannelBytes2Seconds(streams[0], posByte);
                double len = Bass.BASS_ChannelBytes2Seconds(streams[0], lenByte);
                onPossition(pos, len);
                Thread.Sleep(250);
            }
        }
        private void StartEncoding()
        {
            _opusValue.LoadParams(_opusValue.CFG);
            _lameValue.LoadParams(_lameValue.CFG);

            new AudioOpus().Start(file, TestOpusFile, 0, 0, 0, _opusValue, onProgress, null);
            new AudioLame().Start(file, TestLameFile, 1, 0, 0, _lameValue, onProgress, null);

            streams[0] = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT);
            streams[1] = Bass.BASS_StreamCreateFile(TestOpusFile, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT);
            streams[2] = Bass.BASS_StreamCreateFile(TestLameFile, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT);

            Bass.BASS_ChannelSetAttribute(streams[0], BASSAttribute.BASS_ATTRIB_VOL, 1f);
            Bass.BASS_ChannelSetAttribute(streams[1], BASSAttribute.BASS_ATTRIB_VOL, 0f);
            Bass.BASS_ChannelSetAttribute(streams[2], BASSAttribute.BASS_ATTRIB_VOL, 0f);

            isEncoded = true;
        }
        public void Play()
        {
            foreach (var stream in streams)
                Bass.BASS_ChannelPlay(stream, false);
            posThread.Start();
        }
        public void Stop()
        {
            
        }
        public void ChangeCodec(int index)
        {
            for (int i = 0; i < streams.Length; i++)
            {
                if (index == i)
                    Bass.BASS_ChannelSetAttribute(streams[i], BASSAttribute.BASS_ATTRIB_VOL, 1f);
                else
                    Bass.BASS_ChannelSetAttribute(streams[i], BASSAttribute.BASS_ATTRIB_VOL, 0f);
            }
            cStream = index;
        }

        public float GetSpectrum(int low, int hi)
        {
            visuals.MaxFFT = BASSData.BASS_DATA_FFT256;
            float amp = visuals.DetectFrequency(streams[cStream], low, hi, false);
            return amp;
        }
        public Bitmap GetSpectrum2()
        {
            return visuals.CreateSpectrumWave(streams[cStream], 300, 300,
                Color.FromArgb(50, 50, 50), Color.FromArgb(70, 70, 70), Color.Black,
                1, true, true, true);
        }
        
        /*
        public Bitmap GetSpectrum()
        {
            int band = 44100 / 2;
            int iter = 0;
            float k = 1;
            if (bitmapCount >= bitmap.Width)
                bitmapCount = 0;

            for (int i = 0; i < band; i+=100, iter++)
            {
                Color color = Color.Black;
                float amp = visuals.DetectFrequency(streams[cStream], i, i + 100, false);
                int c = 0;
                if (amp * 255 < 255) c = (int)(amp * 255f);
                else c = 255;
                int ni = (int)(c * k);
                if (ni < 255)
                    c = ni;
                else
                    c = 255;
                color = Color.FromArgb(c, c, c);
                k += 0.022f;
                bitmap.SetPixel(bitmapCount, bitmap.Height - iter - 1,
                    color);
            }
            bitmapCount += 1;

            return bitmap;
        }*/

    }
}
