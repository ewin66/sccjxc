using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TAddWinform
{
    public partial class FormUser : FormMdiBase
    {
        private static string strAlert = string.Empty;

        private static string rowEidt = string.Empty;

        private static string RowDelete = string.Empty;

        private static string DeleteInfo = string.Empty;
        public FormUser()
        {
            InitializeComponent();
        }

        private void btnSerach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = @" select id,cUserName,cLoginTime,(case when is_Admin=1 then '是' else '否' end ) as isYes  from " + Program.DataBaseName + "..Tbl_User where 1=1";
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                sql += " and  cUserName like '%" + this.txtName.Text + "%'";
            }
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            this.gridControl1.DataSource = dt.DefaultView;
        }



        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormUserEidt frm = new FormUserEidt();
            frm.IsAddNew = true;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEidt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (null == row)
            {
                MessageBox.Show(rowEidt, strAlert, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FormUserEidt frm = new FormUserEidt();
            frm.IsAddNew = false;
            frm.Id = Convert.ToInt32(row["id"]);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (null == row)
            {
                MessageBox.Show(RowDelete, strAlert, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int count = DbHelperSQL.ExecuteSql(" delete " + Program.DataBaseName + "..Tbl_User where id=" + row["id"]);
                if (count == 0)
                {
                    MessageBox.Show(DeleteInfo, strAlert, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strAlert, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {

            if (GlobalParameters.iLanugage > 10)
            {
                this.Text = "User Account Setting";
                btnAdd.Caption = "New";
                btnEidt.Caption = "Edit";
                btnDelete.Caption = "Delete";
                btnSerach.Caption = "Inquire";
                gridColumn2.Caption = "User Name";
                gridColumn5.Caption = "Last Login";
                gridColumn9.Caption = "System Admin";
                label1.Text = "User Name";



                gridColumn6.Caption = "Retail Price";
                gridColumn7.Caption = "Latest Cost";
                gridColumn8.Caption = "Export Report";
                gridColumn4.Caption = "Upload Pictures";
                gridColumn10.Caption = "Warehouse";


                DataTable dts = new DataTable();
                dts.Columns.Add("Authorize", typeof(string));

                DataRow row = dts.NewRow();
                row = dts.NewRow();
                row[0] = "Yes";
                dts.Rows.Add(row);
                row = dts.NewRow();
                row[0] = "No";
                dts.Rows.Add(row);


                repositoryItemGridLookUpEdit1.DisplayMember = "Authorize";
                repositoryItemGridLookUpEdit1.ValueMember = "Authorize";
                repositoryItemGridLookUpEdit1.DataSource = dts;


                DataTable dt = DbHelperSQL.Query(" select code as 'Warehouse Number' ,name as 'Warehouse Name' from AA_Warehouse ").Tables[0];

                this.repositoryItemCheckedComboBoxEdit1.DataSource = dt;
                this.repositoryItemCheckedComboBoxEdit1.ValueMember = "Warehouse Number";
                this.repositoryItemCheckedComboBoxEdit1.DisplayMember = "Warehouse Name";
                strAlert = "Alert";
                rowEidt = "Please select one row!";
                RowDelete = "Please select one row!";

                DeleteInfo = "delete is fail!";
            }
            else {

                strAlert = "提示";
                rowEidt = "请选择一行进行编辑！";
                RowDelete = "请选择一行进行删除！";
                DeleteInfo = "删除失败！";

                DataTable dts = new DataTable();
                dts.Columns.Add("是否拥有", typeof(string));

                DataRow row = dts.NewRow();
                row = dts.NewRow();
                row[0] = "是"; ;
                dts.Rows.Add(row);
                row = dts.NewRow();
                row[0] = "否";
                dts.Rows.Add(row);


                repositoryItemGridLookUpEdit1.DisplayMember = "是否拥有";
                repositoryItemGridLookUpEdit1.ValueMember = "是否拥有";
                repositoryItemGridLookUpEdit1.DataSource = dts;


                DataTable dt = DbHelperSQL.Query(" select code as '仓库编码' ,name as '仓库名称' from AA_Warehouse ").Tables[0];

                this.repositoryItemCheckedComboBoxEdit1.DataSource = dt;
                this.repositoryItemCheckedComboBoxEdit1.ValueMember = "仓库编码";
                this.repositoryItemCheckedComboBoxEdit1.DisplayMember = "仓库名称";
            
            }
            

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (null == row)
            {
                return;
            }
            else
            {
                string sql = " select * from " + Program.DataBaseName + "..Tbl_User where id=" + row["id"];
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                this.gridControl2.DataSource = dt.DefaultView;

            }

        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gridView2.GetFocusedDataRow();
            if (null == row)
                return;
            string sql = string.Empty;
            sql = " update " + Program.DataBaseName + "..Tbl_User  set " + e.Column.FieldName + "='" + e.Value + "' where id=" + row["id"];
            DbHelperSQL.ExecuteSql(sql);
            LoadData();
        }
    }
}
