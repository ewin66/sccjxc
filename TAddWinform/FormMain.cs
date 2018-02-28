using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace TAddWinform
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.lblUser.Caption = CurrentUser.Instance.UserName;
            this.cAccountName.Caption = GlobalParameters.Company;
            this.lblLoginDate.Caption = DateTime.Now.ToString();
            if (GlobalParameters.iLanugage > 10)
            {
                this.trvWorkShop.BeginUnboundLoad();
                this.trvWorkShop.AppendNode(new object[] {
            "Inventory Inquiry"}, -1, 2, 2, -1);
                this.trvWorkShop.AppendNode(new object[] {
            "User Account Setting"}, -1, 2, 2, -1);
                this.trvWorkShop.EndUnboundLoad();
                smnuSystem.Caption = "System";
                smunWindows.Caption = "Window";
               
                this.nbgWorkshop.Caption = "Operations";
                this.btnExit.Caption = "Exit";
                this.btnRestart.Caption = "Restart";
                this.btnPassWord.Caption = "Change Password";
                this.Text = "Inventory Inquiry";
            }
            else
            {
                this.trvWorkShop.BeginUnboundLoad();
                this.trvWorkShop.AppendNode(new object[] {
            "现存量查询"}, -1, 2, 2, -1);
                this.trvWorkShop.AppendNode(new object[] {
            "用户设置"}, -1, 2, 2, -1);
                this.trvWorkShop.EndUnboundLoad();
                smnuSystem.Caption = "系统";
                smunWindows.Caption = "窗口";
                this.nbgWorkshop.Caption = "业务管理";
            }

            if (CurrentUser.Instance.IsAdmin == false)
            {
                this.trvWorkShop.Nodes[1].Visible = false;
            }
            //初始化显示窗口
            // ShowMdiForm(typeof(FormLog));

            // this.trvWorkShop.Nodes[1].Visible = false;


        }

        private void ShowMdiForm(Type ucType)
        {

            FormMdiBase formTemp = null;
            //Serach Mdi Form
            foreach (Form formMdiTemp in this.MdiChildren)
            {
                if (formMdiTemp.GetType().Name == ucType.Name)
                {
                    formTemp = formMdiTemp as FormMdiBase;
                    break;
                }
            }
            //Create Mdi Form From Assembly
            if (formTemp == null)
            {
                try
                {
                    formTemp = (FormMdiBase)System.Activator.CreateInstance(ucType, null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                if (formTemp != null)
                {
                    formTemp.LoadMdiForm += new MdiFormLoadEventHandler(LoadMdiFormHandler);
                    formTemp.UnloadMdiForm += new MdiFormUnLoadEventHandler(UnLoadMdiFormHandler);
                }
            }
            if (formTemp == null)
            {
                MessageBox.Show("This function does not exist.");
                return;
            }
            formTemp.MdiParent = this;
            formTemp.BringToFront();
            formTemp.Show();
        }

        private void LoadMdiFormHandler(FormMdiBase sender)
        {
            DevExpress.XtraBars.BarButtonItem item = new DevExpress.XtraBars.BarButtonItem();
            item.Caption = sender.Text;
            item.Tag = sender.GetType();
            item.ItemClick += MdiBarItemClick;
            smunWindows.AddItem(item);
        }

        private void UnLoadMdiFormHandler(FormMdiBase sender)
        {
            foreach (DevExpress.XtraBars.BarItemLink item in smunWindows.ItemLinks)
            {
                if (item.Caption == sender.Text)
                {
                    smunWindows.ItemLinks.Remove(item);
                    break;
                }
            }
        }

        private void MdiBarItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Type frmType = e.Item.Tag as Type;
            if (frmType == null) return;
            ShowMdiForm(frmType);
        }

        private void barMain_Merge(object sender, DevExpress.XtraBars.BarManagerMergeEventArgs e)
        {
            //    foreach (DevExpress.XtraBars.Bar bar in e.ChildManager.Bars)
            //    {
            //        barChild.Merge(bar);
            //        bar.Visible = false;
            //    }
        }

        private void btnReLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Restart();
        }
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }


        private void TreeView_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.TreeList trvTemp = sender as DevExpress.XtraTreeList.TreeList;
            if (trvTemp.FocusedNode.HasChildren) return;

            string strDisplayName = trvTemp.FocusedNode[0].ToString();
            if (GlobalParameters.iLanugage > 10)
            {
                switch (strDisplayName)
                {
                    case "Inventory Inquiry":
                        ShowMdiForm(typeof(FormOrder));
                        break;
                    case "User Account Setting":
                        ShowMdiForm(typeof(FormUser));
                        break;
                }
            }else
            {
                switch (strDisplayName)
                {
                    case "现存量查询":
                        ShowMdiForm(typeof(FormOrder));
                        break;
                    case "用户设置":
                        ShowMdiForm(typeof(FormUser));
                        break;
                    case "商品操作":
                        ShowMdiForm(typeof(FormGoods));
                        break;
                    case "关联单位操作":
                        ShowMdiForm(typeof(FormCompany));
                        break;
                }
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPassWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPwd frm = new FormPwd();
            frm.ShowDialog();
        }

    }
}