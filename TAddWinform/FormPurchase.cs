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
using DevExpress.XtraGrid.Views.Base;
using TAddWinform.Model;

namespace TAddWinform
{
    //采购入库
    public partial class FormPurchase : FormMdiBase
    {
        public FormPurchase()
        {
            InitializeComponent();
        }

        private int value;
        //窗体加载
        private void FormPurchase_Load(object sender, EventArgs e)
        {
            //四个下拉框的初始化值
            LookUpEditInit();
            //此处的表单为增加一条入库单据,显示为空的数据源即可
            NullDataToGridView();
        }

        //保存
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        //重置
        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        //添加行
        private void btnAddRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        //删除行
        private void btnDeleteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            foreach (DataRow row in table.Rows)
            {
                goodsNameList.Add(new Goods()
                {
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
            string sql = "select * from " + Program.DataBaseName + "..MD_GoodsFrom where actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<GoodsFrom> goodsFroms = new List<GoodsFrom>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
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
            string sql = "select * from " + Program.DataBaseName + "..MD_GoodsCategory where actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<GoodsCategory> goodsCategories = new List<GoodsCategory>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
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

        private void NullDataToGridView()
        {
            //string sql = "select MD_BillItem.ID, MD_Goods.GoodsCode,MD_Goods.GoodsName,MD_GoodsFrom.GoodsFromName,MD_GoodsCategory.GoodsCategoryName, MD_BillItem.UnitPrice, MD_BillItem.Count from MD_BillItem inner join MD_Goods on  MD_BillItem.Goods_ID=MD_Goods.ID inner join MD_GoodsFrom on MD_Goods.GoodsFromID=MD_GoodsFrom.ID inner join MD_GoodsCategory on MD_Goods.GoodsCategoryID=MD_GoodsCategory.ID";
            DataTable dt = new DataTable();
            dt.Columns.Add("GoodsCode");
            dt.Columns.Add("GoodsName");
            dt.Columns.Add("GoodsFromName");
            dt.Columns.Add("GoodsCategoryName");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Count");
            dt.Columns.Add("Total");
            gridControl1.DataSource = dt;
        }

        #region 录入检验

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (string.IsNullOrEmpty(gridView1.GetRowCellValue(e.RowHandle, "GoodsCode").ToString()))
            {
                e.Valid = false;
                e.ErrorText = string.Format("{0}不能为空", gridView1.Columns["GoodsCode"].Caption);
                gridView1.FocusedColumn = gridView1.Columns["GoodsCode"];
            }
            gridView1.CloseEditor();
            lueGoodsName.EditValueChanged+=lueGoodsName_EditValueChanged;

            if (gridView1.GetRowCellValue(e.RowHandle, "GoodsName").ToString() == "请选择") {
                e.Valid = false;
                e.ErrorText = string.Format("请选择{0}", gridView1.Columns["GoodsName"].Caption);
                gridView1.FocusedColumn = gridView1.Columns["GoodsName"];
            }
            //if (lueGoodsFromName.GetDisplayText() == "请选择")
            //{//    e.Valid = false;
            //    e.ErrorText = string.Format("请选择{0}", gridView1.Columns["GoodsFromName"].Caption);
            //    gridView1.FocusedColumn = gridView1.Columns["GoodsFromName"];
            //    return;
            //}

            if (lueGoodsCategoryName.EditValueChangedDelay == 0){
                e.Valid = false;
                e.ErrorText = string.Format("请选择{0}", gridView1.Columns["GoodsCategoryName"].Caption);
                gridView1.FocusedColumn = gridView1.Columns["GoodsCategoryName"];
                return;
            }

            if (gridView1.GetRowCellValue(e.RowHandle, "UnitPrice").GetType() != typeof(int) ||
                gridView1.GetRowCellValue(e.RowHandle, "UnitPrice").GetType() != typeof(decimal))
            {
                e.Valid = false;
                e.ErrorText = string.Format("{0}只能是整数或者小数", gridView1.Columns["UnitPrice"].Caption);
                gridView1.FocusedColumn = gridView1.Columns["UnitPrice"];
                return;
            }

            if (gridView1.GetRowCellValue(e.RowHandle, "Count").GetType() != typeof(int))
            {
                e.Valid = false;
                e.ErrorText = string.Format("{0}只能是整数", gridView1.Columns["Count"].Caption);
                gridView1.FocusedColumn = gridView1.Columns["Count"];
                return;
            }
        }

        private void lueGoodsName_EditValueChanged(object sender, EventArgs e)
        {
            //BaseEdit edit = gridView1.ActiveEditor;
            //switch (gridView1.FocusedColumn.FieldName)
            //{
            //    case "GoodsName":
            //        gridView1.SetFocusedRowCellValue(gridView1.Columns["GoodsName"],edit.EditValue);
            //    break;
            //}
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            if (lookUpEdit != null)
            {
                value = Convert.ToInt32(lookUpEdit.EditValue);
            }
        }

        #endregion

        #region 单元格值变化事件

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var s = e.Value.ToString();
            Console.WriteLine(s);
        }

        #endregion
    }
}