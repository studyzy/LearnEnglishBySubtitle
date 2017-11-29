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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvKnownWords = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneticSymbols = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sentence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knownContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.add2UnknownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteKnownWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportKnownWords = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddKnownWords = new System.Windows.Forms.Button();
            this.rtbKnownWords = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txbNewWordSearch = new System.Windows.Forms.TextBox();
            this.dgvUnknownWords = new System.Windows.Forms.DataGridView();
            this.IsStar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.音标 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknownContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.move2KnownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveWordFromUnknowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PronunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportUnknownWords = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewWords = new System.Windows.Forms.Button();
            this.rtbNewWords = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txbIgnoreSearch = new System.Windows.Forms.TextBox();
            this.dgvIgnores = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCleanAll = new System.Windows.Forms.Button();
            this.dgvQueryResult = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNewWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbWordQueryInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.allWordContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allAdd2UnknowntoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allIgnoretoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allSoundtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allRememberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnownWords)).BeginInit();
            this.knownContextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknownWords)).BeginInit();
            this.unknownContextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIgnores)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).BeginInit();
            this.allWordContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 685);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvKnownWords);
            this.tabPage1.Controls.Add(this.btnExportKnownWords);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 659);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "熟悉的单词";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvKnownWords
            // 
            this.dgvKnownWords.AllowUserToAddRows = false;
            this.dgvKnownWords.AllowUserToDeleteRows = false;
            this.dgvKnownWords.AllowUserToResizeRows = false;
            this.dgvKnownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKnownWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnownWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
            this.PhoneticSymbols,
            this.Mean,
            this.Sentence,
            this.Source});
            this.dgvKnownWords.ContextMenuStrip = this.knownContextMenuStrip;
            this.dgvKnownWords.Location = new System.Drawing.Point(8, 6);
            this.dgvKnownWords.Name = "dgvKnownWords";
            this.dgvKnownWords.ReadOnly = true;
            this.dgvKnownWords.RowHeadersVisible = false;
            this.dgvKnownWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKnownWords.ShowCellErrors = false;
            this.dgvKnownWords.ShowCellToolTips = false;
            this.dgvKnownWords.ShowEditingIcon = false;
            this.dgvKnownWords.ShowRowErrors = false;
            this.dgvKnownWords.Size = new System.Drawing.Size(873, 575);
            this.dgvKnownWords.TabIndex = 5;
            this.dgvKnownWords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKnownWords_CellDoubleClick);
            this.dgvKnownWords.Resize += new System.EventHandler(this.dgvKnownWords_Resize);
            // 
            // Word
            // 
            this.Word.DataPropertyName = "Word";
            this.Word.HeaderText = "单词";
            this.Word.Name = "Word";
            this.Word.ReadOnly = true;
            // 
            // PhoneticSymbols
            // 
            this.PhoneticSymbols.DataPropertyName = "PhoneticSymbols";
            this.PhoneticSymbols.HeaderText = "音标";
            this.PhoneticSymbols.Name = "PhoneticSymbols";
            this.PhoneticSymbols.ReadOnly = true;
            // 
            // Mean
            // 
            this.Mean.DataPropertyName = "Meaning";
            this.Mean.HeaderText = "解释";
            this.Mean.Name = "Mean";
            this.Mean.ReadOnly = true;
            this.Mean.Width = 400;
            // 
            // Sentence
            // 
            this.Sentence.DataPropertyName = "Sentence";
            this.Sentence.HeaderText = "例句";
            this.Sentence.Name = "Sentence";
            this.Sentence.ReadOnly = true;
            this.Sentence.Width = 400;
            // 
            // Source
            // 
            this.Source.DataPropertyName = "Source";
            this.Source.HeaderText = "来源";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // knownContextMenuStrip
            // 
            this.knownContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add2UnknownToolStripMenuItem,
            this.deleteKnownWordToolStripMenuItem,
            this.SoundToolStripMenuItem});
            this.knownContextMenuStrip.Name = "knownContextMenuStrip";
            this.knownContextMenuStrip.Size = new System.Drawing.Size(197, 70);
            // 
            // add2UnknownToolStripMenuItem
            // 
            this.add2UnknownToolStripMenuItem.Name = "add2UnknownToolStripMenuItem";
            this.add2UnknownToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.add2UnknownToolStripMenuItem.Text = "不记得了，加入生词本";
            this.add2UnknownToolStripMenuItem.Click += new System.EventHandler(this.add2UnknownToolStripMenuItem_Click);
            // 
            // deleteKnownWordToolStripMenuItem
            // 
            this.deleteKnownWordToolStripMenuItem.Name = "deleteKnownWordToolStripMenuItem";
            this.deleteKnownWordToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.deleteKnownWordToolStripMenuItem.Text = "不是单词，删除";
            this.deleteKnownWordToolStripMenuItem.Click += new System.EventHandler(this.deleteKnownWordToolStripMenuItem_Click);
            // 
            // SoundToolStripMenuItem
            // 
            this.SoundToolStripMenuItem.Name = "SoundToolStripMenuItem";
            this.SoundToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SoundToolStripMenuItem.Text = "真人发音";
            this.SoundToolStripMenuItem.Click += new System.EventHandler(this.SoundToolStripMenuItem_Click);
            // 
            // btnExportKnownWords
            // 
            this.btnExportKnownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportKnownWords.Location = new System.Drawing.Point(779, 604);
            this.btnExportKnownWords.Name = "btnExportKnownWords";
            this.btnExportKnownWords.Size = new System.Drawing.Size(75, 42);
            this.btnExportKnownWords.TabIndex = 4;
            this.btnExportKnownWords.Text = "导 出";
            this.btnExportKnownWords.UseVisualStyleBackColor = true;
            this.btnExportKnownWords.Click += new System.EventHandler(this.btnExportKnownWords_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddKnownWords);
            this.groupBox1.Controls.Add(this.rtbKnownWords);
            this.groupBox1.Location = new System.Drawing.Point(8, 586);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加熟悉的单词";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "一个单词一行，不要带标点符号";
            // 
            // btnAddKnownWords
            // 
            this.btnAddKnownWords.Location = new System.Drawing.Point(435, 17);
            this.btnAddKnownWords.Name = "btnAddKnownWords";
            this.btnAddKnownWords.Size = new System.Drawing.Size(75, 42);
            this.btnAddKnownWords.TabIndex = 2;
            this.btnAddKnownWords.Text = "添 加";
            this.btnAddKnownWords.UseVisualStyleBackColor = true;
            this.btnAddKnownWords.Click += new System.EventHandler(this.btnAddKnownWords_Click);
            // 
            // rtbKnownWords
            // 
            this.rtbKnownWords.Location = new System.Drawing.Point(6, 18);
            this.rtbKnownWords.Name = "rtbKnownWords";
            this.rtbKnownWords.Size = new System.Drawing.Size(197, 41);
            this.rtbKnownWords.TabIndex = 0;
            this.rtbKnownWords.Text = "";
            this.toolTip1.SetToolTip(this.rtbKnownWords, "请输入您认识的单词，一行一个单词");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txbNewWordSearch);
            this.tabPage2.Controls.Add(this.dgvUnknownWords);
            this.tabPage2.Controls.Add(this.btnExportUnknownWords);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 659);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生词本";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txbNewWordSearch
            // 
            this.txbNewWordSearch.Location = new System.Drawing.Point(8, 6);
            this.txbNewWordSearch.Name = "txbNewWordSearch";
            this.txbNewWordSearch.Size = new System.Drawing.Size(135, 21);
            this.txbNewWordSearch.TabIndex = 7;
            this.txbNewWordSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbNewWordSearch_KeyDown);
            // 
            // dgvUnknownWords
            // 
            this.dgvUnknownWords.AllowUserToAddRows = false;
            this.dgvUnknownWords.AllowUserToDeleteRows = false;
            this.dgvUnknownWords.AllowUserToResizeRows = false;
            this.dgvUnknownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnknownWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnknownWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsStar,
            this.dataGridViewTextBoxColumn1,
            this.音标,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dgvUnknownWords.ContextMenuStrip = this.unknownContextMenuStrip;
            this.dgvUnknownWords.Location = new System.Drawing.Point(8, 33);
            this.dgvUnknownWords.Name = "dgvUnknownWords";
            this.dgvUnknownWords.ReadOnly = true;
            this.dgvUnknownWords.RowHeadersVisible = false;
            this.dgvUnknownWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnknownWords.ShowCellErrors = false;
            this.dgvUnknownWords.ShowCellToolTips = false;
            this.dgvUnknownWords.ShowEditingIcon = false;
            this.dgvUnknownWords.ShowRowErrors = false;
            this.dgvUnknownWords.Size = new System.Drawing.Size(873, 555);
            this.dgvUnknownWords.TabIndex = 6;
            this.dgvUnknownWords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnknownWords_CellClick);
            this.dgvUnknownWords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnknownWords_CellDoubleClick);
            this.dgvUnknownWords.Resize += new System.EventHandler(this.dgvUnknownWords_Resize);
            // 
            // IsStar
            // 
            this.IsStar.DataPropertyName = "IsStar";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Blue;
            this.IsStar.DefaultCellStyle = dataGridViewCellStyle9;
            this.IsStar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IsStar.Frozen = true;
            this.IsStar.HeaderText = "☆";
            this.IsStar.Name = "IsStar";
            this.IsStar.ReadOnly = true;
            this.IsStar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsStar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsStar.Text = "☆";
            this.IsStar.ToolTipText = "如果觉得这个生词很重要，需要优先记忆，可以点亮该星";
            this.IsStar.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn1.HeaderText = "单词";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // 音标
            // 
            this.音标.DataPropertyName = "PhoneticSymbols";
            this.音标.HeaderText = "音标";
            this.音标.Name = "音标";
            this.音标.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Meaning";
            this.dataGridViewTextBoxColumn3.HeaderText = "解释";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 400;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Sentence";
            this.dataGridViewTextBoxColumn2.HeaderText = "例句";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Source";
            this.dataGridViewTextBoxColumn4.HeaderText = "来源";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // unknownContextMenuStrip
            // 
            this.unknownContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.move2KnownToolStripMenuItem,
            this.RemoveWordFromUnknowToolStripMenuItem,
            this.PronunToolStripMenuItem});
            this.unknownContextMenuStrip.Name = "unknownContextMenuStrip";
            this.unknownContextMenuStrip.Size = new System.Drawing.Size(209, 70);
            // 
            // move2KnownToolStripMenuItem
            // 
            this.move2KnownToolStripMenuItem.Name = "move2KnownToolStripMenuItem";
            this.move2KnownToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.move2KnownToolStripMenuItem.Text = "终于记住了！移出生词本";
            this.move2KnownToolStripMenuItem.Click += new System.EventHandler(this.move2KnownToolStripMenuItem_Click);
            // 
            // RemoveWordFromUnknowToolStripMenuItem
            // 
            this.RemoveWordFromUnknowToolStripMenuItem.Name = "RemoveWordFromUnknowToolStripMenuItem";
            this.RemoveWordFromUnknowToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.RemoveWordFromUnknowToolStripMenuItem.Text = "不是单词，删除";
            this.RemoveWordFromUnknowToolStripMenuItem.Click += new System.EventHandler(this.RemoveWordFromUnknowToolStripMenuItem_Click);
            // 
            // PronunToolStripMenuItem
            // 
            this.PronunToolStripMenuItem.Name = "PronunToolStripMenuItem";
            this.PronunToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.PronunToolStripMenuItem.Text = "真人发音";
            this.PronunToolStripMenuItem.Click += new System.EventHandler(this.PronunToolStripMenuItem_Click);
            // 
            // btnExportUnknownWords
            // 
            this.btnExportUnknownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportUnknownWords.Location = new System.Drawing.Point(762, 611);
            this.btnExportUnknownWords.Name = "btnExportUnknownWords";
            this.btnExportUnknownWords.Size = new System.Drawing.Size(75, 42);
            this.btnExportUnknownWords.TabIndex = 5;
            this.btnExportUnknownWords.Text = "导 出";
            this.btnExportUnknownWords.UseVisualStyleBackColor = true;
            this.btnExportUnknownWords.Click += new System.EventHandler(this.btnExportUnknownWords_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnAddNewWords);
            this.groupBox2.Controls.Add(this.rtbNewWords);
            this.groupBox2.Location = new System.Drawing.Point(8, 594);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 67);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加生词";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "一个单词一行，不要带标点符号";
            // 
            // btnAddNewWords
            // 
            this.btnAddNewWords.Location = new System.Drawing.Point(371, 18);
            this.btnAddNewWords.Name = "btnAddNewWords";
            this.btnAddNewWords.Size = new System.Drawing.Size(75, 42);
            this.btnAddNewWords.TabIndex = 2;
            this.btnAddNewWords.Text = "添 加";
            this.btnAddNewWords.UseVisualStyleBackColor = true;
            this.btnAddNewWords.Click += new System.EventHandler(this.btnAddNewWords_Click);
            // 
            // rtbNewWords
            // 
            this.rtbNewWords.Location = new System.Drawing.Point(6, 18);
            this.rtbNewWords.Name = "rtbNewWords";
            this.rtbNewWords.Size = new System.Drawing.Size(143, 43);
            this.rtbNewWords.TabIndex = 0;
            this.rtbNewWords.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txbIgnoreSearch);
            this.tabPage4.Controls.Add(this.dgvIgnores);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(889, 659);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "忽略词";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txbIgnoreSearch
            // 
            this.txbIgnoreSearch.Location = new System.Drawing.Point(8, 6);
            this.txbIgnoreSearch.Name = "txbIgnoreSearch";
            this.txbIgnoreSearch.Size = new System.Drawing.Size(135, 21);
            this.txbIgnoreSearch.TabIndex = 9;
            this.txbIgnoreSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbIgnoreSearch_KeyDown);
            // 
            // dgvIgnores
            // 
            this.dgvIgnores.AllowUserToAddRows = false;
            this.dgvIgnores.AllowUserToDeleteRows = false;
            this.dgvIgnores.AllowUserToResizeRows = false;
            this.dgvIgnores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIgnores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIgnores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn13});
            this.dgvIgnores.Location = new System.Drawing.Point(8, 33);
            this.dgvIgnores.Name = "dgvIgnores";
            this.dgvIgnores.ReadOnly = true;
            this.dgvIgnores.RowHeadersVisible = false;
            this.dgvIgnores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIgnores.ShowCellErrors = false;
            this.dgvIgnores.ShowCellToolTips = false;
            this.dgvIgnores.ShowEditingIcon = false;
            this.dgvIgnores.ShowRowErrors = false;
            this.dgvIgnores.Size = new System.Drawing.Size(873, 555);
            this.dgvIgnores.TabIndex = 8;
            this.dgvIgnores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIgnores_CellClick);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "ButtonText";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn1.Frozen = true;
            this.dataGridViewButtonColumn1.HeaderText = "移除";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "移除";
            this.dataGridViewButtonColumn1.ToolTipText = "也许应该记住，别忽略了！";
            this.dataGridViewButtonColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn9.HeaderText = "单词";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CreateTime";
            this.dataGridViewTextBoxColumn13.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 150;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCleanAll);
            this.tabPage3.Controls.Add(this.dgvQueryResult);
            this.tabPage3.Controls.Add(this.txbWordQueryInput);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(889, 659);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "单词记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCleanAll
            // 
            this.btnCleanAll.Location = new System.Drawing.Point(722, 13);
            this.btnCleanAll.Name = "btnCleanAll";
            this.btnCleanAll.Size = new System.Drawing.Size(93, 21);
            this.btnCleanAll.TabIndex = 8;
            this.btnCleanAll.Text = "清空所有记录";
            this.btnCleanAll.UseVisualStyleBackColor = true;
            this.btnCleanAll.Click += new System.EventHandler(this.btnCleanAll_Click);
            // 
            // dgvQueryResult
            // 
            this.dgvQueryResult.AllowUserToAddRows = false;
            this.dgvQueryResult.AllowUserToDeleteRows = false;
            this.dgvQueryResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column1,
            this.IsNewWord,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.dgvQueryResult.ContextMenuStrip = this.allWordContextMenuStrip;
            this.dgvQueryResult.Location = new System.Drawing.Point(10, 41);
            this.dgvQueryResult.Name = "dgvQueryResult";
            this.dgvQueryResult.ReadOnly = true;
            this.dgvQueryResult.RowHeadersVisible = false;
            this.dgvQueryResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueryResult.ShowCellErrors = false;
            this.dgvQueryResult.ShowCellToolTips = false;
            this.dgvQueryResult.ShowEditingIcon = false;
            this.dgvQueryResult.ShowRowErrors = false;
            this.dgvQueryResult.Size = new System.Drawing.Size(873, 620);
            this.dgvQueryResult.TabIndex = 7;
            this.dgvQueryResult.Resize += new System.EventHandler(this.dgvQueryResult_Resize);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn5.HeaderText = "单词";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PhoneticSymbols";
            this.Column1.HeaderText = "音标";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // IsNewWord
            // 
            this.IsNewWord.DataPropertyName = "IsNewWord";
            this.IsNewWord.HeaderText = "生词";
            this.IsNewWord.Name = "IsNewWord";
            this.IsNewWord.ReadOnly = true;
            this.IsNewWord.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Meaning";
            this.dataGridViewTextBoxColumn7.HeaderText = "解释";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 400;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Sentence";
            this.dataGridViewTextBoxColumn6.HeaderText = "例句";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 400;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Source";
            this.dataGridViewTextBoxColumn8.HeaderText = "来源";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // txbWordQueryInput
            // 
            this.txbWordQueryInput.Location = new System.Drawing.Point(55, 14);
            this.txbWordQueryInput.Name = "txbWordQueryInput";
            this.txbWordQueryInput.Size = new System.Drawing.Size(140, 21);
            this.txbWordQueryInput.TabIndex = 2;
            this.txbWordQueryInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbWordQueryInput_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "单词：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(232, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // allWordContextMenuStrip
            // 
            this.allWordContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allAdd2UnknowntoolStripMenuItem,
            this.allRememberToolStripMenuItem,
            this.allIgnoretoolStripMenuItem,
            this.allSoundtoolStripMenuItem});
            this.allWordContextMenuStrip.Name = "knownContextMenuStrip";
            this.allWordContextMenuStrip.Size = new System.Drawing.Size(197, 114);
            // 
            // allAdd2UnknowntoolStripMenuItem
            // 
            this.allAdd2UnknowntoolStripMenuItem.Name = "allAdd2UnknowntoolStripMenuItem";
            this.allAdd2UnknowntoolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.allAdd2UnknowntoolStripMenuItem.Text = "不记得了，加入生词本";
            this.allAdd2UnknowntoolStripMenuItem.Click += new System.EventHandler(this.allAdd2UnknowntoolStripMenuItem_Click);
            // 
            // allIgnoretoolStripMenuItem
            // 
            this.allIgnoretoolStripMenuItem.Name = "allIgnoretoolStripMenuItem";
            this.allIgnoretoolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.allIgnoretoolStripMenuItem.Text = "不是单词，删除";
            this.allIgnoretoolStripMenuItem.Click += new System.EventHandler(this.allIgnoretoolStripMenuItem_Click);
            // 
            // allSoundtoolStripMenuItem
            // 
            this.allSoundtoolStripMenuItem.Name = "allSoundtoolStripMenuItem";
            this.allSoundtoolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.allSoundtoolStripMenuItem.Text = "真人发音";
            this.allSoundtoolStripMenuItem.Click += new System.EventHandler(this.allSoundtoolStripMenuItem_Click);
            // 
            // allRememberToolStripMenuItem
            // 
            this.allRememberToolStripMenuItem.Name = "allRememberToolStripMenuItem";
            this.allRememberToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.allRememberToolStripMenuItem.Text = "记住了，不再陌生！";
            this.allRememberToolStripMenuItem.Click += new System.EventHandler(this.allRememberToolStripMenuItem_Click);
            // 
            // UserVocabularyMgtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 685);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserVocabularyMgtForm";
            this.Text = "词汇管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserVocabularyMgtForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnownWords)).EndInit();
            this.knownContextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknownWords)).EndInit();
            this.unknownContextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIgnores)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).EndInit();
            this.allWordContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddKnownWords;
        private System.Windows.Forms.RichTextBox rtbKnownWords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddNewWords;
        private System.Windows.Forms.RichTextBox rtbNewWords;
        private System.Windows.Forms.Button btnExportKnownWords;
        private System.Windows.Forms.Button btnExportUnknownWords;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txbWordQueryInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvKnownWords;
        private System.Windows.Forms.DataGridView dgvUnknownWords;
        private System.Windows.Forms.ContextMenuStrip knownContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip unknownContextMenuStrip;
        private System.Windows.Forms.DataGridView dgvQueryResult;
        private System.Windows.Forms.ToolStripMenuItem add2UnknownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem move2KnownToolStripMenuItem;
        private System.Windows.Forms.Button btnCleanAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneticSymbols;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mean;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sentence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsNewWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ToolStripMenuItem deleteKnownWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SoundToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem RemoveWordFromUnknowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PronunToolStripMenuItem;
        private System.Windows.Forms.DataGridViewButtonColumn IsStar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 音标;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNewWordSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txbIgnoreSearch;
        private System.Windows.Forms.DataGridView dgvIgnores;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.ContextMenuStrip allWordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem allAdd2UnknowntoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allIgnoretoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allSoundtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allRememberToolStripMenuItem;
    }
}