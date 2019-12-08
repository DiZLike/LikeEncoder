using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib.Encoders.Lame
{
    public class AudioLameValue : EncoderValue
    {
        public bool SwapChannel { get; set; }
        public int MinBitrate { get; set; }
        public int MaxBitrate { get; set; }
        public bool CBR { get; set; }
        public bool ABR { get; set; }
        public bool VBR { get; set; }
        public bool VBR_Old { get; set; }
        public int VBRmode { get; set; }
        public int Lowpass { get; set; }

        public string[] VVBRmodes;

        public string CFG = @"enc\lame.cfg";

        
        public override string Format()
        {
            string ch = VChannels[EncParam["stereomode"].ToInt()];
            return string.Format(@"{0} kHz / {1} kBit / {2}",
                VFrequencyes[EncParam["frequency"].ToInt()],
                EncParam["vbr"].ToBool() ? VVBRmodes[EncParam["vbrmode"].ToInt()] : VBitrates[EncParam["bitrate"].ToInt()],
                ch);
        }
        public override void GetEncoderValues()
        {
            Cfg cfg = new Cfg(Cfg.ENC_CFG);
            VFrequencyes = cfg.Read("lame_frequency").Split(',');
            VBitrates = cfg.Read("lame_bitrate").Split(',');
            VQualityes = cfg.Read("lame_quality").Split(',');
            VChannels = cfg.Read("lame_stereomode").Split(',');
            VVBRmodes = cfg.Read("lame_vbrmode").Split(',');
        }
        internal override void SetEncoderValues()
        {
            //LoadParams(CFG);
            Frequency = VFrequencyes[EncParam["frequency"].ToInt()].ToInt();
            Bitrate = VBitrates[EncParam["bitrate"].ToInt()].ToInt();
            Quality = EncParam["quality"].ToInt();
            Channels = EncParam["stereomode"].ToInt();
            //MinBitrate = EncParam["minbitrate"].ToInt();
            //MaxBitrate = EncParam["maxbitrate"].ToInt();
            SwapChannel = EncParam["swapchannel"].ToBool();
            CBR = EncParam["cbr"].ToBool();
            ABR = EncParam["abr"].ToBool();
            VBR = EncParam["vbr"].ToBool();
            VBR_Old = EncParam["vbrold"].ToBool();
            VBRmode = EncParam["vbrmode"].ToInt();
            Lowpass = Frequency / 2;
        }
    }
}
