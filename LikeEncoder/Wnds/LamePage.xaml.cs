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
using lib.Encoders.Lame;

namespace LikeEncoder.Wnds
{
    /// <summary>
    /// Логика взаимодействия для LamePage.xaml
    /// </summary>
    public partial class LamePage : Page
    {
        ValueChangedHandler onValueChanged;
        private AudioLameValue lame;

        public LamePage(ValueChangedHandler onValueChanged, AudioLameValue lame)
        {
            InitializeComponent();
            this.onValueChanged = onValueChanged;
            this.lame = lame;
            LoadEncoderOptions();
            LoadEncoderParameters();
            onValueChanged(lame.Format());
        }

        private void LoadEncoderOptions()
        {
            frequency.ItemsSource = lame.VFrequencyes;
            bitrate.ItemsSource = lame.VBitrates;
            quality.ItemsSource = lame.VQualityes;
            channel.ItemsSource = lame.VChannels;
        }

        private void LoadEncoderParameters()
        {
            lame.LoadParams(lame.CFG);
            swap.IsChecked = lame.EncParam["swapchannel"].ToBool();
            cbr.IsChecked = lame.EncParam["cbr"].ToBool();
            abr.IsChecked = lame.EncParam["abr"].ToBool();
            vbr.IsChecked = lame.EncParam["vbr"].ToBool();
            vbrold.IsChecked = lame.EncParam["vbrold"].ToBool();

            frequency.SelectedIndex = lame.EncParam["frequency"].ToInt();

            if (!vbr.IsChecked.Value)
            {
                bitrate.SelectedIndex = lame.EncParam["bitrate"].ToInt();
            }
            else
            {
                bitrate.ItemsSource = lame.VVBRmodes;
                bitrate.SelectedIndex = lame.EncParam["vbrmode"].ToInt();
            }
            quality.SelectedIndex = lame.EncParam["quality"].ToInt();
            channel.SelectedIndex = lame.EncParam["stereomode"].ToInt();
        }

        private void ValueChanged()
        {
            if (bitrate.SelectedIndex < 0
                || frequency.SelectedIndex < 0
                || quality.SelectedIndex < 0
                || channel.SelectedIndex < 0)
                return;
            lame.EncParam["frequency"] = frequency.SelectedIndex;
            if (!vbr.IsChecked.Value)
                lame.EncParam["bitrate"] = bitrate.SelectedIndex;
            else
                lame.EncParam["vbrmode"] = bitrate.SelectedIndex;
            lame.EncParam["quality"] = quality.SelectedIndex;
            lame.EncParam["stereomode"] = channel.SelectedIndex;

            lame.EncParam["cbr"] = cbr.IsChecked.Value;
            lame.EncParam["abr"] = abr.IsChecked.Value;
            lame.EncParam["vbr"] = vbr.IsChecked.Value;
            lame.EncParam["vbrold"] = vbrold.IsChecked.Value;
            lame.EncParam["swapchannel"] = swap.IsChecked.Value;

            onValueChanged(lame.Format());
        }

        private void ValueChanged(object sender, SelectionChangedEventArgs e)
        {
            ValueChanged();
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            if (vbr == null) return;
            if (lame == null) return;
            if (vbr.IsChecked.Value)
            {
                bitrate.ItemsSource = lame.VVBRmodes;
                bitrate.SelectedIndex = lame.EncParam["vbrmode"].ToInt();
            }
            else
            {
                bitrate.ItemsSource = lame.VBitrates;
                bitrate.SelectedIndex = lame.EncParam["bitrate"].ToInt();
            }

            ValueChanged();
        }
    }
}
