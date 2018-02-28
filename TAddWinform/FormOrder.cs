using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace TAddWinform
{
    public partial class FormOrder : FormMdiBase
    {
        List<CurrentStockModel> list = new List<CurrentStockModel>();
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

            SetLanguage();
            Init();
            string fileName = CommonHelper.currenctDir + "\\XtraGrid_SaveLayoutToXML.xml";
            if (File.Exists(fileName))
            {
                //gridView1.RestoreLayoutFromXml(fileName);
            }
        }


        private void SetLanguage()
        {
            if (GlobalParameters.iLanugage > 10)
            {
                this.Text = "Inventory Inquiry";
                this.btnSerch.Text = "Inquire";
                this.btnExport.Text = "Export";

                this.label1.Text = "Warehouse";
                this.label2.Text = "Category";
                this.label3.Text = "Product Number";
                this.label4.Text = "Product Name";
                this.label15.Text = "Preview";

                this.label8.Text = "Material";
                this.label9.Text = "Color";
                this.label10.Text = "Dimensions";
                this.label12.Text = "COO";


                this.label7.Text = "English Name";
                this.label11.Text = "UOM";
                this.label13.Text = "Retail Price";
                this.label18.Text = "Spec";

                this.label5.Text = "Picture Folder";
                this.btnSelectUp.Text = "Select";
                this.btnUpdate.Text = "Update";
                this.label6.Text = "Backup Folder";

                this.btnSelectDown.Text = "Select";
                chkZero.Text = "Show Out-of-stock";

                this.label16.Text = "Sort By";
                this.label17.Text = "Sort Order";

                rad1.Text = "Ascending";
                rad2.Text = "Descending";

                gridColumn2.Caption = "Warehouse Number";
                gridColumn3.Caption = "Warehouse Name";
                gridColumn4.Caption = "Product Number";
                gridColumn5.Caption = "Product Name";
                gridColumn6.Caption = "Spec";
                gridColumn7.Caption = "English Name";
                gridColumn8.Caption = "Material";
                gridColumn9.Caption = "Color";
                gridColumn10.Caption = "Dimensions";
                gridColumn11.Caption = "COO";
                gridColumn12.Caption = "UOM";
                gridColumn13.Caption = "Quantity In Stock";

                gridColumn17.Caption = "Quantity Incoming Estimated";
                gridColumn18.Caption = "Quantity Outgoing Estimated";
                gridColumn19.Caption = "Quantity Available";

                gridColumn16.Caption = "Picture";
                gridColumn15.Caption = "Latest Cost";
                gridColumn14.Caption = "Retail Price";

            }
        }

        private void Init()
        {
            string sql = string.Empty;

            if (CurrentUser.Instance.IsAdmin == false)
            {
                sql = "select iwarehouse from " + Program.DataBaseName + "..Tbl_User where  cUserName='" + CurrentUser.Instance.UserName + "' ";
                DataTable wDt = DbHelperSQL.Query(sql).Tables[0];
                string strwhere = string.Empty;
                if (wDt.Rows.Count > 0)
                {
                    string[] warehouse = wDt.Rows[0]["iwarehouse"].ToString().Split(',');
                    for (int i = 0; i < warehouse.Length; i++)
                    {
                        strwhere += "'" + warehouse[i].Trim() + "',";
                    }
                    strwhere = strwhere.Substring(0, strwhere.Length - 1);
                }
                sql = " select id,name from AA_Warehouse where code in (" + strwhere + " )";
            }
            else
            {
                sql = " select id,name from AA_Warehouse ";
            }
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            this.checkedWareHouse.Properties.DataSource = dt;
            this.checkedWareHouse.Properties.ValueMember = "id";
            this.checkedWareHouse.Properties.DisplayMember = "name";

            dt = DbHelperSQL.Query(" select id ,name from aa_inventoryclass order by code").Tables[0];
            this.checkedInventoryClass.Properties.DataSource = dt;
            this.checkedInventoryClass.Properties.ValueMember = "id";
            this.checkedInventoryClass.Properties.DisplayMember = "name";
            if (CurrentUser.Instance.IsAdmin == false)
            {
                SetState(CurrentUser.Instance.UserName);
            }
            DataTable col = new DataTable();
            col.Columns.Add("cValue", typeof(string));
            col.Columns.Add("cName", typeof(string));
            if (GlobalParameters.iLanugage > 10)
            {
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].Visible && gridView1.Columns[i].Caption != "Picture")
                    {

                        DataRow row = col.NewRow();
                        row["cValue"] = gridView1.Columns[i].FieldName;
                        row["cName"] = gridView1.Columns[i].Caption;
                        col.Rows.Add(row);
                    }
                }
            }
            else
            {
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].Visible && gridView1.Columns[i].Caption != "图片")
                    {

                        DataRow row = col.NewRow();
                        row["cValue"] = gridView1.Columns[i].FieldName;
                        row["cName"] = gridView1.Columns[i].Caption;
                        col.Rows.Add(row);
                    }
                }
            }
            this.checkedComBoxCol.Properties.DataSource = col;
            this.checkedComBoxCol.Properties.ValueMember = "cValue";
            this.checkedComBoxCol.Properties.DisplayMember = "cName";
        }
        private void SetState(string cUserName)
        {
            string sql = "select * from " + Program.DataBaseName + "..Tbl_User where cUserName='" + cUserName + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];

            if (dt.Rows[0]["Import"].ToString() == "是")
            {
                btnExport.Visible = true;
            }
            else
            {
                btnExport.Visible = false;
            }

            if (dt.Rows[0]["cCost"].ToString() == "是")
            {
                gridColumn15.Visible = true;

            }
            else
            {
                gridColumn15.Visible = false;

            }

            if (dt.Rows[0]["cSalePrice"].ToString() == "是")
            {
                gridColumn14.Visible = true;
            }
            else
            {
                gridColumn14.Visible = false;
            }

            if (dt.Rows[0]["cPicture"].ToString() == "是")
            {
                btnUpdate.Visible = true;
                btnSelectUp.Visible = true;
            }
            else
            {
                btnUpdate.Visible = false;
                btnSelectUp.Visible = false;
            }


        }
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Import();
        }


        private string InvClass(string id)
        {
            string str = string.Empty;
            string sql = "select isEndNode,idparent,id from aa_inventoryclass  where  idparent='" + id + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "'" + dt.Rows[i]["id"].ToString() + "',";
                str += InvClass(dt.Rows[i]["id"].ToString());
            }
            return str;
        }

        private void Import()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel文件|*.xls";
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            string fileName = sf.FileName;

            CurrentStockModel[] model = list.ToArray();

            HSSFWorkbook book = new HSSFWorkbook();
            ISheet sheet = book.CreateSheet(this.Text);
            IRow rowHeader = sheet.CreateRow(0);

            rowHeader.CreateCell(0, CellType.STRING).SetCellValue("序号");
            if (GlobalParameters.iLanugage > 10)
            {
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].Visible && (gridView1.Columns[i].Caption != "Latest Cost" && gridView1.Columns[i].Caption != "Retail Price"))
                    {
                        rowHeader.CreateCell(i, CellType.STRING).SetCellValue(gridView1.Columns[i].Caption);
                        sheet.SetColumnWidth(i, 20 * 256);
                    }
                }
            }
            else
            {

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].Visible && (gridView1.Columns[i].Caption != "最新成本" && gridView1.Columns[i].Caption != "零售价"))
                    {
                        rowHeader.CreateCell(i, CellType.STRING).SetCellValue(gridView1.Columns[i].Caption);
                        sheet.SetColumnWidth(i, 20 * 256);
                    }
                }


            }
            if (gridColumn15.Visible && gridColumn14.Visible)
            {
                rowHeader.CreateCell(gridColumn15.AbsoluteIndex, CellType.STRING).SetCellValue(gridColumn15.Caption);

                rowHeader.CreateCell(gridColumn14.AbsoluteIndex, CellType.STRING).SetCellValue(gridColumn14.Caption);
            }
            else
            {
                if (gridColumn15.Visible && gridColumn14.Visible == false)
                {
                    rowHeader.CreateCell(gridColumn15.AbsoluteIndex, CellType.STRING).SetCellValue(gridColumn15.Caption);
                }
                else if (gridColumn14.Visible && gridColumn15.Visible == false)
                {
                    rowHeader.CreateCell(gridColumn15.AbsoluteIndex, CellType.STRING).SetCellValue(gridColumn14.Caption);
                }
            }
            try
            {
                ICellStyle style = book.CreateCellStyle();
                style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                string bakPath = string.Empty;
                if (string.IsNullOrWhiteSpace(this.txtDown.Text))
                {
                    string fileM = System.IO.Path.Combine(CommonHelper.currenctDir, "tmp");
                    if (!Directory.Exists(fileM))
                    {
                        Directory.CreateDirectory(fileM);
                    }
                    string[] str = Directory.GetFiles(fileM);
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i].Contains(".jpg"))
                        {
                            File.Delete(str[i]);
                        }
                    }
                    bakPath = fileM;
                }
                else
                {
                    bakPath = this.txtDown.Text;
                }

                for (int i = 0; i < model.Length; i++)
                {
                    CurrentStockModel em = model[i];
                    IRow row = sheet.CreateRow(i + 1);
                    int iwdith = 0;
                   
                    if (null != em.Photo && !string.IsNullOrEmpty(ClsSystem.gnvl(em.Photo,"")))
                    {
                        string picPath = System.IO.Path.Combine(bakPath, em.InvCode + ".jpg");
                        
                        if (!File.Exists(picPath))
                        {
                            System.IO.File.WriteAllBytes(picPath, em.Photo);
                        }
                        using (System.Drawing.Image img = System.Drawing.Image.FromFile(picPath))
                        {
                            int iheight = img.Height * 10;
                            row.Height = (short)iheight;
                            iwdith = Convert.ToInt32(img.Width);
                        }
                        
                    }
                    else
                    {
                        row.Height = 30 * 10;
                    }

                    ICell cell = row.CreateCell(0);
                    cell.CellStyle = style;
                    cell.SetCellValue(i + 1);

                    cell = row.CreateCell(1);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.WareCode);

                    cell = row.CreateCell(2);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.WareName);

                    cell = row.CreateCell(3);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.InvCode);

                    cell = row.CreateCell(4);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.InvName);

                    cell = row.CreateCell(5);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.InvStd);

                    cell = row.CreateCell(6);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.ItemName);

                    cell = row.CreateCell(7);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.Materials);


                    cell = row.CreateCell(8);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.Color);

                    cell = row.CreateCell(9);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.Dimension);

                    cell = row.CreateCell(10);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.COO);

                    cell = row.CreateCell(11);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.UnitName);
                    cell = row.CreateCell(12);
                    cell.CellStyle = style;
                    cell.SetCellValue(em.Qty.ToString());
                    cell = row.CreateCell(13);

                    cell.CellStyle = style;
                    cell.SetCellValue(em.r.ToString());
                    cell = row.CreateCell(14);

                    cell.CellStyle = style;
                    cell.SetCellValue(em.c.ToString());
                    cell = row.CreateCell(15);

                    cell.CellStyle = style;
                    cell.SetCellValue(em.k.ToString());
                    cell = row.CreateCell(16);

                    cell.CellStyle = style;
                    if (em.Photo != null)
                    {
                        int pictureIdx = book.AddPicture(em.Photo, PictureType.JPEG);
                        HSSFPatriarch patriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch();

                        //add a picture  (0, 0, 1023, 0, 6, 6 + i, 6, i+1);
                        //HSSFClientAnchor anchor = new HSSFClientAnchor(1, 1, 1023, 1, 6,i+1, 6, i+2);
                        //  HSSFClientAnchor anchor = new HSSFClientAnchor(50, 50, iwdith * 4 >= 1023 ? 1000 : iwdith * 4, 0, 13, i + 1, 13, i + 2);
                        HSSFClientAnchor anchor = new HSSFClientAnchor(50, 20, iwdith * 4 >= 1023 ? 1000 : iwdith * 4, 0, 16, i + 1, 16, i + 2);

                        //                    HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 1023, 0, 6, i + 1, 6, i + 2);
                        IPicture pict = patriarch.CreatePicture(anchor, pictureIdx);
                        // pict.Resize();
                    }

                    if (gridColumn15.Visible && gridColumn14.Visible)
                    {
                        cell = row.CreateCell(17);
                        cell.CellStyle = style;
                        cell.SetCellValue(em.cCost.ToString());

                        cell = row.CreateCell(18);
                        cell.CellStyle = style;
                        cell.SetCellValue(em.cSalePrice.ToString());
                    }
                    else
                    {
                        if (gridColumn15.Visible && gridColumn14.Visible == false)
                        {
                            cell = row.CreateCell(17);
                            cell.CellStyle = style;
                            cell.SetCellValue(em.cCost.ToString());
                        }
                        else if (gridColumn14.Visible && gridColumn15.Visible == false)
                        {
                            cell = row.CreateCell(17);
                            cell.CellStyle = style;
                            cell.SetCellValue(em.cSalePrice.ToString());

                        }
                    }
                }


                using (Stream str = File.OpenWrite(fileName))
                {
                    book.Write(str);
                }
                if (GlobalParameters.iLanugage > 10)
                {
                    MessageBox.Show("Export is suceess！");
                }
                else
                {
                    MessageBox.Show("导出成功！");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }



        private void btnEidt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void LoadData()
        {
            if (chkZero.Checked == false)
            {
                if (string.IsNullOrEmpty(ClsSystem.gnvl(this.checkedWareHouse.EditValue, "")))
                {
                    if (GlobalParameters.iLanugage > 10)
                    {
                        MessageBox.Show("Warehouse is not empty！");
                    }
                    else
                    {
                        MessageBox.Show("仓库信息不能为空！");
                    }
                    return;
                }
            }
            string sql = @" select CONVERT(decimal(18,2),isnull(latestCost,0)) as latestCost, isnull(ware.code,'') as wareCode,isnull(inv.specification,'')as specification, isnull(ware.name,'') as wareName,
                isnull(inv.code,'') as invCode, isnull(inv.name,'') as invName,isnull(unit.name,'') as unitName,convert(decimal(36,2),isnull(st.baseQuantity,0)) as qty,img.FileContent,cast(round(isnull(price.retailPrice,0),2)   as   numeric(20,2)) as retailPrice,
                isnull(inv.priuserdefnvc1,'') as ItemName,
                isnull(inv.priuserdefnvc2,'') as Materials,
                isnull(inv.priuserdefnvc3,'') as Color,
                isnull(inv.priuserdefnvc4,'') as Dimension,
                isnull(inv.priuserdefnvc5,'') as COO,
                cast(round(isnull(purchaseArrivalBaseQuantity,0),2)   as   numeric(20,2))  as r,
                cast(round(isnull(saleDeliveryBaseQuantity,0),2) as   numeric(20,2)) as c,
                cast(round(isnull(st.baseQuantity,0)+isnull(purchaseArrivalBaseQuantity,0)-isnull(saleDeliveryBaseQuantity,0),2) as numeric(20,2)) as k   
                from AA_inventory as inv
                left join ST_CurrentStock  as st on st.idinventory= inv.id			  
                left join AA_Warehouse as ware on st.idwarehouse=ware.id
			    left join AA_Unit as unit on unit.id= st.idbaseunit
			    left join eap_UserImageInfo as img on img.FileName = inv.imageFile
                left join aa_inventoryclass as class on class.id=idinventoryclass
                left join AA_InventoryPrice as price on price.idinventory = inv.id
			  where 1=1 " + StrWhere();

            string sort = string.Empty;

            if (!string.IsNullOrEmpty(this.checkedComBoxCol.EditValue.ToString()))
            {
                if (checkedComBoxCol.EditValue.ToString().Contains(","))
                {
                    string[] depart = checkedComBoxCol.EditValue.ToString().Split(',');
                    string departmentCode = string.Empty;
                    for (int i = 0; i < depart.Length; i++)
                    {
                        departmentCode = departmentCode + "" + depart[i].ToString().Trim() + ",";
                    }
                    departmentCode = departmentCode.Substring(0, departmentCode.Length - 1);
                    sort = departmentCode;
                }
                else
                {
                    sort = checkedComBoxCol.EditValue.ToString().Trim();
                }
            }


            if (!string.IsNullOrEmpty(sort))
            {
                if (rad1.Checked)
                {
                    sql += " order by " + sort + "  ";
                }
                else
                {
                    sql += " order by " + sort + " desc ";
                }
            }
            try
            {
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];

                if (dt.Rows.Count == 0)
                {
                    this.gridControl1.DataSource = null;
                    if (GlobalParameters.iLanugage > 10)
                    {
                        MessageBox.Show("Data is empty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MessageBox.Show("没有数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                this.gridControl1.DataSource = dt;
                list.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CurrentStockModel m = new CurrentStockModel();
                    m.WareCode = ClsSystem.gnvl(dt.Rows[i]["wareCode"], "");
                    m.WareName = ClsSystem.gnvl(dt.Rows[i]["wareName"], "");
                    m.InvCode = ClsSystem.gnvl(dt.Rows[i]["invCode"], "");
                    m.InvName = ClsSystem.gnvl(dt.Rows[i]["invName"], "");
                    m.UnitName = ClsSystem.gnvl(dt.Rows[i]["unitName"], "");
                    m.InvStd = ClsSystem.gnvl(dt.Rows[i]["specification"], "");
                    m.ItemName = ClsSystem.gnvl(dt.Rows[i]["ItemName"], "");

                    m.Materials = ClsSystem.gnvl(dt.Rows[i]["Materials"], "");
                    m.Color = ClsSystem.gnvl(dt.Rows[i]["Color"], "");
                    m.Dimension = ClsSystem.gnvl(dt.Rows[i]["Dimension"], "");
                    m.COO = ClsSystem.gnvl(dt.Rows[i]["COO"], "");
                    m.cCost = Convert.ToDecimal(ClsSystem.gnvl(dt.Rows[i]["latestCost"], "0"));
                    m.cSalePrice = Convert.ToDecimal(ClsSystem.gnvl(dt.Rows[i]["retailPrice"], "0"));
                    m.Qty = Convert.ToDecimal(ClsSystem.gnvl(dt.Rows[i]["qty"], "0"));
                    m.r = Convert.ToDecimal(ClsSystem.gnvl(dt.Rows[i]["r"], "0"));
                    m.c = Convert.ToDecimal(ClsSystem.gnvl(dt.Rows[i]["c"], "0"));
                    m.k = Convert.ToDecimal(ClsSystem.gnvl(dt.Rows[i]["k"], "0"));
                    if (DBNull.Value != DbHelperSQL.GetNull(dt.Rows[i]["FileContent"]) && !string.IsNullOrEmpty(ClsSystem.gnvl(dt.Rows[i]["FileContent"], "")))
                    {
                        m.Photo = (byte[])dt.Rows[i]["FileContent"];
                    }
                    else
                    {
                        m.Photo = null;
                    }


                    list.Add(m);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string StrWhere()
        {
            string strwhere = string.Empty;



            if (!string.IsNullOrEmpty(this.txtcInvCode.Text))
            {
                if (this.txtcInvCode.Text.Contains(","))
                {
                    string[] strCode = this.txtcInvCode.Text.Split(',');
                    string whereCode = string.Empty;
                    for (int i = 0; i < strCode.Length; i++)
                    {
                        whereCode += "'" + strCode[i] + "',";
                    }
                    whereCode = whereCode.Substring(0, whereCode.Length - 1);
                    strwhere = strwhere + " and inv.code in ( " + whereCode + ")";
                }
                else
                {
                    strwhere = strwhere + " and  inv.code in ( '" + this.txtcInvCode.Text + "')";
                }
            }

            if (nUp.Value != 0)
            {
                strwhere = strwhere + " and  cast(round(isnull(price.retailPrice,0),2)   as   numeric(20,2)) >=  '" + nUp.Value + "'";
            }
            if (nDown.Value != 0)
            {
                strwhere = strwhere + " and  cast(round(isnull(price.retailPrice,0),2)   as   numeric(20,2)) < '" + nDown.Value + "'";
            }
            if (!string.IsNullOrEmpty(this.txtcInvName.Text))
            {
                strwhere = strwhere + " and inv.name like '%" + this.txtcInvName.Text + "%'";
            }
            if (!string.IsNullOrEmpty(this.txtEnglish.Text))
            {
                strwhere = strwhere + " and inv.priuserdefnvc1 like '%" + this.txtEnglish.Text + "%'";
            }

            if (!string.IsNullOrEmpty(this.txtmateril.Text))
            {
                strwhere = strwhere + " and inv.priuserdefnvc2 like '%" + this.txtmateril.Text + "%'";
            }
            if (!string.IsNullOrEmpty(this.txtColor.Text))
            {
                strwhere = strwhere + " and inv.priuserdefnvc3 like '%" + this.txtColor.Text + "%'";
            }
            if (!string.IsNullOrEmpty(this.txtDimension.Text))
            {
                strwhere = strwhere + " and inv.priuserdefnvc4 like '%" + this.txtDimension.Text + "%'";
            }

            if (!string.IsNullOrEmpty(this.txtCOO.Text))
            {
                strwhere = strwhere + " and inv.priuserdefnvc5 like '%" + this.txtCOO.Text + "%'";
            }
            if (!string.IsNullOrEmpty(this.txtunitName.Text))
            {
                strwhere = strwhere + " and unit.name like '%" + this.txtunitName.Text + "%'";
            }

            if (!string.IsNullOrEmpty(this.txtcStd.Text))
            {
                strwhere = strwhere + " and    inv.specification like '%" + this.txtcStd.Text + "%'";
            }

            if (!string.IsNullOrEmpty(this.checkedWareHouse.EditValue.ToString()))
            {
                if (checkedWareHouse.EditValue.ToString().Contains(","))
                {
                    string[] depart = checkedWareHouse.EditValue.ToString().Split(',');
                    string departmentCode = string.Empty;
                    for (int i = 0; i < depart.Length; i++)
                    {
                        departmentCode = departmentCode + "'" + depart[i].ToString().Trim() + "',";
                    }
                    departmentCode = departmentCode.Substring(0, departmentCode.Length - 1);
                    //if (chkZero.Checked == false)
                    //{
                    strwhere = strwhere + " and  st.idwarehouse in ( " + departmentCode + ")";
                    //}
                    //else
                    //{
                    //    strwhere = strwhere + " and ( st.idwarehouse in ( " + departmentCode + ")  or 1=1 )";
                    //}
                }
                else
                {
                    //if (chkZero.Checked == false)
                    //{
                    strwhere = strwhere + " and  st.idwarehouse in ( '" + checkedWareHouse.EditValue.ToString().Trim() + "')";
                    //}
                    //else
                    //{

                    //    strwhere = strwhere + " and (  st.idwarehouse in ( '" + checkedWareHouse.EditValue.ToString().Trim() + "') or 1=1 )";
                    //}
                }
            }
            if (!string.IsNullOrEmpty(this.checkedInventoryClass.Text))
            {
                if (checkedInventoryClass.EditValue.ToString().Contains(","))
                {
                    string[] depart = checkedInventoryClass.EditValue.ToString().Split(',');
                    string departmentCode = string.Empty;
                    for (int i = 0; i < depart.Length; i++)
                    {
                        departmentCode = departmentCode + InvClass(depart[i].ToString().Trim());
                    }
                    departmentCode = departmentCode.Substring(0, departmentCode.Length - 1);
                    strwhere = strwhere + " and idinventoryclass in ( " + departmentCode + ")";
                }
                else
                {
                    string departmentCode = checkedInventoryClass.EditValue.ToString().Trim();
                    //  departmentCode = departmentCode.Substring(0, departmentCode.Length - 1);
                    strwhere = strwhere + " and  idinventoryclass in ( '" + departmentCode + "')";
                }
            }

            if (chkZero.Checked == false)
            {
                strwhere = strwhere + " and  isnull(st.baseQuantity,0)>0 ";
            }

            return strwhere;

        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }



        private void btnSelectUp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog f = new System.Windows.Forms.FolderBrowserDialog();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtUp.Text = f.SelectedPath;
            }
        }

        private void btnSelectDown_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog f = new System.Windows.Forms.FolderBrowserDialog();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtDown.Text = f.SelectedPath;
            }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Import();
        }




        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string fileName = CommonHelper.currenctDir + "\\XtraGrid_SaveLayoutToXML.xml";
            gridView1.SaveLayoutToXml(fileName);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string fileName = CommonHelper.currenctDir + "\\XtraGrid_SaveLayoutToXMLBak.xml";
            gridView1.RestoreLayoutFromXml(fileName);

        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            DataRow row = gridView1.GetFocusedDataRow();
            if (null == row)
                return;
            if (DbHelperSQL.GetNull(row["FileContent"]) == DBNull.Value)
            {
                pictureEdit1.Image = null;
                pictureEdit1.Width = 200;
                pictureEdit1.Height = 200;
            }
            else
            {
                Image img = ByteArrayToImage((byte[])DbHelperSQL.GetNull(row["FileContent"]));
                pictureEdit1.Image = img;
                pictureEdit1.Width = img.Width;
                pictureEdit1.Height = img.Height;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUp.Text))
            {
                if (GlobalParameters.iLanugage > 10)
                {
                    MessageBox.Show("Please select the picture folder!");
                }
                else
                {
                    MessageBox.Show("请先选择图片路径!");
                }

                return;
            }
            string strmsg = string.Empty;
            string[] strpath = Directory.GetFiles(this.txtUp.Text);
            int count = 0;
            for (int i = 0; i < strpath.Length; i++)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(strpath[i]);
                string[] myfile = strpath[i].Split('\\');
                string filename = myfile[myfile.Length - 1].Substring(0, myfile[myfile.Length - 1].LastIndexOf('.'));
                string lastName = myfile[myfile.Length - 1].Substring(myfile[myfile.Length - 1].Length - 4, 4);
                System.IO.FileInfo f = new FileInfo(strpath[i]);
                long size = f.Length;
                object inventoryId = DbHelperSQL.GetSingle("select id from AA_inventory where code='" + filename + "'");
                //  object inventoryId = DbHelperSQL.GetSingle("select id from AA_inventory where right(specification,8)='" + filename + "'");

                if (null != inventoryId)
                {
                    string strpic = Guid.NewGuid().ToString() + lastName;

                    string sql = @"INSERT INTO [eap_UserImageInfo]([ID] ,[VoucherName],[DtoID],[FileName],[FileType]
                                   ,[FileSize] ,[FileContent],[Creater],[CreateTime])
                             VALUES(NEWID(),'inventory','00000000-0000-0000-0000-000000000000' ,@FileName,@FileType,@FileSize,@FileContent,'',getdate())";
                    DbHelperSQL.ExecuteSql(sql, new SqlParameter[] { new SqlParameter("@FileName", strpic), new SqlParameter("@FileType", lastName), new SqlParameter("@FileSize", size), new SqlParameter("@FileContent", bytes) });
                    sql = " update AA_inventory set imageFile=@imageFile where id=@id";
                    DbHelperSQL.ExecuteSql(sql, new SqlParameter[] { new SqlParameter("@imageFile", strpic), new SqlParameter("@id", inventoryId) });
                    count = count + 1;
                    if (GlobalParameters.iLanugage > 10)
                    {
                        strmsg = strmsg + "Part number：" + filename + "upload completed" + "\r\n";
                    }
                    else
                    {
                        strmsg = strmsg + "存货编码：" + filename + "更新成功" + "\r\n";
                    }
                }
                else
                {
                    if (GlobalParameters.iLanugage > 10)
                    {
                        strmsg = strmsg + "Part number：" + filename + "doesn't exist" + "\r\n";
                    }
                    else
                    {
                        strmsg = strmsg + "存货编码：" + filename + "找不到对应的存货" + "\r\n";
                    }
                }
            }
            CommonHelper.WirteLog(strmsg);
            string msg = string.Empty;
            if (GlobalParameters.iLanugage > 10)
            {
                msg = string.Format("Upload completed!Total{0}records,completed{1},failed{2},please check the log for details!", strpath.Length, count, strpath.Length - count);
            }
            else
            {
                msg = string.Format("导入成功！总共{0}条数据，成功导入{1}条，失败{2}条，请检查日志！", strpath.Length, count, strpath.Length - count);
            }
            MessageBox.Show(msg);
            CommonHelper.WirteLog(strmsg);
        }
    }
}
