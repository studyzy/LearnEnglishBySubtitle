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
