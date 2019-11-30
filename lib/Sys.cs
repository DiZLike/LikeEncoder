using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace lib
{
    public static class Sys
    {
        public static double MemoryUsege()
        {
            return Math.Round((float)Process.GetCurrentProcess().WorkingSet64 / 1024f / 1024f, 1);
        }
    }
}
