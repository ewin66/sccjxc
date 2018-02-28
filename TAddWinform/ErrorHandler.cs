using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAddWinform {
    public class ErrorHandler {
        public static void OnError(Exception e)
        {
            if (e.GetType()==typeof(ApplicationException)||e.GetType().IsSubclassOf(typeof(ApplicationException)))
            {
                MessageBox.Show(e.Message, "提示: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(e.Message + "\r\n\r\n\r\n" + e.StackTrace, "程序错误: ", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
