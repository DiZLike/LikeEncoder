using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lib
{
    public static class Debug
    {
        public static void Log(string msg)
        {
            try
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "app.log", msg + "\r\n");
            }
            catch { }
        }
    }
}
