using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lib
{
    public class Error
    {
        internal static readonly string INIT = "Ошибка инициализации аудиоустройства";
        internal static readonly string ENCODER_STREAM = "Ошибка декодирования аудио";
        internal static readonly string ENCODER_START = "Ошибка конвертирования";

        public string Message { get; set; }
        public IntPtr Handle { get; set; }
        public DateTime Date { get { return DateTime.Now; } }

        public Error(IntPtr handle, string message)
        {
            this.Handle = handle;
            this.Message = message;
        }
    }

}
