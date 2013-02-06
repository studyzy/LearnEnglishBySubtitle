namespace Studyzy.LeanEnglishBySubtitle
{
    partial class FillDictionaryForm
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
            this.btnSelectLd2File = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLd2File = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectLd2File
            // 
            this.btnSelectLd2File.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectLd2File.Location = new System.Drawing.Point(352, 9);
            this.btnSelectLd2File.Name = "btnSelectLd2File";
            this.btnSelectLd2File.Size = new System.Drawing.Size(38, 23);
            this.btnSelectLd2File.TabIndex = 0;
            this.btnSelectLd2File.Text = "...";
            this.btnSelectLd2File.UseVisualStyleBackColor = true;
            this.btnSelectLd2File.Click += new System.EventHandler(this.btnSelectLd2File_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "LD2字典：";
            // 
            // txbLd2File
            // 
            this.txbLd2File.Location = new System.Drawing.Point(63, 9);
            this.txbLd2File.Name = "txbLd2File";
            this.txbLd2File.Size = new System.Drawing.Size(283, 21);
            this.txbLd2File.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(14, 62);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(464, 338);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(403, 12);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 4;
            this.btnParse.Text = "解析";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // FillDictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 412);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txbLd2File);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectLd2File);
            this.Name = "FillDictionaryForm";
            this.Text = "FillDictionaryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectLd2File;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLd2File;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnParse;
    }
}