using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace tagslib.Tags.Opus
{
    public class OpusFile : AudioFile
    {
        private ParamArray comments = new ParamArray();

        public OpusFile(string opusfile)
            : base(opusfile)
        {
            //SetOffset(0x4D); //0x49
            SetOffset(0x49);
            byte offset = ReadByte();
            AddOffset(offset);

            SetOffset(0x112 + 0xC738 + 0x112 + 0xC738);
            var g = ReadStringChar(4);

            /*
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
            var img = comments["METADATA_BLOCK_PICTURE"];
            */
            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "12.txt", img);
            //byte[] b = Convert.FromBase64String(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "12.txt"));

            //File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "1.txt", b);

            

            
            

        }



    }
}
