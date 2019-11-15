using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Enc;

namespace lib.Encoders
{
    public class AudioOpus : AudioEncoder
    {
        public float Framesize { get; set; }

        public void Start()
        {
            Bitrate = 16;
            Framesize = 20;
            cmd = string.Format("opusenc --bitrate {0} --framesize {1} - {2}.opus", Bitrate, Framesize, outputFile);
            CreateStream(inputFile, cmd, BASSEncode.BASS_ENCODE_FP_16BIT);
            StartEncode();
        }

    }
}
