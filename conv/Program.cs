using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace conv
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWnd());
            }
            else
            {

            }
        }
    }
}
