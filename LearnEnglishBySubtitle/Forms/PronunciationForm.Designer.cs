namespace Studyzy.LearnEnglishBySubtitle.Forms
{
    partial class PronunciationForm
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
            this.rbUK = new System.Windows.Forms.RadioButton();
            this.rbUS = new System.Windows.Forms.RadioButton();
            this.cbxDownload = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbUK
            // 
            this.rbUK.AutoSize = true;
            this.rbUK.Checked = true;
            this.rbUK.Location = new System.Drawing.Point(23, 26);
            this.rbUK.Name = "rbUK";
            this.rbUK.Size = new System.Drawing.Size(73, 17);
            this.rbUK.TabIndex = 0;
            this.rbUK.Text = "英式发音";
            this.rbUK.UseVisualStyleBackColor = true;
            // 
            // rbUS
            // 
            this.rbUS.AutoSize = true;
            this.rbUS.Location = new System.Drawing.Point(128, 26);
            this.rbUS.Name = "rbUS";
            this.rbUS.Size = new System.Drawing.Size(73, 17);
            this.rbUS.TabIndex = 0;
            this.rbUS.Text = "美式发音";
            this.rbUS.UseVisualStyleBackColor = true;
            // 
            // cbxDownload
            // 
            this.cbxDownload.AutoSize = true;
            this.cbxDownload.Checked = true;
            this.cbxDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDownload.Location = new System.Drawing.Point(23, 75);
            this.cbxDownload.Name = "cbxDownload";
            this.cbxDownload.Size = new System.Drawing.Size(146, 17);
            this.cbxDownload.TabIndex = 1;
            this.cbxDownload.Text = "自动下载所有单词发音";
            this.cbxDownload.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(241, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PronunciationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 160);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxDownload);
            this.Controls.Add(this.rbUS);
            this.Controls.Add(this.rbUK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PronunciationForm";
            this.Text = "PronunciationForm";
            this.Load += new System.EventHandler(this.PronunciationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbUK;
        private System.Windows.Forms.RadioButton rbUS;
        private System.Windows.Forms.CheckBox cbxDownload;
        private System.Windows.Forms.Button btnOK;
    }
}