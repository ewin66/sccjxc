using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TAddWinform
{
    public class CommonHelper
    {

        public static string currenctDir = AppDomain.CurrentDomain.BaseDirectory;
        public static string GetMD5(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }

        public static void WirteLog(string msg)
        {
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "导入日志.txt";
            FileStream fs = new FileStream(System.IO.Path.Combine(currenctDir, filename), FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(msg);
            sw.Close();
            fs.Close();
        }

        public static int GetWeekOfYear(DateTime curDay)
        {
            int firstdayofweek = Convert.ToInt32(Convert.ToDateTime(curDay.Year.ToString() + "- " + "1-1 ").DayOfWeek);

            int days = curDay.DayOfYear;
            int daysOutOneWeek = days - (7 - firstdayofweek + 1);

            if (daysOutOneWeek <= 0)
            {
                return 1;
            }
            else
            {
                int weeks = daysOutOneWeek / 7;
                if (daysOutOneWeek % 7 != 0)
                    weeks++;
                return weeks;
            }
        } 
        public static string Get12Month(DateTime dateTime)
        {

            string bin = string.Empty;
            string month = dateTime.Month.ToString();
            switch (month)
            {
                case "1":
                    bin = "1";
                    break;
                case "2":
                    bin = "2";
                    break;
                case "3":
                    bin = "3";
                    break;
                case "4":
                    bin = "4";
                    break;
                case "5":
                    bin = "5";
                    break;
                case "6":
                    bin = "6";
                    break;
                case "7":
                    bin = "7";
                    break;
                case "8":
                    bin = "8";
                    break;
                case "9":
                    bin = "9";
                    break;
                case "10":
                    bin = "A";
                    break;
                case "11":
                    bin = "B";
                    break;
                case "12":
                    bin = "C";
                    break;
            }
            return bin;
        }

        public static string Get12MonthBybin(string objbin)
        {

            string bin = string.Empty;
            switch (objbin)
            {
                case "1":
                    bin = "1";
                    break;
                case "2":
                    bin = "2";
                    break;
                case "3":
                    bin = "3";
                    break;
                case "4":
                    bin = "4";
                    break;
                case "5":
                    bin = "5";
                    break;
                case "6":
                    bin = "6";
                    break;
                case "7":
                    bin = "7";
                    break;
                case "8":
                    bin = "8";
                    break;
                case "9":
                    bin = "9";
                    break;
                case "A":
                    bin = "10";
                    break;
                case "B":
                    bin = "11";
                    break;
                case "C":
                    bin = "12";
                    break;
            }
            return bin;
        }
        /// <summary>
        /// 字符串处理函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterSpecial(string str)//特殊字符过滤函数
        {
            if (str == "") //如果字符串为空，直接返回。
            {
                return str;
            }
            else
            {
                str = str.Replace("'", "");
                str = str.Replace("<", "");
                str = str.Replace(">", "");
                str = str.Replace("%", "");
                str = str.Replace("'delete", "");
                str = str.Replace("''", "");
                str = str.Replace("\"\"", "");
                str = str.Replace(",", "");
                str = str.Replace(".", "");
                str = str.Replace(">=", "");
                str = str.Replace("=<", "");
                str = str.Replace("-", "");
                str = str.Replace("_", "");
                str = str.Replace(";", "");
                str = str.Replace("||", "");
                str = str.Replace("[", "");
                str = str.Replace("]", "");
                str = str.Replace("&", "");
                str = str.Replace("/", "");
                str = str.Replace("-", "");
                str = str.Replace("|", "");
                str = str.Replace("?", "");
                str = str.Replace(">?", "");
                str = str.Replace("?<", "");
                str = str.Replace(" ", "");
                return str;
            }
        }
    }
}
