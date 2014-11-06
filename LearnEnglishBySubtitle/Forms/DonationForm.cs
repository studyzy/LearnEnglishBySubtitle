using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using javax.annotation;
using Resources = Studyzy.LearnEnglishBySubtitle.Properties.Resources;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class DonationForm : Form
    {
        public DonationForm()
        {
            InitializeComponent();
        }

        private void DonationForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = Resources.Donate;
        }
    }
}
