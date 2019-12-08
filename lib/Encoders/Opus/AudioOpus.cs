using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Enc;
using lib.Encoders.Opus;
<<<<<<< HEAD
using System.Threading;
=======
>>>>>>> d29c2d4be9dea9162fcb9bc50a453536ab565ba2

namespace lib.Encoders.Lame
{
    public class AudioOpus : AudioEncoder
    {
<<<<<<< HEAD
        public AudioOpus(CancellationToken token) : base(token) { }
=======
>>>>>>> d29c2d4be9dea9162fcb9bc50a453536ab565ba2
        public override void Start(string sourceAudio, string exitAudio, int index, double startPos,
            double endPos, EncoderValue encval, ProgressHandler onProgress, ErrorHandler onError)
        {
            base.Start(sourceAudio, exitAudio, index, startPos, endPos, encval, onProgress, onError);
            var ev = encval as AudioOpusValue;

            sbCmd.Append(@"enc\opus\opusenc ");
            sbCmd.AppendFormat("--bitrate {0} ", ev.Bitrate);
            sbCmd.AppendFormat("--framesize {0} ", ev.Framesize);
            sbCmd.AppendFormat("--comp {0} ", ev.Quality);
            if (ev.Music)
                sbCmd.Append("--music ");
            if (ev.Speech)
                sbCmd.Append("--speech ");
            if (ev.Channels == 1)
                sbCmd.Append("--downmix-mono ");

            sbCmd.AppendFormat("- \"{0}\"", exitAudio);
            cmd = sbCmd.ToString();
            Debug.Log(cmd);

            bool created = CreateStream(sourceAudio, cmd, BASSEncode.BASS_ENCODE_FP_16BIT);
            if (created)
                StartEncode();
        }

    }
}
