using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TAddWinform
{
    static class Program
    {

        public static string DataBaseName = "jxc";
        //public static string DataBaseName = "uf";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //FormLanguage f = new FormLanguage();
            //if (f.ShowDialog() == DialogResult.OK)
            //{

            //FormLogin frmLogin = new FormLogin();
            //if (frmLogin.ShowDialog() == DialogResult.OK)
                Application.Run(new FormMain());
            ////}
            //else
            //    Application.Exit();
        }
    }
}
