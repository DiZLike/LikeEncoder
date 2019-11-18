using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lib;

namespace conv.Wnds
{
    public partial class OpusWnd : Form
    {
        private object[] param;
        private Cfg cfg = new Cfg(Consts.OPUS_CFG);

        public OpusWnd(ref object[] param)
        {
            InitializeComponent();
            this.param = param;
            frequency.SelectedIndex = 0;
            frequency.Enabled = false;

            bitrate.Text = cfg.Read("bitrate");
            frame.Text = cfg.Read("frame");
            quality.Text = cfg.Read("quality");
            channel.SelectedIndex = Convert.ToInt32(cfg.Read("channel"));
            if (Convert.ToBoolean(cfg.Read("music")))
                music.Checked = true;
            if (Convert.ToBoolean(cfg.Read("speech")))
                speech.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            param[0] = bitrate.Text;
            param[1] = frame.Text;
            param[3] = quality.Text;
            param[4] = channel.SelectedIndex;
            param[5] = music.Checked;
            param[6] = speech.Checked;

            cfg.Write("bitrate", param[0]);
            cfg.Write("frame", param[1]);
            cfg.Write("quality", param[3]);
            cfg.Write("channel", param[4]);
            cfg.Write("music", param[5]);
            cfg.Write("speech", param[6]);
            Close();
        }

        private void myButton1_Load(object sender, EventArgs e)
        {

        }
    }
}
