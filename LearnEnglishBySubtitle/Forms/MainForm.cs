using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using Studyzy.LearnEnglishBySubtitle.EngDict;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using Studyzy.LearnEnglishBySubtitle.Subtitle;
using Studyzy.LearnEnglishBySubtitle.UserData;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dbOperator = new DbOperator();
        
            englishWordService = new EnglishWordService(dictionaryService);
        }

        private int userRank = 4;
        private bool removeChinese = true;
        DbOperator dbOperator;
     
        private EnglishWordService englishWordService;
        private DictionaryService dictionaryService=new ModernDictionaryService();
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
            if (removeChinese)
            {
                srts = RemoveChinese(srts);
            }
            ShowSubtitleText(srts);
            Subtitle = srts;
        }
        private IList<SrtFormat> RemoveChinese(IList<SrtFormat> srts )
        {
            var newSrts = new List<SrtFormat>();
            for (int i = 0; i < srts.Count; i++)
            {
                var srtFormat = srts[i];
                var lines = srtFormat.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                IList<string> newLines = new List<string>();
                foreach (var line in lines)
                {
                    var l = StringHelper.RemoveRemark(line);
                    if (!StringHelper.IsChinese(l))
                    {
                        newLines.Add(l);
                    }
                }
                if (newLines.Count > 0)
                {
                    srtFormat.Text = string.Join("\r\n", newLines.ToArray());
                }
                else
                {
                    srtFormat.Text = " ";
                }
                newSrts.Add(srtFormat);
            }
            return newSrts;
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
            backgroundLoadDictionary.RunWorkerAsync();
        }
        private void ShowMessage(string message)
        {
            toolStripStatusLabel1.Text = message;
        }
        private void btnSyncNewWords_Click(object sender, EventArgs e)
        {

            //var uid = Convert.ToInt32(txbUserId.Text);
            //ShowMessage("读取用户生词本...");
            ////读取用户不认识的词
            //var newWordList= HujiangWebService.GetUserItems(uid, Convert.ToDateTime("2000-1-1"));

            //ShowMessage( "生词：" + newWordList.Count + "个");
            //dbOperator.SaveUserNewWords(newWordList);
            //ShowMessage("读取用户背诵记录...");
            ////读取用户背诵过的书和单元，得到用户已认识词列表
            //IList<User_LearnHistory> histories=new List<User_LearnHistory>();
            //var userBooks = HujiangWebService.GetPublicBooks(uid, "en");
            //foreach (var userBook in userBooks)
            //{
            //    var unitId = HujiangWebService.GetUserUnitMax(uid, userBook.BookID);
            //    if (unitId > 0)
            //    {
            //        richTextBox1.AppendText(userBook.BookName+ " UnitId:"+unitId+"\r\n");
            //        histories.Add(new User_LearnHistory(){BookId = userBook.BookID,MaxUnitId = unitId});
            //    }
            //}
            ////将用户记录写入数据库
            //dbOperator.SaveUserLearnHistory(histories);
            //ShowMessage("统计用户的已知和未知词汇...");
            //service.CalcUserVocabulary(newWordList);
            //ShowMessage("同步完成");
        }

     

        private void btnRemark_Click(object sender, EventArgs e)
        {
            userRank = 4;// Convert.ToInt32(numUserVocabularyRank.Value);

            var subtitleWords = PickNewWords(Subtitle);
            if (subtitleWords.Count > 0)
            {
                NewWordConfirmForm form=new NewWordConfirmForm();
                form.DataSource = subtitleWords.Values.ToList();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var subtitleName = Path.GetFileNameWithoutExtension(txbSubtitleFilePath.Text);
                     dbOperator.SaveSubtitleNewWords(form.SelectedNewWords,subtitleName);
                      Dictionary<string,SubtitleWord> result=new Dictionary<string, SubtitleWord>();
                      foreach (var subtitleWord in form.SelectedNewWords)
                      {
                          result.Add(subtitleWord.Word, subtitleWord);
                      }
                    var newSubtitle = new List<SrtFormat>();
                    for (int i = 0; i < Subtitle.Count; i++)
                    {
                        var srtFormat = Subtitle[i];
                        srtFormat.Text = StringAndRemarkString(srtFormat.Text, result);
                        newSubtitle.Add(srtFormat);
                    }
                    Subtitle = newSubtitle;
                    ShowSubtitleText(newSubtitle);
                    ClearCache();
                }
            }

           
        }
        private IDictionary<string, SubtitleWord> PickNewWords(IList<SrtFormat> subtitles)
        {
            Dictionary<string,SubtitleWord> result=new Dictionary<string, SubtitleWord>();
            var texts = subtitles.Select(s => s.Text).ToList();
            foreach (var line in texts)
            {
                var array = line.Split(new char[] { ' ', ',', '.', '?', ':', '!' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in array)
                {
                    var original = englishWordService.GetOriginalWord(word);
                    if (result.ContainsKey(original))
                    {
                        continue;
                    }
                 
                    var mean = RemarkWord(original);
                    if (mean!=null)
                        result.Add(original, new SubtitleWord() { Word = original, WordInSubitle = word, Means = mean.Means, SubtitleSentence = line });
                }
            }
            return result;
        }

        private string StringAndRemarkString(string line,IDictionary<string,SubtitleWord> words )
        {
            var array = line.Split(new char[] {' ', ',', '.', '?', ':', '!'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in array)
            {
                var w = englishWordService.GetOriginalWord(word);
                var mean = words.ContainsKey(w) ? words[w].SelectMean : "";
                if (!string.IsNullOrEmpty(mean))
                {
                    if(shortMean)
                    {
                        var meanarray = mean.Split(new char[]{';',','},StringSplitOptions.RemoveEmptyEntries);
                        mean = meanarray[0];
                    }
                    line = ReplaceNewWord(line, word, mean);
                }
            }
            return line;
        }

        private string ReplaceNewWord(string line,string word,string mean)
        {
            string fontFormat = "({0})";
            if (meanColor != default(Color))
            {
                fontFormat = "(<font color='#" + meanColor.R.ToString("x") + meanColor.G.ToString("x") + meanColor.B.ToString("x") +"'>{0}</font>)";
            }
            return line.Replace(word, word +string.Format(fontFormat,mean.Trim()) );
        }

        private Dictionary<string, EngDictionary> cachedDict = new Dictionary<string, EngDictionary>();

        private IList<string> easyWord;
        private bool IsEasyWord(string word)
        {
            if(easyWord==null)
            easyWord = dbOperator.GetAll<EasyWord>().Select(e => e.Word).ToList();
            return easyWord.Contains(word);
        }

        private EngDictionary RemarkWord(string word)
        {
            if (IsEasyWord(word))
            {
                return null;
            }
            if (!cachedDict.ContainsKey(word))
            {
                var w = CalcAndGetWordAndMean(word);
                if(!string.IsNullOrEmpty(w))
                {
                    var d = dictionaryService.GetChineseMeanInDict(w);
                    cachedDict[word] = d;
                }
                else
                {
                    cachedDict[word] = null;
                }
              
            }
            return cachedDict[word];
        }

        private IList<UserVocabulary> userVocabularies;
 
        private UserVocabulary GetUserVocabulary(string word)
        {
            if (userVocabularies == null||userVocabularies.Count==0)
            {
                userVocabularies = dbOperator.GetAll<UserVocabulary>();
            }
            return (userVocabularies.Where(v => v.Word == word).FirstOrDefault());
        }

        private IList<VocabularyRank> vocabularyRanks;
        private VocabularyRank GetVocabularyRank(string word)
        {
          if (vocabularyRanks == null||vocabularyRanks.Count==0)
            {
                vocabularyRanks = dbOperator.GetAll<VocabularyRank>();
            }
            return (vocabularyRanks.Where(v => v.Word == word).FirstOrDefault());
        }
        private string CalcAndGetWordAndMean(string word)
        {
 
            var vocabulary = GetUserVocabulary(word);
            if (vocabulary != null)
            {
                if (vocabulary.KnownStatus == KnownStatus.Known)
                {
                    //用户认识这个词，那么就不用替换
                    return "";
                }
                else //用户的生词表中有这个词，
                {
                    return (word);
                }
            }
            //用户词汇中没有这个词，那么就查询词频分级表，看有没有分级信息
            var rank = GetVocabularyRank(word);
            if (rank != null)
            {
                if (rank.RankValue < userRank)
                {
                    return (word);
                }
                else
                {
                    return "";
                }
            }
            return (word);

        }

      

    
        private void backgroundLoadDictionary_DoWork(object sender, DoWorkEventArgs e)
        {
            dictionaryService.IsInDictionary("a");
        }

        private void backgroundLoadDictionary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowMessage("字典装载完成.");
            btnRemark.Enabled = true;
        }
        private  void ClearCache()
        {
            userVocabularies.Clear();
            cachedDict.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var bakFile = txbSubtitleFilePath.Text + ".bak";
            if(!File.Exists(bakFile))
            {
                File.Copy(txbSubtitleFilePath.Text, bakFile);
            }
            var str = SrtOperator.SrtFormat2String(Subtitle);
            FileOperationHelper.WriteFile(txbSubtitleFilePath.Text, Encoding.UTF8, str);
            ShowMessage("保存成功");
        }

        private void ToolStripMenuItemAdjustSubtitleTimeline_Click(object sender, EventArgs e)
        {
            TimelineAdjustForm form=new TimelineAdjustForm();
            form.Show();
        }

        private void ToolStripMenuItemFilterChinese_Click(object sender, EventArgs e)
        {
            removeChinese = ToolStripMenuItemFilterChinese.Checked;
        }

        private bool shortMean = true;
        private void ToolStripMenuItemShortMean_Click(object sender, EventArgs e)
        {
            shortMean = ToolStripMenuItemShortMean.Checked;
        }

        private void ToolStripMenuItemMeanStyleConfig_Click(object sender, EventArgs e)
        {
            var r = colorDialog1.ShowDialog();
            if ( r== DialogResult.OK)
            {
                meanColor = colorDialog1.Color;
            }
            else if(r==DialogResult.Cancel)
            {
                meanColor = default(Color);
            }
        }

        private Color meanColor;

        private void ToolStripMenuItemDictionaryConfig_Click(object sender, EventArgs e)
        {
            DictionaryConfigForm form=new DictionaryConfigForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.dictionaryService = form.SelectDictionaryService;
                englishWordService.DictionaryService = dictionaryService;
                if(!backgroundLoadDictionary.IsBusy)
                {
                    backgroundLoadDictionary.RunWorkerAsync();
                }
            }
        }

        private void ToolStripMenuItemUserVocabularyConfig_Click(object sender, EventArgs e)
        {
            UserVocabularyConfigForm form=new UserVocabularyConfigForm();
            form.Show();
        }

        private void ToolStripMenuItemUserVocabularyMgt_Click(object sender, EventArgs e)
        {
            UserVocabularyMgtForm form=new UserVocabularyMgtForm();
            form.Show();
        }

        private void ToolStripMenuItemAbount_Click(object sender, EventArgs e)
        {
            AboutBox a=new AboutBox();
            a.Show();
        }

        private void ToolStripMenuItemDonate_Click(object sender, EventArgs e)
        {
            Process.Start("http://imewlconverter.googlecode.com/svn/wiki/donate.html");
        }

        private void ToolStripMenuItemLastVersion_Click(object sender, EventArgs e)
        {
            Process.Start("https://code.google.com/p/learn-english-by-subtitle/downloads/list");
        }

    }
}
