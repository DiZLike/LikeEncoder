using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO;

namespace lib
{
    public static class Ext
    {
        public static int ToInt(this object value)
        {
            int result = 0;
            bool ok = int.TryParse(value.ToString(), out result);
            return result;
        }
        public static bool ToBool(this object value)
        {
            bool result = false;
            bool ok = bool.TryParse(value.ToString(), out result);
            if (!ok)
            {
                if (value.ToString() == "1")
                    result = true;
                else
                    result = false;
            }
            return result;
        }
        public static bool CheckText(this string value, string text)
        {
            var str = value.Remove(text.Length, value.Length - text.Length);
            if (str.ToLower() == text.ToLower())
                return true;
            else return false;
        }
        public static string GetAfterValue(this string text, string value)
        {
            int index = text.IndexOf(value);
            //return text.Remove(index, value.Length);
            var s = text.Substring(index + value.Length, text.Length - index - value.Length);;
            return s;
        }
        public static string FilterSymbols(string path)
        {
            StringBuilder s = new StringBuilder();
            var sym1 = Path.GetInvalidFileNameChars();
            for (int x = 0; x < path.Length; x++)
            {
                bool ok = true;
                for (int y = 0; y < sym1.Length; y++)
                {
                    if (path[x] == sym1[y])
                        ok = false;
                }
                if (ok)
                    s.Append(path[x]);
            }
            return s.ToString();
        }
    }
}
