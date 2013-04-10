using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Studyzy.LeanEnglishBySubtitle.Entities;

namespace Studyzy.LeanEnglishBySubtitle.Forms
{
    public partial class UserVocabularyConfigForm : Form
    {
        public UserVocabularyConfigForm()
        {
            InitializeComponent();
        }

        private void UserVocabularyConfigForm_Load(object sender, EventArgs e)
        {
            string remark =
                "柯林斯词典给我们提供了一个很好的背单词方法，他一共包含33320个单词和词组，按照词频分为六级，5级词汇包含1342个词，最常用的也是最简单的，然后4级1388个，3级1831个，2级3407个，1级8228个，0级包含17124个\r\n注意：0级是最难最不常用的，5级是最常用的！！";
            richTextBox1.Text = remark;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DbOperator dbOperator=new DbOperator();
            var words = dbOperator.FindAll<VocabularyRank>(v => v.RankValue >= numUserVocabularyRank.Value);
            Service service=new Service();
            var vocabulary = new List<Vocabulary>();
            foreach (var vocabularyRank in words)
            {
               vocabulary.Add(new Vocabulary(){Word = vocabularyRank.Word,IsKnown = true});
            }
            service.SaveUserVocabulary(vocabulary,"柯林斯词频分级");
            MessageBox.Show("用户词频设置保存成功");
            this.Close();
        }
    }
}
