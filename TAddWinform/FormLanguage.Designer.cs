namespace TAddWinform
{
    partial class FormLanguage
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmblanguage = new System.Windows.Forms.ComboBox();
            this.btnCanCel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "语言/language";
            // 
            // cmblanguage
            // 
            this.cmblanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblanguage.FormattingEnabled = true;
            this.cmblanguage.Items.AddRange(new object[] {
            "Chinese",
            "English"});
            this.cmblanguage.Location = new System.Drawing.Point(125, 24);
            this.cmblanguage.Name = "cmblanguage";
            this.cmblanguage.Size = new System.Drawing.Size(128, 20);
            this.cmblanguage.TabIndex = 1;
            // 
            // btnCanCel
            // 
            this.btnCanCel.Location = new System.Drawing.Point(38, 74);
            this.btnCanCel.Name = "btnCanCel";
            this.btnCanCel.Size = new System.Drawing.Size(81, 23);
            this.btnCanCel.TabIndex = 2;
            this.btnCanCel.Text = "取消/CanCel";
            this.btnCanCel.UseVisualStyleBackColor = true;
            this.btnCanCel.Click += new System.EventHandler(this.btnCanCel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(169, 74);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定/OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 109);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCanCel);
            this.Controls.Add(this.cmblanguage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语言/language";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmblanguage;
        private System.Windows.Forms.Button btnCanCel;
        private System.Windows.Forms.Button btnOK;
    }
}