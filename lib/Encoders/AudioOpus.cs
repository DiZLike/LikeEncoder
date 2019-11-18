using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Enc;

namespace lib.Encoders
{
    public class AudioOpus : AudioEncoder
    {
        public string Framesize { get; set; }

        public void Start(string sourceAudio, string exitAudio, int index, ProgressHandler onProgress)
        {
            this.onProgress = onProgress;
            this.index = index;
            string cmd = string.Format("encoders\\opus\\opusenc --bitrate {0} --framesize {1} - \"{2}.opus\"",
                Bitrate,
                Framesize,
                exitAudio);
            CreateStream(sourceAudio, cmd, BASSEncode.BASS_ENCODE_FP_16BIT);
            StartEncode();
        }

    }
}
