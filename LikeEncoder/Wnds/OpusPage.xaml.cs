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
using lib.Encoders.Opus;

namespace Likenc.Wnds
{
    /// <summary>
    /// Логика взаимодействия для OpusPage.xaml
    /// </summary>
    public partial class OpusPage : Page
    {
        ValueChangedHandler onValueChanged;
        private AudioOpusValue opus;

        public OpusPage(ValueChangedHandler onValueChanged, AudioOpusValue opus)
        {
            InitializeComponent();
            this.onValueChanged = onValueChanged;
            this.opus = opus;
            LoadEncoderOptions();
            LoadEncoderParameters();
            onValueChanged(opus.Format());
        }
        
        private void LoadEncoderOptions()
        {
            frequency.Items.Add("48000");
            frequency.SelectedIndex = 0;

            bitrate.ItemsSource = opus.VBitrates;
            framesize.ItemsSource = opus.VFramesizes;
            quality.ItemsSource = opus.VQualityes;
            channel.ItemsSource = opus.VChannels;
        }

        private void LoadEncoderParameters()
        {
            opus.LoadParams(opus.CFG);
            if (opus.EncParam["music"].ToBool())
                music.IsChecked = true;
            if (opus.EncParam["speech"].ToBool())
                speech.IsChecked = true;

            bitrate.SelectedIndex = opus.EncParam["bitrate"].ToInt();
            framesize.SelectedIndex = opus.EncParam["framesize"].ToInt();
            quality.SelectedIndex = opus.EncParam["quality"].ToInt();
            channel.SelectedIndex = opus.EncParam["channel"].ToInt();
        }

        private void ValueChanged()
        {
            if (bitrate.SelectedIndex < 0
                || framesize.SelectedIndex < 0
                || quality.SelectedIndex < 0
                || channel.SelectedIndex < 0)
                return;

            opus.EncParam["bitrate"] = bitrate.SelectedIndex;
            opus.EncParam["framesize"] = framesize.SelectedIndex;
            opus.EncParam["quality"] = quality.SelectedIndex;
            opus.EncParam["channel"] = channel.SelectedIndex;
            opus.EncParam["music"] = music.IsChecked;
            opus.EncParam["speech"] = speech.IsChecked;

            opus.SaveParam(opus.CFG);
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
