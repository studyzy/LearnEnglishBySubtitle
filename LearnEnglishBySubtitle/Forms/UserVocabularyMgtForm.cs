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
        private DictionaryService dictionaryService = new ModernDictionaryService();
        private void UserVocabularyMgtForm_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            logger.Debug("Begin Load Know Words");
            var knowns = dbOperator.FindAll<UserVocabulary>(v => v.KnownStatus == KnownStatus.Known).Select(v => v.Word).OrderBy(v=>v).ToList();
            cbxKnownList.ClearSelected();
            cbxKnownList.DataSource = knowns;
            logger.Debug("Finish Load Know Words");
            logger.Debug("Begin Load Unknown Words");
            var notknown = dbOperator.FindAll<UserVocabulary>(v => v.KnownStatus == KnownStatus.Unknown).Select(v => v.Word).OrderBy(v => v).ToList();
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
                if (uword == null)
                {
                    vocabulary.Add(new Vocabulary() {Word = word, IsKnown = true});
                }
            }

            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
        }

        private void btnAddNewWords_Click(object sender, EventArgs e)
        {
            var vocabulary = new List<Vocabulary>();
            foreach (var word in rtbKnownWords.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var uword = service.GetUserWord(word);
                if (uword == null)
                {
                    vocabulary.Add(new Vocabulary() { Word = word, IsKnown = false });
                }
            }

            service.SaveUserVocabulary(vocabulary, "手工");
            BindList();
        }
    }
}
