using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

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

        public double TimeStart { get; set; }
        public double TimeEnd { get; set; }

        public string Codec { get; set; }
        public string Frequency { get; set; }
        public string Bitrate { get; set; }
        public string Channels { get; set; }
        public string Duration { get; set; }
        public int Index { get; set; }
        public bool Add { get; set; }

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

        public static int AddCount(TTag[] tags)
        {
            int count = 0;
            foreach (var item in tags)
            {
                if (item.Add) count++;
            }
            return count;
        }
        public TTag Copy()
        {
            TTag copy = new TTag();
            foreach (PropertyInfo item in typeof(TTag).GetProperties())
            {
                if (!item.CanWrite) continue;
                item.SetValue(copy, item.GetValue(this, null), null);
            }
            return copy;
        }

    }
}