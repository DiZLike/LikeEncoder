using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass;
using System.Threading;
using System.Threading.Tasks;
using lib.Cue;
using TagLib;
using IO = System.IO;
using System.Windows.Controls;

namespace lib.NTrack
{
    public delegate void LoadTagHandler(TTag tags);

    public class AudioTags
    {
        private LoadTagHandler onLoadTags;
        private int index;
        private string file;
        private static bool savePict = true;
        public TTag Tags { get; set; }

        public AudioTags(string file, int index, LoadTagHandler onLoadTags)
        {
            this.onLoadTags = onLoadTags;
            this.index = index;
            this.file = file;
            Task.Factory.StartNew(LoadTags);
        }
<<<<<<< HEAD
        /// <summary>
        /// For CUE File
        /// </summary>
        /// <param name="file"></param>
        public AudioTags(string file)
        {
            this.file = file;
            //LoadTags();
        }
        public TTag[] LoadCue()
        {
            List<TTag> _tags = new List<TTag>();
            CueFile cue = new CueFile(file);
            file = cue.File;
            LoadTags();
            string[] tm = Tags.Duration.Split(':');
            for (int x = 0; x < cue.Tracks.Count; x++)
            {
                var t = cue.Tracks[x];
                TTag newTTag = Tags.Copy();

                newTTag.Album = cue.Title;
                newTTag.TrackNo = (x + 1).ToString();
                newTTag.Artist = cue.Performer;
                newTTag.Title = t.Title;
                newTTag.TimeStart = t.Seconds;

                if (x + 1 < cue.Tracks.Count)
                {
                    newTTag.TimeEnd = cue.Tracks[x + 1].Seconds;
                    TimeSpan ts = new TimeSpan(0, 0, (int)newTTag.TimeEnd - (int)newTTag.TimeStart);
                    newTTag.Duration = ts.ToString("mm':'ss");
                }
                else
                {
                    TimeSpan ts = new TimeSpan(0, tm[0].ToInt(), tm[1].ToInt()).Subtract(
                        new TimeSpan(0, 0, (int)newTTag.TimeStart));
                    newTTag.Duration = ts.ToString("mm':'ss");
                    TimeSpan ts2 = new TimeSpan(0, tm[0].ToInt(), tm[1].ToInt());
                    newTTag.TimeEnd = ts2.TotalMilliseconds / 1000;
                }
                _tags.Add(newTTag);
            }
            return _tags.ToArray();
=======

        public AudioTags(string file)
        {
            this.file = file;




            LoadTags();
>>>>>>> d29c2d4be9dea9162fcb9bc50a453536ab565ba2
        }

        public static void SaveTags(string file, TTag tag)
        {
            if (!System.IO.File.Exists(file))
                return;
            var tfile = TagLib.File.Create(file);
            var stfile = TagLib.File.Create(tag.FileName);

            tfile.Tag.Album = stfile.Tag.Album;
            tfile.Tag.AlbumArtists = stfile.Tag.AlbumArtists;
            tfile.Tag.AlbumArtistsSort = stfile.Tag.AlbumArtistsSort;
            tfile.Tag.AlbumSort = stfile.Tag.AlbumSort;
            tfile.Tag.AmazonId = stfile.Tag.AmazonId;
            tfile.Tag.BeatsPerMinute = stfile.Tag.BeatsPerMinute;
            tfile.Tag.Comment = stfile.Tag.Comment;
            tfile.Tag.Composers = stfile.Tag.Composers;
            tfile.Tag.ComposersSort = stfile.Tag.ComposersSort;
            tfile.Tag.Conductor = stfile.Tag.Conductor;
            tfile.Tag.Copyright = stfile.Tag.Copyright;
            tfile.Tag.DateTagged = stfile.Tag.DateTagged;
            tfile.Tag.Description = stfile.Tag.Description;
            tfile.Tag.Disc = stfile.Tag.Disc;
            tfile.Tag.DiscCount = stfile.Tag.DiscCount;
            tfile.Tag.Genres = stfile.Tag.Genres;
            tfile.Tag.Grouping = stfile.Tag.Grouping;
            tfile.Tag.InitialKey = stfile.Tag.InitialKey;
            tfile.Tag.ISRC = stfile.Tag.ISRC;
            tfile.Tag.Lyrics = stfile.Tag.Lyrics;
            tfile.Tag.MusicBrainzArtistId = stfile.Tag.MusicBrainzArtistId;
            tfile.Tag.MusicBrainzDiscId = stfile.Tag.MusicBrainzDiscId;
            tfile.Tag.MusicBrainzReleaseArtistId = stfile.Tag.MusicBrainzReleaseArtistId;
            tfile.Tag.MusicBrainzReleaseCountry = stfile.Tag.MusicBrainzReleaseCountry;
            tfile.Tag.MusicBrainzReleaseGroupId = stfile.Tag.MusicBrainzReleaseGroupId;
            tfile.Tag.MusicBrainzReleaseId = stfile.Tag.MusicBrainzReleaseId;
            tfile.Tag.MusicBrainzReleaseStatus = stfile.Tag.MusicBrainzReleaseStatus;
            tfile.Tag.MusicBrainzReleaseType = stfile.Tag.MusicBrainzReleaseType;
            tfile.Tag.MusicBrainzTrackId = stfile.Tag.MusicBrainzTrackId;
            tfile.Tag.MusicIpId = stfile.Tag.MusicIpId;
            tfile.Tag.Performers = stfile.Tag.Performers;
            tfile.Tag.PerformersRole = stfile.Tag.PerformersRole;
            tfile.Tag.PerformersSort = stfile.Tag.PerformersSort;

            if (!savePict)
                tfile.Tag.Pictures = stfile.Tag.Pictures;
            else
                SavePictures(stfile.Tag.Pictures, file, tag);

            tfile.Tag.Publisher = stfile.Tag.Publisher;
            tfile.Tag.RemixedBy = stfile.Tag.RemixedBy;
            tfile.Tag.ReplayGainAlbumGain = stfile.Tag.ReplayGainAlbumGain;
            tfile.Tag.ReplayGainAlbumPeak = stfile.Tag.ReplayGainAlbumPeak;
            tfile.Tag.ReplayGainTrackGain = stfile.Tag.ReplayGainTrackGain;
            tfile.Tag.ReplayGainTrackPeak = stfile.Tag.ReplayGainTrackPeak;
            tfile.Tag.Subtitle = stfile.Tag.Subtitle;

            tfile.Tag.Title = stfile.Tag.Title == null ? tag.Title : stfile.Tag.Title;

            tfile.Tag.TitleSort = stfile.Tag.TitleSort;
            tfile.Tag.Track = stfile.Tag.Track;
            tfile.Tag.TrackCount = stfile.Tag.TrackCount;
            tfile.Tag.Year = stfile.Tag.Year;

            Cfg app_cfg = new Cfg(Cfg.APP_CFG);
            bool si = app_cfg.ReadBool("saveinfo", false);
            if (si)
                tfile.Tag.Comment += tfile.Tag.Comment.Length > 0 ? "\n" + AddComment(tag) : AddComment(tag);

            tfile.Save();
        }
        public static string AddComment(TTag tag)
        {
            string info = string.Format("Codec: {0}, {1}, {2}, {3}", tag.Codec, tag.Frequency, tag.Bitrate, tag.Channels);
            return info;
        }
        public static void SavePictures(IPicture[] pict, string file, TTag tag)
        {
            var s = IO.Path.GetDirectoryName(file);
            byte[] png = new byte[] { 0x89, 0x50, 0x4e, 0x47 };
            byte[] jpg = new byte[] { 0xff, 0xd8, 0xff, 0xe0 };
            string format = String.Empty;
            for (int i = 0; i < pict.Length; i++)
            {
                byte[] bytes = pict[i].Data.Data;
                if (CheckBytes(png, bytes))
                    format = ".png";
                if (CheckBytes(jpg, bytes))
                    format = ".jpg";
                string filename = pict.Length == 1 ? tag.Album : tag.Album + (i + 1).ToString();
                string allname = IO.Path.Combine(s, filename + format);
                if (IO.File.Exists(allname))
                    continue;
                try
                {
                    IO.File.WriteAllBytes(allname, bytes);
                }
                catch
                {

                }
            }
        }
        public static string DirectoryStructPattern(string pattern, TTag tag)
        {
            string artist = "[artist]";
            string album = "[album]";
            string title = "[title]";
            string year = "[year]";
            string trackno = "[trackNo]";
            string filename = "[filename]";

            if (tag.TrackNo != null)
                if (tag.TrackNo.ToInt() < 10)
                    tag.TrackNo = "0" + tag.TrackNo;

            string o = pattern.Replace(artist, tag.Artist);
            o = o.Replace(album, tag.Album);
            o = o.Replace(title, tag.Title);
            if (tag.Year != null)
                o = o.Replace(year, tag.Year);
            if (tag.TrackNo != null)
                o = o.Replace(trackno, tag.TrackNo);
            o = o.Replace(filename, tag.FileName);

            return o;
        }

        private void LoadTags()
        {
            Tags = new TTag();
            Tags.Index = index;
            var info = BassTags.BASS_TAG_GetFromFile(file);

            Tags.Album = info.album;
            Tags.Artist = info.artist;
            Tags.Title = info.title;
            Tags.FileName = file;
            Tags.Year = info.year;
            Tags.TrackNo = info.track;

            Tags.Codec = GetCodec(info.channelinfo.ctype);
            Tags.Frequency = Math.Round((float)info.channelinfo.freq / 1000f, 1).ToString() + " kHz";
            Tags.Bitrate = info.bitrate + " kBit";
            Tags.Channels = GetChannel(info.channelinfo.chans);
            Tags.Duration = new TimeSpan(0, 0, 0, (int)info.duration).ToString("mm':'ss");
            info = null;
            if (onLoadTags != null)
                onLoadTags(Tags);
        }

        private string GetCodec(BASSChannelType ctype)
        {
            switch (ctype)
            {
                case BASSChannelType.BASS_CTYPE_STREAM_OPUS:
                    return "Opus";
                case BASSChannelType.BASS_CTYPE_STREAM_FLAC:
                    return "FLAC";
                default:
                    return "Unknown";
            }
        }
        private string GetChannel(int channels)
        {
            if (channels == 1)
                return "Mono";
            else
                return "Stereo";
        }
        private static bool CheckBytes(byte[] shortbytes, byte[] longbytes)
        {
            for (int i = 0; i < shortbytes.Length; i++)
            {
                if (shortbytes[i] != longbytes[i]) return false;
            }
            return true;
        }
    }
}
