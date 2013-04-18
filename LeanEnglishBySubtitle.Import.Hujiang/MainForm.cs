using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Studyzy.LeanEnglishBySubtitle.Import.Hujiang
{
    public partial class MainForm : Form
    {
        private DbOperator dbOperator;
        public MainForm()
        {
            dbOperator = new DbOperator();
            InitializeComponent();
        }

        private void btnSyncNewWords_Click(object sender, EventArgs e)
        {
            var uid = Convert.ToInt32(txbUserId.Text);
            ShowMessage("读取用户生词本...");
            //读取用户不认识的词
            var newWordList = HujiangWebService.GetUserItems(uid, Convert.ToDateTime("2000-1-1"));

            ShowMessage("生词：" + newWordList.Count + "个");
            //dbOperator.SaveUserNewWords(newWordList);
            ShowMessage("读取用户背诵记录...");
            //读取用户背诵过的书和单元，得到用户已认识词列表
            var histories = new Dictionary<int, int>();
            var userBooks = HujiangWebService.GetPublicBooks(uid, "en");
            foreach (var userBook in userBooks)
            {
                var unitId = HujiangWebService.GetUserUnitMax(uid, userBook.BookID);
                if (unitId > 0)
                {
                    richTextBox1.AppendText(userBook.BookName + " UnitId:" + unitId + "\r\n");
                    histories.Add(userBook.BookID, unitId);
                }
            }
            //将用户记录写入数据库
            //dbOperator.SaveUserLearnHistory(histories);
            ShowMessage("统计用户的已知和未知词汇...");
            var list = CalcUserVocabulary(newWordList, histories);
            foreach (var vocabulary in list)
            {
                ShowMessage(vocabulary.ToString());
            }
            ShowMessage("开始同步到本地");
            Service service = new Service();
            service.SaveUserVocabulary(list,"开心词场");
            ShowMessage("同步完成");
        }

        private IList<Vocabulary> CalcUserVocabulary(IList<string> newWords, IDictionary<int, int> histories)
        {
            var result = new Dictionary<string, Vocabulary>();


            //var histories = dbOperator.GetAll<User_LearnHistory>();
            foreach (var history in histories)
            {
                //读取已经背诵的单元
                var items = dbOperator.GetBookItemsBelowMaxUnitId(history.Key, history.Value);
                foreach (var item in items)
                {
                    if (!result.ContainsKey(item.Word))
                        result.Add(item.Word, new Vocabulary() { Word = item.Word, IsKnown = true });
                }
            }
            foreach (var newword in newWords)
            {
                if (result.ContainsKey(newword))
                {
                    result[newword].IsKnown = false;
                }
                else
                {
                    result.Add(newword, new Vocabulary() { Word = newword, IsKnown = false });
                }
            }
            return new List<Vocabulary>(result.Values);
        }

        private void ShowMessage(string str)
        {
            richTextBox1.AppendText(DateTime.Now+"\t"+ str + "\r\n");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
