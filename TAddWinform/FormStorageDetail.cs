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

namespace TAddWinform
{
    public partial class FormStorageDetail : FormMdiBase
    {
        public FormStorageDetail()
        {
            InitializeComponent();
        }

        public delegate void OpenInDetail(int id);

        public event OpenInDetail OpenInDetailEvent;


        //加载
        private void FormStorageDetail_Load(object sender, EventArgs e)
        {
            LoadAllDataToList();
        }

        private void LoadAllDataToList()
        {
            List<StorageDetail> storageDetails = new List<StorageDetail>();
            string sql =
                "select b.Id,bi.ID as biid ,b.MakeDate, g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,bi.Count,b.Maker,b.Remark from MD_BillItem as bi inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID inner join MD_Goods as g on bi.GoodsName=g.ID" +
                " where b.billtype_id=1 and g.Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows)
            {
                storageDetails.Add(new StorageDetail()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    BiId = Convert.ToInt32(row["biid"]),
                    MakeDate = row["MakeDate"].ToString(),
                    GoodsName = row["GoodsName"].ToString(),
                    GoodsFromName = row["GoodsFromName"].ToString(),
                    GoodsCategoryName = row["GoodsCategoryName"].ToString(),
                    StorehouseName = row["StorehouseName"].ToString(),
                    Count = row["Count"].ToString(),
                    Maker = row["Maker"].ToString(),
                    Remark = row["Remark"].ToString()
                });
            }

            gridControl1.DataSource = storageDetails;
        }

        /*单元格的双击事件
         双击之后传值跳转到入库单界面,显示入库的明细
         */
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            try
            {
                if (_hInfo.InRowCell)
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BiId"));
                    FormPurchase frm = new FormPurchase {Tag = id};
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private GridHitInfo _hInfo = null;

        private void gridView1_MouseDown_1(object sender, MouseEventArgs e)
        {
            _hInfo = gridView1.CalcHitInfo(e.Y, e.Y);
        }

        //搜索
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadAllDataToList();
        }

        //条件搜索
        private void btnWhereSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormWhereStockIn frm = new FormWhereStockIn();
            frm.SelectWhereStockInEvent += frm_SelectWhereStockInEvent;
            frm.ShowDialog();
        }

        //删除
        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //删除billItem的Id即可
            //获得选中的行
            int selectedhandle = gridView1.GetSelectedRows()[0];
            //获得某列的值
            int biId = Convert.ToInt32(gridView1.GetRowCellValue(selectedhandle, "BiId"));
            //删除操作
            string sql = "delete MD_BillItem where id=" + biId;
            try
            {
                if (DataAccessUtil.ExecuteNonQuery(sql, new List<SqlParameter>()) > 0)
                {
                    LoadAllDataToList();
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.OnError(exception);
            }
        }

        //修改
        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("双击单元格进行修改..","来自于长者的提示",MessageBoxButtons.OK);
        }

        public void frm_SelectWhereStockInEvent(List<StorageDetail> storageDetails)
        {
            gridControl1.DataSource = storageDetails;
        }
    }
}