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
            this.dgvKnownWords = new System.Windows.Forms.DataGridView();
            this.knownContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.add2UnknownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportKnownWords = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddKnownWords = new System.Windows.Forms.Button();
            this.rtbKnownWords = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvUnknownWords = new System.Windows.Forms.DataGridView();
            this.unknownContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.move2KnownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportUnknownWords = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddNewWords = new System.Windows.Forms.Button();
            this.rtbNewWords = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCleanAll = new System.Windows.Forms.Button();
            this.dgvQueryResult = new System.Windows.Forms.DataGridView();
            this.txbWordQueryInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mean = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sentence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNewWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnownWords)).BeginInit();
            this.knownContextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknownWords)).BeginInit();
            this.unknownContextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(897, 750);
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
            this.tabPage1.Size = new System.Drawing.Size(889, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "熟悉的单词";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvKnownWords
            // 
            this.dgvKnownWords.AllowUserToAddRows = false;
            this.dgvKnownWords.AllowUserToDeleteRows = false;
            this.dgvKnownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKnownWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKnownWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
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
            this.dgvKnownWords.Size = new System.Drawing.Size(873, 395);
            this.dgvKnownWords.TabIndex = 5;
            // 
            // knownContextMenuStrip
            // 
            this.knownContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add2UnknownToolStripMenuItem});
            this.knownContextMenuStrip.Name = "knownContextMenuStrip";
            this.knownContextMenuStrip.Size = new System.Drawing.Size(186, 26);
            // 
            // add2UnknownToolStripMenuItem
            // 
            this.add2UnknownToolStripMenuItem.Name = "add2UnknownToolStripMenuItem";
            this.add2UnknownToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.add2UnknownToolStripMenuItem.Text = "不记得了,加入生词本";
            this.add2UnknownToolStripMenuItem.Click += new System.EventHandler(this.add2UnknownToolStripMenuItem_Click);
            // 
            // btnExportKnownWords
            // 
            this.btnExportKnownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportKnownWords.Location = new System.Drawing.Point(779, 426);
            this.btnExportKnownWords.Name = "btnExportKnownWords";
            this.btnExportKnownWords.Size = new System.Drawing.Size(75, 46);
            this.btnExportKnownWords.TabIndex = 4;
            this.btnExportKnownWords.Text = "导 出";
            this.btnExportKnownWords.UseVisualStyleBackColor = true;
            this.btnExportKnownWords.Click += new System.EventHandler(this.btnExportKnownWords_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnAddKnownWords);
            this.groupBox1.Controls.Add(this.rtbKnownWords);
            this.groupBox1.Location = new System.Drawing.Point(8, 407);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加熟悉的单词";
            // 
            // btnAddKnownWords
            // 
            this.btnAddKnownWords.Location = new System.Drawing.Point(363, 17);
            this.btnAddKnownWords.Name = "btnAddKnownWords";
            this.btnAddKnownWords.Size = new System.Drawing.Size(75, 46);
            this.btnAddKnownWords.TabIndex = 2;
            this.btnAddKnownWords.Text = "添 加";
            this.btnAddKnownWords.UseVisualStyleBackColor = true;
            this.btnAddKnownWords.Click += new System.EventHandler(this.btnAddKnownWords_Click);
            // 
            // rtbKnownWords
            // 
            this.rtbKnownWords.Location = new System.Drawing.Point(6, 19);
            this.rtbKnownWords.Name = "rtbKnownWords";
            this.rtbKnownWords.Size = new System.Drawing.Size(197, 44);
            this.rtbKnownWords.TabIndex = 0;
            this.rtbKnownWords.Text = "";
            this.toolTip1.SetToolTip(this.rtbKnownWords, "请输入您认识的单词，一行一个单词");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvUnknownWords);
            this.tabPage2.Controls.Add(this.btnExportUnknownWords);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 724);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生词本";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvUnknownWords
            // 
            this.dgvUnknownWords.AllowUserToAddRows = false;
            this.dgvUnknownWords.AllowUserToDeleteRows = false;
            this.dgvUnknownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnknownWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnknownWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            this.dgvUnknownWords.ContextMenuStrip = this.unknownContextMenuStrip;
            this.dgvUnknownWords.Location = new System.Drawing.Point(8, 6);
            this.dgvUnknownWords.Name = "dgvUnknownWords";
            this.dgvUnknownWords.ReadOnly = true;
            this.dgvUnknownWords.RowHeadersVisible = false;
            this.dgvUnknownWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnknownWords.ShowCellErrors = false;
            this.dgvUnknownWords.ShowCellToolTips = false;
            this.dgvUnknownWords.ShowEditingIcon = false;
            this.dgvUnknownWords.ShowRowErrors = false;
            this.dgvUnknownWords.Size = new System.Drawing.Size(873, 631);
            this.dgvUnknownWords.TabIndex = 6;
            // 
            // unknownContextMenuStrip
            // 
            this.unknownContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.move2KnownToolStripMenuItem});
            this.unknownContextMenuStrip.Name = "unknownContextMenuStrip";
            this.unknownContextMenuStrip.Size = new System.Drawing.Size(171, 26);
            // 
            // move2KnownToolStripMenuItem
            // 
            this.move2KnownToolStripMenuItem.Name = "move2KnownToolStripMenuItem";
            this.move2KnownToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.move2KnownToolStripMenuItem.Text = "终于记住了！移除";
            this.move2KnownToolStripMenuItem.Click += new System.EventHandler(this.move2KnownToolStripMenuItem_Click);
            // 
            // btnExportUnknownWords
            // 
            this.btnExportUnknownWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportUnknownWords.Location = new System.Drawing.Point(762, 662);
            this.btnExportUnknownWords.Name = "btnExportUnknownWords";
            this.btnExportUnknownWords.Size = new System.Drawing.Size(75, 46);
            this.btnExportUnknownWords.TabIndex = 5;
            this.btnExportUnknownWords.Text = "导 出";
            this.btnExportUnknownWords.UseVisualStyleBackColor = true;
            this.btnExportUnknownWords.Click += new System.EventHandler(this.btnExportUnknownWords_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnAddNewWords);
            this.groupBox2.Controls.Add(this.rtbNewWords);
            this.groupBox2.Location = new System.Drawing.Point(8, 643);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加生词";
            // 
            // btnAddNewWords
            // 
            this.btnAddNewWords.Location = new System.Drawing.Point(371, 19);
            this.btnAddNewWords.Name = "btnAddNewWords";
            this.btnAddNewWords.Size = new System.Drawing.Size(75, 46);
            this.btnAddNewWords.TabIndex = 2;
            this.btnAddNewWords.Text = "添 加";
            this.btnAddNewWords.UseVisualStyleBackColor = true;
            this.btnAddNewWords.Click += new System.EventHandler(this.btnAddNewWords_Click);
            // 
            // rtbNewWords
            // 
            this.rtbNewWords.Location = new System.Drawing.Point(6, 19);
            this.rtbNewWords.Name = "rtbNewWords";
            this.rtbNewWords.Size = new System.Drawing.Size(263, 46);
            this.rtbNewWords.TabIndex = 0;
            this.rtbNewWords.Text = "";
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
            this.tabPage3.Size = new System.Drawing.Size(889, 724);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "单词记录";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCleanAll
            // 
            this.btnCleanAll.Location = new System.Drawing.Point(722, 14);
            this.btnCleanAll.Name = "btnCleanAll";
            this.btnCleanAll.Size = new System.Drawing.Size(93, 23);
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
            this.IsNewWord,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.dgvQueryResult.ContextMenuStrip = this.unknownContextMenuStrip;
            this.dgvQueryResult.Location = new System.Drawing.Point(10, 44);
            this.dgvQueryResult.Name = "dgvQueryResult";
            this.dgvQueryResult.ReadOnly = true;
            this.dgvQueryResult.RowHeadersVisible = false;
            this.dgvQueryResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueryResult.ShowCellErrors = false;
            this.dgvQueryResult.ShowCellToolTips = false;
            this.dgvQueryResult.ShowEditingIcon = false;
            this.dgvQueryResult.ShowRowErrors = false;
            this.dgvQueryResult.Size = new System.Drawing.Size(873, 672);
            this.dgvQueryResult.TabIndex = 7;
            // 
            // txbWordQueryInput
            // 
            this.txbWordQueryInput.Location = new System.Drawing.Point(55, 15);
            this.txbWordQueryInput.Name = "txbWordQueryInput";
            this.txbWordQueryInput.Size = new System.Drawing.Size(140, 20);
            this.txbWordQueryInput.TabIndex = 2;
            this.txbWordQueryInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbWordQueryInput_KeyDown);
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
            // Word
            // 
            this.Word.DataPropertyName = "Word";
            this.Word.HeaderText = "单词";
            this.Word.Name = "Word";
            this.Word.ReadOnly = true;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn1.HeaderText = "单词";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
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
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn5.HeaderText = "单词";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
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
            // UserVocabularyMgtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 750);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserVocabularyMgtForm";
            this.Text = "词汇管理";
            this.Load += new System.EventHandler(this.UserVocabularyMgtForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnownWords)).EndInit();
            this.knownContextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknownWords)).EndInit();
            this.unknownContextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Mean;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sentence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsNewWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}