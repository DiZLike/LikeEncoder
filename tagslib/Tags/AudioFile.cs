using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using tagslib.Tags;

namespace tagslib.Tags
{
    public abstract class AudioFile
    {
        public MTags Tags { get; set; }

        private string file;
        private FileStream fileStream;

        public AudioFile(string file)
        {
            this.file = file;
            fileStream = new FileStream(file, FileMode.Open);
        }
        protected void SetOffset(long offset)
        {
            fileStream.Position = offset;
        }
        protected void AddOffset(long offset)
        {
            fileStream.Position += offset;
        }
        protected string ReadStringChar(int charCount)
        {
            return fileStream.ReadStringChar(0x8);
        }
        protected string ReadString(int bit)
        {
            return fileStream.ReadString(bit);
        }
        protected int ReadInt()
        {
            return fileStream.ReadInt();
        }
        protected byte ReadByte()
        {
            return (byte)fileStream.ReadByte();
        }
        protected void GetTags(string[] rawTags, ref ParamArray tags)
        {
            foreach (var item in rawTags)
            {
                var tag = ParseComment(item);
                tags[tag[0]] = tag[1];
            }
        }
        private string[] ParseComment(string comment)
        {
            int splitIndex = 0;
            for (int i = 0; i < comment.Length; i++)
            {
                if (comment[i] == '=')
                {
                    splitIndex = i;
                    break;
                }
            }
            string name = comment.Substring(0, splitIndex);
            string value = comment.Substring(splitIndex + 1);
            return new string[] { name, value };
        }
        protected void Close()
        {
            fileStream.Close();
        }

    }
}
