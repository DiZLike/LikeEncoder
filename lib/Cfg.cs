using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lib
{
    public class Cfg
    {
        private string file;
        private string badeDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";
        private List<string> all = new List<string>();

        public Cfg(string file)
        {
            this.file = file;
        }

        public string Read(string key)
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
            return String.Empty;
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
    }
}
