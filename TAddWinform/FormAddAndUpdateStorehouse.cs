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
    public partial class FormAddAndUpdateStorehouse : FormMdiBase {
        public FormAddAndUpdateStorehouse() {
            InitializeComponent();
        }

        public delegate void Update();

        public event Update UpdateEvent;


        //表单加载事件
        private void FormAddAndUpdateStorehouse_Load(object sender, EventArgs e) {
            if (Tag != null && Convert.ToInt32(Tag) > 0) {
                btnAdd.Text = "修改";
                FillData(Convert.ToInt32(Tag));
            } else {
                btnAdd.Text = "添加";
                ResetViewsData();
            }
        }

        private void FillData(int id) {
            string sql = "select * from " + Program.DataBaseName + "..MD_Storehouse where Actived=1 and id=" + id;
            List<SqlParameter> list = new List<SqlParameter>();
            DataRow row = DataAccessUtil.ExecuteDataTable(sql, list).Rows[0];
            txtCode.Text = row["StorehouseCode"].ToString();
            txtName.Text = row["StorehouseName"].ToString();
            txtRemark.Text = row["Remark"].ToString();
        }

        private void ResetViewsData() {
            txtCode.Text = "";
            txtName.Text = "";
            txtRemark.Text = "";
        }

        //委托和事件
        public delegate void AddStorehouse();

        public event AddStorehouse AddStorehouseEvent;

        private void btnAdd_Click(object sender, EventArgs e) {
            try
            {
                CheckViewDatas();
                if (btnAdd.Text == "添加")
                {
                    IsContainsToDataBase();//要添加的值是否在数据库中已经存在
                    AddToStorehouseDataBase();//添加
                }
                else
                {
                    UpdateStorehouseById();//修改需要修改的值
                }
                
            }
            catch (Exception exception)
            {
                ErrorHandler.OnError(exception);
            }
        }

        private void UpdateStorehouseById()
        {
            string sql = "update " + Program.DataBaseName + "..MD_Storehouse set StorehouseCode=@code" +
                         ",StorehouseName=@name,remark=@remark where actived=1 and id="+Convert.ToInt32(Tag);
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@code",txtCode.Text.Trim()),
                new SqlParameter("@name",txtName.Text.Trim()),
                new SqlParameter("@remark",txtRemark.Text.Trim()),
            };
            if (DataAccessUtil.ExecuteNonQuery(sql,list)>0)
            {
                //发出事件
                if (UpdateEvent != null)
                {
                    UpdateEvent();
                    this.Close();
                }
            }
        }

        private void IsContainsToDataBase() {
            string sql = "select * from " + Program.DataBaseName + "..MD_Storehouse where Actived=1" +
                         " and StorehouseCode=@code and StorehouseName=@name";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@code",txtCode.Text.Trim()),
                new SqlParameter("@name",txtName.Text.Trim())
            };
            if (DataAccessUtil.ExecuteNonQuery(sql, list) > 0) {
                throw new ApplicationException("当前要添加的值在数据库中已经存在..");
            }
        }

        private void AddToStorehouseDataBase() {
            string sql = "insert into " + Program.DataBaseName + "..MD_Storehouse(StorehouseCode,StorehouseName,remark) values(@code,@name,@remark)";
            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@code",txtCode.Text.Trim()),
                new SqlParameter("@name",txtName.Text.Trim()),
                new SqlParameter("@remark",txtRemark.Text.Trim()),
            };
            if (DataAccessUtil.ExecuteNonQuery(sql, list) > 0) {
                if (AddStorehouseEvent != null) {
                    AddStorehouseEvent();
                }
                Close();
            }
        }

        private void CheckViewDatas() {
            if (string.IsNullOrEmpty(txtCode.Text.Trim())) {
                throw new ApplicationException("仓库编码不能为空.");
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim())) {
                throw new ApplicationException("仓库名称不能为空.");
            }
        }
        //取消关闭窗体
        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }


    }
}