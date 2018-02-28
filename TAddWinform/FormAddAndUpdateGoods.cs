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
    public partial class FormAddAndUpdateGoods : FormMdiBase {
        public FormAddAndUpdateGoods() {
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
            //跳过来的tag是否有值,有值是修改,无值是添加
            if (Tag!=null&&Convert.ToInt32(Tag)>0)
            {
                btnAdd.Text = "修改";
                FillData(Convert.ToInt32(Tag));
            }
            else
            {
                btnCancel_Click(null, null);
                btnAdd.Text = "添加";
            }
        }

        private void FillData(int id)
        {
            string sql = "select * from "+Program.DataBaseName+"..MD_Goods" +
                         " where id=@id and Actived=1";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@id",id)
            };
            DataRow row = DataAccessUtil.ExecuteDataTable(sql,list).Rows[0];
            txtCode.Text = row["GoodsCode"].ToString();
            txtName.Text = row["GoodsName"].ToString();
            lueGoodsFrom.EditValue = row["GoodsFromId"];
            lueGoodsCategory.EditValue = row["GoodsCategoryId"];
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
                if (btnAdd.Text.Equals("添加"))
                {
                    //进行商品的添加
                    AddGoods();
                }
                else
                {
                    //进行商品的修改
                    UpdateGoods();
                }
                
            } catch (Exception exception) {
                ErrorHandler.OnError(exception);
            }
        }

        private void UpdateGoods()
        {
            string sql = "update "+Program.DataBaseName+"..MD_Goods set" +
                         " GoodsCode=@code,GoodsName=@name,GoodsFromId=@fid,GoodsCategoryId=@cid" +
                         " where id=@id and Actived=1";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@code",txtCode.Text.Trim()),
                new SqlParameter("@name",txtName.Text.Trim()),
                new SqlParameter("@fid",lueGoodsFrom.EditValue),
                new SqlParameter("@cid",lueGoodsCategory.EditValue),
                new SqlParameter("@id",Convert.ToInt32(Tag))
            };
            if (DataAccessUtil.ExecuteNonQuery(sql,list)>0)
            {
                SelectAllGoodsesEvent();
                this.Close();//修改成功关闭窗口
            }
            else
            {
                throw new ApplicationException("修改失败");
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