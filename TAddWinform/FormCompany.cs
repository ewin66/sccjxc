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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TAddWinform.Model;

namespace TAddWinform {
    public partial class FormCompany : FormMdiBase {
        public FormCompany() {
            InitializeComponent();
        }
        
        /// <summary>
        /// 表单的加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCompany_Load(object sender, EventArgs e)
        {
            LoadAllCompany();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            LoadAllCompany();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            FormCompanyWhere formCompanyWhere = new FormCompanyWhere();
            formCompanyWhere.SelectCompanyEvent+=formCompanyWhere_SelectCompanyEvent;
            formCompanyWhere.StartPosition = FormStartPosition.CenterParent;
            formCompanyWhere.ShowDialog();
        }

        /// <summary>
        /// 添加往来单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            FormAddAndUpdateCompany formAddAndUpdateCompany = new FormAddAndUpdateCompany();
            formAddAndUpdateCompany.addCompanyEvent+=formAddAndUpdateCompany_addCompanyEvent;
            formAddAndUpdateCompany.StartPosition = FormStartPosition.CenterParent;
            formAddAndUpdateCompany.ShowDialog();
        }

        /// <summary> 修改往来单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("双击单元格进行修改");
        }

        /// <summary>
        /// 删除往来单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barLargeButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //获得选中的第一行的下标
            int selectRow = gv.GetSelectedRows()[0];
            //根据下标选择列值
            int id = Convert.ToInt32(gv.GetRowCellValue(selectRow, gv.Columns["Id"]));
            string sql = "update " + Program.DataBaseName + "..MD_Company set Actived=0 where id=" + id;
            List<SqlParameter> list = new List<SqlParameter>();
            if (DataAccessUtil.ExecuteNonQuery(sql, list) > 0) {
                LoadAllCompany();
            }//gv.DeleteRow(gv.FocusedRowHandle);
        }

        private void LoadAllCompany()
        {
            string sql = "select * from "+Program.DataBaseName+"..MD_Company where Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<Company> companies = new List<Company>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,list);
            foreach (DataRow row in table.Rows)
            {
                companies.Add(new Company()
                {
                    Id = Convert.ToInt32(row["id"]),
                    CompanyCode = row["CompanyCode"].ToString(),
                    CompanyName1 = row["CompanyName"].ToString(),
                    CompanyType = Convert.ToInt32(row["CompanyType"]),
                    Actived = Convert.ToBoolean(row["Actived"]),
                    Remark = row["Remark"].ToString()
                });
            }

            gridControl1.DataSource = companies;
        }

        /// <summary>
        /// GridView格式化单元格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName=="CompanyType")
            {
                switch (e.DisplayText)
                {
                    case "0":
                        e.DisplayText = "供货商";
                        break;
                    case "1":
                        e.DisplayText = "客户";
                        break;
                }
            }
        }

        public void formCompanyWhere_SelectCompanyEvent(Company company)
        {
            string sql = "select * from "+Program.DataBaseName+"..MD_Company where actived=1";
            if (!string.IsNullOrEmpty(company.CompanyCode))
            {
                sql += " and CompanyCode=" + "'" + company.CompanyCode + "'";
            }

            if (!string.IsNullOrEmpty(company.CompanyName1)) {
                sql += " and CompanyName like" + "'%" + company.CompanyName1 + "%'";
            }

            if (company.CompanyType==0||company.CompanyType==1)
            {
                sql += " and CompanyType=" + company.CompanyType;
            }

            List<SqlParameter> list = new List<SqlParameter>();
            List<Company> companies = new List<Company>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,list);
            foreach (DataRow row in table.Rows)
            {
                companies.Add(new Company()
                {
                    Id = Convert.ToInt32(row["id"]),
                    CompanyCode = row["CompanyCode"].ToString(),
                    CompanyName1 = row["CompanyName"].ToString(),
                    CompanyType = Convert.ToInt32(row["CompanyType"]),
                    Remark = row["Remark"].ToString()
                });
            }

            gridControl1.DataSource = companies;
        }

        public void formAddAndUpdateCompany_addCompanyEvent()
        {
            LoadAllCompany();

        }
        //单元格双击事件
        private void gv_DoubleClick(object sender, EventArgs e) {
            if (gv.FocusedRowHandle < 0) {
                return;
            }

            try {
                if (info.InRowCell) {
                    FormAddAndUpdateCompany formAddAndUpdate = new FormAddAndUpdateCompany();
                    int selectRow = gv.GetSelectedRows()[0];  //获得选中的第一行的下标
                    int id = Convert.ToInt32(gv.GetRowCellValue(selectRow, gv.Columns["Id"])); //根据下标选择列值
                    formAddAndUpdate.Tag = id;
                    formAddAndUpdate.addCompanyEvent += formAddAndUpdateCompany_addCompanyEvent;
                    formAddAndUpdate.StartPosition = FormStartPosition.CenterParent;
                    formAddAndUpdate.ShowDialog();
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }
        private GridHitInfo info = null;
        private void gv_MouseDown(object sender, MouseEventArgs e) {
            info = gv.CalcHitInfo(e.Y, e.Y);
        }
    }
}