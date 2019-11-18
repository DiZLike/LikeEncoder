using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.Misc;
using Un4seen.Bass;
using System.IO;
using lib.Encoders;
using System.Threading;

namespace lib
{
    public delegate void ErrorHandler(Error error);
    public delegate void ProgressHandler(int index, int progress);

    public enum EncoderType
    {
        OPUS = 0
    }

    public class BassApp
    {
        protected readonly string pluginsFolder = AppDomain.CurrentDomain.BaseDirectory + @"bass_plugins\";
        protected readonly string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        protected IntPtr handle;

        private ErrorHandler onError;
        private ProgressHandler onProgress;
        private int threadCount = 1;
        private Thread[] encodingThread;
        private List<Track> trackList;
        private EncoderType encoderType;
        private string outFolder;
        private object[] param;

        //public AudioOpus aOpus;

        public BassApp(IntPtr handle, ErrorHandler onError, ProgressHandler onProgress)
        {
            this.handle = handle;
            this.onError = onError;
            this.onProgress = onProgress;
            Init();
            //aOpus = new AudioOpus();
        }

        private void Init()
        {
            bool isInit = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, handle);
            if (!isInit)
                onError(new Error(handle, Error.INIT));
            var p = Directory.GetFiles(pluginsFolder);
            foreach (var item in p)
                Bass.BASS_PluginLoad(item);
            SetThreadCount(4);
        }

        public void SetThreadCount(int count)
        {
            threadCount = count;
            encodingThread = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
                encodingThread[i] = new Thread(new ThreadStart(BeginEncoding));
        }

        public void Start(EncoderType encoderType, object[] param, string[] tracks, string outputFolder)
        {
            this.encoderType = encoderType;
            this.param = param;
            this.outFolder = outputFolder;
            trackList = new List<Track>();

            for (int i = 0; i < tracks.Length; i++)
                trackList.Add(new Track()
                    {
                        Index = i, Name = tracks[i]
                    });

            for (int i = 0; i < threadCount; i++)
            {
                encodingThread[i].Start();
                Thread.Sleep(500);
            }
            
        }

        private void BeginEncoding()
        {
            
            for (int i = 0; i < trackList.Count; i++)
            {
                if (trackList[i].Complete || trackList[i].Started)
                    continue;
                trackList[i].Started = true;
                switch (encoderType)
                {
                    case EncoderType.OPUS:
                        StartOpus(i);
                        break;
                }
                
                trackList[i].Complete = true;
            }
        }

        private bool CheckComplite()
        {
            foreach (var item in trackList)
            {
                if (!item.Started || !item.Complete)
                    return true;
            }
            return false;
        }

        private void StartOpus(int index)
        {
            var opus = new AudioOpus();
            opus.Bitrate = Convert.ToInt32(param[0]);
            opus.Framesize = param[1].ToString();
            opus.Quality = Convert.ToInt32(param[3]);
            opus.Channels = (int)param[4];
            opus.Music = (bool)param[5];
            opus.Speech = (bool)param[6];

            string of = Path.GetFileNameWithoutExtension(trackList[index].Name);
            opus.Start(trackList[index].Name, outFolder + of, index, onProgress);
        }

    }
}
