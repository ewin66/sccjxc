using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TAddWinform
{
    public partial class FormLanguage : Form
    {
        public FormLanguage()
        {
            InitializeComponent();
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ClsSystem.gnvl(cmblanguage.SelectedItem, "")))
            {
                MessageBox.Show("请至少选择一项！/Please choose at least one！", "提示/Warning",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        
        }
    }
}
