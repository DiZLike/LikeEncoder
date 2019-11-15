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
    public class EncoderEventArgs : EventArgs
    {
        public float Progress { get; set; }

        public EncoderEventArgs(float progress)
        {
            Progress = progress;
        }
    }

    public abstract class AudioEncoder
    {
        public int Bitrate { get; set; }

        public delegate void EncoderEventHandler(object sender, EncoderEventArgs e);
        public event EncoderEventHandler OnProgress;

        protected int stream;
        protected string cmd;
        protected string inputFile;
        protected string outputFile;

        private Thread encoderThread;

        public void SetIO(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
        }

        protected void CreateStream(string file, string cmd, BASSEncode encodeFlags)
        {
            stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_DECODE);
            BassEnc.BASS_Encode_Start(stream, cmd, encodeFlags, null, IntPtr.Zero);
        }

        protected void StartEncode()
        {
            encoderThread = new Thread(delegate()
                {
                    byte[] _encBuffer = new byte[65536];
                    while (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
                    {
                        Bass.BASS_ChannelGetData(stream, _encBuffer, _encBuffer.Length);
                        long length = Bass.BASS_ChannelGetLength(stream);
                        long pos = Bass.BASS_ChannelGetPosition(stream);
                        float progress = (float)pos / (float)length * 100f;
                        if (OnProgress == null) continue;
                        OnProgress(this, new EncoderEventArgs(progress));
                    }
                });
            encoderThread.Start();
        }

        public void Stop()
        {
            encoderThread.Abort();
        }

    }
}
