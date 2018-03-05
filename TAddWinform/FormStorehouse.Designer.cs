namespace TAddWinform {
    partial class FormStorehouse {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem3 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem4 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem5 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StorehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StorehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barLargeButtonItem1,
            this.barLargeButtonItem2,
            this.barLargeButtonItem3,
            this.barLargeButtonItem4,
            this.barLargeButtonItem5,
            this.barStaticItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar1.Text = "Tools";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "数据展示";
            this.barStaticItem1.Id = 6;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem5)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Caption = "查询全部";
            this.barLargeButtonItem1.Id = 1;
            this.barLargeButtonItem1.ImageUri.Uri = "Zoom";
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.Caption = "条件查询";
            this.barLargeButtonItem2.Id = 2;
            this.barLargeButtonItem2.ImageUri.Uri = "Zoom100";
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            // 
            // barLargeButtonItem3
            // 
            this.barLargeButtonItem3.Caption = "修改";
            this.barLargeButtonItem3.Id = 3;
            this.barLargeButtonItem3.ImageUri.Uri = "Recurrence";
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            this.barLargeButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            // 
            // barLargeButtonItem4
            // 
            this.barLargeButtonItem4.Caption = "添加";
            this.barLargeButtonItem4.Id = 4;
            this.barLargeButtonItem4.ImageUri.Uri = "Add";
            this.barLargeButtonItem4.Name = "barLargeButtonItem4";
            this.barLargeButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem4_ItemClick);
            // 
            // barLargeButtonItem5
            // 
            this.barLargeButtonItem5.Caption = "删除";
            this.barLargeButtonItem5.Id = 5;
            this.barLargeButtonItem5.ImageUri.Uri = "Cancel";
            this.barLargeButtonItem5.Name = "barLargeButtonItem5";
            this.barLargeButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem5_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(443, 91);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 288);
            this.barDockControlBottom.Size = new System.Drawing.Size(443, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 91);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 197);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(443, 91);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 197);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "查询全部";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageUri.Uri = "Zoom";
            this.barButtonItem1.Name = "barButtonItem1";
            toolTipTitleItem1.Text = "查询全部";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.barButtonItem1.SuperTip = superToolTip1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 91);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(443, 197);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.StorehouseCode,
            this.StorehouseName,
            this.Remark});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown_1);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // StorehouseCode
            // 
            this.StorehouseCode.AppearanceCell.Options.UseTextOptions = true;
            this.StorehouseCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StorehouseCode.AppearanceHeader.Options.UseTextOptions = true;
            this.StorehouseCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StorehouseCode.Caption = "仓库编码";
            this.StorehouseCode.FieldName = "StorehouseCode";
            this.StorehouseCode.Name = "StorehouseCode";
            this.StorehouseCode.Visible = true;
            this.StorehouseCode.VisibleIndex = 0;
            // 
            // StorehouseName
            // 
            this.StorehouseName.AppearanceCell.Options.UseTextOptions = true;
            this.StorehouseName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StorehouseName.AppearanceHeader.Options.UseTextOptions = true;
            this.StorehouseName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StorehouseName.Caption = "仓库名称";
            this.StorehouseName.FieldName = "StorehouseName";
            this.StorehouseName.Name = "StorehouseName";
            this.StorehouseName.Visible = true;
            this.StorehouseName.VisibleIndex = 1;
            // 
            // Remark
            // 
            this.Remark.AppearanceCell.Options.UseTextOptions = true;
            this.Remark.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Remark.AppearanceHeader.Options.UseTextOptions = true;
            this.Remark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Remark.Caption = "备注";
            this.Remark.FieldName = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 2;
            // 
            // FormStorehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 311);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormStorehouse";
            this.Text = "仓库管理";
            this.Load += new System.EventHandler(this.FormStorehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem3;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem4;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn StorehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn StorehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
    }
}