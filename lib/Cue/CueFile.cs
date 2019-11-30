using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib.Cue
{
    public class CueFile
    {
        public string Title { get; set; }
        public string Performer { get; set; }
        public string File { get; set; }
        public string Format { get; set; }
        public int TrackCount { get; set; }
        public List<CueItem> Tracks { get; set; }

        private string cue;
        private string[] cueText;

        public CueFile(string cue)
        {
            this.cue = cue;
            GetCueText(cue);
            GetCueTitle();
            GetCuePerformer();
            GetCueFile();
            GetCueTrackCount();
            GetCueTracks();

            var r = Tracks[4].Seconds;
        }

        private void GetCueTracks()
        {
            if (Tracks == null) Tracks = new List<CueItem>();
            var index = 0;
            for (int i = 0; i < cueText.Length; i++)
            {
                var line = cueText[i];

                bool finded = line.CheckText("TRACK");
                if (!finded) continue;
                var val = line.GetAfterValue("TRACK");
                if (!val.ToLower().Contains("AUDIO".ToLower()))
                    continue;

                var time = String.Empty;
                var trackTitle = String.Empty;
                for (int x = i + 1; x < cueText.Length; x++)
                {
                    line = cueText[x];
                    finded = line.CheckText("TRACK");
                    if (finded)
                    {
                        i = x + 1;
                        break;
                    }
                    if (time == String.Empty)
                        time = GetTrackTime(line);
                    if (trackTitle == String.Empty)
                        trackTitle = GetTrackTitle(line);
                    if (trackTitle != String.Empty && trackTitle != String.Empty)
                    {
                        Tracks.Add(new CueItem(trackTitle, index++, time));
                        i = x + 1;
                        break;
                    }
                }

            }
        }

        private string GetTrackTitle(string line)
        {
            if (!line.Contains("TITLE")) return String.Empty;
            return line.GetAfterValue("TITLE ").Replace("\"", "");
        }

        private string GetTrackTime(string line)
        {
            if (!line.Contains("INDEX")) return String.Empty;
            var spl = line.Split(' ');
            if (spl.Length < 1) return String.Empty;
            return spl[spl.Length - 1];
        }

        private void GetCueTrackCount()
        {
            for (int i = 0; i < cueText.Length; i++)
            {
                var line = cueText[i];
                bool finded = line.CheckText("TRACK");
                if (!finded) continue;
                TrackCount++;
            }
        }

        private void GetCueFile()
        {
            var fileTag = "FILE ";
            var file = GetCueValue(fileTag, "TRACK");

            int c = 0;
            int startIndex = 0;
            int lastIndex = 0;
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] == '\"') c++;
                else continue;
                if (c == 1)
                    startIndex = i + 1;
                if (c == 2)
                    lastIndex = i;
            }
            File = file.Substring(startIndex, lastIndex - startIndex);
            Format = file.Substring(lastIndex + 1);
        }

        private void GetCueTitle()
        {
            var title = "TITLE ";
            Title = GetCueValue(title, "TRACK").Replace("\"", "");
        }
        private void GetCuePerformer()
        {
            var performer = "PERFORMER ";
            Performer = GetCueValue(performer, "TRACK").Replace("\"", "");
        }

        private string GetCueValue(string value, string stopString)
        {
            for (int i = 0; i < cueText.Length; i++)
            {
                var line = cueText[i];
                if (line.CheckText(stopString)) return String.Empty;

                bool finded = line.CheckText(value);
                if (!finded) continue;
                return line.GetAfterValue(value);
            }
            return String.Empty;
        }

        private void GetCueText(string cue)
        {
            if (!System.IO.File.Exists(cue)) return;
            cueText = System.IO.File.ReadAllLines(cue);
        }

    }
}