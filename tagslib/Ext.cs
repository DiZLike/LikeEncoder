using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace tagslib
{
    public static class Ext
    {
        public static string ReadStringChar(this FileStream stream, int count)
        {
            byte[] bytes = new byte[count];
            stream.Read(bytes, 0, bytes.Length);
            return Encoding.UTF8.GetString(bytes);
        }
        public static string ReadString(this FileStream stream, int bit)
        {
            byte[] charsCountBytes = new byte[bit / 8];
            stream.Read(charsCountBytes, 0, charsCountBytes.Length);
            uint charsCount = BitConverter.ToUInt32(charsCountBytes, 0);
            byte[] stringBytes = new byte[charsCount];
            stream.Read(stringBytes, 0, stringBytes.Length);
            return Encoding.UTF8.GetString(stringBytes);
        }
        public static int ReadInt(this FileStream stream)
        {
            byte[] intBytes = new byte[32 / 8];
            stream.Read(intBytes, 0, intBytes.Length);
            return BitConverter.ToInt32(intBytes, 0);
        }
    }
}
