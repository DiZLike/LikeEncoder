using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass;
using System.Threading;
using System.Threading.Tasks;

namespace lib.NTrack
{
    public delegate void LoadTagHandler(TTag tags);

    public class AudioTags
    {
        private LoadTagHandler onLoadTags;
        private int index;
        private string file;
        public TTag Tags { get; set; }

        public AudioTags(string file, int index, LoadTagHandler onLoadTags)
        {
            this.onLoadTags = onLoadTags;
            this.index = index;
            this.file = file;
            Task.Factory.StartNew(LoadTags);
        }

        public AudioTags(string file)
        {
            this.file = file;




            LoadTags();
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
            tfile.Tag.Pictures = stfile.Tag.Pictures;
            tfile.Tag.Publisher = stfile.Tag.Publisher;
            tfile.Tag.RemixedBy = stfile.Tag.RemixedBy;
            tfile.Tag.ReplayGainAlbumGain = stfile.Tag.ReplayGainAlbumGain;
            tfile.Tag.ReplayGainAlbumPeak = stfile.Tag.ReplayGainAlbumPeak;
            tfile.Tag.ReplayGainTrackGain = stfile.Tag.ReplayGainTrackGain;
            tfile.Tag.ReplayGainTrackPeak = stfile.Tag.ReplayGainTrackPeak;
            tfile.Tag.Subtitle = stfile.Tag.Subtitle;
            tfile.Tag.Title = stfile.Tag.Title;
            tfile.Tag.TitleSort = stfile.Tag.TitleSort;
            tfile.Tag.Track = stfile.Tag.Track;
            tfile.Tag.TrackCount = stfile.Tag.TrackCount;
            tfile.Tag.Year = stfile.Tag.Year;
            tfile.Save();
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

    }
}
