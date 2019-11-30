using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib.Cue
{
    public class CueItem
    {
        public string Title { get; set; }
        public int Index { get; set; }
        public string TimeString { get; set; }
        public TimeSpan Time
        {
            get
            {
                string[] s = TimeString.Split(':');
                return new TimeSpan(0, 0, s[0].ToInt(), s[1].ToInt(), s[2].ToInt() * 10);
            }
        }
        public double Seconds
        {
            get
            {
                return Time.TotalMilliseconds / 1000;
            }
        }
        public CueItem(string title, int index, string time)
        {
            Title = title;
            Index = index;
            TimeString = time;
        }
    }
}
