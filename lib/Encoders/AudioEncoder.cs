using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using System.IO;
using Un4seen.Bass.AddOn.Enc;
using System.Threading.Tasks;
using System.Threading;
using Un4seen.Bass.AddOn.Mix;
using lib.Encoders;

namespace lib
{
    public abstract class AudioEncoder
    {
        protected ProgressHandler onProgress;
        protected ErrorHandler onError;
        protected int index;
        protected int stream;
        protected int mixer;
        private CancellationToken token;

        protected double startPos = 0;
        protected double endPos = 0;

        private int enc;
        protected StringBuilder sbCmd;
        protected string cmd;
        protected EncoderValue ev;

        private Cfg app_cfg;
        private int buffer;

        public AudioEncoder(CancellationToken token)
        {
            this.token = token;
            this.app_cfg = new Cfg(Cfg.APP_CFG);
            this.buffer = app_cfg.ReadInt("buffer", 6);
        }

        public virtual void Start(string sourceAudio, string exitAudio, int index, double startPos,
            double endPos, EncoderValue ev, ProgressHandler onProgress, ErrorHandler onError)
        {
            this.onProgress = onProgress;
            this.onError = onError;
            this.index = index;
            this.startPos = startPos;
            this.endPos = endPos;
            this.ev = ev;
            sbCmd = new StringBuilder();
            ev.SetEncoderValues();
        }

        protected bool CreateStream(string file, string cmd, BASSEncode encodeFlags)
        {
            stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_DECODE);
            if (stream == 0)
            {
                onError(new Error(IntPtr.Zero, Error.ENCODER_STREAM));
                return false;
            }
            if (startPos > 0)
                Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, startPos));

            BASS_CHANNELINFO ci = new BASS_CHANNELINFO();
            Bass.BASS_ChannelGetInfo(stream, ci);
            mixer = BassMix.BASS_Mixer_StreamCreate(ev.Frequency, ci.chans, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MIXER_END);
            BassMix.BASS_Mixer_StreamAddChannel(mixer, stream, 0);

            enc = BassEnc.BASS_Encode_Start(mixer, cmd, encodeFlags, null, IntPtr.Zero);
            if (enc == 0)
            {
                onError(new Error(IntPtr.Zero, Error.ENCODER_START));
                return false;
            }
            return true;
        }
        protected void StartEncode()
        {
            byte[] _encBuffer = new byte[(int)Math.Pow(2, buffer + 4)];
            while (Bass.BASS_ChannelIsActive(mixer) == BASSActive.BASS_ACTIVE_PLAYING
                && !token.IsCancellationRequested)
            {
                Bass.BASS_ChannelGetData(mixer, _encBuffer, _encBuffer.Length);
                long length = Bass.BASS_ChannelGetLength(stream);
                long pos = Bass.BASS_ChannelGetPosition(stream);

                if (Bass.BASS_ChannelBytes2Seconds(stream, pos) >= endPos && endPos != 0)
                    Bass.BASS_ChannelStop(stream);

                if (startPos == 0 && endPos == 0)
                {
                    int progress = (int)((float)pos / (float)length * 100f);
                    if (progress % 5 == 0 || progress >= 99)
                        onProgress(index, progress);
                }
                else
                {
                    double posSec = Bass.BASS_ChannelBytes2Seconds(stream, pos);
                    float fendPos = (float)endPos;
                    float fstartPos = (float)startPos;

                    int progress = (int)((posSec - fstartPos) / (endPos - startPos) * 100f);
                    if (progress % 5 == 0 || progress >= 99)
                        onProgress(index, progress);
                }
            }
            BassEnc.BASS_Encode_Stop(enc);
        }
        public void SetPossition(double pos)
        {
            Bass.BASS_ChannelSetPosition(stream, Bass.BASS_ChannelSeconds2Bytes(stream, pos));
        }
    }
}