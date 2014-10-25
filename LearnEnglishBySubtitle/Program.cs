using System;
using System.Collections.Generic;
using System.IO;
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


            var dbPath = "UserVocabulary.db3";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(dbPath))
            {
                var s= File.Create(dbPath);
                s.Close();
                DbOperator.Instance.InitDatabase();
                MessageBox.Show("这是您第一次运行本程序，请先设置词汇量","词库设置",MessageBoxButtons.OK,MessageBoxIcon.Information);
                var diag = new UserVocabularyConfigForm();
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());    
                }
                else
                {
                    File.Delete(dbPath);
                }
            }
            else
            {
                Application.Run(new SentenceTranForm());
            }
        }
    }
}
