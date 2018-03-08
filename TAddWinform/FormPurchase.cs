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
            SaveDataToDataBase(); //将数据保存到数据库
        }

        //重置
        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetViews();
        }

        //删除行
        private void btnDeleteRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("确定要删除吗?","提示!!!",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                gridView1.DeleteSelectedRows();
            }

            DataRow row = gridView1.GetFocusedDataRow();
        }

        #region 四个下拉框的初始化值

        private void LookUpEditInit()
        {
            LoadStorehouseData();
            LoadGoodsData();
            LoadGoodsFromData();
            LoadGoodsCategoryData();
            LoadCompanyData();
        }

        private void LoadCompanyData()
        {
            string sql = "select * from " + Program.DataBaseName + "..MD_Company where Actived=1 and CompanyType=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<Company> companies = new List<Company>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows)
            {
                companies.Add(new Company()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CompanyCode = row["CompanyCode"].ToString(),
                    CompanyName1 = row["CompanyName"].ToString(),
                    CompanyType = Convert.ToInt32(row["CompanyType"])
                });
            }

            lueCompany.Properties.DisplayMember = "CompanyName1";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.Properties.DataSource = companies;
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
            dt.Columns.Add("GoodsCode", typeof(string));
            dt.Columns.Add("GoodsName", typeof(string));
            dt.Columns.Add("GoodsFromName", typeof(string));
            dt.Columns.Add("GoodsCategoryName", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Count", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            gridControl1.DataSource = dt;
        }

        #region 单元格值变化事件

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (null != row)
            {
                string goodsCode = row["GoodsCode"].ToString();
                string goodsName = row["GoodsName"].ToString();
                string goodsFromName = row["GoodsFromName"].ToString();
                string goodsCategoryName = row["GoodsCategoryName"].ToString();
                string unitPrice = row["UnitPrice"].ToString();
                string count = row["Count"].ToString();
                if (!string.IsNullOrEmpty(unitPrice) && !string.IsNullOrEmpty(count))
                {
                    row["Total"] = Convert.ToDecimal(unitPrice) * Convert.ToDecimal(count);
                }
            }
        }

        #endregion

        #region 保存到数据库

        private void SaveDataToDataBase()
        {
            //入库bill
            try
            {
                CheckBillData();
                BillDataToDataBase();
            }
            catch (Exception e)
            {
                ErrorHandler.OnError(e);
            }

            //入库billitem
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i <= gridView1.RowCount-1; i++)
                {
                    DataRow row = gridView1.GetDataRow(i);
                    string goodsCode = row["GoodsCode"].ToString();
                    string goodsName = row["GoodsName"].ToString();
                    string goodsFromNameId = row["GoodsFromName"].ToString();
                    string goodsCategoryNameId = row["GoodsCategoryName"].ToString();
                    string unitPrice = row["UnitPrice"].ToString();
                    string count = row["Count"].ToString();
                    if (!string.IsNullOrEmpty(unitPrice) && !string.IsNullOrEmpty(count))
                    {
                        row["Total"] = Convert.ToDecimal(unitPrice) * Convert.ToDecimal(count);
                    }

                    string total = row["Total"].ToString();
                    try
                    {
                        CheckDataIsValid(goodsCode, goodsName, goodsFromNameId, goodsCategoryNameId, unitPrice, count,
                            total);
                        //首先查询出bill表的最后一条Id
                        int billId = SelectLastIdFromBill();
                        InsertDataToBillItem(billId, goodsCode, goodsName, goodsFromNameId, goodsCategoryNameId, unitPrice, count,total);
                    }
                    catch (Exception e)
                    {
                        ErrorHandler.OnError(e);
                    }
                }
            }
        }

        private void InsertDataToBillItem(int billId, string goodsCode, string goodsName, string goodsFromNameId, string goodsCategoryNameId, string unitPrice, string count, string total)
        {
            string sql = "insert into " + Program.DataBaseName + "..MD_BillItem" +
                         "(Bill_ID,GoodsCode,GoodsName,GoodsFrom_ID,GoodsCategory_ID,UnitPrice,Count,Total)" +
                         " values(@billId,@goodsCode,@goodsName,@goodsFromNameId,@goodsCategoryNameId,@unitPrice" +
                         ",@count,@total)";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@billId",billId),
                new SqlParameter("@goodsCode",goodsCode),
                new SqlParameter("@goodsName",goodsName),
                new SqlParameter("@goodsFromNameId",goodsFromNameId),
                new SqlParameter("@goodsCategoryNameId",goodsCategoryNameId),
                new SqlParameter("@unitPrice",unitPrice),
                new SqlParameter("@count",count),
                new SqlParameter("@total",total)
            };
            if (DataAccessUtil.ExecuteNonQuery(sql, list)>0)
            {
                MessageBox.Show("入库单保存成功...", "提示!!", MessageBoxButtons.OK);
                ResetViews();//重置数据
            }
        }

        private void ResetViews()
        {
            txtPurOddNumber.Text = "";
            txtMaker.Text = "";
            deTime.Text = "";
            lueCompany.EditValue = null;
            lueStorehouse.EditValue = null;
            NullDataToGridView();
        }

        private int SelectLastIdFromBill()
        {
            string sql = "select top 1 * from " + Program.DataBaseName + "..MD_Bill order by id desc";
            List<SqlParameter> list = new List<SqlParameter>();
            return (int) DataAccessUtil.ExecuteScalar(sql, list);
        }

        private void BillDataToDataBase()
        {
            string sql = "insert into " + Program.DataBaseName + "..MD_Bill" +
                         "(Storehouse_ID,BillType_ID,Maker,MakeDate,Company_ID,BillCode)" +
                         " values(@sid,@bid,@maker,@md,@cid,@bc)";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@sid", lueStorehouse.EditValue),
                new SqlParameter("@bid", 1), //1入库,2出库
                new SqlParameter("@maker", txtMaker.Text.Trim()),
                new SqlParameter("@md", deTime.Text.Trim()),
                new SqlParameter("@cid", lueCompany.EditValue),
                new SqlParameter("@bc", txtPurOddNumber.Text.Trim())
            };
            DataAccessUtil.ExecuteNonQuery(sql, list);
        }

        private void CheckBillData()
        {
            if (string.IsNullOrEmpty(txtPurOddNumber.Text.Trim()))
            {
                throw new ApplicationException("入库单号不能为空");
            }

            if (string.IsNullOrEmpty(deTime.Text.Trim()))
            {
                throw new ApplicationException("入库时间不能为空");
            }

            if (string.IsNullOrEmpty(txtMaker.Text.Trim()))
            {
                throw new ApplicationException("制单人不能为空");
            }

            if (Convert.ToInt32(lueCompany.EditValue) <= 0)
            {
                throw new ApplicationException("没有选择关联单位");
            }

            if (Convert.ToInt32(lueStorehouse.EditValue) <= 0)
            {
                throw new ApplicationException("没有选择仓库");
            }
        }

        private void CheckDataIsValid(string goodsCode, string goodsName, string goodsFromNameId,
            string goodsCategoryNameId, string unitPrice, string count, string total)
        {
            if (string.IsNullOrEmpty(goodsCode))
            {
                throw new ApplicationException("编码不能为空");
            }

            if (string.IsNullOrEmpty(goodsName))
            {
                throw new ApplicationException("名称不能为空");
            }

            if (string.IsNullOrEmpty(goodsFromNameId))
            {
                throw new ApplicationException("产地不能为空");
            }

            if (string.IsNullOrEmpty(goodsCategoryNameId))
            {
                throw new ApplicationException("种类不能为空");
            }

            if (string.IsNullOrEmpty(unitPrice))
            {
                throw new ApplicationException("单价不能为空");
            }

            if (string.IsNullOrEmpty(count))
            {
                throw new ApplicationException("数量不能为空");
            }
        }

        #endregion
    }
}