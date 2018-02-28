namespace TAddWinform
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labUser = new System.Windows.Forms.Label();
            this.labPWD = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.imgLogin = new DevExpress.XtraEditors.PictureEdit();
            this.labzt = new System.Windows.Forms.Label();
            this.cmbZT = new System.Windows.Forms.ComboBox();
            this.lang = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labUser
            // 
            this.labUser.AutoSize = true;
            this.labUser.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labUser.Location = new System.Drawing.Point(124, 19);
            this.labUser.Name = "labUser";
            this.labUser.Size = new System.Drawing.Size(31, 14);
            this.labUser.TabIndex = 1;
            this.labUser.Text = "用户";
            this.labUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPWD
            // 
            this.labPWD.AutoSize = true;
            this.labPWD.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labPWD.Location = new System.Drawing.Point(124, 44);
            this.labPWD.Name = "labPWD";
            this.labPWD.Size = new System.Drawing.Size(31, 14);
            this.labPWD.TabIndex = 2;
            this.labPWD.Text = "密码";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(197, 16);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(160, 22);
            this.txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(197, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(160, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(160, 135);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Enter += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(257, 135);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imgLogin
            // 
            this.imgLogin.EditValue = global::TAddWinform.Properties.Resources.Login;
            this.imgLogin.Location = new System.Drawing.Point(7, 16);
            this.imgLogin.Name = "imgLogin";
            this.imgLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imgLogin.Properties.ReadOnly = true;
            this.imgLogin.Properties.ShowMenu = false;
            this.imgLogin.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.imgLogin.Size = new System.Drawing.Size(79, 83);
            this.imgLogin.TabIndex = 7;
            // 
            // labzt
            // 
            this.labzt.AutoSize = true;
            this.labzt.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labzt.Location = new System.Drawing.Point(124, 94);
            this.labzt.Name = "labzt";
            this.labzt.Size = new System.Drawing.Size(43, 14);
            this.labzt.TabIndex = 1;
            this.labzt.Text = "帐套名";
            // 
            // cmbZT
            // 
            this.cmbZT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZT.FormattingEnabled = true;
            this.cmbZT.Location = new System.Drawing.Point(197, 91);
            this.cmbZT.Name = "cmbZT";
            this.cmbZT.Size = new System.Drawing.Size(160, 22);
            this.cmbZT.TabIndex = 8;
            // 
            // lang
            // 
            this.lang.AutoSize = true;
            this.lang.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lang.Location = new System.Drawing.Point(124, 69);
            this.lang.Name = "lang";
            this.lang.Size = new System.Drawing.Size(55, 14);
            this.lang.TabIndex = 1;
            this.lang.Text = "语言区域";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "中文",
            "English"});
            this.comboBox1.Location = new System.Drawing.Point(197, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 22);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(424, 197);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbZT);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.imgLogin);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lang);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labzt);
            this.Controls.Add(this.labPWD);
            this.Controls.Add(this.labUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labUser;
        private System.Windows.Forms.Label labPWD;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraEditors.PictureEdit imgLogin;
        private System.Windows.Forms.Label labzt;
        private System.Windows.Forms.ComboBox cmbZT;
        private System.Windows.Forms.Label lang;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}
