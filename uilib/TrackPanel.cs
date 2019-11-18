using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace uilib
{
    public partial class TrackPanel : UserControl
    {
        public List<Track> Tracks = new List<Track>();

        public TrackPanel()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(TrackPanel_MouseWheel);
        }

        private void TrackPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            
        }

        private Track CreateTrack()
        {
            Track track = new Track();
            track.Anchor = AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            int vsX = SystemInformation.VerticalScrollBarWidth;
            if (!VerticalScroll.Visible)
                track.Size = new Size(this.Size.Width, track.SizeY);
            else
                track.Size = new Size(this.Size.Width - vsX, track.SizeY);
            if (Tracks.Count == 0)
                track.Location = new Point(0, 0);
            else
            {
                int y = Tracks[Tracks.Count - 1].Location.Y + track.Size.Height - 1;
                track.Location = new Point(0, y);
            }

            this.Controls.Add(track);
            Tracks.Add(track);
            return track;
        }

        public void AddTrack(string path, string title, string format)
        {
            Track track = CreateTrack();
            track.Complete = false;
            track.EncodingProgress = 0;
            track.Path = path;
            track.Format = format;
            track.Title = title;

        }

    }
}
