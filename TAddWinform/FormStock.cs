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
            //select g.ID as gid,gf.ID as gfid,gc.ID as gcid,g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=1 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,g.ID,gf.ID,gc.ID

            //所有的出库单
            //select g.ID as gid,gf.ID as gfid,gc.ID as gcid,g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=0 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,g.ID,gf.ID,gc.ID


            string sql = "select g.ID as gid,gf.ID as gfid,gc.ID as gcid,b.Storehouse_ID,g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=1 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,g.ID,gf.ID,gc.ID,b.Storehouse_ID";
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
                stock.GoodsId = Convert.ToInt32(row["gid"]);
                stock.GoodsFromId = Convert.ToInt32(row["gfid"]);
                stock.GoodsCategoryId = Convert.ToInt32(row["gcid"]);
                stock.StorehouseId = Convert.ToInt32(row["Storehouse_ID"]);
                stockDetailsIn.Add(stock); //所有入库结果
            }


            string outSql = "select g.ID as gid,gf.ID as gfid,gc.ID as gcid,b.Storehouse_ID,g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,sum(bi.Count) as lastcount from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID where b.BillType_ID=0 group by g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,b.BillType_ID,g.ID,gf.ID,gc.ID,b.Storehouse_ID";
            List<StockDetail> stockDetailsOut = new List<StockDetail>();
            DataTable tableOut = DataAccessUtil.ExecuteDataTable(outSql, sqlParameters);
            foreach (DataRow row in tableOut.Rows) {
                StockDetail stock = new StockDetail();
                stock.GoodsName = row["GoodsName"].ToString();//名称
                stock.GoodsFromName = row["GoodsFromName"].ToString();//产地
                stock.GoodsCategoryName = row["GoodsCategoryName"].ToString();//品种
                stock.StorehouseName = row["StorehouseName"].ToString();//仓库名称
                stock.LastCount = row["lastcount"].ToString();//每个商品的最终出库数量
                stock.GoodsId = Convert.ToInt32(row["gid"]);
                stock.GoodsFromId = Convert.ToInt32(row["gfid"]);
                stock.GoodsCategoryId = Convert.ToInt32(row["gcid"]);
                stock.StorehouseId = Convert.ToInt32(row["Storehouse_ID"]);
                stockDetailsOut.Add(stock); //所有出库结果
            }


            List<StockDetail> lastShowDetails = new List<StockDetail>();
            foreach (StockDetail detailIn in stockDetailsIn)
            {
                foreach (StockDetail detailOut in stockDetailsOut)
                {
                    if (detailIn.GoodsId == detailOut.GoodsId && detailIn.GoodsFromId == detailOut.GoodsFromId && detailIn.GoodsCategoryId == detailOut.GoodsCategoryId)
                    {
                        StockDetail stock = new StockDetail();
                        stock.GoodsId = detailIn.GoodsId;
                        stock.GoodsFromId = detailIn.GoodsFromId;
                        stock.GoodsCategoryId = detailIn.GoodsCategoryId;
                        stock.StorehouseId = detailIn.StorehouseId;
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
            //将库存量录入数据库
            foreach (StockDetail detail in lastShowDetails)
            {
                string insertSql = "insert into "+Program.DataBaseName+"..MD_Stock(Goods_ID,Storehouse_ID,Count,GoodsFrom_ID,GoodsCategory_ID) values(@goods_ID,@storehouse_ID,@coun,@goodsFrom_ID,@goodsCategory_ID)";
                List<SqlParameter> list = new List<SqlParameter>()
                {
                    new SqlParameter("@goods_ID",detail.GoodsId),
                    new SqlParameter("@storehouse_ID",detail.StorehouseId),
                    new SqlParameter("@coun",Convert.ToDecimal(detail.LastCount)),
                    new SqlParameter("@goodsFrom_ID",detail.GoodsFromId),
                    new SqlParameter("@goodsCategory_ID",detail.GoodsCategoryId),
                };
                try
                {
                    DataAccessUtil.ExecuteNonQuery(insertSql, list);
                }
                catch (Exception e)
                {
                    ErrorHandler.OnError(e);
                }
            }
        }

        #endregion
    }
}