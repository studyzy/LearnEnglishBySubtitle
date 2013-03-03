using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Studyzy.LeanEnglishBySubtitle.Helpers;
using Studyzy.LeanEnglishBySubtitle.Subtitle;

namespace Studyzy.LeanEnglishBySubtitle.Forms
{
    public partial class RemoveChineseSubtitleForm : Form
    {
        public RemoveChineseSubtitleForm()
        {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFilePath.Text = String.Join(" | ", openFileDialog1.FileNames);
            }
        }

        private Dictionary<string, IList<SrtFormat>> SubtitleFiles = new Dictionary<string, IList<SrtFormat>>();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            var filePaths = txbFilePath.Text.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            SubtitleFiles.Clear();
            foreach (var filePath in filePaths)
            {
                var content = FileOperationHelper.ReadFile(filePath);
                var srts = SrtOperator.Parse(content);
                var newSrts = new List<SrtFormat>();
                for (int i=0;i< srts.Count;i++)
                {
                    var srtFormat = srts[i];
                    var lines = srtFormat.Text.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                    IList<string> newLines = new List<string>();
                    foreach (var line in lines)
                    {
                        if(!StringHelper.IsChinese(line))
                        {
                            newLines.Add(line);
                        }
                    }
                    if(newLines.Count>0)
                    {
                        srtFormat.Text = string.Join("\r\n", newLines.ToArray());
                    }
                    else
                    {
                        srtFormat.Text = " ";
                    }
                    newSrts.Add(srtFormat);
                }
                SubtitleFiles.Add(filePath, newSrts);
            }
            richTextBox1.Clear();
            foreach (var subtitleFile in SubtitleFiles)
            {
                richTextBox1.AppendText("----"+subtitleFile.Key+"----\r\n");
                richTextBox1.AppendText(SrtOperator.SrtFormat2String(subtitleFile.Value));
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var subtitleFile in SubtitleFiles)
            {
                File.Copy(subtitleFile.Key,subtitleFile.Key+".bak");
                FileOperationHelper.WriteFile(subtitleFile.Key, Encoding.UTF8,
                                              SrtOperator.SrtFormat2String(subtitleFile.Value));
            }
            MessageBox.Show("完成");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
