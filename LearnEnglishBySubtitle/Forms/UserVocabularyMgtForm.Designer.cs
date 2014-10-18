namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    partial class UserVocabularyMgtForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExportKnownWords = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddKnownWords = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbKnownWords = new System.Windows.Forms.RichTextBox();
            this.btnToUnknown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxKnownList = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportUnknownWords = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddNewWords = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbNewWords = new System.Windows.Forms.RichTextBox();
            this.btnSetThemKnown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxUnknownList = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridWordQuery = new System.Windows.Forms.DataGridView();
            this.txbWordQueryInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKnownStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWordQuery)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 782);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExportKnownWords);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnToUnknown);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbxKnownList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 756);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "熟悉的单词";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExportKnownWords
            // 
            this.btnExportKnownWords.Location = new System.Drawing.Point(722, 407);
            this.btnExportKnownWords.Name = "btnExportKnownWords";
            this.btnExportKnownWords.Size = new System.Drawing.Size(75, 46);
            this.btnExportKnownWords.TabIndex = 4;
            this.btnExportKnownWords.Text = "导 出";
            this.btnExportKnownWords.UseVisualStyleBackColor = true;
            this.btnExportKnownWords.Click += new System.EventHandler(this.btnExportKnownWords_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddKnownWords);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rtbKnownWords);
            this.groupBox1.Location = new System.Drawing.Point(333, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 254);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加熟悉的单词";
            // 
            // btnAddKnownWords
            // 
            this.btnAddKnownWords.Location = new System.Drawing.Point(389, 186);
            this.btnAddKnownWords.Name = "btnAddKnownWords";
            this.btnAddKnownWords.Size = new System.Drawing.Size(75, 46);
            this.btnAddKnownWords.TabIndex = 2;
            this.btnAddKnownWords.Text = "添 加";
            this.btnAddKnownWords.UseVisualStyleBackColor = true;
            this.btnAddKnownWords.Click += new System.EventHandler(this.btnAddKnownWords_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "请输入熟悉的单词，一行一个单词：";
            // 
            // rtbKnownWords
            // 
            this.rtbKnownWords.Location = new System.Drawing.Point(17, 60);
            this.rtbKnownWords.Name = "rtbKnownWords";
            this.rtbKnownWords.Size = new System.Drawing.Size(263, 173);
            this.rtbKnownWords.TabIndex = 0;
            this.rtbKnownWords.Text = "";
            // 
            // btnToUnknown
            // 
            this.btnToUnknown.Location = new System.Drawing.Point(722, 18);
            this.btnToUnknown.Name = "btnToUnknown";
            this.btnToUnknown.Size = new System.Drawing.Size(75, 46);
            this.btnToUnknown.TabIndex = 2;
            this.btnToUnknown.Text = "放到生词本";
            this.btnToUnknown.UseVisualStyleBackColor = true;
            this.btnToUnknown.Click += new System.EventHandler(this.btnToUnknown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "选中的这些单词其实我并不是很熟悉，还是放到生词本中吧：";
            // 
            // cbxKnownList
            // 
            this.cbxKnownList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxKnownList.FormattingEnabled = true;
            this.cbxKnownList.Location = new System.Drawing.Point(3, 3);
            this.cbxKnownList.Name = "cbxKnownList";
            this.cbxKnownList.Size = new System.Drawing.Size(293, 750);
            this.cbxKnownList.TabIndex = 0;
            this.cbxKnownList.SelectedIndexChanged += new System.EventHandler(this.cbxKnownList_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExportUnknownWords);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnSetThemKnown);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbxUnknownList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(823, 756);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生词本";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExportUnknownWords
            // 
            this.btnExportUnknownWords.Location = new System.Drawing.Point(722, 407);
            this.btnExportUnknownWords.Name = "btnExportUnknownWords";
            this.btnExportUnknownWords.Size = new System.Drawing.Size(75, 46);
            this.btnExportUnknownWords.TabIndex = 5;
            this.btnExportUnknownWords.Text = "导 出";
            this.btnExportUnknownWords.UseVisualStyleBackColor = true;
            this.btnExportUnknownWords.Click += new System.EventHandler(this.btnExportUnknownWords_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddNewWords);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rtbNewWords);
            this.groupBox2.Location = new System.Drawing.Point(333, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 254);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加生词";
            // 
            // btnAddNewWords
            // 
            this.btnAddNewWords.Location = new System.Drawing.Point(389, 186);
            this.btnAddNewWords.Name = "btnAddNewWords";
            this.btnAddNewWords.Size = new System.Drawing.Size(75, 46);
            this.btnAddNewWords.TabIndex = 2;
            this.btnAddNewWords.Text = "添 加";
            this.btnAddNewWords.UseVisualStyleBackColor = true;
            this.btnAddNewWords.Click += new System.EventHandler(this.btnAddNewWords_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "请输入不熟悉的生词，一行一个单词：";
            // 
            // rtbNewWords
            // 
            this.rtbNewWords.Location = new System.Drawing.Point(17, 60);
            this.rtbNewWords.Name = "rtbNewWords";
            this.rtbNewWords.Size = new System.Drawing.Size(263, 173);
            this.rtbNewWords.TabIndex = 0;
            this.rtbNewWords.Text = "";
            // 
            // btnSetThemKnown
            // 
            this.btnSetThemKnown.Location = new System.Drawing.Point(722, 18);
            this.btnSetThemKnown.Name = "btnSetThemKnown";
            this.btnSetThemKnown.Size = new System.Drawing.Size(75, 46);
            this.btnSetThemKnown.TabIndex = 3;
            this.btnSetThemKnown.Text = "标记为熟悉";
            this.btnSetThemKnown.UseVisualStyleBackColor = true;
            this.btnSetThemKnown.Click += new System.EventHandler(this.btnSetThemKnown_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(379, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "经过不断努力，选中的单词我终于记住了，放到熟悉的单词列表里吧：";
            // 
            // cbxUnknownList
            // 
            this.cbxUnknownList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxUnknownList.FormattingEnabled = true;
            this.cbxUnknownList.Location = new System.Drawing.Point(3, 3);
            this.cbxUnknownList.Name = "cbxUnknownList";
            this.cbxUnknownList.Size = new System.Drawing.Size(293, 750);
            this.cbxUnknownList.TabIndex = 1;
            this.cbxUnknownList.SelectedIndexChanged += new System.EventHandler(this.cbxUnknownList_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridWordQuery);
            this.tabPage3.Controls.Add(this.txbWordQueryInput);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(823, 756);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "单词记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridWordQuery
            // 
            this.dataGridWordQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWordQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cWord,
            this.cKnownStatus,
            this.cMean,
            this.cSource});
            this.dataGridWordQuery.Location = new System.Drawing.Point(10, 69);
            this.dataGridWordQuery.Name = "dataGridWordQuery";
            this.dataGridWordQuery.RowTemplate.Height = 23;
            this.dataGridWordQuery.Size = new System.Drawing.Size(805, 676);
            this.dataGridWordQuery.TabIndex = 3;
            // 
            // txbWordQueryInput
            // 
            this.txbWordQueryInput.Location = new System.Drawing.Point(55, 15);
            this.txbWordQueryInput.Name = "txbWordQueryInput";
            this.txbWordQueryInput.Size = new System.Drawing.Size(140, 20);
            this.txbWordQueryInput.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "单词：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(232, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "TXT|*.txt";
            // 
            // cWord
            // 
            this.cWord.DataPropertyName = "Word";
            this.cWord.Frozen = true;
            this.cWord.HeaderText = "Word";
            this.cWord.Name = "cWord";
            this.cWord.ReadOnly = true;
            // 
            // cKnownStatus
            // 
            this.cKnownStatus.DataPropertyName = "IsNewWord";
            this.cKnownStatus.Frozen = true;
            this.cKnownStatus.HeaderText = "KnownStatus";
            this.cKnownStatus.Name = "cKnownStatus";
            this.cKnownStatus.ReadOnly = true;
            // 
            // cMean
            // 
            this.cMean.DataPropertyName = "Meaning";
            this.cMean.Frozen = true;
            this.cMean.HeaderText = "Meaning";
            this.cMean.Name = "cMean";
            this.cMean.ReadOnly = true;
            this.cMean.Width = 400;
            // 
            // cSource
            // 
            this.cSource.DataPropertyName = "Source";
            this.cSource.Frozen = true;
            this.cSource.HeaderText = "Source";
            this.cSource.Name = "cSource";
            this.cSource.ReadOnly = true;
            this.cSource.Width = 300;
            // 
            // UserVocabularyMgtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 782);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserVocabularyMgtForm";
            this.Text = "词汇管理";
            this.Load += new System.EventHandler(this.UserVocabularyMgtForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWordQuery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox cbxKnownList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox cbxUnknownList;
        private System.Windows.Forms.Button btnToUnknown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetThemKnown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddKnownWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbKnownWords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddNewWords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbNewWords;
        private System.Windows.Forms.Button btnExportKnownWords;
        private System.Windows.Forms.Button btnExportUnknownWords;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txbWordQueryInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridWordQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn cWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKnownStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMean;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSource;
    }
}