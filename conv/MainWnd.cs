using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lib;
using System.IO;
using conv.Wnds;

namespace conv
{
    public partial class MainWnd : Form
    {
        private BassApp app;
        private OpenFileDialog openFileDialog;

        /*
         *      0: битрейт
         *      1: фреймы
         *      2: частота
         *      3: качество алгоритма
         *      4: каналы
         *      5: Music
         *      6: Speech
         * */
        private object[] param = new object[20];

        public MainWnd()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;

            CreateDialogs();
            app = new BassApp(this.Handle, OnError, OnProgress);
            //app.aOpus.OnProgress += new AudioEncoder.EncoderEventHandler(aOpus_OnProgress);

            var encs = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\encoders\encoders.txt");
            foreach (var item in encs)
                borderComboBox1.Items.Add(item);
            borderComboBox1.SelectedIndex = 0;
        }

        private void CreateDialogs()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
        }

        private void OnError(Error error)
        {
            string msg = string.Format("{0}", error.Message);
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnProgress(int index, int progress)
        {
            trackPanel1.Invoke(new Action<int>((i) => trackPanel1.Tracks[index].EncodingProgress = i), progress);
        }

        private void AddTracks()
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            var tracks = openFileDialog.FileNames;
            foreach (var track in tracks)
            {
                trackPanel1.AddTrack(track,
                    Path.GetFileNameWithoutExtension(track), "YUI");
            }
        }

        /*
        void aOpus_OnProgress(object sender, EncoderEventArgs e)
        {
            //progress1.Invoke(new Action<float>((f) => progress1.Value = (int)f), e.Progress);
        }*/

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddTracks();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<string> tracks = new List<string>();
            foreach (var item in trackPanel1.Tracks)
		        tracks.Add(item.Path);
            app.Start((EncoderType)borderComboBox1.SelectedIndex, param, tracks.ToArray(), AppDomain.CurrentDomain.BaseDirectory);
        }

        private void btnTextBox1_Click(object sender, EventArgs e)
        {
            switch (borderComboBox1.SelectedIndex)
            {
                case 0:
                    new OpusWnd(ref param).ShowDialog();
                    break;
            }
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
