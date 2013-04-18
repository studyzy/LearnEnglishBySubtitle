using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle;
using Studyzy.LeanEnglishBySubtitle.Forms;

namespace LeanEnglishBySubtitle.Import.Iciba
{
    class MainForm:ImportForm
    {
        public MainForm()
        {
            this.Text = "金山词霸数据导入";
            this.openFileDialog1.Filter = "金山词霸文本导出|*.txt";
            this.richTextBox1.Text =
@"在PC版的金山词霸中，单击右上角的“生词本”按钮，系统将打开生词本窗口，
在弹出的生词本窗口中，单击“生词本管理”按钮，系统将打开生词本管理对话框，
点击“导出”按钮，并选择导出格式为“词霸生词本格式，可用于导入（*.txt）”选项
即可将生词本导出成文本文件，保存到硬盘上。
然后单击本程序的...按钮，选择该txt文件，然后单击“导入”按钮，即可完成必应生词本导入。";
        }
        protected override void Import_Click(object sender, EventArgs e)
        {
            var list = CibaTxtParseHelper.Parse(txbFilePath.Text);
            var result = new List<Vocabulary>();
            foreach (var str in list)
            {
                result.Add(new Vocabulary() { Word = str, IsKnown = false });
            }
            Service service = new Service();
            service.SaveUserVocabulary(result, "金山词霸");
        }
    }
}
