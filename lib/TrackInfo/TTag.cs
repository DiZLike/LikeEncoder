using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib.NTrack
{
    public class TTag
    {
        public string FileName { get; set; }

        public string Album { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string TrackNo { get; set; }


        public string Codec { get; set; }
        public string Frequency { get; set; }
        public string Bitrate { get; set; }
        public string Channels { get; set; }
        public string Duration { get; set; }
        public int Index { get; set; }

        public string FormatInfo
        {
            get
            {
                return string.Format("{0}, {1}, {2}, {3}",
                    Frequency, Bitrate, Channels, Duration);
            }
        }
        public string ArtistTitle
        {
            get
            {
                return string.Format("{0} - {1}",
                    Artist, Title);
            }
        }

    }
}
