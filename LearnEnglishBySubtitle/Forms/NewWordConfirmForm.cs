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
                //row.Cells[1].Value = subtitleWord.IsNewWord;
                row.Cells[2].Value = subtitleWord.Word;
                row.Cells[3].Value = subtitleWord.ShowCount;
                row.Cells[4].Value = subtitleWord.SubtitleSentence;
                var cbx = row.Cells[5] as DataGridViewComboBoxCell;
                if (subtitleWord.Means.Count == 1)
                {
                    row.Cells.Remove(cbx);
                    DataGridViewTextBoxCell txb = new DataGridViewTextBoxCell();
                    row.Cells.Insert(5,txb);
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
            Splash.Show();
            //var knownWords = new List<String>();
            var words = new List<SubtitleWord>();
            Splash.Status = "读取用户选择...";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var c1 = Convert.ToBoolean(row.Cells[1].Value);
                var c2 = row.Cells[2].Value;
                var word = DataSource.Where(w => w.Word == c2).SingleOrDefault();
                word.IsNewWord = c1;

                var userMean = row.Cells[6].Value;
                if (userMean == null || userMean.ToString().Trim() == String.Empty)
                {
                    word.SelectMean = row.Cells[5].Value.ToString();
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
            var rest= this.Width - 300;
            dataGridView1.Columns[4].Width = rest/2;
            dataGridView1.Columns[5].Width = rest/2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            this.Close();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string w = dataGridView1.Rows[e.RowIndex].Cells["Word"].Value.ToString();
                dbOperator.AddIgnoreWord(w);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex == 1) //已经记住该单词
            {
                string word = dataGridView1.Rows[e.RowIndex].Cells["Word"].Value.ToString();
                string sentence = dataGridView1.Rows[e.RowIndex].Cells["SubtitleSentence"].Value.ToString();
                //var subtitleName = Path.GetFileNameWithoutExtension(SubtitleFileName);
                var userVo = dbOperator.GetUserWord(word);
                if (userVo == null)
                {
                    userVo = new UserVocabulary()
                    {
                    
                        Word = word,
                        Sentence = sentence,
                        Source = "字幕",
                        CreateTime = DateTime.Now
                   
                    };
                }
                userVo.KnownStatus = KnownStatus.Known;
                userVo.UpdateTime = DateTime.Now;
                dbOperator.SaveUserVocabulary(userVo);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
