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
                "select b.MakeDate, g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,bi.Count,b.Maker,b.Remark from MD_BillItem as bi inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID inner join MD_Goods as g on bi.GoodsName=g.ID" +
                " where b.billtype_id=0";
            List<SqlParameter> list = new List<SqlParameter>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows)
            {
                storageDetails.Add(new StorageDetail()
                {
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
    }
}