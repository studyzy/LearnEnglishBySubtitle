namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    partial class PreviewVocabularyForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPickupNewWords = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dgbtnIgnore = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IsNewWord = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WordRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubtitleSentence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Means = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(762, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgbtnIgnore,
            this.IsNewWord,
            this.Word,
            this.WordRank,
            this.SubtitleSentence,
            this.Means});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(825, 397);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "单击“字幕分析”按钮选择字幕所在文件夹，系统将根据用户词汇量分析出高频生词，用户记住这些高频生词更容易看懂字幕。";
            // 
            // btnPickupNewWords
            // 
            this.btnPickupNewWords.Location = new System.Drawing.Point(762, 9);
            this.btnPickupNewWords.Name = "btnPickupNewWords";
            this.btnPickupNewWords.Size = new System.Drawing.Size(75, 32);
            this.btnPickupNewWords.TabIndex = 3;
            this.btnPickupNewWords.Text = "字幕分析";
            this.btnPickupNewWords.UseVisualStyleBackColor = true;
            this.btnPickupNewWords.Click += new System.EventHandler(this.btnPickupNewWords_Click);
            // 
            // dgbtnIgnore
            // 
            this.dgbtnIgnore.FillWeight = 50F;
            this.dgbtnIgnore.HeaderText = "忽略";
            this.dgbtnIgnore.Name = "dgbtnIgnore";
            this.dgbtnIgnore.ReadOnly = true;
            this.dgbtnIgnore.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgbtnIgnore.Text = "X";
            this.dgbtnIgnore.Width = 40;
            // 
            // IsNewWord
            // 
            this.IsNewWord.HeaderText = "是否生词";
            this.IsNewWord.Name = "IsNewWord";
            this.IsNewWord.Width = 40;
            // 
            // Word
            // 
            this.Word.HeaderText = "单词";
            this.Word.Name = "Word";
            this.Word.ReadOnly = true;
            this.Word.Width = 75;
            // 
            // WordRank
            // 
            this.WordRank.HeaderText = "词频";
            this.WordRank.Name = "WordRank";
            this.WordRank.ReadOnly = true;
            this.WordRank.Width = 40;
            // 
            // SubtitleSentence
            // 
            this.SubtitleSentence.HeaderText = "原文";
            this.SubtitleSentence.Name = "SubtitleSentence";
            this.SubtitleSentence.ReadOnly = true;
            this.SubtitleSentence.Width = 300;
            // 
            // Means
            // 
            this.Means.HeaderText = "解释";
            this.Means.Name = "Means";
            this.Means.ReadOnly = true;
            this.Means.Width = 300;
            // 
            // PreviewVocabularyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 494);
            this.Controls.Add(this.btnPickupNewWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "PreviewVocabularyForm";
            this.Text = "生词预习";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPickupNewWords;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewButtonColumn dgbtnIgnore;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNewWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn WordRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubtitleSentence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Means;
    }
}