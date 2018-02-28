using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TAddWinform
{
    public class GlobalParameters
    {
        public static String ConnectionString = ConfigurationManager.ConnectionStrings["jxc"].ConnectionString;

        public static String msg = "提示";
        public static String Company = string.Empty;
        public static int iLanugage = 0;
    }
}
