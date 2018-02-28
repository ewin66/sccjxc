using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TAddWinform
{
    public partial class FormUserEidt : Form
    {
        public bool IsAddNew { get; set; }
        public int Id { get; set; }
        public FormUserEidt()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql = " select cUserName from " + Program.DataBaseName + "..Tbl_User where cUserName='" + this.txtName.Text.Trim() + "'";
            if (IsAddNew == false)
            {
                sql += " and id<>" + this.Id;
            }
            try
            {
                object obj = DbHelperSQL.GetSingle(sql);
                if (null != obj)
                {
                    MessageBox.Show("用户名已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                int count = 0;
                if (IsAddNew)
                {
                    sql = " insert into " + Program.DataBaseName + "..Tbl_User(cUserName,cPassWord,is_Admin) values(@cUserName,@cPassWord,@is_Admin) ";
                    count = DbHelperSQL.ExecuteSql(sql, new SqlParameter[] { new SqlParameter("@cUserName",this.txtName.Text.Trim()),
                                                                             new SqlParameter("@cPassWord", CommonHelper.GetMD5(this.txtPassWord.Text)),
                                                                             new SqlParameter("@is_Admin", chkRole.Checked?1:0 ) });
                    if (string.IsNullOrEmpty(this.txtPassWord.Text))
                    {
                        sql = " update " + Program.DataBaseName + "..Tbl_User set cPassWord=null where cUserName='" + this.txtName.Text.Trim() + "'";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.txtPassWord.Text.Trim()))
                    {
                        sql = " update " + Program.DataBaseName + "..Tbl_User set cPassWord=null,is_Admin=" + (chkRole.Checked ? 1 : 0) + " where id='" + this.Id + "'";
                    }
                    else if (this.labOld.Text != this.txtPassWord.Text)
                    {
                        sql = " update " + Program.DataBaseName + "..Tbl_User set cPassWord='" + CommonHelper.GetMD5(this.txtPassWord.Text) + "',is_Admin=" + (chkRole.Checked ? 1 : 0) + " where id='" + this.Id + "'";
                    }
                    else
                    {
                        sql = " update " + Program.DataBaseName + "..Tbl_User set is_Admin=" + (chkRole.Checked ? 1 : 0) + " where id='" + this.Id + "'";

                    }
                    count = DbHelperSQL.ExecuteSql(sql);
                }
                if (count > 0)
                {
                    MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("操作失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void FormMethodEidt_Load(object sender, EventArgs e)
        {
            if (IsAddNew == false)
            {
                DataTable dt = DbHelperSQL.Query("select cUserName,is_Admin, isnull(cPassWord,999) as pwd from " + Program.DataBaseName + "..Tbl_User where id=" + this.Id).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.txtName.Text = dt.Rows[0]["cUserName"].ToString();
                    this.txtPassWord.Text = dt.Rows[0]["pwd"].ToString();
                    this.labOld.Text = dt.Rows[0]["pwd"].ToString();
                    if (dt.Rows[0]["is_Admin"].ToString() == "1")
                    {
                        chkRole.Checked = true;
                    }
                    else
                    {
                        chkRole.Checked = false;
                    }

                }
                this.txtName.ReadOnly = true;
            }
        }
    }
}
