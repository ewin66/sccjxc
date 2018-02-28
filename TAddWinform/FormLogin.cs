using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace TAddWinform {
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm {

        public static string chkUserName = string.Empty;
        public static string chkZt = string.Empty;

        public static string ShowServer = string.Empty;

        public static string ChkUser = string.Empty;

        public static string ChkLogin = string.Empty;
        public FormLogin() {
            InitializeComponent();
            this.txtUser.Text = LogHelper.Read(System.Environment.CurrentDirectory + "\\user.txt");
        }



        public string CheckLogin() {
            string msg = string.Empty;
            if (string.IsNullOrEmpty(this.txtUser.Text)) {
                msg += chkUserName + "\r\n";
            }
            return msg;
        }

        //登录按钮
        private void btnLogin_Click(object sender, EventArgs e) {
            string str = CheckLogin();

            if (!string.IsNullOrEmpty(str)) {
                MessageBox.Show(ShowServer, GlobalParameters.msg);
                return;
            }
            StringBuilder sbq = new StringBuilder();

            sbq.Remove(0, sbq.Length);
            sbq.AppendFormat(" SELECT isnull(password,999) as pwd,isadmin FROM " + Program.DataBaseName + "..MD_User where  UserCode='{0}' ", this.txtUser.Text.Trim());
            DataTable usertable = DbHelperSQL.Query(sbq.ToString()).Tables[0];
            if (usertable.Rows.Count == 0) {
                MessageBox.Show(ChkUser, GlobalParameters.msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usertable.Rows.Count > 0) {
                string sql = "update " + Program.DataBaseName + "..MD_User set LoginTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where UserCode='" + this.txtUser.Text.Trim() + "'";
                DbHelperSQL.ExecuteSql(sql);
                CurrentUser.Instance.UserName = this.txtUser.Text.Trim();
                CurrentUser.Instance.IsAdmin = Convert.ToBoolean(usertable.Rows[0]["isadmin"]);
                //GlobalParameters.Company = ClsSystem.gnvl(this.cmbZT.Text, "");
                DialogResult = DialogResult.OK;

                //GlobalParameters.ConnectionString = GlobalParameters.ConnectionString.Replace(Program.DataBaseName, cmbZT.SelectedValue.ToString()); ;
                LogHelper.Write(this.txtUser.Text.Trim(), System.Environment.CurrentDirectory + "\\user.txt");
                FormMain formMain = new FormMain();
                formMain.Show();
                this.Close();
            }
        }

        //取消按钮
        private void btnExit_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void FormLogin_Load(object sender, EventArgs e) {
            SetLanguage();
            comboBox1.SelectedIndex = 0;
            //保存当前登录用户至缓存
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (ClsSystem.gnvl(comboBox1.SelectedItem, "") == "English") {
                GlobalParameters.iLanugage = 100;
            } else {

                GlobalParameters.iLanugage = 0;
            }
            SetLanguage();
        }

        public void SetLanguage() {
            if (GlobalParameters.iLanugage > 10) {
                this.Text = "Login";
                this.btnLogin.Text = "Login";
                this.btnExit.Text = "Cancel";
                this.labUser.Text = "User Name";
                this.labPWD.Text = "Password";
                this.lang.Text = "Language";
                this.labzt.Text = "Account Book";
                chkUserName = "User Name is incorrect";
                chkZt = "Account Book is incorrect";
                ShowServer = "Server is is incorrect";
                ChkUser = "User Name is incorrect";
                ChkLogin = "User Name or Password is incorrect";
            } else {
                this.Text = "登录";
                this.btnLogin.Text = "确定";
                this.btnExit.Text = "退出";
                this.labUser.Text = "用户";
                this.labPWD.Text = "密码";
                this.lang.Text = "语言区域";
                this.labzt.Text = "帐套名";
                chkUserName = "用户名不能为空！";
                chkZt = "账套信息不能为空！";
                ShowServer = "服务器链接失败！";
                ChkUser = "用户名不存在！";
                ChkLogin = "用户名或密码不对！";
            }
        }
    }
}
