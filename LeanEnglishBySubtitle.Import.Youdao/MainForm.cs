using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle;
using Studyzy.LeanEnglishBySubtitle.Forms;

namespace LeanEnglishBySubtitle.Import.Youdao
{
    class MainForm:ImportForm
    {
        public MainForm()
        {
            this.Text = "有道词典生词本导入";
            this.richTextBox1.Text =
                @"在PC版的有道词典中打开单词本窗口，然后切换到“浏览”选项卡，该选项卡中列出了所有之间记录的单词。
单击“管理”菜单下的“导出”选项，选择要导出的分类，
然后单击“导出...”按钮，选择保存类型为“有道单词本格式，可用于导入（*.xml）选项，然后保存单本地磁盘。
单击右上角的...按钮，选择该导出的文件，然后单击“导入”按钮，即可将单词导入到本程序中";
        }
        protected override void Import_Click(object sender, EventArgs e)
        {
            var list = XmlParseHelper.Parse(txbFilePath.Text);
            var result = new List<Vocabulary>();
            foreach (var str in list)
            {
                result.Add(new Vocabulary() { Word = str, IsKnown = false });
            }
            Service service = new Service();
            service.SaveUserVocabulary(result, "有道词典");
        }
    }
}
