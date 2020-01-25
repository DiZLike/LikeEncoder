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

namespace Likenc.Wnds
{
    /// <summary>
    /// Логика взаимодействия для CueWnd.xaml
    /// </summary>
    public partial class CueWnd : Window
    {
        private List<CheckBox> _cbs = new List<CheckBox>();
        public TTag[] tags;
        public CueWnd(TTag[] tags)
        {
            InitializeComponent();
            this.tags = tags;
            for (int i = 0; i < tags.Length; i++)
                AddCheckBox(tags[i].ArtistTitle);
        }

        private void AddCheckBox(string text)
        {
            CheckBox cb = new CheckBox();
            cb.Margin = new Thickness(3, 3, 3, 3);
            cb.BorderBrush = new SolidColorBrush(Color.FromRgb(0xBF, 0xBF, 0xBF));
            cb.Content = text;
            cb.IsChecked = true;
            cue.Items.Add(cb);
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tags.Length; i++)
            {
                var ch = cue.Items[i] as CheckBox;
                tags[i].Add = ch.IsChecked.Value;
            }
            Close();
        }

    }
}
