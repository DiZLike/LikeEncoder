using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lib
{
    public class Cfg
    {
        public static string ENC_CFG = @"enc\enc.cfg";
        public static string APP_CFG = @"app.cfg";
        public static string PARAM_TXT = @"enc\param.txt";

        private string file;
        private string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";
        private List<string> all = new List<string>();

        public Cfg(string file)
        {
            this.file = baseDirectory + file;
        }
        public string Read(string key, string def)
        {
            if (File.Exists(file))
                all = File.ReadAllLines(file).ToList();
            foreach (var item in all)
            {
                if (key.Length >= item.Length)
                    continue;
                var it = item.Remove(key.Length);
                if (it != key) continue;
                var result = item.Remove(0, key.Length + 1);
                return result;
            }
            return def;
        }
        public string Read(string key)
        {
            return Read(key, String.Empty);
        }
        public int ReadInt(string key)
        {
            return Read(key).ToInt();
        }
        public int ReadInt(string key, int def)
        {
            return Read(key, def.ToString()).ToInt();
        }
        public bool ReadBool(string key)
        {
            return Read(key).ToBool();
        }
        public void Write(string key, object value)
        {
            if (File.Exists(file))
                all = File.ReadAllLines(file).ToList();
            for (int i = 0; i < all.Count; i++)
            {
                if (key.Length >= all[i].Length)
                    continue;
                var itKey = all[i].Remove(key.Length);
                if (itKey != key) continue;
                all[i] = key + "=" + value;
                File.WriteAllLines(file, all.ToArray());
                return;
            }
            all.Add(key + "=" + value);
            File.WriteAllLines(file, all.ToArray());
        }
        public void Write(string key, Enum value)
        {
            Write(key, (int)Enum.Parse(value.GetType(), value.ToString()));
        }
    }
}
