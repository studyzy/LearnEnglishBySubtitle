using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using Studyzy.LeanEnglishBySubtitle.Helpers;
using Studyzy.LeanEnglishBySubtitle.Subtitle;
using Studyzy.LeanEnglishBySubtitle.UserData;

namespace Studyzy.LeanEnglishBySubtitle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbSubtitleFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            SrtOperator sboperator=new SrtOperator();
            var txt = FileOperationHelper.ReadFile(txbSubtitleFilePath.Text);
            var srts = sboperator.Parse(txt);
            foreach (var srtFormat in srts)
            {
                richTextBox1.AppendText(srtFormat.Text+"----------\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDictionaryForm form1=new FillDictionaryForm();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var desc= dbOperator.GetDecription(txbSubtitleFilePath.Text);
            var list = StringHelper.GetCoreDescriptions(desc);
            richTextBox1.Text = string.Join("\r\n",list);
        }
        DbOperator dbOperator=new DbOperator();
        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }

        private void btnSyncNewWords_Click(object sender, EventArgs e)
        {
            var list= HujiangWebService.GetUserItems(11009764, Convert.ToDateTime("2000-1-1"));

            richTextBox1.Text = string.Join("\r\n", list);


        }
    }
}
