namespace TAddWinform
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.smnuSystem = new DevExpress.XtraBars.BarSubItem();
            this.btnRestart = new DevExpress.XtraBars.BarButtonItem();
            this.btnPassWord = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.smunWindows = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.lblUserName = new DevExpress.XtraBars.BarStaticItem();
            this.lblUser = new DevExpress.XtraBars.BarStaticItem();
            this.lblLoginDate = new DevExpress.XtraBars.BarStaticItem();
            this.cAccountName = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgTreeView = new DevExpress.Utils.ImageCollection(this.components);
            this.smnuHelp = new DevExpress.XtraBars.BarSubItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnEnglish = new DevExpress.XtraBars.BarButtonItem();
            this.btnSimplifiedChinese = new DevExpress.XtraBars.BarButtonItem();
            this.btnTraditionalChinese = new DevExpress.XtraBars.BarButtonItem();
            this.btnJapanese = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.lblCompany = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.navMain = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgWorkshop = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.trvWorkShop = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splMain = new DevExpress.XtraEditors.SplitterControl();
            this.mdiMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).BeginInit();
            this.navMain.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvWorkShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiMain)).BeginInit();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu,
            this.barStatus});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Images = this.imgTreeView;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.smnuSystem,
            this.smunWindows,
            this.smnuHelp,
            this.btnExit,
            this.btnRestart,
            this.btnAbout,
            this.btnHelp,
            this.barButtonItem1,
            this.btnEnglish,
            this.btnSimplifiedChinese,
            this.btnTraditionalChinese,
            this.lblUserName,
            this.btnJapanese,
            this.barButtonItem2,
            this.lblUser,
            this.lblLoginDate,
            this.lblCompany,
            this.barButtonItem3,
            this.btnPassWord,
            this.cAccountName,
            this.barButtonItem4,
            this.barButtonItem5});
            this.barMain.MainMenu = this.barMenu;
            this.barMain.MaxItemId = 29;
            this.barMain.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.Never;
            this.barMain.StatusBar = this.barStatus;
            this.barMain.Merge += new DevExpress.XtraBars.BarManagerMergeEventHandler(this.barMain_Merge);
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Main menu";
            this.barMenu.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.smnuSystem),
            new DevExpress.XtraBars.LinkPersistInfo(this.smunWindows)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DisableCustomization = true;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Main menu";
            // 
            // smnuSystem
            // 
            this.smnuSystem.Caption = "系统";
            this.smnuSystem.Id = 0;
            this.smnuSystem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRestart),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPassWord),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
            this.smnuSystem.Name = "smnuSystem";
            // 
            // btnRestart
            // 
            this.btnRestart.Caption = "重新启动";
            this.btnRestart.Id = 4;
            this.btnRestart.ImageIndex = 4;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReLogin_ItemClick);
            // 
            // btnPassWord
            // 
            this.btnPassWord.Caption = "修改密码";
            this.btnPassWord.Id = 23;
            this.btnPassWord.Name = "btnPassWord";
            this.btnPassWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPassWord_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "退出";
            this.btnExit.Id = 3;
            this.btnExit.ImageIndex = 3;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // smunWindows
            // 
            this.smunWindows.Caption = "窗口";
            this.smunWindows.Id = 1;
            this.smunWindows.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.smunWindows.Name = "smunWindows";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = " 换肤";
            this.barButtonItem5.Id = 28;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblUserName),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.lblUser, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblLoginDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.cAccountName)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // lblUserName
            // 
            this.lblUserName.Id = 14;
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblUser
            // 
            this.lblUser.Caption = "User";
            this.lblUser.Id = 19;
            this.lblUser.Name = "lblUser";
            this.lblUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblLoginDate
            // 
            this.lblLoginDate.Caption = "Login Date";
            this.lblLoginDate.Id = 20;
            this.lblLoginDate.Name = "lblLoginDate";
            this.lblLoginDate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // cAccountName
            // 
            this.cAccountName.Caption = "cAccountName";
            this.cAccountName.Id = 24;
            this.cAccountName.Name = "cAccountName";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(824, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 470);
            this.barDockControlBottom.Size = new System.Drawing.Size(824, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 446);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(824, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 446);
            // 
            // imgTreeView
            // 
            this.imgTreeView.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgTreeView.ImageStream")));
            this.imgTreeView.Images.SetKeyName(0, "SReport.png");
            this.imgTreeView.Images.SetKeyName(1, "SFolderOpen.png");
            this.imgTreeView.Images.SetKeyName(2, "SFunction.png");
            // 
            // smnuHelp
            // 
            this.smnuHelp.Caption = "帮助";
            this.smnuHelp.Id = 2;
            this.smnuHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAbout),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHelp)});
            this.smnuHelp.Name = "smnuHelp";
            // 
            // btnAbout
            // 
            this.btnAbout.Caption = "关于";
            this.btnAbout.Id = 5;
            this.btnAbout.ImageIndex = 1;
            this.btnAbout.Name = "btnAbout";
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "帮助";
            this.btnHelp.Id = 6;
            this.btnHelp.ImageIndex = 0;
            this.btnHelp.Name = "btnHelp";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnEnglish
            // 
            this.btnEnglish.Id = 10;
            this.btnEnglish.Name = "btnEnglish";
            // 
            // btnSimplifiedChinese
            // 
            this.btnSimplifiedChinese.Id = 11;
            this.btnSimplifiedChinese.Name = "btnSimplifiedChinese";
            // 
            // btnTraditionalChinese
            // 
            this.btnTraditionalChinese.Id = 12;
            this.btnTraditionalChinese.Name = "btnTraditionalChinese";
            // 
            // btnJapanese
            // 
            this.btnJapanese.Id = 15;
            this.btnJapanese.Name = "btnJapanese";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 18;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // lblCompany
            // 
            this.lblCompany.Id = 25;
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Id = 26;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 27;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // navMain
            // 
            this.navMain.ActiveGroup = this.nbgWorkshop;
            this.navMain.ContentButtonHint = null;
            this.navMain.Controls.Add(this.navBarGroupControlContainer2);
            this.navMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.navMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgWorkshop});
            this.navMain.Location = new System.Drawing.Point(0, 24);
            this.navMain.Name = "navMain";
            this.navMain.OptionsNavPane.ExpandedWidth = 194;
            this.navMain.Size = new System.Drawing.Size(194, 446);
            this.navMain.TabIndex = 6;
            this.navMain.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // nbgWorkshop
            // 
            this.nbgWorkshop.Caption = "业务管理";
            this.nbgWorkshop.ControlContainer = this.navBarGroupControlContainer2;
            this.nbgWorkshop.Expanded = true;
            this.nbgWorkshop.GroupClientHeight = 500;
            this.nbgWorkshop.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgWorkshop.Name = "nbgWorkshop";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.trvWorkShop);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(194, 371);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // trvWorkShop
            // 
            this.trvWorkShop.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.trvWorkShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvWorkShop.Location = new System.Drawing.Point(0, 0);
            this.trvWorkShop.Name = "trvWorkShop";
            this.trvWorkShop.BeginUnboundLoad();
            this.trvWorkShop.AppendNode(new object[] {
            "系统操作"}, -1, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "商品操作"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "关联单位操作"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "采购入库"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "仓库管理"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "现存量"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "销售出库"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "入库明细"}, 0, 0, 1, -1);
            this.trvWorkShop.AppendNode(new object[] {
            "出库明细"}, 0, 0, 1, -1);
            this.trvWorkShop.EndUnboundLoad();
            this.trvWorkShop.OptionsBehavior.Editable = false;
            this.trvWorkShop.OptionsBehavior.PopulateServiceColumns = true;
            this.trvWorkShop.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.trvWorkShop.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.trvWorkShop.OptionsView.ShowColumns = false;
            this.trvWorkShop.OptionsView.ShowHorzLines = false;
            this.trvWorkShop.OptionsView.ShowIndicator = false;
            this.trvWorkShop.OptionsView.ShowVertLines = false;
            this.trvWorkShop.SelectImageList = this.imgTreeView;
            this.trvWorkShop.Size = new System.Drawing.Size(194, 371);
            this.trvWorkShop.TabIndex = 2;
            this.trvWorkShop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trvWorkShop_FocusedNodeChanged);
            this.trvWorkShop.DoubleClick += new System.EventHandler(this.TreeView_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "DisplayName";
            this.treeListColumn1.FieldName = "DisplayName";
            this.treeListColumn1.MinWidth = 69;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // splMain
            // 
            this.splMain.Location = new System.Drawing.Point(194, 24);
            this.splMain.Name = "splMain";
            this.splMain.Size = new System.Drawing.Size(5, 446);
            this.splMain.TabIndex = 5;
            this.splMain.TabStop = false;
            // 
            // mdiMain
            // 
            this.mdiMain.MdiParent = this;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(824, 497);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.navMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Office 2016 Dark";
            this.Name = "FormMain";
            this.Text = "主页面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTreeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).EndInit();
            this.navMain.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trvWorkShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitterControl splMain;
        private DevExpress.XtraNavBar.NavBarControl navMain;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiMain;
        private DevExpress.XtraBars.BarSubItem smnuSystem;
        private DevExpress.XtraBars.BarSubItem smunWindows;
        private DevExpress.XtraBars.BarSubItem smnuHelp;
        private DevExpress.XtraBars.BarButtonItem btnRestart;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.Utils.ImageCollection imgTreeView;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnEnglish;
        private DevExpress.XtraBars.BarButtonItem btnSimplifiedChinese;
        private DevExpress.XtraBars.BarButtonItem btnTraditionalChinese;
        private DevExpress.XtraBars.BarStaticItem lblUserName;
        private DevExpress.XtraBars.BarButtonItem btnJapanese;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarStaticItem lblUser;
        private DevExpress.XtraBars.BarStaticItem lblLoginDate;
        private DevExpress.XtraBars.BarStaticItem lblCompany;
        private DevExpress.XtraNavBar.NavBarGroup nbgWorkshop;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraTreeList.TreeList trvWorkShop;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnPassWord;
        private DevExpress.XtraBars.BarButtonItem cAccountName;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
    }
}