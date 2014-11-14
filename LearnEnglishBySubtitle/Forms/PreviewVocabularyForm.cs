using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using Studyzy.LearnEnglishBySubtitle.Subtitles;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class PreviewVocabularyForm : Form
    {
        private static ILog logger = LogManager.GetLogger(typeof (PreviewVocabularyForm));
        public PreviewVocabularyForm()
        {
            InitializeComponent();
        }

        private void btnPickupNewWords_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            List<string> sentences=new List<string>();

            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                string filePath = fileInfo.FullName;
                var txt = FileOperationHelper.ReadFile(filePath);
                var stOperator = SubtitleHelper.GetOperatorByFileName(filePath);
                var srts = stOperator.Parse(txt);

                srts = stOperator.RemoveChinese(srts);
                sentences.AddRange(srts.Bodies.Values.Select(l => l.EnglishText));
            }

            Splash.Show();
            Splash.Status = "解析字幕中...";
            IDictionary<string,VPreviewWord> previewWords=new Dictionary<string, VPreviewWord>();
            foreach (var sentence in sentences)
            {
                var newWords = SentenceParse.Instance.Pickup(sentence);
                foreach (KeyValuePair<string, string> keyValuePair in newWords)
                {
                    string original = keyValuePair.Key;
                    string word = keyValuePair.Value;
                    if (previewWords.ContainsKey(original))
                    {
                        previewWords[original].Rank++;
                    }
                    else
                    {
                        var mean = SentenceParse.Instance.RemarkWord(sentence, word, original);
                        if (mean != null)
                        {


                            var wd = new VPreviewWord()
                            {
                                Word = mean.Word,
                                Rank = 1,
                                Sentence = sentence,
                                Mean =
                                    mean.DefaultMean == null ? mean.Means[0].ToString() : mean.DefaultMean.ToString()
                            };
                            previewWords.Add(original, wd);
                        }
                    }
                }
            }
            DisplayPreviewWords(previewWords.Values);

            Splash.Close();
        }

        private void DisplayPreviewWords(ICollection<VPreviewWord> words)
        {
            var newResult = words.Where(r=>r.Rank>1).OrderByDescending(w => w.Rank).ThenBy(w=>w.Word);
            this.dataGridView1.Rows.Clear();
            foreach (var subtitleWord in newResult)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                var btn = row.Cells[0] as DataGridViewButtonCell;
                btn.Value = "X";
                row.Cells[1].Value = true;
                row.Cells[2].Value = subtitleWord.Word;
                row.Cells[3].Value = subtitleWord.Rank;
                row.Cells[4].Value = subtitleWord.Sentence;
                row.Cells[5].Value = subtitleWord.Mean;

                dataGridView1.Rows.Add(row);
            }
        }
    }

    public class VPreviewWord
    {
        public string Word { get; set; }
        public string Sentence { get; set; }
        public string Mean { get; set; }
        public int Rank { get; set; }
    }
}
