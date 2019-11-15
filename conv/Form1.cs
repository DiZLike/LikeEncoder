using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lib;

namespace conv
{
    public partial class Form1 : Form
    {
        private App app;

        public Form1()
        {
            InitializeComponent();
            app = new App(this.Handle);
            app.aOpus.OnProgress += new AudioEncoder.EncoderEventHandler(aOpus_OnProgress);
            app.test();
        }

        void aOpus_OnProgress(object sender, EncoderEventArgs e)
        {
            progressBar1.Invoke(new Action<float>((f) => progressBar1.Value = (int)f), e.Progress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            app.aOpus.Stop();
        }
    }
}
