using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using lib.NTrack;
using lib;
using System.Threading.Tasks;

namespace LikeEncoder.Wnds
{
    /// <summary>
    /// Логика взаимодействия для PlayWnd.xaml
    /// </summary>
    public partial class PlayWnd : Window
    {
        public int Index { get; set; }
        PlayApp play;
        List<TTag> tags;
        Vst v;

        string pospat = "{0} \\ {1}";
        TimeSpan dur = new TimeSpan();

        float rmsMax = 0;

        public PlayWnd(List<TTag> tag)
        {
            InitializeComponent();
            tags = tag;
            play = new PlayApp(OnPossitionChanged);
        }

        private void OnPossitionChanged(double pos)
        {
            Dispatcher.BeginInvoke(new Action<double>((b)
                => this.pos.Value = b), pos);

            TimeSpan p = new TimeSpan(0, 0, (int)pos);
            string s = string.Format(pospat, p.ToString("mm':'ss"), dur.ToString("mm':'ss"));

            Dispatcher.BeginInvoke(new Action<string>((b)
                => this.lpos.Content = b), s);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            //play.Play(tags[Index].FileName);
            play.Decode(tags[Index].FileName);
            play.SetVolume((int)vol.Value);
            double d = play.GetDuration();
            dur = new TimeSpan(0, 0, (int)d);
            pos.Maximum = d;
            lpos.Content = string.Format(pospat, "0:00", dur.ToString("mm':'ss"));

            
            Task.Factory.StartNew(() =>
                {
                    v = new Vst(play.GetStream());
                    var q = v.Scan(-7.0f);
                });
            
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            //play.Stop();
            v.test();
        }

        private void vol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lvol == null)
                return;
            lvol.Content = vol.Value.ToString();
            play.SetVolume((int)vol.Value);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            play.Stop();
        }

        private void btnVst_Click(object sender, RoutedEventArgs e)
        {
            v = new Vst(play.GetStream());
            Task.Factory.StartNew(() =>
                {
                    v.GetRMS(ontest, 10);
                });
            v.Show();
            
        }

        private void ontest(float val)
        {
            Dispatcher.BeginInvoke(new Action<float>((b)
                => this.btnVst.Content = b + " | " + rmsMax), val);
            if (val > rmsMax || rmsMax == 0)
                rmsMax = val;

        }

    }
}
