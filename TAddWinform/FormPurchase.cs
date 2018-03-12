﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
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

        private int _flag;

        //窗体加载
        private void FormPurchase_Load(object sender, EventArgs e)
        {
            //四个下拉框的初始化值
            LookUpEditInit();
            if (Convert.ToInt32(Tag) > 0)
            {
                _flag = Convert.ToInt32(Tag);
                //是从单据明细跳转而来
                FillDataToViews(Convert.ToInt32(Tag));
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                btnSave.Visibility = BarItemVisibility.Never;
                btnAddRow.Visibility = BarItemVisibility.Never;
                btnDeleteRow.Visibility = BarItemVisibility.Never;
                btnReset.Visibility = BarItemVisibility.Never;
                btnUp.Visibility = BarItemVisibility.Always;
                btnNext.Visibility = BarItemVisibility.Always;
                btnHomePage.Visibility = BarItemVisibility.Always;
                btnShadowe.Visibility = BarItemVisibility.Always;
                txtPurOddNumber.ReadOnly = true;
                deTime.ReadOnly = true;
                txtMaker.ReadOnly = true;
                lueCompany.ReadOnly = true;
                lueStorehouse.ReadOnly = true;
            }
            else
            {
                //此处的表单为增加一条入库单据,显示为空的数据源即可
                NullDataToGridView();
                gridView1.OptionsBehavior.Editable = true;
                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                btnSave.Visibility = BarItemVisibility.Always;
                btnAddRow.Visibility = BarItemVisibility.Always;
                btnDeleteRow.Visibility = BarItemVisibility.Always;
                btnReset.Visibility = BarItemVisibility.Always;
                btnUp.Visibility = BarItemVisibility.Never;
                btnNext.Visibility = BarItemVisibility.Never;
                btnHomePage.Visibility = BarItemVisibility.Never;
                btnShadowe.Visibility = BarItemVisibility.Never;
                txtPurOddNumber.ReadOnly = false;
                deTime.ReadOnly = false;
                txtMaker.ReadOnly = false;
                lueCompany.ReadOnly = false;
                lueStorehouse.ReadOnly = false;
            }
        }

        private void FillDataToViews(int id)
        {
            string sql =
                "select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,bi.*,b.* " +
                "from MD_BillItem as bi inner join MD_Bill as b on bi.Bill_ID=b.id  " +
                "inner join MD_Goods as g on bi.GoodsName=g.ID " +
                "inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID " +
                "inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID where b.BillType_ID=1 and b.id=" +
                id;
            List<SqlParameter> list = new List<SqlParameter>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("老哥,没有数据啦...", "提示!!!", MessageBoxButtons.OK);
                return;
            }

            DataRow row = table.Rows[0];
            txtPurOddNumber.Text = row["BillCode"].ToString();
            deTime.Text = row["MakeDate"].ToString();
            txtMaker.Text = row["Maker"].ToString();
            lueCompany.EditValue = Convert.ToInt32(row["Company_ID"]);
            lueStorehouse.EditValue = Convert.ToInt32(row["Storehouse_ID"]);
            DataTable dt = new DataTable();
            dt.Columns.Add("GoodsCode", typeof(string));
            dt.Columns.Add("GoodsName", typeof(string));
            dt.Columns.Add("GoodsFromName", typeof(string));
            dt.Columns.Add("GoodsCategoryName", typeof(string));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Count", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            gridControl1.DataSource = dt;
            DataRow newRow = dt.NewRow();
            dt.Rows.Add(newRow);
            newRow["GoodsCode"] = row["GoodsCode"];
//            newRow["GoodsName"] = row["GoodsName"];
            lueGoodsName.NullText = row["GoodsName"].ToString();
//            newRow["GoodsFromName"] = row["GoodsFromName"];
            lueGoodsFromName.NullText = row["GoodsFromName"].ToString();
//            newRow["GoodsCategoryName"] = row["GoodsCategoryName"];
            lueGoodsCategoryName.NullText = row["GoodsCategoryName"].ToString();
            newRow["UnitPrice"] = row["UnitPrice"];
            newRow["Count"] = row["Count"];
            newRow["Total"] = row["Total"];
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
            if (MessageBox.Show("确定要删除吗?", "提示!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
            string sql = "select * from " + Program.DataBaseName + "..MD_Company where Actived=1 and CompanyType=0";
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
                for (int i = 0; i <= gridView1.RowCount - 2; i++)
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
                        InsertDataToBillItem(billId, goodsCode, goodsName, goodsFromNameId, goodsCategoryNameId,
                            unitPrice, count, total);
                    }
                    catch (Exception e)
                    {
                        ErrorHandler.OnError(e);
                    }
                }
            }
        }

        private void InsertDataToBillItem(int billId, string goodsCode, string goodsName, string goodsFromNameId,
            string goodsCategoryNameId, string unitPrice, string count, string total)
        {
            //如果此商品的ID在单据中存在的话就更新当前入库单据的Count即可
            //if (SumGoodsCount(goodsName, count))
            //{
            //    MessageBox.Show("入库单保存成功...", "提示!!", MessageBoxButtons.OK);
            //    ResetViews();
            //    return;
            //}
            string sql = "insert into " + Program.DataBaseName + "..MD_BillItem" +
                         "(Bill_ID,GoodsCode,GoodsName,GoodsFrom_ID,GoodsCategory_ID,UnitPrice,Count,Total)" +
                         " values(@billId,@goodsCode,@goodsName,@goodsFromNameId,@goodsCategoryNameId,@unitPrice" +
                         ",@count,@total)";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@billId", billId),
                new SqlParameter("@goodsCode", goodsCode),
                new SqlParameter("@goodsName", goodsName),
                new SqlParameter("@goodsFromNameId", goodsFromNameId),
                new SqlParameter("@goodsCategoryNameId", goodsCategoryNameId),
                new SqlParameter("@unitPrice", unitPrice),
                new SqlParameter("@count", count),
                new SqlParameter("@total", total)
            };
            if (DataAccessUtil.ExecuteNonQuery(sql, list) > 0)
            {
                MessageBox.Show("入库单保存成功...", "提示!!", MessageBoxButtons.OK);
                ResetViews(); //重置数据
            }
        }

        private bool SumGoodsCount(string goodsName, string count)
        {
            string sql = "select isnull(sum(bi.count),0) from MD_BillItem  as bi  inner join MD_Bill as b on bi.Bill_ID=b.ID where bi.GoodsName="+goodsName+" and b.BillType_ID=1";
            List<SqlParameter> list = new List<SqlParameter>();
            int inCount = Convert.ToInt32(DataAccessUtil.ExecuteScalar(sql,list));
            if (inCount>0)
            {
                int i = inCount + Convert.ToInt32(count);
                sql = "update MD_BillItem set count=" + i + " where GoodsName=" + goodsName;
                List<SqlParameter> s = new List<SqlParameter>();
                DataAccessUtil.ExecuteNonQuery(sql, s);
                return true;
            }
            else
            {
                return false;
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
                new SqlParameter("@bid", true), //1入库,0出库
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

        //首页数据
        private void btnHomePage_ItemClick(object sender, ItemClickEventArgs e)
        {
            FillDataToViews(1);
        }

        //上一条数据
        private void btnUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select isnull(max(id),0) from MD_Bill where id <" + _flag + " and BillType_ID=1";
            List<SqlParameter> list = new List<SqlParameter>();
            int tempId = Convert.ToInt32(DataAccessUtil.ExecuteScalar(sql, list));
            if (tempId > 0)
            {
                FillDataToViews(tempId);
                if (tempId != 0)
                {
                    _flag = tempId;
                }
            }
            else
            {
                MessageBox.Show("当前已经是第一条单据了", "提示!!!", MessageBoxButtons.OK);
                return;
            }
        }

        //下一条数据
        private void btnNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select isnull(min(id),0) from MD_Bill where id >" + _flag + " and BillType_ID=1";
            List<SqlParameter> list = new List<SqlParameter>();
            object value = DataAccessUtil.ExecuteScalar(sql, list);
            if (value != null)
            {
                int tempId = Convert.ToInt32(value);
                FillDataToViews(tempId);
                if (tempId!=0)
                {
                    _flag = tempId;
                }
            }
        }

        //尾页数据
        private void btnShadowe_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select TOP 1 * from " + Program.DataBaseName + "..MD_BillItem" + " order by id desc";
            List<SqlParameter> list = new List<SqlParameter>();
            int id = Convert.ToInt32(DataAccessUtil.ExecuteScalar(sql, list));
            FillDataToViews(id);
        }
    }
}