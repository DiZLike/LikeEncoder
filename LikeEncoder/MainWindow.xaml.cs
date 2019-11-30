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
using System.Data;
using WinForms = System.Windows.Forms;
using LikeEncoder.Binding;
using Microsoft.Win32;
using lib;
using lib.NTrack;
using lib.Encoders;
using LikeEncoder.Wnds;
using System.Threading.Tasks;
using System.Threading;
using lib.Encoders.Opus;
using lib.Cue;

namespace LikeEncoder
{
    public delegate void ValueChangedHandler(string encoderInfo);

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BassApp app;
        private List<TTag> _tags = new List<TTag>();
        public MainWindow()
        {
            InitializeComponent();
            app = new BassApp(IntPtr.Zero, OnError, OnProgress, OnComplete, OnCancel);
            Load();
        }

        private void OnError(Error error)
        {
            string msg = string.Format("{0}", error.Message);
            MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            LockUI(false);
            trackList.Dispatcher.Invoke(new Action(() => this.progress.Value++));
        }

        private void OnComplete()
        {
            LockUI(false);
            trackList.Dispatcher.Invoke(new Action(() => this.progress.Value = 0));
        }

        private void OnProgress(int index, int progress)
        {
            var trackItem = new BTrackList()
            {
                ID = index + 1,
                Format = _tags[index].FormatInfo,
                Title = _tags[index].ArtistTitle,
            };

            if (progress < 100)
                trackItem.Status = progress + "%";
            else
            {
                trackItem.Status = "Готово";
                trackList.Dispatcher.Invoke(new Action(() => this.progress.Value++));
            }
            trackList.Dispatcher.Invoke(new Action<BTrackList>((i) => trackList.Items[index] = i), trackItem);
        }
        private void OnLoadTags(TTag tags)
        {
            _tags.Add(tags);
            var trackItem = new BTrackList()
            {
                ID = tags.Index + 1,
                Format = tags.FormatInfo,
                Title = tags.ArtistTitle,
                Status = "Ожидание"
            };
            trackList.Dispatcher.Invoke(new Action<BTrackList>((i) => trackList.Items[tags.Index] = i), trackItem);
            progress.Dispatcher.Invoke(new Action<int>((i) => progress.Maximum = i), _tags.Count);
        }
        private void OnEncoderValueChanged(string encoderInfo)
        {
            formatTitle.Text = encoderInfo;
        }
        private void OnCancel()
        {
            LockUI(false);
            trackList.Dispatcher.Invoke(new Action(() => this.progress.Value = 0));
        }

        private void SaveAppCfg()
        {
            var cfg = new Cfg(Cfg.APP_CFG);
            cfg.Write("wndw", this.Width);
            cfg.Write("wndh", this.Height);
            cfg.Write("wndx", this.Left);
            cfg.Write("wndy", this.Top);
            cfg.Write("wnds", this.WindowState);
            cfg.Write("lid", tlID.Width);
            cfg.Write("lt", tlTitle.Width);
            cfg.Write("lf", tlFormat.Width);
            cfg.Write("ls", tlStatus.Width);
            cfg.Write("out", outPath.Text);
        }
        private void LoadAppCfg()
        {
            var cfg = new Cfg(Cfg.APP_CFG);
            this.Width = cfg.ReadInt("wndw", 658);
            this.Height = cfg.ReadInt("wndh", 438);
            this.Left = cfg.ReadInt("wndx", 0);
            this.Top = cfg.ReadInt("wndy", 0);
            this.WindowState = (WindowState)cfg.ReadInt("wnds", 0);
            tlID.Width = cfg.ReadInt("lid", 30);
            tlTitle.Width = cfg.ReadInt("lt", 233);
            tlFormat.Width = cfg.ReadInt("lf", 100);
            tlStatus.Width = cfg.ReadInt("ls", 55);
            outPath.Text = cfg.Read("out", AppDomain.CurrentDomain.BaseDirectory);
        }

        private void LockUI(bool _lock)
        {
            addBtn.Dispatcher.Invoke(new Action<bool>((b)
                => addBtn.IsEnabled = b), !_lock);
            outPath.Dispatcher.Invoke(new Action<bool>((b)
                => outPath.IsEnabled = b), !_lock);
            outPathBtn.Dispatcher.Invoke(new Action<bool>((b)
                => outPathBtn.IsEnabled = b), !_lock);
            encodersList.Dispatcher.Invoke(new Action<bool>((b)
                => encodersList.IsEnabled = b), !_lock);
            formatTitle.Dispatcher.Invoke(new Action<bool>((b)
                => formatTitle.IsEnabled = b), !_lock);
            formatFrame.Dispatcher.Invoke(new Action<bool>((b)
                => formatFrame.IsEnabled = b), !_lock);

            StartBtn.Dispatcher.Invoke(new Action(() =>
                {
                    StartBtn.Content = _lock ? "Стоп" : "Старт";
                    StartBtn.Tag = _lock ? "stop" : "start";
                }));

        }

<<<<<<< HEAD
        private void ShowMemoryUsege()
        {
            while (true)
            {
                this.Dispatcher.Invoke(new Action<double>((d) 
                    => this.Title = d.ToString()), Sys.MemoryUsege());
                Thread.Sleep(1000);
            }
        }

=======
>>>>>>> 58bfb773b28e99cf52281248c35db62c296c6ce1
        private void Load()
        {
            var encs = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\enc\encoders.txt");
            foreach (var item in encs)
                encodersList.Items.Add(item);
            /*
            new AudioOpus().GetEncoderParams();
            new AudioLame().GetEncoderParams();*/

            var cfg = new Cfg(Cfg.ENC_CFG);
            int defenc = cfg.Read("default_encoder").ToInt();
            encodersList.SelectedIndex = defenc;
<<<<<<< HEAD
=======
            switch ((EncoderType)defenc)
            {
                case EncoderType.OPUS:
                    var opus = new AudioOpus();
                    opus.LoadParams();
                    formatTitle.Text = opus.Format();
                    break;
            }
            ShowEncoderPage();
>>>>>>> 58bfb773b28e99cf52281248c35db62c296c6ce1
            cfg = new Cfg(Cfg.APP_CFG);
            var fn = cfg.Read("nameformat").Split(',');
            foreach (var item in fn)
                namesFormat.Items.Add(item);
        }

        private void BtnAddTrack_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            bool? b = ofd.ShowDialog();
            if (!b.Value) return;
            var tracks = ofd.FileNames;

            for (int i = 0; i < tracks.Length; i++)
            {
                var ext = System.IO.Path.GetExtension(tracks[i]);
                if (ext != ".cue")
                {
                    var at = new AudioTags(tracks[i], _tags.Count + i, OnLoadTags);
                    var trackItem = new BTrackList()
                    {
                        ID = _tags.Count + i + 1,
                        Format = "",
                        Title = System.IO.Path.GetFileName(tracks[i]),
                        Status = "Загрузка"
                    };
                    trackList.Items.Add(trackItem);
                }
                else
                {
                    CueFile cue = new CueFile(tracks[i]);
                    var at = new AudioTags(cue.File);
                    string[] tm = at.Tags.Duration.Split(':');

                    for (int x = 0; x < cue.Tracks.Count; x++)
                    {
                        var t = cue.Tracks[x];
                        at.Tags.Album = cue.Title;
                        at.Tags.TrackNo = (x + 1).ToString();
                        at.Tags.Artist = cue.Performer;
                        at.Tags.Title = t.Title;
                        at.Tags.TimeStart = t.Seconds;

                        if (x + 1 < cue.Tracks.Count)
                        {
                            at.Tags.TimeEnd = cue.Tracks[x + 1].Seconds;
                            TimeSpan ts = new TimeSpan(0, 0, (int)at.Tags.TimeEnd - (int)at.Tags.TimeStart);
                            at.Tags.Duration = ts.ToString("mm':'ss");
                        }
                        else
                        {
                            TimeSpan ts = new TimeSpan(0, tm[0].ToInt(), tm[1].ToInt()).Subtract(
                                new TimeSpan(0, 0, (int)at.Tags.TimeStart));
                            at.Tags.Duration = ts.ToString("mm':'ss");
                        }

                        _tags.Add(at.Tags);

                        var trackItem = new BTrackList()
                        {
                            ID = _tags.Count,
                            Format = _tags[x].FormatInfo,
                            Title = at.Tags.Title,
                            Status = "Ожидание"
                        };
                        trackList.Items.Add(trackItem);

                        
                    }
                }


            }
        }

        private void BtnStart(object sender, RoutedEventArgs e)
        {
            if (StartBtn.Tag.ToString() == "start")
            {
                string pattern = namesFormat.Text;
                List<string> tracks = new List<string>();
                if (_tags == null) return;
                foreach (var item in _tags)
                    tracks.Add(item.FileName);
                EncoderType enc = (EncoderType)encodersList.SelectedIndex;
                app.Start(enc, tracks.ToArray(), _tags.ToArray(), pattern, outPath.Text);
                LockUI(true);
            }
            else
            {
                app.Stop();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAppCfg();
            Task.Factory.StartNew(ShowMemoryUsege);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveAppCfg();
        }

        private void BtnTargetFolder(object sender, RoutedEventArgs e)
        {
            var openDir = new WinForms.FolderBrowserDialog();
            if (openDir.ShowDialog() != WinForms.DialogResult.OK)
                return;
            outPath.Text = openDir.SelectedPath;
            if (outPath.Text[outPath.Text.Length - 1] != '\\')
                outPath.Text += "\\";
        }

        private void ShowEncoderPage()
        {
            Page encPage = new Page();
            switch ((EncoderType)encodersList.SelectedIndex)
            {
                case EncoderType.OPUS:
                    encPage = new OpusPage(OnEncoderValueChanged, app._opusValue);
                    break;
                case EncoderType.MP3_LAME:
                    encPage = new LamePage(OnEncoderValueChanged, app._lameValue);
                    break;
                default:
                    encPage = new Page();
                    break;
            }
            formatFrame.Navigate(encPage);
        }

        private void FormatChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowEncoderPage();
        }
    }
}
