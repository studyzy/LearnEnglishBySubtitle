using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Studyzy.LearnEnglishBySubtitle.EngDict;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class DictionaryConfigForm : Form
    {
        public DictionaryConfigForm()
        {
            InitializeComponent();
        }

        private void DictionaryConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is RadioButton)
                {
                    var rbtn = control as RadioButton;
                    if (rbtn.Checked)
                    {
                        SelectDictionaryService= GetServiceByName(rbtn.Text);
                    }
                }
            }
            DialogResult=DialogResult.OK;
        }

        public DictionaryService SelectDictionaryService { get; private set; }

        private DictionaryService GetServiceByName(string name)
        {
            //if (name == "牛津高阶英汉双解词典")
            //{
            //    return new OxfordDictionaryService();
            //}
            //if (name == "朗道英汉词典")
            //    return new LangdaoE2CDictionaryService();
            //if (name == "现代英汉综合大辞典")
            //    return new ModernDictionaryService();
            //if (name == "英汉速查词典")
            //    return new QuickE2CDictionaryService();
            if (name == "维科英汉词典")
                return new ViconDictionaryService();
            return null;
        }
    }
}
