using System;
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

    public enum MyBASSAttribute
    {
        BASS_ATTRIB_OPUS_GAIN = 0x13001
    }

    public enum EncoderType
    {
        OPUS = 0,
        MP3_LAME = 1
    }

    public class EncApp
    {
        protected readonly string pluginsFolder = AppDomain.CurrentDomain.BaseDirectory + @"bass_plugins\";
        protected readonly string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        protected IntPtr handle;

        private ErrorHandler onError;
        private ProgressHandler onProgress;
        private CompleteHandler onComplete;
        private CancelHandler onCancel;

        private int threadCount = 4;
        private Thread[] encodingThreads;
        private List<Track> trackList;
        private TTag[] tags;
        private EncoderType encoderType;
        private string outFolder;
        private string filePattern;
        private Cfg app_cfg;
        private List<int> _bassplugins = new List<int>();

        private List<AudioEncoder> activeEnc = new List<AudioEncoder>();

        public AudioOpusValue _opusValue = new AudioOpusValue();
        public AudioLameValue _lameValue = new AudioLameValue();
        public int TrackCount { get { return trackList.Count; } }


        public EncApp(IntPtr handle, ErrorHandler onError, ProgressHandler onProgress,
            CompleteHandler onComplete, CancelHandler onCancel)
        {
            this.handle = handle;
            this.onError = onError;
            this.onProgress = onProgress;
            this.onComplete = onComplete;
            this.onCancel = onCancel;
            //token = cancelTokenSource.Token;
            app_cfg = new Cfg(Cfg.APP_CFG);
            Init();
        }
        private void Init()
        {
            bool isInit = Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, handle);
            if (!isInit)
                onError(new Error(handle, Error.INIT));
            var p = Directory.GetFiles(pluginsFolder);
            foreach (var item in p)
            {
                int h = Bass.BASS_PluginLoad(item);
                _bassplugins.Add(h);
            }
        }
        public void SetThreadCount()
        {
            threadCount = app_cfg.ReadInt("cores", Environment.ProcessorCount - 1) + 1;
            encodingThreads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
                encodingThreads[i] = new Thread(BeginEncoding);
        }
        public void Start(EncoderType encoderType, string[] tracks, TTag[] tags, string filePattern, string outputFolder)
        {
            SetThreadCount();
            this.encoderType = encoderType;
            this.tags = tags;
            this.outFolder = outputFolder;
            this.filePattern = filePattern;
            if (!Directory.Exists(outFolder))
                Directory.CreateDirectory(outFolder);

            switch (encoderType)
            {
                case EncoderType.OPUS:
                    _opusValue.SaveParam(_opusValue.CFG);
                    break;
                case EncoderType.MP3_LAME:
                    _lameValue.SaveParam(_lameValue.CFG);
                    break;
            }

            trackList = new List<Track>();

            for (int i = 0; i < tracks.Length; i++)
                trackList.Add(new Track()
                    {
                        Index = i, Name = tracks[i]
                    });

            for (int i = 0; i < threadCount; i++)
            {
                encodingThreads[i].Start();
                Thread.Sleep(50);
            }
        }
        public void Stop()
        {
            /*
            foreach (var thread in encodingThreads)
                thread.Abort();*/
            foreach (var item in activeEnc)
                item.Cancel();

            onCancel();
        }
        private void BeginEncoding()
        {
            for (int i = 0; i < trackList.Count; i++)
            {
                Debug.Log(string.Format("Thread: {0} -> {1}: {2} | started: {3}, completed: {4}",
                    Thread.CurrentThread.ManagedThreadId,
                    trackList[i].Index, trackList[i].Name, trackList[i].Started,
                    trackList[i].Complete));


                //if (token.IsCancellationRequested) return;
                if (trackList[i].Complete || trackList[i].Started)
                    continue;
                trackList[i].Started = true;
                string of = Path.GetFileNameWithoutExtension(trackList[i].Name);

                string ofn = outFolder + AudioTags.DirectoryStructPattern(filePattern, tags[i]);
                if (!Directory.Exists(Path.GetDirectoryName(ofn)))
                    Directory.CreateDirectory(Path.GetDirectoryName(ofn));

                AudioEncoder en = null;
                switch (encoderType)
                {
                    case EncoderType.OPUS:
                        ofn += ".opus";
                        en = new AudioOpus();
                        activeEnc.Add(en);
                        en.Start(trackList[i].Name, ofn, i,
                            tags[i].TimeStart, tags[i].TimeEnd, _opusValue, onProgress, onError);
                        break;
                    case EncoderType.MP3_LAME:
                        ofn += ".mp3";
                        en = new AudioLame();
                        activeEnc.Add(en);
                        en.Start(trackList[i].Name, ofn, i,
                            tags[i].TimeStart, tags[i].TimeEnd, _lameValue, onProgress, onError);
                        break;
                }
                
                trackList[i].Complete = true;
                AudioTags.SaveTags(ofn, tags[i]);

                activeEnc.Remove(en);
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
        public void StreamDestroy(int stream)
        {
            Bass.BASS_StreamFree(stream);
        }

    }
}
