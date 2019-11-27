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
using System.Windows.Navigation;
using System.Windows.Shapes;
using lib;
using lib.Encoders;

namespace LikeEncoder.Wnds
{
    /// <summary>
    /// Логика взаимодействия для OpusPage.xaml
    /// </summary>
    public partial class OpusPage : Page
    {
        ValueChangedHandler onValueChanged;
        AudioOpus opus;

        public OpusPage(ValueChangedHandler onValueChanged)
        {
            InitializeComponent();
            this.onValueChanged = onValueChanged;
            LoadEncoderOptions();
            LoadEncoderParameters();
        }
        private void LoadEncoderParameters()
        {
            opus = new AudioOpus();
            opus.LoadParams();

            var br = BassApp.param["bitrate"].ToString();
            for (int i = 0; i < bitrate.Items.Count; i++)
            {
                if (bitrate.Items[i].ToString() == br)
                    bitrate.SelectedIndex = i;
            }
            framesize.Text = BassApp.param["framesize"].ToString();
            quality.Text = BassApp.param["quality"].ToString();
            channel.SelectedIndex = BassApp.param["channel"].ToInt();
            if (BassApp.param["music"].ToBool())
                music.IsChecked = true;
            if (BassApp.param["speech"].ToBool())
                speech.IsChecked = true;
        }

        private void LoadEncoderOptions()
        {
            Cfg cfg = new Cfg(Cfg.ENC_CFG);
            var _bitrate = cfg.Read("opus_bitrate").Split(',');
            var _framesize = cfg.Read("opus_framesize").Split(',');
            var _quality = cfg.Read("opus_quality").Split(',');
            var _channel = cfg.Read("opus_channel").Split(',');

            frequency.Items.Add("48000");
            frequency.SelectedIndex = 0;

            bitrate.ItemsSource = _bitrate;
            framesize.ItemsSource = _framesize;
            quality.ItemsSource = _quality;
            channel.ItemsSource = _channel;
        }
        private void ValueChanged()
        {
            if (opus == null || bitrate.SelectedIndex < 0
                || framesize.SelectedIndex < 0
                || quality.SelectedIndex < 0
                || channel.SelectedIndex < 0)
                return;
            BassApp.param["bitrate"] = bitrate.Items[bitrate.SelectedIndex].ToString();
            BassApp.param["framesize"] = framesize.Items[framesize.SelectedIndex].ToString();
            BassApp.param["quality"] = quality.Items[quality.SelectedIndex].ToString();
            BassApp.param["channel"] = channel.SelectedIndex;
            BassApp.param["music"] = music.IsChecked;
            BassApp.param["speech"] = speech.IsChecked;
            onValueChanged(opus.Format());
        }

        private void auto_Checked(object sender, RoutedEventArgs e)
        {
            ValueChanged();
        }

        private void ValueChanged(object sender, SelectionChangedEventArgs e)
        {
            ValueChanged();
        }
    }
}
