using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TAddWinform
{
    public class LogHelper
    {
        public static void Write(string sLog)
        {
            string fileName = System.Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            //打开文件
            string sPath = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(sPath))
                System.IO.Directory.CreateDirectory(sPath);
            FileStream mFileStream = new FileStream(fileName, FileMode.OpenOrCreate | FileMode.Append);
            StreamWriter mStreamWriter = new StreamWriter(mFileStream, System.Text.Encoding.Unicode);
            if (sLog != "")
                mStreamWriter.WriteLine(sLog);
            mStreamWriter.Close();
            mFileStream.Close();
        }

        public static void Write(string sLog, string fileName)
        {
            //打开文件
            string sPath = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(sPath))
                System.IO.Directory.CreateDirectory(sPath);
            FileStream mFileStream = new FileStream(fileName, FileMode.Create);
            StreamWriter mStreamWriter = new StreamWriter(mFileStream, System.Text.Encoding.Unicode);
            if (sLog != "")
                mStreamWriter.WriteLine(sLog);
            mStreamWriter.Close();
            mFileStream.Close();
        }

        public static string Read(string fileName)
        {
            //打开文件
            string sPath = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(sPath))
                System.IO.Directory.CreateDirectory(sPath);
            FileStream mFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            mFileStream.Close();

            StreamReader mStreamReader = new StreamReader(fileName, System.Text.Encoding.Default);
            string strline = "";
            string strContent = "";
            if (mStreamReader.Peek() >= 0)
            {
                strline = mStreamReader.ReadLine().ToString();
                while (strline != "")
                {
                    strContent = strContent + strline + "\r\n";
                    strline = "";
                    if (mStreamReader.Peek() >= 0)
                    {
                        strline = mStreamReader.ReadLine().ToString();
                    }
                }
            }
            mStreamReader.Close();
            return strContent;
        }
        public static string Read()
        {
            return Read(DateTime.Now);
        }

        public static string Read(DateTime dtLog)
        {
            string fileName = System.Environment.CurrentDirectory + "\\" + dtLog.ToString("yyyyMMdd") + ".txt";
            //打开文件
            string sPath = System.IO.Path.GetDirectoryName(fileName);
            if (!System.IO.Directory.Exists(sPath))
                System.IO.Directory.CreateDirectory(sPath);
            FileStream mFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            mFileStream.Close();

            StreamReader mStreamReader = new StreamReader(fileName, System.Text.Encoding.Default);
            string strline = "";
            string strContent = "";
            if (mStreamReader.Peek() >= 0)
            {
                strline = mStreamReader.ReadLine().ToString();
                while (strline != "")
                {
                    strContent = strContent + strline + "\r\n";
                    strline = "";
                    if (mStreamReader.Peek() >= 0)
                    {
                        strline = mStreamReader.ReadLine().ToString();
                    }
                }
            }
            mStreamReader.Close();
            return strContent;
        }
    }
}
