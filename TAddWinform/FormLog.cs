using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TAddWinform
{
    public partial class FormLog : FormMdiBase
    {
        public FormLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = LogHelper.Read(dateTimePicker1.Value);
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
