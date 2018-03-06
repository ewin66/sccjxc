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
    //采购入库
    public partial class FormPurchase : FormMdiBase {
        public FormPurchase() {
            InitializeComponent();
        }
        //窗体加载
        private void FormPurchase_Load(object sender, EventArgs e) {
            //四个下拉框的初始化值
            LookUpEditInit();
        }

        //保存
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
        //重置
        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }
        //添加行
        private void btnAddRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            gridView1.AddNewRow();//添加新的一行//this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "GoodsCode", "0");//列初始值1
            //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "GoodsName", "0");//列初始值2
            //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "GoodsFromName", "0");//列初始值2
            //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "GoodsCategoryName", "0");//列初始值2
            //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "UnitPrice", "0");//列初始值2
            //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "Count", "0");//列初始值2
            //this.gridView1.SetRowCellValue(this.gridView1.FocusedRowHandle, "Total", "0");//列初始值2
            //this.gridView1.FocusedRowHandle--;

        }
        //删除行
        private void btnDeleteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        #region 四个下拉框的初始化值
        private void LookUpEditInit()
        {
            LoadStorehouseData();
            LoadGoodsData();
            LoadGoodsFromData();
            LoadGoodsCategoryData();
        }

        private void LoadStorehouseData()
        {
            string sql = "select * from " + Program.DataBaseName + "..MD_Storehouse where Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<Storehouse> storehouses = new List<Storehouse>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows)
            {
                storehouses.Add(new Storehouse()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    StorehouseCode = row["StorehouseCode"].ToString(),
                    StorehouseName = row["StorehouseName"].ToString()
                });
            }

            lueStorehouse.Properties.DisplayMember = "StorehouseName";
            lueStorehouse.Properties.ValueMember = "Id";
            lueStorehouse.Properties.DataSource = storehouses;
        }

        private void LoadGoodsData()
        {
            string sql = "select * from " + Program.DataBaseName + "..MD_Goods where Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<Goods> goodsNameList = new List<Goods>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows) {
                goodsNameList.Add(new Goods() {
                    Id = Convert.ToInt32(row["Id"]),
                    GoodsCode = row["GoodsCode"].ToString(),
                    GoodsName = row["GoodsName"].ToString()
                });
            }
            lueGoodsName.ValueMember = "Id";
            lueGoodsName.DisplayMember = "GoodsName";
            lueGoodsName.DataSource = goodsNameList;
        }

        private void LoadGoodsFromData()
        {
            string sql = "select * from "+Program.DataBaseName+"..MD_GoodsFrom where actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<GoodsFrom> goodsFroms = new List<GoodsFrom>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,list);
            foreach (DataRow row in table.Rows)
            {
                goodsFroms.Add(new GoodsFrom()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    GoodsFromCode = row["GoodsFromCode"].ToString(),
                    GoodsFromName = row["GoodsFromName"].ToString()
                });
            }

            lueGoodsFromName.DisplayMember = "GoodsFromName";
            lueGoodsFromName.ValueMember = "Id";
            lueGoodsFromName.DataSource = goodsFroms;
        }

        private void LoadGoodsCategoryData()
        {
            string sql = "select * from "+Program.DataBaseName+"..MD_GoodsCategory where actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<GoodsCategory> goodsCategories = new List<GoodsCategory>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,list);
            foreach (DataRow row in table.Rows)
            {
                goodsCategories.Add(new GoodsCategory()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    GoodsCategoryCode = row["GoodsCategoryCode"].ToString(),
                    GoodsCategoryName = row["GoodsCategoryName"].ToString()
                });
            }

            lueGoodsCategoryName.DisplayMember = "GoodsCategoryName";
            lueGoodsCategoryName.ValueMember = "Id";
            lueGoodsCategoryName.DataSource = goodsCategories;
        }

        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (this.gridView1.FocusedColumn == e.Column)
            {
                object o = gridView1.GetRowCellValue(1,"GoodsName");
                txtMaker.Text = o.ToString();
            }
        }
    }
}