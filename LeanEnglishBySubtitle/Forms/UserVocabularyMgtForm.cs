using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Studyzy.LeanEnglishBySubtitle.EngDict;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle.Forms
{
    public partial class UserVocabularyMgtForm : Form
    {
        public UserVocabularyMgtForm()
        {
            InitializeComponent();
        }
        DbOperator dbOperator=new DbOperator();
        Service service=new Service();
        private DictionaryService dictionaryService = new ModernDictionaryService();
        private void UserVocabularyMgtForm_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            var knowns = dbOperator.FindAll<UserVocabulary>(v => v.KnownStatus == KnownStatus.Known).Select(v => v.Word).OrderBy(v=>v).ToList();
            cbxKnownList.ClearSelected();
            cbxKnownList.DataSource = knowns;

            var notknown = dbOperator.FindAll<UserVocabulary>(v => v.KnownStatus == KnownStatus.Unknown).Select(v => v.Word).OrderBy(v => v).ToList();
            cbxUnknownList.ClearSelected();
            cbxUnknownList.DataSource = notknown;
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
    }
}
