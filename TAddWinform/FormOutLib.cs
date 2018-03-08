using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using TAddWinform.Model;

namespace TAddWinform
{
    public partial class FormOutLib : FormMdiBase
    {
        public FormOutLib()
        {
            InitializeComponent();
        }

        #region 五个下拉框的数据加载
        private void FormOutLib_Load(object sender, EventArgs e)
        {
            LoadlueCompanyData();
            LoadLueStorehouseData();
            LoadLueGoodsNameData();
            LoadGoodsCategoryData();
            LoadGoodsFromData();
        }

        private void LoadGoodsFromData()
        {
            string sql = "select * from " + Program.DataBaseName + "..MD_GoodsFrom where actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<GoodsFrom> goodsFroms = new List<GoodsFrom>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows) {
                goodsFroms.Add(new GoodsFrom() {
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
            foreach (DataRow row in table.Rows) {
                goodsCategories.Add(new GoodsCategory() {
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
            foreach (DataRow row in table.Rows) {
                goodsNameList.Add(new Goods() {
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
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,sqlParameters);
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
            string sql = "select * from "+Program.DataBaseName+"..MD_Company where Actived=1 and CompanyType=0";
            List<SqlParameter> list = new List<SqlParameter>();
            List<Company> companies = new List<Company>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,list);
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

    }
}