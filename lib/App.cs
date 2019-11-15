using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.Misc;
using Un4seen.Bass;
using System.IO;
using Un4seen.Bass.AddOn.Opus;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.Bass.AddOn.Enc;
using lib.Encoders;

namespace lib
{
    public class App
    {
        protected readonly string pluginsFolder = AppDomain.CurrentDomain.BaseDirectory + @"bass_plugins\";
        protected readonly string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
        protected IntPtr handle;

        public AudioOpus aOpus;

        public App(IntPtr handle)
        {
            this.handle = handle;
            aOpus = new AudioOpus();
        }

        private void LoadPlugins()
        {
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, handle);
            var p = Directory.GetFiles(pluginsFolder);
            foreach (var item in p)
                Bass.BASS_PluginLoad(item);
        }

        public void test()
        {
            LoadPlugins();
            aOpus.SetIO(baseFolder + "01.opus", "out");
            aOpus.Start();
            
        }

    }
}
