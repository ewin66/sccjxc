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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TAddWinform.Model;

namespace TAddWinform {
    //仓库管理窗体
    //添加,修改,删除操作之后都是查询出来所有的列表,之后条件查询才是定向查询,需要单独处理
    public partial class FormStorehouse : FormMdiBase {
        public FormStorehouse() {
            InitializeComponent();
        }
        private void FormStorehouse_Load(object sender, EventArgs e) {
            LoadStorehouseList();
        }
        //添加仓库事件
        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            FormAddAndUpdateStorehouse frm = new FormAddAndUpdateStorehouse();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.AddStorehouseEvent+=frm_AddStorehouseEvent;
            frm.ShowDialog();
        }
        //查询全部事件
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            LoadStorehouseList();
        }
        //条件查询仓库事件
        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormStorehouseWhere frm = new FormStorehouseWhere();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.StorehouseWhereEvent+=frm_StorehouseWhereEvent;
            frm.ShowDialog();
        }
        //修改仓库事件
        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("双击每行单元格进行修改");
        }
        //删除仓库事件
        private void barLargeButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteStorehouseById();
        }

        private void DeleteStorehouseById()
        {
            if (gridView1.FocusedRowHandle < 0) {
                return;
            }
            try {
                if (_info.InRowCell) {
                    int selectRow = gridView1.GetSelectedRows()[0];  //获得选中的第一行的下标
                    var id = Convert.ToInt32(gridView1.GetRowCellValue(selectRow, gridView1.Columns["Id"])); //根据下标选择列值
                    string sql = "Update " + Program.DataBaseName + "..MD_Storehouse set actived=0 where id="+id;
                    List<SqlParameter> list = new List<SqlParameter>();
                    if (DataAccessUtil.ExecuteNonQuery(sql,list)>0)
                    {
                        LoadStorehouseList();}
                }
            } catch (Exception exception) {
                ErrorHandler.OnError(exception);
            }
        }

        private void LoadStorehouseList()
        {
            string sql = "select * from "+Program.DataBaseName+"..MD_Storehouse where Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            List<Storehouse> storehouses = new List<Storehouse>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql,list);
            foreach (DataRow row in table.Rows)
            {
                storehouses.Add(new Storehouse()
                {
                    Id = Convert.ToInt32(row["id"]),
                    StorehouseCode = row["StorehouseCode"].ToString(),
                    StorehouseName = row["StorehouseName"].ToString(),
                    Actived = Convert.ToBoolean(row["Actived"]),
                    Remark = row["Remark"].ToString()
                });
            }

            gridControl1.DataSource = storehouses;
        }
        public void frm_AddStorehouseEvent()
        {
            LoadStorehouseList();
        }

        public void frm_StorehouseWhereEvent(List<Storehouse>  cStorehouses)
        {
            gridControl1.DataSource = cStorehouses;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e) {
            if (gridView1.FocusedRowHandle < 0) {
                return;
            }

            try
            {
                if (_info.InRowCell)
                {
                    FormAddAndUpdateStorehouse frm = new FormAddAndUpdateStorehouse();
                    int selectRow = gridView1.GetSelectedRows()[0];  //获得选中的第一行的下标
                    var id = Convert.ToInt32(gridView1.GetRowCellValue(selectRow, gridView1.Columns["Id"])); //根据下标选择列值
                    frm.Tag = id;frm.UpdateEvent += frm_AddStorehouseEvent;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.OnError(exception);
            }
        }


        private GridHitInfo _info = null;
        /// <summary>
        /// GridView中的鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_MouseDown_1(object sender, MouseEventArgs e) {
            _info = gridView1.CalcHitInfo(e.Y, e.Y);
        }
    }
}