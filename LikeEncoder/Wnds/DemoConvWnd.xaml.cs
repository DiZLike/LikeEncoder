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
using lib;
using lib.Encoders;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LikeEncoder.Wnds
{
    /// <summary>
    /// Логика взаимодействия для DemoConvWnd.xaml
    /// </summary>
    public partial class DemoConvWnd : Window
    {
        private string track;
        private TestCodec tcod;
        private int[] allProgress = new int[2];

        public DemoConvWnd(string track)
        {
            InitializeComponent();
            this.track = track;
            StartTest();
        }

        private void StartTest()
        {
            progress.Maximum = allProgress.Length * 100;
            tcod = new TestCodec(track, OnProgress, OnPossition);
        }

        private void TestBtn(object sender, RoutedEventArgs e)
        {
            tcod.Play();
            new Spectrum(tcod).Show();
        }

        private void StopBtn(object sender, RoutedEventArgs e)
        {
            //tcod.Stop();
            var v = Math.Log(255, 2);
            //b.Save(AppDomain.CurrentDomain.BaseDirectory + @"\1.bmp");
            //spectrum.Source = ConvertToBI(b);
        }

        public BitmapImage ConvertToBI(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        private void GetSpectrum()
        {


            
            while (true)
            {
                //var b = tcod.GetSpectrum();
                //spectrum.Dispatcher.Invoke(new Action<Bitmap>((i) => spectrum.Source = ConvertToBI(i)), b);
                
                Thread.Sleep(25);
            }
        }

        private void OnProgress(int index, int progress)
        {
            allProgress[index] = progress;
            int p = 0;
            foreach (var item in allProgress)
                p += item;

            Dispatcher.BeginInvoke(new Action<int>((i) => this.progress.Value = i), p);
        }
        private void OnPossition(double pos, double max)
        {
            Dispatcher.BeginInvoke(new Action<double>((i) => this.source.Maximum = i), max);
            Dispatcher.BeginInvoke(new Action<double>((i) => this.source.Value = i), pos);
        }

        private void ChangeCodec(object sender, RoutedEventArgs e)
        {
            var obj = sender as RadioButton;
            int index = int.Parse(obj.Tag.ToString());
            tcod.ChangeCodec(index);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tcod.Stop();
        }

        private void spectrum_MouseMove(object sender, MouseEventArgs e)
        {
            //lC1.Content = tcod.GetFreq((int)e.GetPosition(spectrum).X, (int)e.GetPosition(spectrum).Y);
        }

    }
}
