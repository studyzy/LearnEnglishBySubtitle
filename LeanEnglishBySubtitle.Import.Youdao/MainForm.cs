using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Studyzy.LeanEnglishBySubtitle;

namespace LeanEnglishBySubtitle.Import.Youdao
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var list = XmlParseHelper.Parse(txbFilePath.Text);
            var result = new List<Vocabulary>();
            foreach (var str in list)
            {
                result.Add(new Vocabulary(){Word = str,IsKnown = false});
            }
            Service service=new Service();
            service.SaveUserVocabulary(result,"有道词典");
        }


    }
}
