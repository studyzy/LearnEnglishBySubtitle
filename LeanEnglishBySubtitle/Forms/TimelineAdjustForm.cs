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
    public partial class TimelineAdjustForm : Form
    {
        public TimelineAdjustForm()
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
                SubtitleFiles.Add(filePath, srts);
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
                //File.Copy(subtitleFile.Key,subtitleFile.Key+".bak");
                FileOperationHelper.WriteFile(subtitleFile.Key, Encoding.UTF8,
                                              SrtOperator.SrtFormat2String(subtitleFile.Value));
            }
            MessageBox.Show("完成");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var adjustFiles = new Dictionary<string, IList<SrtFormat>>();
            foreach (var key in SubtitleFiles.Keys)
            {
                var path = key;
                richTextBox1.AppendText("----" + path + "----\r\n");
                IList<SrtFormat> result = new List<SrtFormat>();
                for (int i = 0; i < SubtitleFiles[key].Count; i++)
                {
                    var srtFormat = SubtitleFiles[key][i];
                    srtFormat.StartTime = srtFormat.StartTime.AddSeconds((double) numTimelineDelay.Value);
                    srtFormat.EndTime = srtFormat.EndTime.AddSeconds((double) numTimelineDelay.Value);
                    result.Add(srtFormat);
                }
                adjustFiles[key] = result;
                var txt = SrtOperator.SrtFormat2String(result);
                richTextBox1.AppendText(txt);
            }
            SubtitleFiles = adjustFiles;
        }
    }
}
