using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Studyzy.LeanEnglishBySubtitle.Forms
{
    public partial class NewWordConfirmForm : Form
    {
        public NewWordConfirmForm()
        {
            InitializeComponent();
        }
        private DbOperator dbOperator=new DbOperator();
        public IList<SubtitleWord> DataSource { get; set; } 
      

        private void NewWordConfirmForm_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            foreach (var subtitleWord in DataSource)
            {
                DataGridViewRow row=new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = subtitleWord.IsNewWord;
                row.Cells[1].Value = subtitleWord.Word;
                row.Cells[2].Value = subtitleWord.SubtitleSentence;
                var cbx= row.Cells[3] as DataGridViewComboBoxCell;
                if (subtitleWord.Means.Count == 1)
                {
                    row.Cells.Remove(cbx);
                    DataGridViewTextBoxCell txb=new DataGridViewTextBoxCell();
                    row.Cells.Add(txb);
                    txb.Value = subtitleWord.Means[0];
                }
                foreach (var mean in subtitleWord.Means)
                {
                    cbx.Items.Add(mean);
                }
                cbx.Value = subtitleWord.Means[0];
                dataGridView1.Rows.Add(row);
            }
        }

        public IList<SubtitleWord> SelectedNewWords { get; set; } 
        private void btnOK_Click(object sender, EventArgs e)
        {
            var knownWords = new List<String>();
            var unknownWords = new List<SubtitleWord>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var c1 = row.Cells[0].Value;
                var word = row.Cells[1].Value;
                if (!Convert.ToBoolean(c1))
                {
                  
                    knownWords.Add(word.ToString());
                }
                else
                {
                    var s = DataSource.Where(w => w.Word == word).SingleOrDefault();
                    s.SelectMean = row.Cells[3].Value.ToString();
                    unknownWords.Add(s);
                }
            }
            dbOperator.SaveUserKnownWords(knownWords);
            SelectedNewWords = unknownWords;
            DialogResult=DialogResult.OK;
        }

        private void NewWordConfirmForm_Resize(object sender, EventArgs e)
        {
            var rest= this.Width - 240;
            dataGridView1.Columns[2].Width = rest/2;
            dataGridView1.Columns[3].Width = rest/2;
        }
    }
}
