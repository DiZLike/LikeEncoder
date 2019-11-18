using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lib;
using lib.Encoders;

namespace conv.Wnds
{
    public partial class OpusWnd : Form
    {
        //private Cfg cfg = new Cfg(Cfg.OPUS_CFG);

        public OpusWnd()
        {
            InitializeComponent();
            frequency.SelectedIndex = 0;
            frequency.Enabled = false;
            AudioOpus.LoadParams();

            bitrate.Text = BassApp.param["bitrate"].ToString();
            frame.Text = BassApp.param["framesize"].ToString();
            quality.Text = BassApp.param["quality"].ToString();
            channel.SelectedIndex = BassApp.param["channel"].ToInt();
            if (BassApp.param["music"].ToBool())
                music.Checked = true;
            if (BassApp.param["speech"].ToBool())
                speech.Checked = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            BassApp.param["bitrate"] = bitrate.Text;
            BassApp.param["framesize"] = frame.Text;
            BassApp.param["quality"] = quality.Text;
            BassApp.param["channel"] = channel.SelectedIndex;
            BassApp.param["music"] = music.Checked;
            BassApp.param["speech"] = speech.Checked;

            AudioOpus.SaveParam();
            
            Close();
        }

        private void myButton1_Load(object sender, EventArgs e)
        {

        }
    }
}
