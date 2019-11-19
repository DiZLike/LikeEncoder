using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using tagslib.Tags.Opus;

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
                string testFile = @"Y:\Музыка\Eskimo Callboy\2012 - Bury Me In Vegas\04 - Is Anyone Up.opus";
                testFile = @"Y:\Музыка\Alive In Barcelona\2019 - Alive in Barcelona\02 - Know My Name.opus";
                OpusFile opus = new OpusFile(testFile);
            }
        }
    }
}
