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
    public partial class FormStock : FormMdiBase
    {
        public FormStock()
        {
            InitializeComponent();
        }

        #region 表单加载事件

        private void FormStock_Load(object sender, EventArgs e)
        {
            LoadStockDataList(); //库存表单列表
        }

        private void LoadStockDataList()
        {
            string sql = "select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,bi.Count,b.BillType_ID from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID  inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<StockDetail> stockDetails = new List<StockDetail>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,sqlParameters);
            foreach (DataRow row in table.Rows)
            {
                StockDetail stock = new StockDetail();
                stock.GoodsName = row["GoodsName"].ToString();
                stock.GoodsFromName = row["GoodsFromName"].ToString();
                stock.GoodsCategoryName = row["GoodsCategoryName"].ToString();
                stock.StorehouseName = row["StorehouseName"].ToString();
                stock.BillTypeId = Convert.ToBoolean(row["BillType_Id"]);
                if (stock.BillTypeId)
                {
                    stock.InCount = row["Count"].ToString();
                }
                else
                {
                    stock.OutCount = row["Count"].ToString();
                }
                stockDetails.Add(stock);
            }
        }

        #endregion
    }
}