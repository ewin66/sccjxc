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
    public partial class FormOutLibDetail : FormMdiBase{
        public FormOutLibDetail()
        {
            InitializeComponent();
        }

        //初始化
        private void FormOutLibDetail_Load(object sender, EventArgs e)
        {
            List<StorageDetail> storageDetails = new List<StorageDetail>();
            string sql =
                "select b.Id, b.MakeDate, g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,bi.Count,b.Maker,b.Remark from MD_BillItem as bi inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID inner join MD_Goods as g on bi.GoodsName=g.ID" +
                " where b.billtype_id=0 and g.Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows)
            {
                storageDetails.Add(new StorageDetail()
                {
                    Id = Convert.ToInt32(row["Id"]),
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
        private GridHitInfo _hInfo = null;
        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            _hInfo = gridView1.CalcHitInfo(e.Y, e.Y);
        }
       
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            try
            {
                if (_hInfo.InRowCell)
                {
                   int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                   FormOutLib frm = new FormOutLib { Tag = id };
                   frm.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}