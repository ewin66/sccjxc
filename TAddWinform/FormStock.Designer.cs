namespace TAddWinform {
    partial class FormStock {
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
            this.lueStorehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueGoodsName = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStorehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "按仓库查询:";
            // 
            // lueStorehouse
            // 
            this.lueStorehouse.Location = new System.Drawing.Point(116, 46);
            this.lueStorehouse.Name = "lueStorehouse";
            this.lueStorehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStorehouse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StorehouseName", "StorehouseName")});
            this.lueStorehouse.Properties.NullText = "请选择";
            this.lueStorehouse.Properties.ShowFooter = false;
            this.lueStorehouse.Properties.ShowHeader = false;
            this.lueStorehouse.Size = new System.Drawing.Size(100, 20);
            this.lueStorehouse.TabIndex = 1;
            this.lueStorehouse.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(249, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "按商品查询:";
            // 
            // lueGoodsName
            // 
            this.lueGoodsName.Location = new System.Drawing.Point(341, 48);
            this.lueGoodsName.Name = "lueGoodsName";
            this.lueGoodsName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoodsName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoodsName", "GoodsName")});
            this.lueGoodsName.Properties.NullText = "请选择";
            this.lueGoodsName.Properties.ShowFooter = false;
            this.lueGoodsName.Properties.ShowHeader = false;
            this.lueGoodsName.Size = new System.Drawing.Size(100, 20);
            this.lueGoodsName.TabIndex = 3;
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 308);
            this.Controls.Add(this.lueGoodsName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lueStorehouse);
            this.Controls.Add(this.labelControl1);
            this.Name = "FormStock";
            this.Text = "现存量查询";
            this.Load += new System.EventHandler(this.FormStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueStorehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoodsName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueStorehouse;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueGoodsName;
    }
}