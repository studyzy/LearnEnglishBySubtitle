using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Studyzy.LearnEnglishBySubtitle.EngDict;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using log4net;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class UserVocabularyMgtForm : Form
    {
        private ILog logger = LogManager.GetLogger(typeof (UserVocabularyMgtForm));

        public UserVocabularyMgtForm()
        {
            InitializeComponent();
        }

        private DbOperator dbOperator = DbOperator.Instance;
   
        //private DictionaryService dictionaryService = new ViconDictionaryService();
        private void UserVocabularyMgtForm_Load(object sender, EventArgs e)
        {

            BindList();
            backgroundWorker1.RunWorkerAsync();
            this.Activate();
        }

        private void BindList()
        {
            logger.Debug("Begin Load Know Words");
            var knowns =
                dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known)
                    .Select(w => new VUserWord(w))
                    .OrderBy(v => v.Word).ToList();

            dgvKnownWords.AutoGenerateColumns = false;
            dgvKnownWords.DataSource = knowns;
            tabPage1.Text = string.Format("熟悉的单词({0})", knowns.Count);
            //this.toolTip1.SetToolTip(this.tabPage1, "词汇量:"+ knowns.Count.ToString());


            logger.Debug("Finish Load Know Words");
            logger.Debug("Begin Load Unknown Words");
            var notknown =
                dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Unknown)
                    .Select(w => new VUserWord(w))
                   .OrderByDescending(v=>v.IsStar)
                    .ThenBy(v => v.Word)
                    .ToList();
            //dgvUnknownWords.Rows.Clear();
            dgvUnknownWords.AutoGenerateColumns = false;
            //cbxUnknownList.ClearSelected();
            dgvUnknownWords.DataSource = notknown;
            //tabPage2.ToolTipText = notknown.ToString();
            //this.toolTip1.SetToolTip(this.tabPage2, "生词:" + notknown.Count.ToString());
            tabPage2.Text = string.Format("生词本({0})", notknown.Count);
            logger.Debug("Finish Load Unknown Words");
        }



        private void btnAddKnownWords_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (
                var word in rtbKnownWords.Text.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var uword = dbOperator.GetUserWord(word);
                if (uword == null || uword.KnownStatus == KnownStatus.Unknown)
                {
                    vocabulary.Add(new Vocabulary() {Word = word, IsKnown = true});
                }

            }

            dbOperator.SaveUserVocabulary(vocabulary, "手工");
            BindList();
            rtbKnownWords.Clear();
        }

        private void btnAddNewWords_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (
                var word in rtbKnownWords.Text.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                var uword = dbOperator.GetUserWord(word);
                if (uword == null || uword.KnownStatus == KnownStatus.Known)
                {
                    vocabulary.Add(new Vocabulary() {Word = word, IsKnown = false});
                }
            }

            dbOperator.SaveUserVocabulary(vocabulary, "手工");
            BindList();
            rtbKnownWords.Clear();
        }

        private void btnExportKnownWords_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "known.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var rows = dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known)
                    .OrderBy(v => v.Word)
                    .Select(w => w.Word)
                    .ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var row in rows)
                {
                    sb.Append(row + "\r\n");
                }
                FileOperationHelper.WriteFile(saveFileDialog1.FileName, Encoding.UTF8, sb.ToString());
                MessageBox.Show("导出完成");
            }
        }

        private void btnExportUnknownWords_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "unknown.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var rows = dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Unknown)
                    .OrderBy(v=>v.Word).Select(w=>w.Word);
                StringBuilder sb = new StringBuilder();
                foreach (var row in rows)
                {
                    sb.Append(row + "\r\n");
                }
                FileOperationHelper.WriteFile(saveFileDialog1.FileName, Encoding.UTF8, sb.ToString());
                MessageBox.Show("导出完成");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txbWordQueryInput.Text;
            var result = dbOperator.FindAllUserVocabulary(v => v.Word == keyword);
            var subs = dbOperator.FindSubtitleWords(keyword);
            var list = new List<VUserWord>();
            foreach (var userVocabulary in result)
            {
                var row = new VUserWord(userVocabulary);
                var engDic = Global.DictionaryService.GetChineseMeanInDict(userVocabulary.Word);
                if (engDic != null && engDic.Means.Count > 0)
                {
                    row.Meaning = engDic.Means[0].Mean;
                }
                list.Add(row);
            }
            foreach (var subtitleNewWord in subs)
            {
                VUserWord v = new VUserWord();
                v.Word = subtitleNewWord.Word;
                v.Source = subtitleNewWord.SubtitleName;
                v.IsNewWord = (subtitleNewWord.KnownStatus == KnownStatus.Unknown ? "是" : "否");
                v.Sentence = subtitleNewWord.Sentence;
                list.Add(v);
            }
            dgvQueryResult.AutoGenerateColumns = false;
            dgvQueryResult.DataSource = list;

        }

        private void add2UnknownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();

            foreach (DataGridViewRow row in dgvKnownWords.SelectedRows)
            {
                var word = row.Cells[0].Value.ToString();
                vocabulary.Add(new Vocabulary() {Word = word, IsKnown = false});

            }

            dbOperator.SaveUserVocabulary(vocabulary, "手工");

            KeepLocationBind(dgvKnownWords);


        }
    

    private void KeepLocationBind(DataGridView dgv)
        {
            int idx = 0;
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
             idx = row.Index;
            }
            int firstIndex = dgv.FirstDisplayedScrollingRowIndex;
            BindList();
            if (idx >= dgv.RowCount)
            {
                idx = dgv.RowCount - 1;
            }
            var currentRow = dgv.Rows[idx];
            dgv.FirstDisplayedScrollingRowIndex = firstIndex;
            dgv.CurrentCell = currentRow.Cells[0];
        }

        private void move2KnownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (DataGridViewRow row in dgvUnknownWords.SelectedRows)
            {
                var word = row.Cells[1].Value.ToString();
                vocabulary.Add(new Vocabulary() { Word = word, IsKnown = true });
            }
            dbOperator.SaveUserVocabulary(vocabulary, "手工");
            KeepLocationBind(dgvUnknownWords);
        }

        private void btnCleanAll_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("确认要清空所有认识和不认识的单词所有记录？", "确认清空?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if(
                    MessageBox.Show("确认要清空所有认识和不认识的单词所有记录？此操作不可逆，别后悔哦！", "再次确认清空?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
                {
                    dbOperator.ClearUserVocabulary();
                    BindList();
                    MessageBox.Show("已清空，请点击设置词汇量进行重新设置");
                }
            }
        }

        private void txbWordQueryInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
            }
        }

        private void deleteKnownWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvKnownWords.SelectedRows)
            {
                var word = row.Cells[0].Value.ToString();
                dbOperator.DeleteUserVocabulary(word);
                dbOperator.AddIgnoreWord(word);
            }
            KeepLocationBind(dgvKnownWords);
        }

        private void SoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvKnownWords.SelectedRows)
            {
                var word = row.Cells[0].Value.ToString();
                PronunciationDownloader.DownloadAndPlay(word);
            }

        }

        private void dgvKnownWords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string word = dgvKnownWords.Rows[e.RowIndex].Cells[0].Value.ToString();
                PronunciationDownloader.DownloadAndPlay(word);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PronunciationDownloader.DownloadPronunciation();
        }

        private void RemoveWordFromUnknowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUnknownWords.SelectedRows)
            {
                var word = row.Cells[1].Value.ToString();
                dbOperator.DeleteUserVocabulary(word);
                dbOperator.AddIgnoreWord(word);
            }
            KeepLocationBind(dgvUnknownWords);
        }

        private void PronunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUnknownWords.SelectedRows)
            {
                var word = row.Cells[0].Value.ToString();
                PronunciationDownloader.DownloadAndPlay(word);
            }
        }

        private void dgvUnknownWords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string word = dgvUnknownWords.Rows[e.RowIndex].Cells[1].Value.ToString();
                string star = dgvUnknownWords.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (star == "☆")
                {
                    dgvUnknownWords.Rows[e.RowIndex].Cells[0].Value = "★";
                    dbOperator.UpdateStarFlag(word,true);
                }
                else if (star == "★")
                {
                    dgvUnknownWords.Rows[e.RowIndex].Cells[0].Value = "☆";
                    dbOperator.UpdateStarFlag(word, false);
                }
            }
        }

        private const int RollWidth = 22;
        private void dgvKnownWords_Resize(object sender, EventArgs e)
        {
            int otherWidth = dgvKnownWords.Columns[0].Width + dgvKnownWords.Columns[1].Width +
                            dgvKnownWords.Columns[2].Width + dgvKnownWords.Columns[4].Width;
            dgvKnownWords.Columns[3].Width = dgvKnownWords.Width - otherWidth - RollWidth;
        }

        private void dgvUnknownWords_Resize(object sender, EventArgs e)
        {
            int otherWidth = dgvUnknownWords.Columns[0].Width + dgvUnknownWords.Columns[1].Width +
                          dgvUnknownWords.Columns[2].Width +dgvUnknownWords.Columns[3].Width + dgvUnknownWords.Columns[5].Width;
            dgvUnknownWords.Columns[4].Width = dgvUnknownWords.Width - otherWidth - RollWidth;
        }

        private void dgvQueryResult_Resize(object sender, EventArgs e)
        {
            int otherWidth = dgvQueryResult.Columns[0].Width + dgvQueryResult.Columns[1].Width +
                            dgvQueryResult.Columns[2].Width + dgvQueryResult.Columns[3].Width+ dgvQueryResult.Columns[5].Width;
            dgvQueryResult.Columns[4].Width = dgvQueryResult.Width - otherWidth - RollWidth;
        }

        private void dgvUnknownWords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string word = dgvUnknownWords.Rows[e.RowIndex].Cells[1].Value.ToString();
                PronunciationDownloader.DownloadAndPlay(word);
            }
            catch (Exception ex)
            {

            }
        }

    }

    public class VUserWord
    {
        public VUserWord()
        {
            
        }

        public VUserWord(UserVocabulary v)
        {
            Word = v.Word;
            CreateTime = v.CreateTime;
            UpdateTime = v.UpdateTime;
            var m = Global.DictionaryService.GetChineseMeanInDict(v.Word);
            if (m != null)
            {
                Meaning = m.GetAllMeans();
                PhoneticSymbols = m.PhoneticSymbols;
            }
            Source = v.Source;
            
            Sentence = v.Sentence;
            IsNewWord = v.KnownStatus == KnownStatus.Unknown ? "是" : "否";
            IsStar = v.IsStar ? "★" : "☆";
        }

        public string Meaning { get; set; }
        public string IsNewWord { get; set; }
        public string Word { get; set; }
        public string IsStar { get; set; }

        public string PhoneticSymbols { get; set; }
        /// <summary>
        /// 我是否已经知道这个词汇
        /// </summary>
        public KnownStatus KnownStatus { get; set; }
        /// <summary>
        /// 这个状态是从哪个系统得知的
        /// </summary>
        public string Source { get; set; }
        public string Sentence { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
