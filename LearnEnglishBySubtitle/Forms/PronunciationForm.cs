using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class PronunciationForm : Form
    {
        public PronunciationForm()
        {
            InitializeComponent();
        }

        private void PronunciationForm_Load(object sender, EventArgs e)
        {
            string type = DbOperator.Instance.GetConfigValue("PronunciationType");
            if (type == "UK")
            {
                rbUK.Checked = true;
                rbUS.Checked = false;
            }
            else
            {
                rbUK.Checked = false;
                rbUS.Checked = true;
            }
            bool download = Convert.ToBoolean(DbOperator.Instance.GetConfigValue("PronunciationDownload"));
            cbxDownload.Checked = download;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DbOperator.Instance.SetConfigValue("PronunciationType",rbUK.Checked?"UK":"US");
            DbOperator.Instance.SetConfigValue("PronunciationDownload",cbxDownload.Checked.ToString());
            DialogResult= DialogResult.OK;
        }
    }
}
