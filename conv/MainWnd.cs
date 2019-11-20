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
using conv;
using lib.Encoders;
using tagslib.Tags.Opus;

namespace conv
{
    public partial class MainWnd : Form
    {
        private BassApp app;
        private OpenFileDialog openFileDialog;

        public MainWnd()
        {
            InitializeComponent();

            CreateDialogs();
            app = new BassApp(this.Handle, OnError, OnProgress);

            var encs = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\encoders\encoders.txt");
            foreach (var item in encs)
                borderComboBox1.Items.Add(item);
            LoadDefaultEncoder();
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
            if (progress == 100)
                progress1.Invoke(new Action(() => progress1.Value++));
        }

        private void LoadDefaultEncoder()
        {
            var cfg = new Cfg(Cfg.ENC_CFG);
            int defenc = cfg.Read("default_encoder").ToInt();
            borderComboBox1.SelectedIndex = defenc;
            //string encname = borderComboBox1.Items[defenc.ToInt()].ToString().ToLower();
            switch ((EncoderType)defenc)
            {
                case EncoderType.OPUS:
                    AudioOpus.LoadParams();
                    btnTextBox1.Title = AudioOpus.Format;
                    break;
            }
        }

        private void AddTracks()
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            var tracks = openFileDialog.FileNames;

            OpusFile f = new OpusFile(openFileDialog.FileName);

            /*
            foreach (var track in tracks)
            {
                trackPanel1.AddTrack(track,
                    Path.GetFileNameWithoutExtension(track), "YUI");
            }*/

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddTracks();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<string> tracks = new List<string>();
            foreach (var item in trackPanel1.Tracks)
		        tracks.Add(item.Path);
            progress1.Value = 0;
            progress1.Maximum = tracks.Count;
            app.Start((EncoderType)borderComboBox1.SelectedIndex, tracks.ToArray(), AppDomain.CurrentDomain.BaseDirectory);
        }

        private void btnTextBox1_Click(object sender, EventArgs e)
        {
            Form formatForm;
            switch (borderComboBox1.SelectedIndex)
            {
                case 0:
                    formatForm = new OpusWnd();
                    break;
                default:
                    formatForm = new Form();
                    break;
            }
            formatForm.FormClosed += (s, ev) => btnTextBox1.Title = AudioOpus.Format;
            formatForm.ShowDialog();
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            object f = "1";
            f.ToBool();
        }
    }
}
