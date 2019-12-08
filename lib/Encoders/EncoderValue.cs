using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib.Encoders
{
    public abstract class EncoderValue
    {
        public Values EncParam;

        public int Bitrate { get; set; }
        public int Quality { get; set; }
        public int Channels { get; set; }
        public int Frequency { get; set; }

        public string[] VBitrates;
        public string[] VQualityes;
        public string[] VChannels;
        public string[] VFrequencyes;

        public abstract string Format();
        public abstract void GetEncoderValues();
        internal abstract void SetEncoderValues();

        public void LoadParams(string cfgfile)
        {
            Cfg cfg = new Cfg(cfgfile);
            var param = cfg.GetKeys();
            foreach (var item in param)
                LoadParameter(cfg, item);
            SetEncoderValues();
        }
        public void SaveParam(string cfgfile)
        {
            Cfg cfg = new Cfg(cfgfile);
            var param = cfg.GetKeys();
            foreach (var item in param)
                SaveParameter(cfg, item);
        }

        protected void LoadParameter(Cfg cfg, string param)
        {
            EncParam[param] = cfg.Read(param);
        }
        protected void SaveParameter(Cfg cfg, string param)
        {
            cfg.Write(param, EncParam[param]);
        } // static

        public EncoderValue()
        {
            GetEncoderValues();
            SetEncoderValues();
        }

    }
}
