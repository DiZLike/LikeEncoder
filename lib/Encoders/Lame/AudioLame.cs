using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass.AddOn.Enc;
using System.Threading;

namespace lib.Encoders.Lame
{
    public class AudioLame : AudioEncoder
    {
        public AudioLame() { }
        public override void Start(string sourceAudio, string exitAudio, int index, double startPos,
            double endPos, EncoderValue encval, ProgressHandler onProgress, ErrorHandler onError)
        {
            base.Start(sourceAudio, exitAudio, index, startPos, endPos, encval, onProgress, onError);
            var ev = encval as AudioLameValue;
            sbCmd.Append(@"enc\mp3\lame ");
            if (ev.ABR)
                sbCmd.AppendFormat("--abr {0} ", ev.Bitrate);
            else if (ev.CBR)
                sbCmd.AppendFormat("--cbr -b {0} ", ev.Bitrate);
            else if (ev.VBR)
                sbCmd.AppendFormat("-V {0} ", ev.VBRmode);
            else if (ev.VBR_Old)
                sbCmd.AppendFormat("--vbr-old -V {0} ", ev.VBRmode);

            if (ev.SwapChannel)
                sbCmd.AppendFormat("--swap-channel ");

            string ch = String.Empty;
            #region
            switch (ev.Channels)
            {
                case 0: ch = "j"; break;
                case 1: ch = "s"; break;
                case 2: ch = "f"; break;
                case 3: ch = "d"; break;
                case 4: ch = "m"; break;
                case 5: ch = "l"; break;
                case 6: ch = "r"; break;
            }
            #endregion
            sbCmd.AppendFormat("-m {0} ", ch);
            sbCmd.AppendFormat("-q {0} ", ev.Quality);
            sbCmd.AppendFormat("--lowpass {0} --resample {1} ", ev.Lowpass, Math.Round((decimal)ev.Frequency / 1000, 1).ToString().Replace(',', '.'));
            sbCmd.AppendFormat("- \"{0}\"", exitAudio);
            cmd = sbCmd.ToString();
            Debug.Log(cmd);

            bool created = CreateStream(sourceAudio, cmd, BASSEncode.BASS_ENCODE_FP_16BIT);
            if (created)
                StartEncode();
        }
    }
}