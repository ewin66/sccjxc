using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TAddWinform {
    public partial class FormGoodsWhere : FormMdiBase {
        public FormGoodsWhere() {
            InitializeComponent();
        }
        /**
         * 声明事件和委托
         */
        public delegate void SelectGoodses(Goods goods);

        public event SelectGoodses SelectGoodsesEvent;


        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGoodsWhere_Load(object sender, EventArgs e) {
            //创建表单的时候加载产地和品种的下拉选择框的数据
            LoadLueFromData();
            LoadLueCategoryData();
        }
        /// <summary>
        /// 加载品种下拉框
        /// </summary>
        private void LoadLueCategoryData()
        {
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
            lueCategory.Properties.DisplayMember = "GoodsCategoryName";//此处区分大小写
            lueCategory.Properties.ValueMember = "Id"; //此处区分大小写
            lueCategory.Properties.DataSource = listCategory;
        }

        /// <summary>
        /// 加载产地下拉框
        /// </summary>
        private void LoadLueFromData()
        {
            List<GoodsFrom> listFrom = new List<GoodsFrom>();
            string sql = "select * from " + Program.DataBaseName + "..MD_GoodsFrom where Actived=1";
            DataTable table = DbHelperSQL.Query(sql).Tables[0];
            foreach (DataRow row in table.Rows) {
                listFrom.Add(new GoodsFrom()
                {
                    Id = Convert.ToInt32(row["id"]),
                    GoodsFromCode = row["GoodsFromCode"].ToString(),
                    GoodsFromName = row["GoodsFromName"].ToString(),
                    Actived = Convert.ToBoolean(row["Actived"])
                });
            }

            lueFrom.Properties.DisplayMember = "GoodsFromName";//此处区分大小写
            lueFrom.Properties.ValueMember = "Id";//此处区分大小写
            lueFrom.Properties.DataSource = listFrom;
        }
        /// <summary>
        /// 点击搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SelectGoods();

        }
        /// <summary>
        /// 搜索逻辑方法
        /// </summary>
        private void SelectGoods()
        {
            Goods goods = new Goods();
            if (!string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                goods.GoodsCode = txtCode.Text.Trim();
            }

            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                goods.GoodsName = txtName.Text.Trim();
            }
            if (Convert.ToInt32(lueFrom.EditValue)>0)
            {
                goods.GoodsFromId = Convert.ToInt32(lueFrom.EditValue);
            }
            if (Convert.ToInt32(lueCategory.EditValue) > 0) {
                goods.GoodCategoryId = Convert.ToInt32(lueCategory.EditValue);
            }

            SelectGoodsesEvent(goods);this.Close();
        }

        /// <summary>
        /// 点击取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}