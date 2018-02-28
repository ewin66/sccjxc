namespace TAddWinform {
    partial class FormAddAndUpdateGoods {
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lueGoodsFrom = new DevExpress.XtraEditors.LookUpEdit();
            this.lueGoodsCategory = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsCategory.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(63, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "商品编号:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(195, 57);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(63, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "商品名称:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(195, 104);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(63, 153);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "商品产地:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(63, 201);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "商品种类:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(63, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lueGoodsFrom
            // 
            this.lueGoodsFrom.Location = new System.Drawing.Point(195, 148);
            this.lueGoodsFrom.Name = "lueGoodsFrom";
            this.lueGoodsFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoodsFrom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsFromName", "Name1")});
            this.lueGoodsFrom.Properties.MaxLength = 100;
            this.lueGoodsFrom.Properties.NullText = "请选择";
            this.lueGoodsFrom.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.lueGoodsFrom.Properties.ShowFooter = false;
            this.lueGoodsFrom.Properties.ShowHeader = false;
            this.lueGoodsFrom.Size = new System.Drawing.Size(100, 20);
            this.lueGoodsFrom.TabIndex = 4;
            // 
            // lueGoodsCategory
            // 
            this.lueGoodsCategory.Location = new System.Drawing.Point(195, 198);
            this.lueGoodsCategory.Name = "lueGoodsCategory";
            this.lueGoodsCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoodsCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsCategoryName", "Name2")});
            this.lueGoodsCategory.Properties.NullText = "请选择";
            this.lueGoodsCategory.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.lueGoodsCategory.Properties.ShowFooter = false;
            this.lueGoodsCategory.Properties.ShowHeader = false;
            this.lueGoodsCategory.Size = new System.Drawing.Size(100, 20);
            this.lueGoodsCategory.TabIndex = 4;
            // 
            // FormAddGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 318);
            this.Controls.Add(this.lueGoodsCategory);
            this.Controls.Add(this.lueGoodsFrom);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.Name = "FormAddGoods";
            this.Text = "商品的添加";
            this.Load += new System.EventHandler(this.FormAddGoods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsCategory.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lueGoodsFrom;
        private DevExpress.XtraEditors.LookUpEdit lueGoodsCategory;
    }
}