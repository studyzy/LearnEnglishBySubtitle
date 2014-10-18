using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        private DictionaryService dictionaryService = new ViconDictionaryService();
        private void UserVocabularyMgtForm_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            logger.Debug("Begin Load Know Words");
            var knowns = dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known).Select(v => v.Word).OrderBy(v=>v).ToList();
            cbxKnownList.ClearSelected();
            cbxKnownList.DataSource = knowns;
            logger.Debug("Finish Load Know Words");
            logger.Debug("Begin Load Unknown Words");
            var notknown = dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Unknown).Select(v => v.Word).OrderBy(v => v).ToList();
            cbxUnknownList.ClearSelected();
            cbxUnknownList.DataSource = notknown;
            logger.Debug("Finish Load Unknown Words");
        }

        private void btnToUnknown_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (var item in cbxKnownList.CheckedItems)
            {
                var word = item.ToString();
                vocabulary.Add(new Vocabulary(){Word = word,IsKnown = false});
            }

            service.SaveUserVocabulary(vocabulary,"手工");
            BindList();
        }

        private void btnSetThemKnown_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (var item in cbxUnknownList.CheckedItems)
            {
                var word = item.ToString();
                vocabulary.Add(new Vocabulary() { Word = word, IsKnown = true });
            }

            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
        }

        private void cbxUnknownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUnknownList.SelectedValue == null)
            {
                return;
            }
            var word = cbxUnknownList.SelectedValue.ToString();
            var d = dictionaryService.GetChineseMeanInDict(word);
            if (d != null)
            {
                var mean = string.Join("\r\n", d.Means);
                this.toolTip1.SetToolTip(this.cbxUnknownList, mean);
            }
        }

        private void cbxKnownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKnownList.SelectedValue == null)
            {
                return;
            }
            var word = cbxKnownList.SelectedValue.ToString();
            var d = dictionaryService.GetChineseMeanInDict(word);
            if (d != null)
            {
                var mean = string.Join("\r\n", d.Means);
                this.toolTip1.SetToolTip(this.cbxKnownList, mean);
            }
        }

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
            var list = new List<VUserWord>();
            foreach (var userVocabulary in result)
            {
                var row = new VUserWord(userVocabulary);
                var engDic = dictionaryService.GetChineseMeanInDict(userVocabulary.Word);
                if (engDic != null && engDic.Means.Count>0)
                {
                    row.Meaning = engDic.Means[0].Mean;
                }
                list.Add(row);
            }
            dataGridWordQuery.DataSource = list;
            
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
            Source = v.Source;
            IsNewWord=v.KnownStatus== KnownStatus.Unknown?"是":"否";
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

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
