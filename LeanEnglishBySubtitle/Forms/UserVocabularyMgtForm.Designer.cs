namespace Studyzy.LeanEnglishBySubtitle.Forms
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
            this.btnToUnknown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxKnownList = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSetThemKnown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxUnknownList = new System.Windows.Forms.CheckedListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 722);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnToUnknown);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbxKnownList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 696);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "熟悉的单词";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnToUnknown
            // 
            this.btnToUnknown.Location = new System.Drawing.Point(722, 17);
            this.btnToUnknown.Name = "btnToUnknown";
            this.btnToUnknown.Size = new System.Drawing.Size(75, 42);
            this.btnToUnknown.TabIndex = 2;
            this.btnToUnknown.Text = "放到生词本";
            this.btnToUnknown.UseVisualStyleBackColor = true;
            this.btnToUnknown.Click += new System.EventHandler(this.btnToUnknown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选中的这些单词其实我并不是很熟悉，还是放到生词本中吧：";
            // 
            // cbxKnownList
            // 
            this.cbxKnownList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxKnownList.FormattingEnabled = true;
            this.cbxKnownList.Location = new System.Drawing.Point(3, 3);
            this.cbxKnownList.Name = "cbxKnownList";
            this.cbxKnownList.Size = new System.Drawing.Size(293, 690);
            this.cbxKnownList.TabIndex = 0;
            this.cbxKnownList.SelectedIndexChanged += new System.EventHandler(this.cbxKnownList_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSetThemKnown);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbxUnknownList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(823, 696);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "生词本";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSetThemKnown
            // 
            this.btnSetThemKnown.Location = new System.Drawing.Point(725, 19);
            this.btnSetThemKnown.Name = "btnSetThemKnown";
            this.btnSetThemKnown.Size = new System.Drawing.Size(75, 38);
            this.btnSetThemKnown.TabIndex = 3;
            this.btnSetThemKnown.Text = "标记为熟悉";
            this.btnSetThemKnown.UseVisualStyleBackColor = true;
            this.btnSetThemKnown.Click += new System.EventHandler(this.btnSetThemKnown_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "经过不断努力，选中的单词我终于记住了，放到熟悉的单词列表里吧：";
            // 
            // cbxUnknownList
            // 
            this.cbxUnknownList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxUnknownList.FormattingEnabled = true;
            this.cbxUnknownList.Location = new System.Drawing.Point(3, 3);
            this.cbxUnknownList.Name = "cbxUnknownList";
            this.cbxUnknownList.Size = new System.Drawing.Size(293, 690);
            this.cbxUnknownList.TabIndex = 1;
            this.cbxUnknownList.SelectedIndexChanged += new System.EventHandler(this.cbxUnknownList_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // UserVocabularyMgtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 722);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserVocabularyMgtForm";
            this.Text = "UserVocabularyMgtForm";
            this.Load += new System.EventHandler(this.UserVocabularyMgtForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
    }
}