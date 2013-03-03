using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using Studyzy.LeanEnglishBySubtitle.EngDict;
using Studyzy.LeanEnglishBySubtitle.Entities;
using Studyzy.LeanEnglishBySubtitle.Helpers;
using Studyzy.LeanEnglishBySubtitle.Subtitle;
using Studyzy.LeanEnglishBySubtitle.UserData;

namespace Studyzy.LeanEnglishBySubtitle.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dbOperator = new DbOperator();
            service = new Service(dbOperator);
            
        }

        private int userRank = 4;
        DbOperator dbOperator;
        Service service;
        private DictionaryService dictionaryService=DictionaryService.Instance;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbSubtitleFilePath.Text = openFileDialog1.FileName;
            }
        }
        IList<SrtFormat> Subtitle; 
        private void btnParse_Click(object sender, EventArgs e)
        {
         
            var txt = FileOperationHelper.ReadFile(txbSubtitleFilePath.Text);
            var srts = SrtOperator.Parse(txt);
            ShowSubtitleText(srts);
            Subtitle = srts;
        }

        private void ShowSubtitleText(IList<SrtFormat> srts )
        {
            richTextBox1.Clear();
            foreach (var srtFormat in srts)
            {
                if (!string.IsNullOrEmpty(srtFormat.Text.Trim()))
                    richTextBox1.AppendText(srtFormat.Text + "\r\n");
            }
        }

      
     
        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }
        private void ShowMessage(string message)
        {
            toolStripStatusLabel1.Text = message;
        }
        private void btnSyncNewWords_Click(object sender, EventArgs e)
        {

            var uid = Convert.ToInt32(txbUserId.Text);
            ShowMessage("读取用户生词本...");
            //读取用户不认识的词
            var newWordList= HujiangWebService.GetUserItems(uid, Convert.ToDateTime("2000-1-1"));

            ShowMessage( "生词：" + newWordList.Count + "个");
            dbOperator.SaveUserNewWords(newWordList);
            ShowMessage("读取用户背诵记录...");
            //读取用户背诵过的书和单元，得到用户已认识词列表
            IList<User_LearnHistory> histories=new List<User_LearnHistory>();
            var userBooks = HujiangWebService.GetPublicBooks(uid, "en");
            foreach (var userBook in userBooks)
            {
                var unitId = HujiangWebService.GetUserUnitMax(uid, userBook.BookID);
                if (unitId > 0)
                {
                    richTextBox1.AppendText(userBook.BookName+ " UnitId:"+unitId+"\r\n");
                    histories.Add(new User_LearnHistory(){BookId = userBook.BookID,MaxUnitId = unitId});
                }
            }
            //将用户记录写入数据库
            dbOperator.SaveUserLearnHistory(histories);
            ShowMessage("统计用户的已知和未知词汇...");
            service.CalcUserVocabulary(newWordList);
            ShowMessage("同步完成");
        }

        private void ToolStripMenuItemRemoveChinese_Click(object sender, EventArgs e)
        {
            RemoveChineseSubtitleForm form = new RemoveChineseSubtitleForm();
            form.Show();
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            userRank = Convert.ToInt32(numUserVocabularyRank.Value);
            var newSubtitle = new List<SrtFormat>();
            for (int i = 0; i < Subtitle.Count;i++ )
            {
                var srtFormat = Subtitle[i];
                srtFormat.Text = StringAndRemarkString(srtFormat.Text);
                newSubtitle.Add(srtFormat);
            }
            Subtitle = newSubtitle;
            ShowSubtitleText(newSubtitle);
        }
        private string StringAndRemarkString(string line)
        {
            var array = line.Split(new char[] {' ', ',', '.', '?', ':', '!'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in array)
            {
                line = line.Replace(word, RemarkWord(WordToLower(word)));
            }
            return line;
        }
        private string WordToLower(string word)
        {
            if (word == "I"||word=="I'm")
                return word;
            return word.ToLower();
        }
        private Dictionary<string,string> cachedDict=new Dictionary<string, string>();

        private IList<string> easyWord;
        private bool IsEasyWord(string word)
        {
            if(easyWord==null)
            easyWord = dbOperator.GetAll<EasyWord>().Select(e => e.Word).ToList();
            return easyWord.Contains(word);
        }

        private string RemarkWord(string word)
        {
            if (IsEasyWord(word))
            {
                return word;
            }
            if (!cachedDict.ContainsKey(word))
            {
                cachedDict[word] = CalcAndGetWordAndMean(word);
              
            }
            return cachedDict[word];
        }

        private IList<User_Vocabulary> userVocabularies;
 
        private User_Vocabulary GetUserVocabulary(string word)
        {
            if (userVocabularies == null)
            {
                userVocabularies = dbOperator.GetAll<User_Vocabulary>();
            }
            return (userVocabularies.Where(v => v.Word == word).FirstOrDefault());
        }

        private IList<VocabularyRank> vocabularyRanks;
        private VocabularyRank GetVocabularyRank(string word)
        {
          if (vocabularyRanks == null)
            {
                vocabularyRanks = dbOperator.GetAll<VocabularyRank>();
            }
            return (vocabularyRanks.Where(v => v.Word == word).FirstOrDefault());
        }
        private string CalcAndGetWordAndMean(string word)
        {
            var originalWord = GetOriginalWord(word);
            var vocabulary = GetUserVocabulary(originalWord);
            if (vocabulary != null)
            {
                if (vocabulary.KnownStatus == KnownStatus.Known)
                {
                    //用户认识这个词，那么就不用替换
                    return word;
                }
                else //用户的生词表中有这个词，
                {
                    return GetWordAndMean(word);
                }
            }
            //用户词汇中没有这个词，那么就查询词频分级表，看有没有分级信息
            var rank = GetVocabularyRank(originalWord);
            if (rank != null)
            {
                if (rank.RankValue < userRank)
                {
                    return GetWordAndMean(word);
                }
                else
                {
                    return word;
                }
            }
            return GetWordAndMean(word);

        }

        private string GetWordAndMean(string word)
        {
            var mean = dictionaryService.GetChineseMean(word);
            if (string.IsNullOrEmpty(mean))
            {
                return word;
            }
            return word + "(" + mean + ")";
        }

        private string GetOriginalWord(string word)
        {
            
            if (word.EndsWith("ing"))//进行时
            {
                var newWord = word.Substring(0, word.Length - 3);
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
                newWord += "e";
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
            }
            if (word.EndsWith("ed") || word.EndsWith("es"))//过去式 //复数
            {
                var newWord = word.Substring(0, word.Length - 2);
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
                newWord += "e";
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
            }
            if (word.EndsWith("s"))//复数
            {
                var newWord = word.Substring(0, word.Length - 1);
                if (dictionaryService.IsInDictionary(newWord))
                {
                    return newWord;
                }
               
            }
            return word;
        }
    }
}
