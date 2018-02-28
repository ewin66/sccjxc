using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TAddWinform
{
    public delegate void MdiFormLoadEventHandler(FormMdiBase sender);
    public delegate void MdiFormUnLoadEventHandler(FormMdiBase sender);

    public partial class FormMdiBase : DevExpress.XtraEditors.XtraForm
    {
        public MdiFormLoadEventHandler LoadMdiForm;
        public MdiFormUnLoadEventHandler UnloadMdiForm;

        public FormMdiBase()
        {
            InitializeComponent();
        }

        private void FormMdiBase_Load(object sender, EventArgs e)
        {
            if (LoadMdiForm != null)
            {
                LoadMdiForm(this);
            }
        }

        private void FormMdiBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UnloadMdiForm != null)
            {
                UnloadMdiForm(this);
            }
        }
    }
}
