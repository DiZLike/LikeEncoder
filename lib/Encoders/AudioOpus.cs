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

        private static string CFG = @"encoders\opus.cfg";

        public static string Format
        {
            get
            {
                string ch = String.Empty;
                if (BassApp.param["channel"].ToInt() == 0)
                    ch = "Stereo";
                else
                    ch = "Mono";
                return string.Format(@"{0} kBit / {1} frame / {2}",
                    BassApp.param["bitrate"],
                    BassApp.param["framesize"],
                    ch);
            }
        }

        public static void LoadParams()
        {
            Cfg cfg = new Cfg(CFG);
            LoadParameter(cfg, "bitrate");
            LoadParameter(cfg, "framesize");
            LoadParameter(cfg, "quality");
            LoadParameter(cfg, "channel");
            LoadParameter(cfg, "music");
            LoadParameter(cfg, "speech");

        }
        public static void SaveParam()
        {
            Cfg cfg = new Cfg(CFG);
            SaveParameter(cfg, "bitrate");
            SaveParameter(cfg, "framesize");
            SaveParameter(cfg, "quality");
            SaveParameter(cfg, "channel");
            SaveParameter(cfg, "music");
            SaveParameter(cfg, "speech");
        }

        public void Start(string sourceAudio, string exitAudio, int index, ProgressHandler onProgress)
        {
            this.onProgress = onProgress;
            this.index = index;
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
