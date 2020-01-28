using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib
{
    public class Warning
    {
        public static readonly string DYCOMP = "Включена динамическая компрессия (DYCOMP). Продолжить?";

        public string Message { get; set; }
        public IntPtr Handle { get; set; }
        public DateTime Date { get { return DateTime.Now; } }

        public Warning(IntPtr handle, string message)
        {
            this.Handle = handle;
            this.Message = message;
        }
    }
}
