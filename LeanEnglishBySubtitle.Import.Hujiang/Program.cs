using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Studyzy.LeanEnglishBySubtitle.Import.Hujiang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            Application.Run(new MainForm());
#else
            Application.Run(new MainForm());
#endif

        }
    }
}
