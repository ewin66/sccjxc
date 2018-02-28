using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TAddWinform
{
    public partial class FormPwd : DevExpress.XtraEditors.XtraForm
    {
        private static string strMsg = string.Empty;
        private static string alertMsg = string.Empty;

        private static string UpdateMsg = string.Empty;
        public FormPwd()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string cUserName = CurrentUser.Instance.UserName;
            string sql = " SELECT isnull(cPassWord,999) as pwd FROM "+Program.DataBaseName+"..Tbl_User where  cUserName='" + cUserName + "' ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (ClsSystem.gnvl(dt.Rows[0]["pwd"], "") != "999" && ClsSystem.gnvl(dt.Rows[0]["pwd"], "") != CommonHelper.GetMD5(this.txtOld.Text))
            {
                MessageBox.Show(strMsg,strMsg, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (string.IsNullOrEmpty(this.txtNew.Text))
            {
                sql = " update " + Program.DataBaseName + "..Tbl_User set cPassWord=null where cUserName='" + cUserName + "'";
            }
            else
            {
                sql = " update " + Program.DataBaseName + "..Tbl_User set cPassWord='" + CommonHelper.GetMD5(this.txtNew.Text) + "' where cUserName='" + cUserName + "'";
            }
            int count = DbHelperSQL.ExecuteSql(sql);
            if (count > 0)
            {
               // MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Update ", strMsg, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void FormPwd_Load(object sender, EventArgs e)
        {
            if (GlobalParameters.iLanugage > 10)
            {
                this.Text = "Change Password";
                label1.Text = "Old Password";
                label2.Text = "New Password";

                btnOK.Text = "OK";
                btnCanCel.Text = "Cancel";

                strMsg = "Old Password incorrect";
                alertMsg = "Alert";
                UpdateMsg = "Update fail!";
            }
            else {
                alertMsg = "提示";
                strMsg = "原密码错误，请重新输入！";
                UpdateMsg = "操作失败！";
            }
        }
    }
}
