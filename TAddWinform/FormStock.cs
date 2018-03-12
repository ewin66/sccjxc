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
            //所有的入库单
            //select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=1 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID

            //所有的出库单
            //select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=0 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID


            string sql = "select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=1 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<StockDetail> stockDetailsIn = new List<StockDetail>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,sqlParameters);
            foreach (DataRow row in table.Rows)
            {
                StockDetail stock = new StockDetail();
                stock.GoodsName = row["GoodsName"].ToString();//名称
                stock.GoodsFromName = row["GoodsFromName"].ToString();//产地
                stock.GoodsCategoryName = row["GoodsCategoryName"].ToString();//品种
                stock.StorehouseName = row["StorehouseName"].ToString();//仓库名称
                stock.LastCount = row["lastcount"].ToString();//每个商品的最终入库数量
                stockDetailsIn.Add(stock); //所有入库结果
            }


            string outSql = "select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=0 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID";
            List<StockDetail> stockDetailsOut = new List<StockDetail>();
            DataTable tableOut = DataAccessUtil.ExecuteDataTable(outSql, sqlParameters);
            foreach (DataRow row in tableOut.Rows) {
                StockDetail stock = new StockDetail();
                stock.GoodsName = row["GoodsName"].ToString();//名称
                stock.GoodsFromName = row["GoodsFromName"].ToString();//产地
                stock.GoodsCategoryName = row["GoodsCategoryName"].ToString();//品种
                stock.StorehouseName = row["StorehouseName"].ToString();//仓库名称
                stock.LastCount = row["lastcount"].ToString();//每个商品的最终入库数量
                stockDetailsOut.Add(stock); //所有出库结果
            }


            List<StockDetail> lastShowDetails = new List<StockDetail>();
            foreach (StockDetail detailIn in stockDetailsIn)
            {
                foreach (StockDetail detailOut in stockDetailsOut)
                {
                    if (detailIn.GoodsName==detailOut.GoodsName&&detailIn.GoodsFromName==detailOut.GoodsFromName&&detailIn.GoodsCategoryName==detailOut.GoodsCategoryName)
                    {
                        StockDetail stock = new StockDetail();
                        stock.GoodsName = detailIn.GoodsName;
                        stock.GoodsFromName = detailIn.GoodsFromName;
                        stock.GoodsCategoryName = detailIn.GoodsCategoryName;
                        stock.StorehouseName = detailIn.StorehouseName;
                        stock.LastCount = (Convert.ToDecimal(detailIn.LastCount) -
                                           Convert.ToDecimal(detailOut.LastCount)).ToString();
                        lastShowDetails.Add(stock);
                    }
                    else
                    {
                        lastShowDetails.Add(detailIn);
                    }
                }
            }

            gridControl1.DataSource = lastShowDetails;
        }

        #endregion
    }
}