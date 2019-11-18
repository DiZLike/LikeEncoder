using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace conv.Wnds
{
    public partial class OpusWnd : Form
    {
        private object[] param;

        public OpusWnd(ref object[] param)
        {
            InitializeComponent();
            this.param = param;
            frequency.SelectedIndex = 0;
            frequency.Enabled = false;
            bitrate.SelectedIndex = 11;
            frame.SelectedIndex = 3;
            quality.SelectedIndex = 0;
            channel.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            param[0] = bitrate.Text;
            param[1] = frame.Text;
            Close();
        }
    }
}
