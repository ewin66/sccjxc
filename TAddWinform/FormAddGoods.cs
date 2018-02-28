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

namespace TAddWinform {
    public partial class FormAddGoods : DevExpress.XtraEditors.XtraForm {
        public FormAddGoods() {
            InitializeComponent();
        }

        //委托和事件
        public delegate void SelectAllGoodses();

        public event SelectAllGoodses SelectAllGoodsesEvent;

        /// <summary>
        /// 表单加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddGoods_Load(object sender, EventArgs e) {
            //创建表单的时候加载产地和品种的下拉选择框的数据
            LoadLueFromData();
            LoadLueCategoryData();
        }

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                //添加时检查控件是否有值
                CheckViewDatas();
                //进行商品的添加
                AddGoods();
            } catch (Exception exception) {
                ErrorHandler.OnError(exception);
            }
        }

        private void AddGoods() {
            string sql = "insert into " + Program.DataBaseName +
                         "..MD_Goods(GoodsCode,GoodsName,GoodsFromId,GoodsCategoryId)" +
                         " values(@code,@name,@from,@category)";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@code",txtCode.Text.Trim()),
                new SqlParameter("@name",txtName.Text.Trim()),
                new SqlParameter("@from",lueGoodsFrom.EditValue),
                new SqlParameter("@category",lueGoodsCategory.EditValue),
            };
            int i = DataAccessUtil.ExecuteNonQuery(sql, list);
            if (i > 0) {
                btnCancel_Click(null, null);
                SelectAllGoodsesEvent();
            } else {
                throw new ApplicationException("添加失败..");
            }
        }

        private void CheckViewDatas() {
            if (string.IsNullOrEmpty(txtCode.Text.Trim())) {
                throw new ApplicationException("商品编码不能为空!");
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim())) {
                throw new ApplicationException("商品名称不能为空!");
            }

            if (Convert.ToInt32(lueGoodsFrom.EditValue) <= 0) {
                throw new ApplicationException("请选择商品产地!");
            }

            if (Convert.ToInt32(lueGoodsCategory.EditValue) <= 0) {
                throw new ApplicationException("请选择商品种类!");
            }
        }

        /// <summary>
        /// 按钮取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e) {
            txtCode.Text = "";
            txtName.Text = "";
            lueGoodsFrom.EditValue = null;
            lueGoodsCategory.EditValue = null;
        }




        /// <summary>
        /// 加载品种下拉框
        /// </summary>
        private void LoadLueCategoryData() {
            List<GoodsCategory> listCategory = new List<GoodsCategory>();
            string sql = "select * from " + Program.DataBaseName + "..MD_GoodsCategory where Actived=1";
            DataTable table = DbHelperSQL.Query(sql).Tables[0];
            foreach (DataRow row in table.Rows) {
                listCategory.Add(new GoodsCategory() {
                    Id = Convert.ToInt32(row["id"]),
                    GoodsCategoryCode = row["GoodsCategoryCode"].ToString(),
                    GoodsCategoryName = row["GoodsCategoryName"].ToString(),
                    Actived = Convert.ToBoolean(row["Actived"])
                });
            }
            lueGoodsCategory.Properties.DisplayMember = "GoodsCategoryName";//此处区分大小写
            lueGoodsCategory.Properties.ValueMember = "Id"; //此处区分大小写
            lueGoodsCategory.Properties.DataSource = listCategory;
        }

        /// <summary>
        /// 加载产地下拉框
        /// </summary>
        private void LoadLueFromData() {
            List<GoodsFrom> listFrom = new List<GoodsFrom>();
            string sql = "select * from " + Program.DataBaseName + "..MD_GoodsFrom where Actived=1";
            DataTable table = DbHelperSQL.Query(sql).Tables[0];
            foreach (DataRow row in table.Rows) {
                listFrom.Add(new GoodsFrom() {
                    Id = Convert.ToInt32(row["id"]),
                    GoodsFromCode = row["GoodsFromCode"].ToString(),
                    GoodsFromName = row["GoodsFromName"].ToString(),
                    Actived = Convert.ToBoolean(row["Actived"])
                });
            }

            lueGoodsFrom.Properties.DisplayMember = "GoodsFromName";//此处区分大小写
            lueGoodsFrom.Properties.ValueMember = "Id";//此处区分大小写
            lueGoodsFrom.Properties.DataSource = listFrom;
        }
    }
}