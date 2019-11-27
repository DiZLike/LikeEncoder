using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using System.IO;
using Un4seen.Bass.AddOn.Enc;
using System.Threading.Tasks;
using System.Threading;

namespace lib
{
    public abstract class AudioEncoder
    {
        public int Bitrate { get; set; }
        public int Quality { get; set; }
        public int Channels { get; set; }

        protected ProgressHandler onProgress;
        protected ErrorHandler onError;
        protected int index;
        protected int stream;

        private int enc;

        public abstract string Format();
        public abstract void LoadParams();
        public abstract void SaveParam();
        public abstract void Start(string sourceAudio, string exitAudio, int index,
            ProgressHandler onProgress, ErrorHandler onError);

        protected static void LoadParameter(Cfg cfg, string param)
        {
            BassApp.param[param] = cfg.Read(param);
        }
        protected static void SaveParameter(Cfg cfg, string param)
        {
            cfg.Write(param, BassApp.param[param]);
        }

        protected bool CreateStream(string file, string cmd, BASSEncode encodeFlags)
        {
            stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_DECODE);
            if (stream == 0)
            {
                onError(new Error(IntPtr.Zero, Error.ENCODER_STREAM));
                return false;
            }
            enc = BassEnc.BASS_Encode_Start(stream, cmd, encodeFlags, null, IntPtr.Zero);
            if (enc == 0)
            {
                onError(new Error(IntPtr.Zero, Error.ENCODER_START));
                return false;
            }
            return true;
        }
        protected void StartEncode()
        {
            byte[] _encBuffer = new byte[65536];
            while (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelGetData(stream, _encBuffer, _encBuffer.Length);
                long length = Bass.BASS_ChannelGetLength(stream);
                long pos = Bass.BASS_ChannelGetPosition(stream);
                int progress = (int)((float)pos / (float)length * 100f);
                if (progress % 5 == 0)
                    onProgress(index, progress);
            }
            BassEnc.BASS_Encode_Stop(enc);
        }
    }
}
