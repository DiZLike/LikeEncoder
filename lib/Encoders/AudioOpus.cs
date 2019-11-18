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
        public bool Music { get; set; }
        public bool Speech { get; set; }

        public void Start(string sourceAudio, string exitAudio, int index, ProgressHandler onProgress)
        {
            this.onProgress = onProgress;
            this.index = index;
            /*
            string cmd = string.Format("encoders\\opus\\opusenc --bitrate {0} --framesize {1} --comp {2} - \"{3}.opus\"",
                Bitrate,
                Framesize,
                Quality,
                exitAudio);*/
            string cmd = String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("encoders\\opus\\opusenc ");
            sb.AppendFormat("--bitrate {0} ", Bitrate);
            sb.AppendFormat("--framesize {0} ", Framesize);
            sb.AppendFormat("--comp {0} ", Quality);
            if (Channels == 1)
                sb.Append("--downmix-mono ");
            if (Music)
                sb.Append("--music ");
            if (Speech)
                sb.Append("--speech ");
            sb.AppendFormat("- \"{0}.opus\"", exitAudio);
            cmd = sb.ToString();
            Debug.Log(cmd);

            CreateStream(sourceAudio, cmd, BASSEncode.BASS_ENCODE_FP_16BIT);
            StartEncode();
        }

    }
}
