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
using Studyzy.LearnEnglishBySubtitle.Subtitles;

namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dbOperator = DbOperator.Instance;

            englishWordService = new EnglishWordService(dictionaryService);
        }

        private ISubtitleOperator stOperator;
        //private int userRank = 4;
        private bool removeChinese = true;
        private DbOperator dbOperator;
        private Subtitle subtitle;
        private EnglishWordService englishWordService;
        private DictionaryService dictionaryService = new ViconDictionaryService();

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbSubtitleFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {

            var txt = FileOperationHelper.ReadFile(txbSubtitleFilePath.Text);
            stOperator = SubtitleHelper.GetOperatorByFileName(txbSubtitleFilePath.Text);
            var srts = stOperator.Parse(txt);

            srts = stOperator.RemoveChinese(srts);

            ShowSubtitleText(srts.Bodies);
            subtitle = srts;
        }

        private void ShowSubtitleText(IList<SubtitleLine> srts,bool withMean=false )
        {
            richTextBox1.Clear();
            foreach (var SubtitleLine in srts)
            {
                var txt = SubtitleLine.Text;
                if (removeChinese)
                {
                    if (withMean)
                    {
                        txt = SubtitleLine.EnglishTextWithMeans;
                    }
                    else
                    {
                        txt = SubtitleLine.EnglishText;
                    }
                }
                if (!string.IsNullOrEmpty(txt.Trim()))
                    richTextBox1.AppendText(txt + "\r\n");
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
      

        private void btnRemark_Click(object sender, EventArgs e)
        {
            //userRank = 4;// Convert.ToInt32(numUserVocabularyRank.Value);

            var subtitleWords = PickNewWords(subtitle.Bodies);
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
                    var newSubtitle = new List<SubtitleLine>();
                    for (int i = 0; i < subtitle.Bodies.Count; i++)
                    {
                        var SubtitleLine = subtitle.Bodies[i];
                        SubtitleLine.EnglishTextWithMeans = StringAndRemarkString(SubtitleLine.EnglishText, result);
                        newSubtitle.Add(SubtitleLine);
                    }
                    subtitle.Bodies = newSubtitle;
                    ShowSubtitleText(newSubtitle,true);
                    ClearCache();
                }
            }

           
        }
        /// <summary>
        /// 找到字幕中的生词，先进行分词，然后取每个单词的原型，然后看每个单词是否认识，认识则跳过，不认识则注释。
        /// </summary>
        /// <param name="subtitles"></param>
        /// <returns></returns>
        private IDictionary<string, SubtitleWord> PickNewWords(IList<SubtitleLine> subtitles)
        {
            Dictionary<string,SubtitleWord> result=new Dictionary<string, SubtitleWord>();
            var knownVocabulary= dbOperator.FindAll<UserVocabulary>(v=>v.KnownStatus== KnownStatus.Known).Select(v=>v.Word).ToList();
            var texts = subtitles.Select(s => s.EnglishText).ToList();
            foreach (var line in texts)
            {
                var array = line.Split(new char[] { ' ', ',', '.', '?', ':', '!' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in array)
                {
                    var original = englishWordService.GetOriginalWord(word);
                    if (knownVocabulary.Contains(word) || knownVocabulary.Contains(original))
                    {
                        //认识的单词，忽略
                        continue;
                    }

                    if (result.ContainsKey(original))
                    {
                        //重复的单词
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
                if (rank.RankValue < 4)
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
            var lines = new List<SubtitleLine>();
            foreach (var subtitleLine in subtitle.Bodies)
            {
                if (removeChinese)
                {
                    subtitleLine.Text = subtitleLine.EnglishTextWithMeans;
                }
                else
                {
                    subtitleLine.Text = subtitleLine.Text.Replace(subtitleLine.EnglishText,
                                                                  subtitleLine.EnglishTextWithMeans);
                }
                lines.Add(subtitleLine);
            }
            subtitle.Bodies = lines;
            var bakFile = txbSubtitleFilePath.Text + ".bak";
            if(!File.Exists(bakFile))
            {
                File.Copy(txbSubtitleFilePath.Text, bakFile);
            }
            var str = stOperator.Subtitle2String(subtitle);
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
            //DictionaryConfigForm form=new DictionaryConfigForm();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    this.dictionaryService = form.SelectDictionaryService;
            //    englishWordService.DictionaryService = dictionaryService;
            //    if(!backgroundLoadDictionary.IsBusy)
            //    {
            //        backgroundLoadDictionary.RunWorkerAsync();
            //    }
            //}
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
            Process.Start("https://sourceforge.net/projects/learnenglishbysubtitle/files/");
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            var array = (Array)e.Data.GetData(DataFormats.FileDrop);
            string files = "";


            foreach (object a in array)
            {
                string path = a.ToString();
                files += path + " | ";
            }
            txbSubtitleFilePath.Text = files.Remove(files.Length - 3);
           
        }

        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://code.google.com/p/learn-english-by-subtitle");
        }

    }
}
