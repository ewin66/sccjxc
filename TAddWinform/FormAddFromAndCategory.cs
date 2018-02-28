using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TAddWinform {
    public partial class FormAddFromAndCategory : FormMdiBase {
        public FormAddFromAndCategory() {
            InitializeComponent();
        }
        /// <summary>
        /// 添加商品种类和产地事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtFrom.Text) && string.IsNullOrEmpty(txtCategory.Text)) {
                MessageBox.Show("至少您得添加一个吧..");
                return;
            }

            if (string.IsNullOrEmpty(txtCategory.Text)) {
                string sql = "insert into " + Program.DataBaseName + "..MD_GoodsFrom(goodsfromname) values('" + txtFrom.Text + "')";
                int i = DbHelperSQL.ExecuteSql(sql);
                if (i > 0) {
                    btnCancel_Click(null, null);
                } else {
                    MessageBox.Show("添加失败");
                }
            } else if (string.IsNullOrEmpty(txtFrom.Text)) {
                string sql = "insert into " + Program.DataBaseName + "..MD_GoodsCategory(goodscategoryname) values('" + txtCategory.Text + "')";
                int i = DbHelperSQL.ExecuteSql(sql);
                if (i > 0) {
                    btnCancel_Click(null, null);
                } else {
                    MessageBox.Show("添加失败");
                }
            } else {
                string sql = "insert into " + Program.DataBaseName + "..MD_GoodsFrom(goodsfromname) values('" + txtFrom.Text + "')";
                int i = DbHelperSQL.ExecuteSql(sql);
                if (i <= 0) {
                    MessageBox.Show("添加失败");
                }
                string sql1 = "insert into " + Program.DataBaseName + "..MD_GoodsCategory(goodscategoryname) values('" + txtCategory.Text + "')";
                int i1 = DbHelperSQL.ExecuteSql(sql1);
                if (i1 > 0) {
                    btnCancel_Click(null, null);
                } else {
                    MessageBox.Show("添加失败");
                }
            }
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            txtCategory.Text = "";
            txtFrom.Text = "";
        }
    }
}