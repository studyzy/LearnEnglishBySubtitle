using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Studyzy.LeanEnglishBySubtitle.Forms;

namespace LeanEnglishBySubtitle.Import.BingDict
{
    public class MainForm:ImportForm
    {
        public MainForm()
        {
            this.Text = "必应词典数据导入";
            this.openFileDialog1.Filter = "必应词典导出文件|*.xml";
            this.richTextBox1.Text =
@"在PC版的微软必应词典中，单击“应用”选项卡，选择“必应生词本”
在弹出的生词本窗口中，单击右上角的“导出”按钮，即可将必应生词本导出成xml文件，保存到硬盘上。
然后单击本程序的...按钮，选择该xml文件，然后单击“导入”按钮，即可完成必应生词本导入。";
        }

    }
}
