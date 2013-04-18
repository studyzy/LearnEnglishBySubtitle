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
