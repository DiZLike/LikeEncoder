﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.Misc;
using Un4seen.Bass;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using lib.NTrack;
using lib.Encoders;
using lib.Encoders.Opus;
using lib.Encoders.Lame;

namespace lib
{
    public delegate void ErrorHandler(Error error);
    public delegate void CancelHandler();
    public delegate void ProgressHandler(int index, int progress);
    public delegate void CompleteHandler();

    public enum EncoderType
    {
        OPUS = 0,
        MP3_LAME = 1
    }

    public class BassApp
    {
        protected readonly string pluginsFolder = AppDomain.CurrentDomain.BaseDirectory + @"bass_plugins\";
        protected readonly string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        protected IntPtr handle;

        private ErrorHandler onError;
        private ProgressHandler onProgress;
        private CompleteHandler onComplete;
        private CancelHandler onCancel;

        private int threadCount = 1;
        private Thread[] encodingThread;
        private List<Track> trackList;
        private TTag[] tags;
        private EncoderType encoderType;
        private string outFolder;
        private string filePattern;

        public AudioOpusValue _opusValue = new AudioOpusValue();
        public AudioLameValue _lameValue = new AudioLameValue();

        public int TrackCount { get { return trackList.Count; } }

        public BassApp(IntPtr handle, ErrorHandler onError, ProgressHandler onProgress,
            CompleteHandler onComplete, CancelHandler onCancel)
        {
            this.handle = handle;
            this.onError = onError;
            this.onProgress = onProgress;
            this.onComplete = onComplete;
            this.onCancel = onCancel;
            Init();
        }
        /*
        public void LoadParam()
        {
            var par = File.ReadAllLines(Cfg.PARAM_TXT);
        }*/

        private void Init()
        {
            bool isInit = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, handle);
            if (!isInit)
                onError(new Error(handle, Error.INIT));
            var p = Directory.GetFiles(pluginsFolder);
            foreach (var item in p)
                Bass.BASS_PluginLoad(item);
        }

        public void SetThreadCount(int count)
        {
            threadCount = count;
            encodingThread = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
                encodingThread[i] = new Thread(new ThreadStart(BeginEncoding));
        }

        public void Start(EncoderType encoderType, string[] tracks, TTag[] tags, string filePattern, string outputFolder)
        {
            SetThreadCount(threadCount);
            this.encoderType = encoderType;
            this.tags = tags;
            this.outFolder = outputFolder;
            this.filePattern = filePattern;
            if (!Directory.Exists(outFolder))
                Directory.CreateDirectory(outFolder);

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

        public void Stop()
        {
            foreach (var thread in encodingThread)
                thread.Abort();
            onCancel();
        }

        private void BeginEncoding()
        {
            for (int i = 0; i < trackList.Count; i++)
            {
                if (trackList[i].Complete || trackList[i].Started)
                    continue;
                trackList[i].Started = true;
                string of = Path.GetFileNameWithoutExtension(trackList[i].Name);

                string ofn = outFolder + AudioTags.DirectoryStructPattern(filePattern, tags[i]);
                if (!Directory.Exists(Path.GetDirectoryName(ofn)))
                    Directory.CreateDirectory(Path.GetDirectoryName(ofn));
                
                switch (encoderType)
                {
                    case EncoderType.OPUS:
                        ofn += ".opus";
                        _opusValue.SaveParam(_opusValue.CFG);
                        new AudioOpus().Start(trackList[i].Name, ofn, i, 
                            tags[i].TimeStart, tags[i].TimeEnd, _opusValue, onProgress, onError);
                        break;
                    case EncoderType.MP3_LAME:
                        ofn += ".mp3";
                        _lameValue.SaveParam(_lameValue.CFG);
                        new AudioLame().Start(trackList[i].Name, ofn, i,
                            tags[i].TimeStart, tags[i].TimeEnd, _lameValue, onProgress, onError);
                        break;
                }
                
                trackList[i].Complete = true;
                AudioTags.SaveTags(ofn, tags[i]);
            }
            CheckAllComplete();
        }

        private void CheckAllComplete()
        {
            foreach (var item in trackList)
            {
                if (!item.Started || !item.Complete)
                    return;
            }
            onComplete();
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

        public int CreateStream(string file)
        {
            return Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_DECODE);
        }

        public void CtreamDestroy(int stream)
        {
            Bass.BASS_StreamFree(stream);
        }

    }
}
