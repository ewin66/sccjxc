namespace TAddWinform {
    partial class FormPurchase {
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnReset = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeleteRow = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lueStorehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMaker = new DevExpress.XtraEditors.TextEdit();
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.txtCompany = new DevExpress.XtraEditors.TextEdit();
            this.txtPurOddNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtPurdate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GoodsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GoodsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGoodsName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.GoodsFromName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGoodsFromName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.GoodsCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueGoodsCategoryName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.UnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueStorehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurOddNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsFromName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsCategoryName)).BeginInit();
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
            this.btnSave,
            this.btnReset,
            this.barStaticItem1,
            this.btnAddRow,
            this.btnDeleteRow});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
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
            this.barStaticItem1.Caption = "入库明细";
            this.barStaticItem1.Id = 3;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReset),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddRow),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDeleteRow)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.Id = 1;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnReset
            // 
            this.btnReset.Caption = "重置";
            this.btnReset.Id = 2;
            this.btnReset.Name = "btnReset";
            this.btnReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReset_ItemClick);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Caption = "添加行";
            this.btnAddRow.Id = 4;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddRow_ItemClick);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Caption = "删除行";
            this.btnDeleteRow.Id = 5;
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeleteRow_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(741, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 414);
            this.barDockControlBottom.Size = new System.Drawing.Size(741, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 359);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(741, 55);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 359);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "保存";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageUri.Uri = "Apply";
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lueStorehouse);
            this.layoutControl1.Controls.Add(this.txtMaker);
            this.layoutControl1.Controls.Add(this.textEdit5);
            this.layoutControl1.Controls.Add(this.txtCompany);
            this.layoutControl1.Controls.Add(this.txtPurOddNumber);
            this.layoutControl1.Controls.Add(this.txtPurdate);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 55);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(289, 266, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(741, 93);
            this.layoutControl1.TabIndex = 11;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lueStorehouse
            // 
            this.lueStorehouse.Location = new System.Drawing.Point(551, 51);
            this.lueStorehouse.MenuManager = this.barManager1;
            this.lueStorehouse.Name = "lueStorehouse";
            this.lueStorehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStorehouse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StorehouseName", "StorehouseName")});
            this.lueStorehouse.Properties.NullText = "请选择";
            this.lueStorehouse.Properties.ShowFooter = false;
            this.lueStorehouse.Properties.ShowHeader = false;
            this.lueStorehouse.Size = new System.Drawing.Size(173, 20);
            this.lueStorehouse.StyleController = this.layoutControl1;
            this.lueStorehouse.TabIndex = 10;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(551, 17);
            this.txtMaker.MenuManager = this.barManager1;
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(173, 20);
            this.txtMaker.StyleController = this.layoutControl1;
            this.txtMaker.TabIndex = 9;
            // 
            // textEdit5
            // 
            this.textEdit5.EditValue = "入库单";
            this.textEdit5.Location = new System.Drawing.Point(330, 51);
            this.textEdit5.MenuManager = this.barManager1;
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit5.Size = new System.Drawing.Size(135, 20);
            this.textEdit5.StyleController = this.layoutControl1;
            this.textEdit5.TabIndex = 8;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(89, 51);
            this.txtCompany.MenuManager = this.barManager1;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(155, 20);
            this.txtCompany.StyleController = this.layoutControl1;
            this.txtCompany.TabIndex = 7;
            // 
            // txtPurOddNumber
            // 
            this.txtPurOddNumber.Location = new System.Drawing.Point(89, 17);
            this.txtPurOddNumber.MenuManager = this.barManager1;
            this.txtPurOddNumber.Name = "txtPurOddNumber";
            this.txtPurOddNumber.Size = new System.Drawing.Size(155, 20);
            this.txtPurOddNumber.StyleController = this.layoutControl1;
            this.txtPurOddNumber.TabIndex = 5;
            // 
            // txtPurdate
            // 
            this.txtPurdate.Location = new System.Drawing.Point(330, 17);
            this.txtPurdate.MenuManager = this.barManager1;
            this.txtPurdate.Name = "txtPurdate";
            this.txtPurdate.Size = new System.Drawing.Size(135, 20);
            this.txtPurdate.StyleController = this.layoutControl1;
            this.txtPurdate.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 20;
            this.layoutControlGroup1.Size = new System.Drawing.Size(741, 93);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtPurdate;
            this.layoutControlItem1.Location = new System.Drawing.Point(241, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(221, 34);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Text = "入库日期:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPurOddNumber;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(241, 34);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem2.Text = "入库单号:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCompany;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 34);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(136, 34);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(241, 39);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Text = "供货单位:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.textEdit5;
            this.layoutControlItem5.Location = new System.Drawing.Point(241, 34);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(221, 39);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem5.Text = "单据类型:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtMaker;
            this.layoutControlItem6.Location = new System.Drawing.Point(462, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(259, 34);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Text = "制单人:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueStorehouse;
            this.layoutControlItem3.Location = new System.Drawing.Point(462, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(259, 39);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Text = "仓库: ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 14);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 148);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueGoodsName,
            this.lueGoodsFromName,
            this.lueGoodsCategoryName});
            this.gridControl1.Size = new System.Drawing.Size(741, 266);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GoodsCode,
            this.GoodsName,
            this.GoodsFromName,
            this.GoodsCategoryName,
            this.UnitPrice,
            this.Count,
            this.Total});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // GoodsCode
            // 
            this.GoodsCode.AppearanceCell.Options.UseTextOptions = true;
            this.GoodsCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsCode.AppearanceHeader.Options.UseTextOptions = true;
            this.GoodsCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsCode.Caption = "商品编码";
            this.GoodsCode.FieldName = "GoodsCode";
            this.GoodsCode.Name = "GoodsCode";
            this.GoodsCode.Visible = true;
            this.GoodsCode.VisibleIndex = 0;
            // 
            // GoodsName
            // 
            this.GoodsName.AppearanceCell.Options.UseTextOptions = true;
            this.GoodsName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsName.AppearanceHeader.Options.UseTextOptions = true;
            this.GoodsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsName.Caption = "商品名称";
            this.GoodsName.ColumnEdit = this.lueGoodsName;
            this.GoodsName.FieldName = "GoodsName";
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Visible = true;
            this.GoodsName.VisibleIndex = 1;
            // 
            // lueGoodsName
            // 
            this.lueGoodsName.AutoHeight = false;
            this.lueGoodsName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoodsName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsName", "商品名称")});
            this.lueGoodsName.Name = "lueGoodsName";
            this.lueGoodsName.NullText = "请选择";
            this.lueGoodsName.ShowFooter = false;
            this.lueGoodsName.ShowHeader = false;
            // 
            // GoodsFromName
            // 
            this.GoodsFromName.AppearanceCell.Options.UseTextOptions = true;
            this.GoodsFromName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsFromName.AppearanceHeader.Options.UseTextOptions = true;
            this.GoodsFromName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsFromName.Caption = "商品产地";
            this.GoodsFromName.ColumnEdit = this.lueGoodsFromName;
            this.GoodsFromName.FieldName = "GoodsFromName";
            this.GoodsFromName.Name = "GoodsFromName";
            this.GoodsFromName.Visible = true;
            this.GoodsFromName.VisibleIndex = 2;
            // 
            // lueGoodsFromName
            // 
            this.lueGoodsFromName.AutoHeight = false;
            this.lueGoodsFromName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoodsFromName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsFromName", "商品产地")});
            this.lueGoodsFromName.Name = "lueGoodsFromName";
            this.lueGoodsFromName.NullText = "请选择";
            this.lueGoodsFromName.ShowFooter = false;
            this.lueGoodsFromName.ShowHeader = false;
            // 
            // GoodsCategoryName
            // 
            this.GoodsCategoryName.AppearanceCell.Options.UseTextOptions = true;
            this.GoodsCategoryName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsCategoryName.AppearanceHeader.Options.UseTextOptions = true;
            this.GoodsCategoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GoodsCategoryName.Caption = "商品种类";
            this.GoodsCategoryName.ColumnEdit = this.lueGoodsCategoryName;
            this.GoodsCategoryName.FieldName = "GoodsCategoryName";
            this.GoodsCategoryName.Name = "GoodsCategoryName";
            this.GoodsCategoryName.Visible = true;
            this.GoodsCategoryName.VisibleIndex = 3;
            // 
            // lueGoodsCategoryName
            // 
            this.lueGoodsCategoryName.AutoHeight = false;
            this.lueGoodsCategoryName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoodsCategoryName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsCategoryName", "商品种类")});
            this.lueGoodsCategoryName.Name = "lueGoodsCategoryName";
            this.lueGoodsCategoryName.NullText = "请选择";
            this.lueGoodsCategoryName.ShowFooter = false;
            this.lueGoodsCategoryName.ShowHeader = false;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AppearanceCell.Options.UseTextOptions = true;
            this.UnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UnitPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.UnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UnitPrice.Caption = "单价";
            this.UnitPrice.FieldName = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Visible = true;
            this.UnitPrice.VisibleIndex = 4;
            // 
            // Count
            // 
            this.Count.AppearanceCell.Options.UseTextOptions = true;
            this.Count.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Count.AppearanceHeader.Options.UseTextOptions = true;
            this.Count.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Count.Caption = "数量";
            this.Count.FieldName = "Count";
            this.Count.Name = "Count";
            this.Count.Visible = true;
            this.Count.VisibleIndex = 5;
            // 
            // Total
            // 
            this.Total.AppearanceCell.Options.UseTextOptions = true;
            this.Total.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Total.AppearanceHeader.Options.UseTextOptions = true;
            this.Total.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Total.Caption = "总金额";
            this.Total.FieldName = "Total";
            this.Total.Name = "Total";
            this.Total.Visible = true;
            this.Total.VisibleIndex = 6;
            // 
            // FormPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 437);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormPurchase";
            this.Text = "采购入库";
            this.Load += new System.EventHandler(this.FormPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueStorehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurOddNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsFromName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsCategoryName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnReset;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtMaker;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.TextEdit txtPurOddNumber;
        private DevExpress.XtraEditors.TextEdit txtPurdate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn GoodsCode;
        private DevExpress.XtraGrid.Columns.GridColumn GoodsName;
        private DevExpress.XtraGrid.Columns.GridColumn GoodsFromName;
        private DevExpress.XtraGrid.Columns.GridColumn GoodsCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn UnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn Count;
        private DevExpress.XtraGrid.Columns.GridColumn Total;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGoodsName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGoodsFromName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueGoodsCategoryName;
        private DevExpress.XtraEditors.LookUpEdit lueStorehouse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem btnAddRow;
        private DevExpress.XtraBars.BarButtonItem btnDeleteRow;


    }
}