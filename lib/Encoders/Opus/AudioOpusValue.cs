using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib.Encoders.Opus
{
    public class AudioOpusValue : EncoderValue
    {
        public string Framesize { get; set; }
        public bool Music { get; set; }
        public bool Speech { get; set; }

        public string[] VFramesizes;

        public string CFG = @"enc\opus.cfg";

        public override string Format()
        {
            string ch = VChannels[EncParam["channel"].ToInt()];
            return string.Format(@"{0} kBit / {1} frame / {2}",
                VBitrates[EncParam["bitrate"].ToInt()],
                VFramesizes[EncParam["framesize"].ToInt()],
                ch);
        }
        public override void GetEncoderValues()
        {
            Cfg cfg = new Cfg(Cfg.ENC_CFG);
            VFrequencyes = cfg.Read("opus_frequency").Split(',');
            VBitrates = cfg.Read("opus_bitrate").Split(',');
            VFramesizes = cfg.Read("opus_framesize").Split(',');
            VQualityes = cfg.Read("opus_quality").Split(',');
            VChannels = cfg.Read("opus_channel").Split(',');
        }
        internal override void SetEncoderValues()
        {
            //LoadParams(CFG);
            Bitrate = VBitrates[EncParam["bitrate"].ToInt()].ToInt();
            Frequency = VFrequencyes[EncParam["frequency"].ToInt()].ToInt();
            Framesize = VFramesizes[EncParam["framesize"].ToInt()];
            Quality = VQualityes[EncParam["quality"].ToInt()].ToInt();
            Channels = EncParam["channels"].ToInt();
            Music = EncParam["music"].ToBool();
            Speech = EncParam["speech"].ToBool();
        }

    }
}
