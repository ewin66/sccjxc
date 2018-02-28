namespace TAddWinform
{
    partial class FormUserEidt
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCanCel = new System.Windows.Forms.Button();
            this.chkRole = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.labOld = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(115, 21);
            this.txtName.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(37, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCanCel
            // 
            this.btnCanCel.Location = new System.Drawing.Point(134, 100);
            this.btnCanCel.Name = "btnCanCel";
            this.btnCanCel.Size = new System.Drawing.Size(75, 23);
            this.btnCanCel.TabIndex = 2;
            this.btnCanCel.Text = "取消";
            this.btnCanCel.UseVisualStyleBackColor = true;
            this.btnCanCel.Click += new System.EventHandler(this.btnCanCel_Click);
            // 
            // chkRole
            // 
            this.chkRole.AutoSize = true;
            this.chkRole.Location = new System.Drawing.Point(92, 78);
            this.chkRole.Name = "chkRole";
            this.chkRole.Size = new System.Drawing.Size(84, 16);
            this.chkRole.TabIndex = 3;
            this.chkRole.Text = "超级管理员";
            this.chkRole.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(92, 47);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(115, 21);
            this.txtPassWord.TabIndex = 1;
            // 
            // labOld
            // 
            this.labOld.AutoSize = true;
            this.labOld.Location = new System.Drawing.Point(37, 125);
            this.labOld.Name = "labOld";
            this.labOld.Size = new System.Drawing.Size(0, 12);
            this.labOld.TabIndex = 4;
            this.labOld.Visible = false;
            // 
            // FormUserEidt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 149);
            this.Controls.Add(this.labOld);
            this.Controls.Add(this.chkRole);
            this.Controls.Add(this.btnCanCel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormUserEidt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户编辑";
            this.Load += new System.EventHandler(this.FormMethodEidt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCanCel;
        private System.Windows.Forms.CheckBox chkRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label labOld;
    }
}