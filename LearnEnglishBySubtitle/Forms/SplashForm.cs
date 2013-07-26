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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        public string StatusInfo
        {
            get { return label1.Text; }
            set
            {
                if (label1.InvokeRequired)
                {
                    Action<string> del = delegate(string msg)
                                             {
                                                 label1.Text = msg;
                                             };
                    label1.Invoke(del, value);
                }
                else
                {
                    label1.Text = value;
                }
            }
        }
    }
}
