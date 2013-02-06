using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Studyzy.LeanEnglishBySubtitle.EngDict;


namespace Studyzy.LeanEnglishBySubtitle
{
    public partial class FillDictionaryForm : Form
    {
        public FillDictionaryForm()
        {
            InitializeComponent();
        }

        private void btnSelectLd2File_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbLd2File.Text = openFileDialog1.FileName;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            LingoesLd2 ld2 = new LingoesLd2();
            ld2.IncludeMeaning = true;
            ld2.XmlEncoding = Encoding.Unicode;
            var dicts = ld2.Parse(txbLd2File.Text);
            DbOperator dbOperator = new DbOperator();
       
            dbOperator.BeginTran();
            foreach (var dict in dicts)
            {
                dbOperator.InsertEngDictionary(dict.Key, dict.Value);
            }
            dbOperator.Commit();
       
        }
    }
}
