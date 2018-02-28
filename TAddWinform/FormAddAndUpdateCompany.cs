using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TAddWinform.Model;

namespace TAddWinform {
    public partial class FormAddAndUpdateCompany : FormMdiBase {
        public FormAddAndUpdateCompany() {
            InitializeComponent();
        }

        //委托与事件
        public delegate void AddCompany();

        public event AddCompany addCompanyEvent;

        //表单加载
        private void FormAddAndUpdateCompany_Load(object sender, EventArgs e) {
            List<CompanyType> companyTypes = new List<CompanyType>()
            {
                new CompanyType()
                {
                    Type = 0,
                    TypeTxt = "供货商"
                },
                new CompanyType()
                {
                    Type = 1,
                    TypeTxt = "客户"
                }
            };
            lueType.Properties.DisplayMember = "TypeTxt";
            lueType.Properties.ValueMember = "Type";
            lueType.Properties.DataSource = companyTypes;
            btnAdd.Text = Tag != null ? "修改" : "添加";
            if (btnAdd.Text=="修改")
            {
                FillDatas();
            }
        }

        private void FillDatas()
        {
            string sql = "select * from " + Program.DataBaseName + "..MD_Company where id=" + Tag;
            List<SqlParameter> list = new List<SqlParameter>();
            DataRow row = DataAccessUtil.ExecuteDataTable(sql,list).Rows[0];
            txtCode.Text = row["CompanyCode"].ToString();
            txtName.Text = row["CompanyName"].ToString();
            lueType.EditValue = row["CompanyType"];
            txtRemark.Text = row["Remark"].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddAndUpdate();
            }
            catch (Exception exception)
            {
                ErrorHandler.OnError(exception);
            }

        }

        public void AddAndUpdate()
        {
            CheckViewDatas();
            Company company = new Company() {
                CompanyCode = txtCode.Text.Trim(),
                CompanyName1 = txtName.Text.Trim(),
                CompanyType = Convert.ToInt32(lueType.EditValue),
                Remark = txtRemark.Text.Trim()
            };
            if (btnAdd.Text == "添加")
            {
                string sql = "insert into " + Program.DataBaseName +
                             "..MD_Company(CompanyCode,CompanyName,CompanyType,Remark) values(@code,@name,@type,@re)";
                List<SqlParameter> list = new List<SqlParameter>()
                {
                    new SqlParameter("@code",company.CompanyCode),
                    new SqlParameter("@name",company.CompanyName1),
                    new SqlParameter("@type",company.CompanyType),
                    new SqlParameter("@re",company.Remark),
                };
                if (DataAccessUtil.ExecuteNonQuery(sql,list)>0)
                {
                    addCompanyEvent();
                    this.Close();
                }
                else
                {
                    throw new ApplicationException("添加失败");
                }
            } else {
                //修改
                string sql = "update " + Program.DataBaseName +
                             "..MD_Company set CompanyCode=@code,CompanyName=@name,CompanyType=@type,Remark=@re" +
                             " where id="+Tag;
                List<SqlParameter> list = new List<SqlParameter>()
                {
                    new SqlParameter("@code",company.CompanyCode),
                    new SqlParameter("@name",company.CompanyName1),
                    new SqlParameter("@type",company.CompanyType),
                    new SqlParameter("@re",company.Remark),
                };
                if (DataAccessUtil.ExecuteNonQuery(sql, list) > 0) {
                    addCompanyEvent();
                    this.Close();
                } else {
                    throw new ApplicationException("修改失败");
                }
            }
        }

        public void CheckViewDatas()
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim())) {
                throw new ApplicationException("编码不能为空");
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim())) {
                throw new ApplicationException("名称不能为空");
            }

            if (lueType.EditValue == null || lueType.EditValue.ToString() == "请选择") {
                throw new ApplicationException("类型不能为空");
            }
        }
    }
}