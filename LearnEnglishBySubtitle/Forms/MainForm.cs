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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Studyzy.LearnEnglishBySubtitle.EngDict;
using Studyzy.LearnEnglishBySubtitle.Entities;
using Studyzy.LearnEnglishBySubtitle.Helpers;
using Studyzy.LearnEnglishBySubtitle.Subtitles;
using Studyzy.LearnEnglishBySubtitle.TranslateServices;

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

        private TranslateService translateService = new YoudaoTranslateService();
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
            dgvSubtitleSentence.Rows.Clear();
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
                {
                    DataGridViewRow row=new DataGridViewRow();
                    row.CreateCells(dgvSubtitleSentence);
                    row.Cells[0].Value = SubtitleLine.Number.ToString();

                    string timeLine = SubtitleLine.StartTime.ToString("HH:mm:ss") + "->" + SubtitleLine.EndTime.ToString("HH:mm:ss");

                    row.Cells[1].Value = timeLine;
                    row.Cells[2].Value = txt;
                    dgvSubtitleSentence.Rows.Add(row);
                }
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
            Splash.Show();
            Splash.Status = "解析字幕中...";
            var subtitleWords = PickNewWords(subtitle.Bodies);
            if (subtitleWords.Count > 0)
            {
                NewWordConfirmForm form = new NewWordConfirmForm();
                form.DataSource = subtitleWords.Values.ToList();
                form.SubtitleFileName = Path.GetFileName(txbSubtitleFilePath.Text);
                form.OnClickOkButton += RemarkSubtitle;
                form.Show();
                form.Focus();
                form.Activate();
                //if (form.ShowDialog() == DialogResult.OK)
                //{

                //  form.SelectedNewWords
                //}
            }
            Splash.Close();

        }
        /// <summary>
        /// 在保存用户认识和不认识的词后将不认识的词传回来，对字幕进行注释
        /// </summary>
        /// <param name="words">不认识的词</param>
        private void RemarkSubtitle(IList<SubtitleWord>  words)
        {
            Dictionary<string, SubtitleWord> result = new Dictionary<string, SubtitleWord>();
            foreach (var subtitleWord in words)
            {
                result.Add(subtitleWord.Word, subtitleWord);
            }
            var newSubtitle = new List<SubtitleLine>();
            for (int i = 0; i < subtitle.Bodies.Count; i++)
            {
                var subtitleLine = subtitle.Bodies[i];
                subtitleLine.EnglishTextWithMeans = ReplaceSubtitleLineByVocabulary(subtitleLine.EnglishText, result);
                newSubtitle.Add(subtitleLine);
            }
            subtitle.Bodies = newSubtitle;
            ShowSubtitleText(newSubtitle, true);
            //ClearCache();
        }


        /// <summary>
        /// 找到字幕中的生词，先进行分词，然后取每个单词的原型，然后看每个单词是否认识，认识则跳过，不认识则注释。
        /// </summary>
        /// <param name="subtitles"></param>
        /// <returns></returns>
        private IDictionary<string, SubtitleWord> PickNewWords(IList<SubtitleLine> subtitles)
        {
            Dictionary<string, SubtitleWord> result = new Dictionary<string, SubtitleWord>();
            var knownVocabulary =
                dbOperator.FindAllUserVocabulary(v => v.KnownStatus == KnownStatus.Known).Select(v => v.Word).ToList();
            var ignores = dbOperator.GetAllIgnoreWords().Select(v => v.Word).ToList();
            var texts = subtitles.Select(s => s.EnglishText).ToList();
            foreach (var line in texts)
            {
                var orgLine = SentenceParse.GetOriginalSentence(line);
                var array = SentenceParse.SplitSentence(orgLine);
                orgLine = orgLine.ToLower();
                foreach (string w in array)
                {

                    if (IsEnglishName(w))
                    {
                        //英文名，忽略
                        continue;
                    }
                    var word = w.ToLower();
                    var original = englishWordService.GetOriginalWord(word);
                    if (IsEasyWord(original))
                    {
                        continue;
                    }
                    if (knownVocabulary.Contains(word) || knownVocabulary.Contains(original) || ignores.Contains(word) ||
                        ignores.Contains(original))
                    {
                        //认识的单词，忽略
                        continue;
                    }

                    if (result.ContainsKey(original))
                    {
                        //重复的单词
                        continue;
                    }

                    var mean = SentenceParse.Instance.RemarkWord(orgLine, word, original);
                    if (mean != null)
                    {
                        var wd = new SubtitleWord()
                        {
                            Word = original,
                            WordInSubitle = word,
                            Means = mean.Means,
                            SubtitleSentence = line,
                            SelectMean = mean.DefaultMean == null?mean.Means[0].ToString(): mean.DefaultMean.ToString()
                        };
                        result.Add(original,wd);
                    }
                }
            }
            return result;
        }

        private string ReplaceSubtitleLineByVocabulary(string line,IDictionary<string,SubtitleWord> words )
        {
            var array = SentenceParse.SplitSentence(line);
            foreach (string word in array)
            {
                if (words.ContainsKey(word))//这个词需要注释
                {
                    var mean = words[word].SelectMean;
                    if (shortMean)
                    {
                        var meanarray = mean.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        mean = meanarray[0];
                        mean = mean.Substring(mean.IndexOf(' ')+1);
                    }
                    line = ReplaceNewWord(line, word, mean);
                }
                //var w = englishWordService.GetOriginalWord(word);
                //var mean = words.ContainsKey(w) ? words[w].SelectMean : "";
                //if (!string.IsNullOrEmpty(mean))
                //{
                //    if(shortMean)
                //    {
                //        var meanarray = mean.Split(new char[]{';',','},StringSplitOptions.RemoveEmptyEntries);
                //        mean = meanarray[0];
                //    }
                //    line = ReplaceNewWord(line, word, mean);
                //}
            }
            return line;
        }

        private string ReplaceNewWord(string line, string word, string mean)
        {
            string fontFormat = "$0({0})";
           
            string newStr = string.Format(fontFormat, mean.Trim());
            Regex wordRegex = new Regex("\\b" + word + "\\b");//匹配单词

            return wordRegex.Replace(line, newStr);
        }


        //private Dictionary<string, EngDictionary> cachedDict = new Dictionary<string, EngDictionary>();

        private bool IsEasyWord(string word)
        {
            var easyWord = InnerDictionaryHelper.GetAllEasyWords();
            return easyWord.Contains(word);
        }
        /// <summary>
        /// 判断是否是英文名，首字母大写，而且在英文名列表中的就是英文名
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool IsEnglishName(string word)
        {
            if (word[0] >= 'A' && word[0] <= 'Z')
            {
                var names = InnerDictionaryHelper.GetAllEnglishNames();
                return names.Contains(word);
            }
            return false;
        }
       

        //private IList<UserVocabulary> userVocabularies;
 
        //private UserVocabulary GetUserVocabulary(string word)
        //{
        //    if (userVocabularies == null||userVocabularies.Count==0)
        //    {
        //        userVocabularies = dbOperator.GetAllUserVocabulary();
        //    }
        //    return (userVocabularies.Where(v => v.Word == word).FirstOrDefault());
        //}

        //private IList<VocabularyRank> vocabularyRanks;
        //private VocabularyRank GetVocabularyRank(string word)
        //{
        //  if (vocabularyRanks == null||vocabularyRanks.Count==0)
        //    {
        //        vocabularyRanks = dbOperator.GetAll<VocabularyRank>();
        //    }
        //    return (vocabularyRanks.Where(v => v.Word == word).FirstOrDefault());
        //}
        //private string CalcAndGetWordAndMean(string word)
        //{

        //    var vocabulary = GetUserVocabulary(word);
        //    if (vocabulary != null)
        //    {
        //        if (vocabulary.KnownStatus == KnownStatus.Known)
        //        {
        //            //用户认识这个词，那么就不用替换
        //            return "";
        //        }
        //        else //用户的生词表中有这个词，
        //        {
        //            return (word);
        //        }
        //    }
        //    //用户词汇中没有这个词，那么就查询词频分级表，看有没有分级信息
        //    var rankData = InnerDictionaryHelper.GetAllVocabularyRanks();
        //    //var rank = GetVocabularyRank(word);
        //    if (!rankData.ContainsKey(word))
        //    {
        //        return word;
        //    }
        //    var rank = rankData[word];


        //    if (rank < 4)
        //    {
        //        return (word);
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}




        private void backgroundLoadDictionary_DoWork(object sender, DoWorkEventArgs e)
        {
            dictionaryService.IsInDictionary("a");
            SentenceParse.Instance.RemarkWord("Test it.", "it", "it");
        }

        private void backgroundLoadDictionary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowMessage("字典装载完成.");
            btnRemark.Enabled = true;
        }
        //private  void ClearCache()
        //{
        //    userVocabularies.Clear();
        //    cachedDict.Clear();
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var lines = new List<SubtitleLine>();
            //foreach (var subtitleLine in subtitle.Bodies)
            //{
            //    if (removeChinese)
            //    {
            //        subtitleLine.Text = subtitleLine.EnglishTextWithMeans;
            //    }
            //    else
            //    {
            //        subtitleLine.Text = subtitleLine.Text.Replace(subtitleLine.EnglishText,subtitleLine.EnglishTextWithMeans);
            //    }
            //    lines.Add(subtitleLine);
            //}
            //subtitle.Bodies = lines;
            var nsubtitle = BuildSubtitleFromGrid();


            if (meanColor != default(Color))
            {
                Regex r=new Regex(@"\(([^\)]+)\)");
                var fontFormat = "(<font color='#" + meanColor.R.ToString("x") + meanColor.G.ToString("x") +
                             meanColor.B.ToString("x") + "'>$1</font>)";
                foreach (SubtitleLine line in nsubtitle.Bodies)
                {
                    if (r.IsMatch(line.Text))
                    {
                        line.Text = r.Replace(line.Text, fontFormat);
                    }
                }

              
            }
            var path = txbSubtitleFilePath.Text;
            var bakFile = Path.GetDirectoryName(path)+"\\" +Path.GetFileNameWithoutExtension(path)+ "_bak"+Path.GetExtension(path);
            if(!File.Exists(bakFile))
            {
                File.Copy(txbSubtitleFilePath.Text, bakFile);
            }
            var str = stOperator.Subtitle2String(nsubtitle);
            FileOperationHelper.WriteFile(txbSubtitleFilePath.Text, Encoding.UTF8, str);
            ShowMessage("保存成功");
        }

        private Subtitle BuildSubtitleFromGrid()
        {
           Subtitle nsubtitle=new Subtitle();
            nsubtitle.Header = subtitle.Header;
            nsubtitle.Footer = nsubtitle.Footer;
            nsubtitle.Bodies = new List<SubtitleLine>();
            foreach (DataGridViewRow row in dgvSubtitleSentence.Rows)
            {
                SubtitleLine line=new SubtitleLine();
                line.Number = Convert.ToInt32( row.Cells[0].Value.ToString());
                var orgLine = subtitle.Bodies.Single(i => i.Number == line.Number);
                line.StartTime = orgLine.StartTime;
                line.EndTime = orgLine.EndTime;
                line.Text = row.Cells[2].Value.ToString();
                nsubtitle.Bodies.Add(line);
            }
            return nsubtitle;
        }

        //private void ToolStripMenuItemAdjustSubtitleTimeline_Click(object sender, EventArgs e)
        //{
        //    TimelineAdjustForm form=new TimelineAdjustForm();
        //    form.Show();
        //}

        #region Menu

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

       

        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://code.google.com/p/learn-english-by-subtitle");
        }

     
        private void YoudaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoudaoToolStripMenuItem.Checked = true;
            BaiduToolStripMenuItem.Checked = false;
            MicrosoftToolStripMenuItem.Checked = false;
            GoogleToolStripMenuItem.Checked = false;
            translateService=new YoudaoTranslateService();
        }

        private void BaiduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoudaoToolStripMenuItem.Checked = false;
            BaiduToolStripMenuItem.Checked = true;
            MicrosoftToolStripMenuItem.Checked = false;
            GoogleToolStripMenuItem.Checked = false;
            translateService = new BaiduTranslateService();
        }

        private void MicrosoftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoudaoToolStripMenuItem.Checked = false;
            BaiduToolStripMenuItem.Checked = false;
            MicrosoftToolStripMenuItem.Checked = true;
            GoogleToolStripMenuItem.Checked = false;
            translateService = new MsTranslateService();
        }

        private void GoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YoudaoToolStripMenuItem.Checked = false;
            BaiduToolStripMenuItem.Checked = false;
            MicrosoftToolStripMenuItem.Checked = false;
            GoogleToolStripMenuItem.Checked = true;
            translateService = new GoogleTranslateService();
        }

        #endregion

        #region Drag
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

        #endregion

        private void dgvSubtitleSentence_Resize(object sender, EventArgs e)
        {
            dgvSubtitleSentence.Columns[2].Width = dgvSubtitleSentence.Width - 179;
        }

        private void SentenceTranslateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSubtitleSentence.SelectedCells.Count > 0)
            {
                var cell = dgvSubtitleSentence.SelectedCells[0];
                if (cell.ColumnIndex == 2)//只对字幕句子进行翻译
                {
                    var sentence = cell.Value.ToString();
                    cell.Value = sentence+"\r\n"+ translateService.TranslateToChinese(sentence);
                }
            }
        }

    }
}
