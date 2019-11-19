using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tagslib.Tags.Opus
{
    public class OpusFile : AudioFile
    {
        private ParamArray comments = new ParamArray();

        public OpusFile(string opusfile)
            : base(opusfile)
        {
            SetOffset(0x4D);

            string opusTags = ReadStringChar(0x8);
            if (opusTags != "OpusTags")
            {
                Close();
                return;
            }
            string libOpus = ReadString(32);
            int tagCount = ReadInt();
            string[] rawTags = new string[tagCount];
            for (int i = 0; i < tagCount; i++)
            {
                string tag = ReadString(32);
                rawTags[i] = tag;
            }
            GetTags(rawTags, ref comments);
        }



    }
}
