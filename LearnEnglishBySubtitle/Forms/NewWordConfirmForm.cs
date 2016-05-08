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
using Studyzy.LearnEnglishBySubtitle.Entities;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class NewWordConfirmForm : Form
    {
        private ILog logger = LogManager.GetLogger(typeof(NewWordConfirmForm));
        public NewWordConfirmForm()
        {
            InitializeComponent();
            NewWordConfirmForm_Resize(null, null);
        }
        private DbOperator dbOperator = DbOperator.Instance;
        public IList<SubtitleWord> DataSource { get; set; }
        public string SubtitleFileName { get; set; }

        public delegate void ProcessNewWords(IList<SubtitleWord> words);

        public event ProcessNewWords OnClickOkButton;
        private void NewWordConfirmForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            foreach (var subtitleWord in DataSource)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                var btn = row.Cells[0] as DataGridViewButtonCell;
                btn.Value = "X";
                var btn1 = row.Cells[1] as DataGridViewButtonCell;
                btn1.Value = "记住";
                var btn2 = row.Cells[2] as DataGridViewButtonCell;
                btn2.Value = subtitleWord.IsStar? "★": "☆";
                //row.Cells[1].Value = subtitleWord.IsNewWord;
                row.Cells[3].Value = subtitleWord.Word;
                row.Cells[4].Value = subtitleWord.ShowCount;
                row.Cells[5].Value = subtitleWord.SubtitleSentence;
                var cbx = row.Cells[6] as DataGridViewComboBoxCell;
                if (subtitleWord.Means.Count == 1)
                {
                    row.Cells.Remove(cbx);
                    DataGridViewTextBoxCell txb = new DataGridViewTextBoxCell();
                    row.Cells.Insert(6,txb);
                    txb.ReadOnly = true;
                    txb.Value = subtitleWord.Means[0];
                }
                else if (subtitleWord.Means.Count == 0)
                {
                    logger.Error("can not find the meaning of word '" + subtitleWord.Word + "'");
                    continue;
                }
                else
                {
                    foreach (var mean in subtitleWord.Means)
                    {
                        cbx.Items.Add(mean.ToString());
                    }
                    if (string.IsNullOrEmpty(subtitleWord.SelectMean))//系统找不到默认意思，就用第一个意思
                    {
                        cbx.Value = subtitleWord.Means[0].ToString();
                    }
                    else
                    {
                        cbx.Value = subtitleWord.SelectMean;
                    }
                    cbx.ValueType = typeof (string);
                }
               
                dataGridView1.Rows.Add(row);
            }
        }

        public IList<SubtitleWord> SelectedNewWords { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Splash.Show("读取用户选择...");
            //var knownWords = new List<String>();
            var words = new List<SubtitleWord>();
          
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //var c1 = Convert.ToBoolean(row.Cells[1].Value);
                var c3 = row.Cells[3].Value;
                var word = DataSource.Where(w => w.Word == c3).SingleOrDefault();
                word.IsNewWord = true;
                word.IsStar = row.Cells[2].Value == "★";
                var userMean = row.Cells[7].Value;
                if (userMean == null || userMean.ToString().Trim() == String.Empty)
                {
                    word.SelectMean = row.Cells[6].Value.ToString();
                }
                else
                {
                    word.SelectMean = userMean.ToString().Trim();
                }
                words.Add(word);

            }
            Splash.Status = "保存单词中...";
            //dbOperator.SaveUserKnownWords(knownWords);
            var subtitleName = Path.GetFileNameWithoutExtension(SubtitleFileName);
            dbOperator.SaveSubtitleNewWords(words, subtitleName);

            SelectedNewWords = words.Where(w=>w.IsNewWord).ToList();
            Splash.Close();

            DialogResult = DialogResult.OK;
            this.Close();
            OnClickOkButton(SelectedNewWords);
        }

        private void NewWordConfirmForm_Resize(object sender, EventArgs e)
        {
            var rest= this.Width - 330;
            dataGridView1.Columns[5].Width = rest/2;
            dataGridView1.Columns[6].Width = rest/2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            this.Close();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string word = null;
            if (e.RowIndex >= 0)
            {
                word= dataGridView1.Rows[e.RowIndex].Cells["Word"].Value.ToString();
            }
            if (e.ColumnIndex == 0)
            {
            
                dbOperator.AddIgnoreWord(word);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex == 1) //已经记住该单词
            {
                string sentence = dataGridView1.Rows[e.RowIndex].Cells["SubtitleSentence"].Value.ToString();
                //var subtitleName = Path.GetFileNameWithoutExtension(SubtitleFileName);
                var userVo = dbOperator.GetUserWord(word);
                if (userVo == null)
                {
                    userVo = new UserVocabulary()
                    {
                    
                        Word = word,
                        Sentence = sentence,
                        Source = this.SubtitleFileName,
                        CreateTime = DateTime.Now
                   
                    };
                }
                userVo.KnownStatus = KnownStatus.Known;
                userVo.UpdateTime = DateTime.Now;
                dbOperator.SaveUserVocabulary(userVo);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            else if (e.ColumnIndex == 2) //IsStar
            {
               var star = dataGridView1.Rows[e.RowIndex].Cells["IsStar"].Value;
                if (star == "☆")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = "★";
                    dbOperator.UpdateStarFlag(word, true);
                }
                else if (star == "★")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = "☆";
                    dbOperator.UpdateStarFlag(word, false);
                }
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //双击单词本身
            {
                string word = dataGridView1.Rows[e.RowIndex].Cells["Word"].Value.ToString();
                PronunciationDownloader.DownloadAndPlay(word);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
