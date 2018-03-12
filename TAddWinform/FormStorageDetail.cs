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

namespace TAddWinform
{
    public partial class FormStorageDetail : FormMdiBase
    {
        public FormStorageDetail()
        {
            InitializeComponent();
        }

        public delegate void OpenInDetail(int id);

        public event OpenInDetail OpenInDetailEvent;



        //加载
        private void FormStorageDetail_Load(object sender, EventArgs e)
        {
            List<StorageDetail> storageDetails = new List<StorageDetail>();
            string sql =
                "select b.Id,b.MakeDate, g.GoodsName,gf.GoodsFromName,gc.GoodsCategoryName,s.StorehouseName,bi.Count,b.Maker,b.Remark from MD_BillItem as bi inner join MD_Bill as b on bi.Bill_ID=b.ID inner join MD_GoodsFrom as gf on bi.GoodsFrom_ID=gf.ID inner join MD_GoodsCategory as gc on bi.GoodsCategory_ID=gc.ID inner join MD_Storehouse as s on b.Storehouse_ID=s.ID inner join MD_Goods as g on bi.GoodsName=g.ID" +
                " where b.billtype_id=1 and g.Actived=1";
            List<SqlParameter> list = new List<SqlParameter>();
            DataTable table = DataAccessUtil.ExecuteDataTable(sql, list);
            foreach (DataRow row in table.Rows)
            {
                storageDetails.Add(new StorageDetail()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    MakeDate = row["MakeDate"].ToString(),
                    GoodsName = row["GoodsName"].ToString(),
                    GoodsFromName = row["GoodsFromName"].ToString(),
                    GoodsCategoryName = row["GoodsCategoryName"].ToString(),
                    StorehouseName = row["StorehouseName"].ToString(),
                    Count = row["Count"].ToString(),
                    Maker = row["Maker"].ToString(),
                    Remark = row["Remark"].ToString()
                });
            }

            gridControl1.DataSource = storageDetails;
        }

        /*单元格的双击事件
         双击之后传值跳转到入库单界面,显示入库的明细
         */
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            try
            {
                if (_hInfo.InRowCell)
                {
                    int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                    FormPurchase frm = new FormPurchase { Tag = id };
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private GridHitInfo _hInfo = null;

        private void gridView1_MouseDown_1(object sender, MouseEventArgs e)
        {
            _hInfo = gridView1.CalcHitInfo(e.Y, e.Y);
        }


        //private void ShowMdiForm(Type ucType)
        //{

        //    FormMdiBase formTemp = null;
        //    //Serach Mdi Form
        //    foreach (Form formMdiTemp in this.MdiChildren)
        //    {
        //        if (formMdiTemp.GetType().Name == ucType.Name)
        //        {
        //            formTemp = formMdiTemp as FormMdiBase;
        //            break;
        //        }
        //    }
        //    //Create Mdi Form From Assembly
        //    if (formTemp == null)
        //    {
        //        try
        //        {
        //            formTemp = (FormMdiBase)System.Activator.CreateInstance(ucType, null, null);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }


        //        if (formTemp != null)
        //        {
        //            formTemp.LoadMdiForm += new MdiFormLoadEventHandler(LoadMdiFormHandler);
        //            formTemp.UnloadMdiForm += new MdiFormUnLoadEventHandler(UnLoadMdiFormHandler);
        //        }
        //    }
        //    if (formTemp == null)
        //    {
        //        MessageBox.Show("This function does not exist.");
        //        return;
        //    }
        //    formTemp.MdiParent = this;
        //    formTemp.BringToFront();
        //    formTemp.Show();
        //}

        //private void LoadMdiFormHandler(FormMdiBase sender)
        //{
        //    DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem();
        //    item.Caption = sender.Text;
        //    item.Tag = sender.GetType();
        //    item.ItemClick += MdiBarItemClick;
        //    smunWindows.AddItem(item);
        //}

        //private void UnLoadMdiFormHandler(FormMdiBase sender)
        //{
        //    foreach (DevExpress.XtraBars.BarItemLink item in smunWindows.ItemLinks)
        //    {
        //        if (item.Caption == sender.Text)
        //        {
        //            smunWindows.ItemLinks.Remove(item);
        //            break;
        //        }
        //    }
        //}

        //private void MdiBarItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    Type frmType = e.Item.Tag as Type;
        //    if (frmType == null) return;
        //    ShowMdiForm(frmType);
        //}
    }
}