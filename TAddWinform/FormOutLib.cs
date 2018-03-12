using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using TAddWinform.Model;

namespace TAddWinform
{
    public partial class FormOutLib : FormMdiBase
    {
        public FormOutLib()
        {
            InitializeComponent();
            NullFillDataToGridView();
        }
        private int _flag;
        //保存
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveDataToDataBase();
        }

        //重置
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetViews();
        }

        //删除行
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("确定要删除吗?", "提示!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                gridView1.DeleteSelectedRows();
            }
        }

        #region 填充空数据进行初始化

        private void NullFillDataToGridView()
        {
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

        #endregion

        #region 五个下拉框的数据加载

        private void FormOutLib_Load(object sender, EventArgs e)
        {
            LoadlueCompanyData();
            LoadLueStorehouseData();
            LoadLueGoodsNameData();
            LoadGoodsCategoryData();
            LoadGoodsFromData();
            if (Convert.ToInt32(Tag)>0)
            {
                //是从单据明细跳转而来
                _flag = Convert.ToInt32(Tag);
                //是从单据明细跳转而来
                FillDataToViews(Convert.ToInt32(Tag));
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                btnSave.Visibility = BarItemVisibility.Never;
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
                NullFillDataToGridView();
                gridView1.OptionsBehavior.Editable = true;
                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                btnSave.Visibility = BarItemVisibility.Always;
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

        private void LoadLueGoodsNameData()
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

        private void LoadLueStorehouseData()
        {
            string sql = "select * from " + Program.DataBaseName + "..MD_Storehouse where Actived=1";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Storehouse> storehouses = new List<Storehouse>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, sqlParameters);
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

        private void LoadlueCompanyData()
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
                    CompanyName1 = row["CompanyName"].ToString()
                });
            }

            lueCompany.Properties.DisplayMember = "CompanyName1";
            lueCompany.Properties.ValueMember = "Id";
            lueCompany.Properties.DataSource = companies;
        }

        #endregion

        #region cell值改变事件

        private void gridView1_CellValueChanged(object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (null != row)
            {
                string unitPrice = row["UnitPrice"].ToString();
                string goodsName = row["GoodsName"].ToString();
                string count = row["Count"].ToString();
                if (!string.IsNullOrEmpty(goodsName) && !string.IsNullOrEmpty(count))
                {
                    string sql =
                        "select g.GoodsName,bi.Count from MD_BillItem as bi inner join MD_Goods as g on bi.GoodsName=g.ID where bi.GoodsName=" +
                        goodsName;
                    List<SqlParameter> list = new List<SqlParameter>();
                    DataRow row1 = DataAccessUtil.ExecuteDataTable(sql, list).Rows[0];
                    if (Convert.ToDecimal(row1["Count"]) < Convert.ToDecimal(count))
                    {
                        MessageBox.Show("当前库存中并没有这么多商品,只有" + Convert.ToDecimal(row1["Count"]) + "个!!", "提示",
                            MessageBoxButtons.OK);
                        row["Count"] = 0;
                    }
                }

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
            try
            {
                //单据头值的合法性检查
                CheckBillData(); 
                //单据体值的合法性检查
                CheckBodyData();
            }
            catch (Exception e)
            {
                ErrorHandler.OnError(e);
            }
        }

        private void CheckBodyData()
        {
            if (gridView1.RowCount > 0)
            {
                for (int i = 0; i <= gridView1.RowCount - 1; i++)
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
                    CheckDataIsValid(goodsCode, goodsName, goodsFromNameId, goodsCategoryNameId, unitPrice, count,
                        total);
                    DataInsertToDataBase(goodsCode, goodsName, goodsFromNameId, goodsCategoryNameId, unitPrice, count,
                        total); //录入数据库,首先录入bill,之后在根据Id录入billitem
                }
            }
        }

        private void DataInsertToDataBase(string goodsCode, string goodsName, string goodsFromNameId, string goodsCategoryNameId, string unitPrice, string count, string total)
        {
            string sql = "insert into "+Program.DataBaseName+"..MD_Bill" +
                         "(Storehouse_ID,BillType_ID,Maker,MakeDate,Company_ID,BillCode)" +
                         " values(@sid,@bid,@maker,@md,@cid,@bc)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@sid", lueStorehouse.EditValue),
                new SqlParameter("@bid", false), //1入库,0出库
                new SqlParameter("@maker", txtMaker.Text.Trim()),
                new SqlParameter("@md", deTime.Text.Trim()),
                new SqlParameter("@cid", lueCompany.EditValue),
                new SqlParameter("@bc", txtPurOddNumber.Text.Trim())
            };
            if (DataAccessUtil.ExecuteNonQuery(sql, sqlParameters)>0)
            {
                //首先查询出bill表的最后一条Id
                int billId = SelectLastIdFromBill();

                sql = "insert into " + Program.DataBaseName + "..MD_BillItem" +
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
                if (DataAccessUtil.ExecuteNonQuery(sql, list) > 0) {
                    MessageBox.Show("出库单保存成功...", "提示!!", MessageBoxButtons.OK);
                    ResetViews();//重置数据
                }
            }
        }

        private int SelectLastIdFromBill()
        {
            string sql = "select top 1 * from " + Program.DataBaseName + "..MD_Bill order by id desc";
            List<SqlParameter> list = new List<SqlParameter>();
            return (int)DataAccessUtil.ExecuteScalar(sql, list);
        }

        private void ResetViews()
        {
            txtPurOddNumber.Text = "";
            txtMaker.Text = "";
            deTime.Text = "";
            lueCompany.EditValue = null;
            lueStorehouse.EditValue = null;
            NullFillDataToGridView();
        }

        private void CheckDataIsValid(string goodsCode, string goodsName, string goodsFromNameId, string goodsCategoryNameId, string unitPrice, string count, string total)
        {
            if (string.IsNullOrEmpty(goodsCode)) {
                throw new ApplicationException("编码不能为空");
            }

            if (string.IsNullOrEmpty(goodsName)) {
                throw new ApplicationException("名称不能为空");
            }

            if (string.IsNullOrEmpty(goodsFromNameId)) {
                throw new ApplicationException("产地不能为空");
            }

            if (string.IsNullOrEmpty(goodsCategoryNameId)) {
                throw new ApplicationException("种类不能为空");
            }

            if (string.IsNullOrEmpty(unitPrice)) {
                throw new ApplicationException("单价不能为空");
            }

            if (string.IsNullOrEmpty(count)) {
                throw new ApplicationException("数量不能为空");
            }
        }

        private void CheckBillData()
        {
            if (string.IsNullOrEmpty(txtPurOddNumber.Text.Trim())) {
                throw new ApplicationException("出库单号不能为空");
            }

            if (string.IsNullOrEmpty(deTime.Text.Trim())) {
                throw new ApplicationException("出库时间不能为空");
            }

            if (string.IsNullOrEmpty(txtMaker.Text.Trim())) {
                throw new ApplicationException("制单人不能为空");
            }

            if (Convert.ToInt32(lueCompany.EditValue) <= 0) {
                throw new ApplicationException("没有选择关联单位");
            }

            if (Convert.ToInt32(lueStorehouse.EditValue) <= 0) {
                throw new ApplicationException("没有选择仓库");
            }
        }

        #endregion
        private void FillDataToViews(int id)
        {
            string sql =
                "select g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,bi.*,b.* " +
                "from MD_BillItem as bi inner join MD_Bill as b on bi.Bill_ID=b.id  " +
                "inner join MD_Goods as g on bi.GoodsName=g.ID " +
                "inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID " +
                "inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID where b.BillType_ID=0 and b.id=" +
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

        private void btnHomePage_ItemClick(object sender, ItemClickEventArgs e)
        {
            FillDataToViews(1);
        }

        private void btnUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select isnull(max(id),0) from MD_Bill where id <" + _flag + " and BillType_ID=0";
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

        private void btnNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select isnull(min(id),0) from MD_Bill where id >" + _flag + " and BillType_ID=0";
            List<SqlParameter> list = new List<SqlParameter>();
            object value = DataAccessUtil.ExecuteScalar(sql, list);
            if (value != null)
            {
                int tempId = Convert.ToInt32(value);
                FillDataToViews(tempId);
                if (tempId != 0)
                {
                    _flag = tempId;
                }
            }
        }

        private void btnShadowe_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql = "select TOP 1 * from " + Program.DataBaseName + "..MD_BillItem" + " order by id desc";
            List<SqlParameter> list = new List<SqlParameter>();
            int id = Convert.ToInt32(DataAccessUtil.ExecuteScalar(sql, list));
            FillDataToViews(id);
        }
    }
}