using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass.AddOn.Opus;
using System.Threading;

namespace lib
{
    public delegate void OnPossitionChanged(double pos);

    public class PlayApp
    {
        OnPossitionChanged onPossitionChanged;
        int stream = 0;
        Thread posThread;

        public PlayApp(OnPossitionChanged onPossitionChanged)
        {
            this.onPossitionChanged = onPossitionChanged;
        }

        public int GetStream()
        {
            return stream;
        }
        public void Play(string file)
        {
            Bass.BASS_ChannelStop(stream);
            stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_DEFAULT);

            Bass.BASS_ChannelSetAttribute(stream, (BASSAttribute)MyBASSAttribute.BASS_ATTRIB_OPUS_GAIN, 0);

            posThread = new Thread(GetPossition);
            Bass.BASS_ChannelPlay(stream, false);

            posThread.Start();
        }

        public void Decode(string file)
        {
            Bass.BASS_ChannelStop(stream);
            stream = Bass.BASS_StreamCreateFile(file, 0, 0, BASSFlag.BASS_STREAM_DECODE);

            Bass.BASS_ChannelSetAttribute(stream, (BASSAttribute)MyBASSAttribute.BASS_ATTRIB_OPUS_GAIN, 0);

            posThread = new Thread(GetPossition);
            //Bass.BASS_ChannelPlay(stream, false);

            posThread.Start();
        }

        public void Stop()
        {
            Bass.BASS_ChannelStop(stream);
            Bass.BASS_StreamFree(stream);
            posThread.Abort();
        }
        public int GetVolume()
        {
            float vol = 0;
            Bass.BASS_ChannelGetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, ref vol);
            return (int)(vol * 100f);
        }
        public void SetVolume(int vol)
        {
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, vol / 100f);
        }

        public double GetDuration()
        {
            long durb = Bass.BASS_ChannelGetLength(stream);
            double durs = Bass.BASS_ChannelBytes2Seconds(stream, durb);
            return durs;
        }

        private void GetPossition()
        {
            while (true)
            {
                long posb = Bass.BASS_ChannelGetPosition(stream);
                double poss = Bass.BASS_ChannelBytes2Seconds(stream, posb);
                onPossitionChanged(poss);
                Thread.Sleep(1000);
            }
        }

    }
}
