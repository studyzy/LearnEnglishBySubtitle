using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Studyzy.LearnEnglishBySubtitle.Forms;
using log4net.Config;

namespace Studyzy.LearnEnglishBySubtitle
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
            if (string.IsNullOrEmpty(RegistryHelper.GetRegistData("Used")))
            {
                MessageBox.Show("这是您第一次运行改程序，请先设置","词库设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
                var diag = new UserVocabularyConfigForm();
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());    
                }
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
