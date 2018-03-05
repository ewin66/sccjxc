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
    public partial class FormStorehouseWhere : FormMdiBase {
        public FormStorehouseWhere() {
            InitializeComponent();
        }

        //委托和事件
        public delegate void StorehouseWhere(List<Storehouse> storehouses);

        public event StorehouseWhere StorehouseWhereEvent;
        private void btnSearch_Click(object sender, EventArgs e) {
            try {
                SelectDatas();
            } catch (Exception exception) {
                ErrorHandler.OnError(exception);
            }
        }

        private void SelectDatas() {
            string sql = "select * from " + Program.DataBaseName + "..MD_Storehouse where Actived=1";
            if (!string.IsNullOrEmpty(txtCode.Text.Trim())) {
                sql += " and StorehouseCode=" + "'" + txtCode.Text.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(txtName.Text.Trim())) {
                sql += " and StorehouseName like" + "'%" + txtName.Text.Trim() + "%'";
            }
            List<SqlParameter> list = new List<SqlParameter>();
            List<Storehouse> storehouses = new List<Storehouse>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows) {
                storehouses.Add(new Storehouse() {
                    Id = Convert.ToInt32(row["id"]),
                    StorehouseCode = row["StorehouseCode"].ToString(),
                    StorehouseName = row["StorehouseName"].ToString(),
                    Actived = Convert.ToBoolean(row["Actived"]),
                    Remark = row["Remark"].ToString()
                });
            }

            if (StorehouseWhereEvent != null)
            {
                StorehouseWhereEvent(storehouses);
                this.Close();
            }
        }
        //取消关闭窗口
        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}