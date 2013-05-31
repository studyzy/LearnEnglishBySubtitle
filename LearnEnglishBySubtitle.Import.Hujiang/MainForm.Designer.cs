namespace Studyzy.LearnEnglishBySubtitle.Import.Hujiang
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label2 = new System.Windows.Forms.Label();
            this.txbUserId = new System.Windows.Forms.TextBox();
            this.btnSyncNewWords = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "沪江Id：";
            // 
            // txbUserId
            // 
            this.txbUserId.Location = new System.Drawing.Point(83, 12);
            this.txbUserId.Name = "txbUserId";
            this.txbUserId.Size = new System.Drawing.Size(100, 21);
            this.txbUserId.TabIndex = 14;
            this.txbUserId.Text = "11009764";
            // 
            // btnSyncNewWords
            // 
            this.btnSyncNewWords.Location = new System.Drawing.Point(207, 10);
            this.btnSyncNewWords.Name = "btnSyncNewWords";
            this.btnSyncNewWords.Size = new System.Drawing.Size(90, 23);
            this.btnSyncNewWords.TabIndex = 13;
            this.btnSyncNewWords.Text = "读取词场数据";
            this.btnSyncNewWords.UseVisualStyleBackColor = true;
            this.btnSyncNewWords.Click += new System.EventHandler(this.btnSyncNewWords_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(472, 397);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 448);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbUserId);
            this.Controls.Add(this.btnSyncNewWords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "沪江开心词场数据导入";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbUserId;
        private System.Windows.Forms.Button btnSyncNewWords;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

