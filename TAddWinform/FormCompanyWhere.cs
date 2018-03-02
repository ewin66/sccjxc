using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TAddWinform.Model;

namespace TAddWinform {
    public partial class FormCompanyWhere : FormMdiBase {
        public FormCompanyWhere() {
            InitializeComponent();
        }

        //委托和事件
        public delegate void SelectCompany(Company company);

        public event SelectCompany SelectCompanyEvent;
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCompanyWhere_Load(object sender, EventArgs e)
        {
            LoadLueTypeData();
        }





        private void LoadLueTypeData()
        {
            List<CompanyType> list = new List<CompanyType>()
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
            lueType.Properties.ValueMember = "Type";
            lueType.Properties.DisplayMember = "TypeTxt";
            lueType.Properties.DataSource = list;

        }

        /// <summary>
        /// 点击搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerach_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            if (!string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                company.CompanyCode = txtCode.Text.Trim();
            }

            if (!string.IsNullOrEmpty(txtName.Text.Trim())) {
                company.CompanyName1 = txtName.Text.Trim();
            }

            if (lueType.EditValue == null || lueType.EditValue.ToString() == "请选择")
            {
                company.CompanyType = 3;
            }
            else
            {
                company.CompanyType = Convert.ToInt32(lueType.EditValue);
            }

            SelectCompanyEvent(company);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            lueType.EditValue = null;
        }
    }
}