using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sun.corba.se.impl.oa.poa;
using Studyzy.LearnEnglishBySubtitle.EngDict;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using log4net;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class UserVocabularyMgtForm : Form
    {
        private ILog logger = LogManager.GetLogger(typeof(UserVocabularyMgtForm));
        public UserVocabularyMgtForm()
        {
            InitializeComponent();
        }
        private DbOperator dbOperator = DbOperator.Instance;
        Service service=new Service();
        //private DictionaryService dictionaryService = new ViconDictionaryService();
        private void UserVocabularyMgtForm_Load(object sender, EventArgs e)
        {
            BindList();
            this.Activate();
        }

        private void BindList()
        {
            logger.Debug("Begin Load Know Words");
            var knowns =
                dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known)
                .Select(w=>new VUserWord(w))
                .OrderBy(v => v.Word).ToList();
            //dgvKnownWords.Rows.Clear();
            dgvKnownWords.AutoGenerateColumns = false;
            dgvKnownWords.DataSource = knowns;

            logger.Debug("Finish Load Know Words");
            logger.Debug("Begin Load Unknown Words");
            var notknown =
                dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Unknown)
                 .Select(w => new VUserWord(w))
                    .OrderBy(v => v.Word)
                    .ToList();
            //dgvUnknownWords.Rows.Clear();
            dgvUnknownWords.AutoGenerateColumns = false;
            //cbxUnknownList.ClearSelected();
            dgvUnknownWords.DataSource = notknown;
            logger.Debug("Finish Load Unknown Words");
        }



        //private void cbxUnknownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbxUnknownList.SelectedValue == null)
        //    {
        //        return;
        //    }
        //    var word = cbxUnknownList.SelectedValue.ToString();
        //    var d = dictionaryService.GetChineseMeanInDict(word);
        //    if (d != null)
        //    {
        //        var mean = string.Join("\r\n", d.Means);
        //        this.toolTip1.SetToolTip(this.cbxUnknownList, mean);
        //    }
        //}

        //private void cbxKnownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbxKnownList.SelectedValue == null)
        //    {
        //        return;
        //    }
        //    var word = cbxKnownList.SelectedValue.ToString();
        //    var d = dictionaryService.GetChineseMeanInDict(word);
        //    if (d != null)
        //    {
        //        var mean = string.Join("\r\n", d.Means);
        //        this.toolTip1.SetToolTip(this.cbxKnownList, mean);
        //    }
        //}

        private void btnAddKnownWords_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (var word in rtbKnownWords.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var uword = service.GetUserWord(word);
                if (uword == null||uword.KnownStatus==KnownStatus.Unknown)
                {
                    vocabulary.Add(new Vocabulary() {Word = word, IsKnown = true});
                }
                
            }

            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
            rtbKnownWords.Clear();
        }

        private void btnAddNewWords_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (var word in rtbKnownWords.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var uword = service.GetUserWord(word);
                if (uword == null||uword.KnownStatus==KnownStatus.Known)
                {
                    vocabulary.Add(new Vocabulary() { Word = word, IsKnown = false });
                }
            }

            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
            rtbKnownWords.Clear();
        }

        private void btnExportKnownWords_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var rows = dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known);
                StringBuilder sb=new StringBuilder();
                foreach (var row in rows)
                {
                    sb.Append(row.Word+"\r\n");
                }
                FileOperationHelper.WriteFile(saveFileDialog1.FileName, Encoding.UTF8, sb.ToString());
                MessageBox.Show("导出完成");
            }
        }

        private void btnExportUnknownWords_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var rows = dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Unknown);
                StringBuilder sb = new StringBuilder();
                foreach (var row in rows)
                {
                    sb.Append(row.Word + "\r\n");
                }
                FileOperationHelper.WriteFile(saveFileDialog1.FileName, Encoding.UTF8, sb.ToString());
                MessageBox.Show("导出完成");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txbWordQueryInput.Text;
            var result = dbOperator.FindAllUserVocabulary(v => v.Word==keyword);
            var subs = dbOperator.FindSubtitleWords(keyword);
            var list = new List<VUserWord>();
            foreach (var userVocabulary in result)
            {
                var row = new VUserWord(userVocabulary);
                var engDic = Global.DictionaryService.GetChineseMeanInDict(userVocabulary.Word);
                if (engDic != null && engDic.Means.Count>0)
                {
                    row.Meaning = engDic.Means[0].Mean;
                }
                list.Add(row);
            }
            foreach (var subtitleNewWord in subs)
            {
                VUserWord v=new VUserWord();
                v.Word = subtitleNewWord.Word;
                v.Source = subtitleNewWord.SubtitleName;
                v.IsNewWord = (subtitleNewWord.KnownStatus == KnownStatus.Unknown?"是":"否");
                v.Sentence = subtitleNewWord.Sentence;
                list.Add(v);
            }
   
            dgvQueryResult.DataSource = list;
            
        }

        private void add2UnknownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (DataGridViewRow row in dgvKnownWords.SelectedRows)
            {
                var word = row.Cells[0].Value.ToString();
                vocabulary.Add(new Vocabulary() { Word = word, IsKnown = false });
            }

            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
        }

        private void move2KnownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (DataGridViewRow row in dgvUnknownWords.SelectedRows)
            {
                var word = row.Cells[0].Value.ToString();
                vocabulary.Add(new Vocabulary() { Word = word, IsKnown = true });
            }
            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
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
            }
            Source = v.Source;
            Sentence = v.Sentence;
            IsNewWord = v.KnownStatus == KnownStatus.Unknown ? "是" : "否";
        }

        public string Meaning { get; set; }
        public string IsNewWord { get; set; }
        public string Word { get; set; }
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
