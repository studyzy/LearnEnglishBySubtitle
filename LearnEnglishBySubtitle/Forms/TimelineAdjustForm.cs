using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using Studyzy.LearnEnglishBySubtitle.Subtitles;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class TimelineAdjustForm : Form
    {
        public TimelineAdjustForm()
        {
            InitializeComponent();
        }

        private ISubtitleOperator stOperator;
        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFilePath.Text = String.Join(" | ", openFileDialog1.FileNames);
            }
        }

        private Dictionary<string, Subtitle> SubtitleFiles = new Dictionary<string, Subtitle>();
        private void btnPreview_Click(object sender, EventArgs e)
        {
            var filePaths = txbFilePath.Text.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            if (filePaths.Length == 0)
            {
                MessageBox.Show("未选择字幕文件");
                return;
            }
            SubtitleFiles.Clear();
            
            stOperator = SubtitleHelper.GetOperatorByFileName(filePaths[0]);
            foreach (var filePath in filePaths)
            {
                var content = FileOperationHelper.ReadFile(filePath);
                var srts = stOperator.Parse(content);
                SubtitleFiles.Add(filePath, srts);
            }
            richTextBox1.Clear();
            foreach (var subtitleFile in SubtitleFiles)
            {
                richTextBox1.AppendText("----"+subtitleFile.Key+"----\r\n");
                richTextBox1.AppendText(stOperator.Subtitle2String(subtitleFile.Value));
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var subtitleFile in SubtitleFiles)
            {
                //File.Copy(subtitleFile.Key,subtitleFile.Key+".bak");
                FileOperationHelper.WriteFile(subtitleFile.Key, Encoding.UTF8,
                                              stOperator.Subtitle2String(subtitleFile.Value));
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

            var adjustFiles = new Dictionary<string, Subtitle>();
            foreach (var key in SubtitleFiles.Keys)
            {
                var path = key;
                richTextBox1.AppendText("----" + path + "----\r\n");
                var result = new  Dictionary<int, SubtitleLine>();
                for (int i = 1; i <= SubtitleFiles[key].Bodies.Count; i++)
                {
                    var subtitleLine = SubtitleFiles[key].Bodies[i];
                    subtitleLine.StartTime = subtitleLine.StartTime.AddSeconds((double) numTimelineDelay.Value);
                    subtitleLine.EndTime = subtitleLine.EndTime.AddSeconds((double) numTimelineDelay.Value);
                    result.Add(i,subtitleLine);
                }
                adjustFiles[key].Bodies = result;
                var txt = stOperator.Subtitle2String(adjustFiles[key]);
                richTextBox1.AppendText(txt);
            }
            SubtitleFiles = adjustFiles;
        }

        private void TimelineAdjustForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void TimelineAdjustForm_DragDrop(object sender, DragEventArgs e)
        {
            var array = (Array)e.Data.GetData(DataFormats.FileDrop);
            string files = "";
            foreach (object a in array)
            {
                string path = a.ToString();
                files += path + " | ";
            }
            txbFilePath.Text = files.Remove(files.Length - 3);
        }
    }
}
