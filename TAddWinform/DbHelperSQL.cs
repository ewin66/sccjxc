using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;

namespace TAddWinform
{
    public abstract class DbHelperSQL
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GlobalParameters.ConnectionString);
        }
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
               
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(GlobalParameters.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }
        public static int ExecuteSql(string SQLString, SqlParameter[] Paras)
        {
            using (SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddRange(Paras);
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static object GetNull(object obj)
        {

            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static object GetSingle(string SQLString, SqlParameter[] Paras)
        {
            using (SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddRange(Paras);
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static object GetSingleWithTrans(string SQLString, SqlTransaction tran)
        {

            using (SqlCommand cmd = new SqlCommand(SQLString, tran.Connection))
            {
                try
                {
                    cmd.Transaction = tran;
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
            }

        }

        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString))
            {
                DataSet ds = new DataSet();
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
                return ds;
            }
        }
        public static DataSet Query(string SQLString, SqlParameter[] Params)
        {
            return Query(SQLString, Params, CommandType.Text);
        }
        public static DataSet Query(string SQLString, SqlParameter[] Params, CommandType cmdType)
        {
            using (SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString))
            {
                DataSet ds = new DataSet();
                connection.Open();
                SqlCommand command = new SqlCommand(SQLString, connection);
                command.CommandTimeout = 300000;
                command.CommandType = cmdType;
                command.Parameters.AddRange(Params);
                SqlDataAdapter adp = new SqlDataAdapter(command);
                adp.Fill(ds);
                return ds;
            }
        }

        public static SqlTransaction BeginTrans()
        {
            SqlConnection connection = new SqlConnection(GlobalParameters.ConnectionString);
            connection.Open();
            return connection.BeginTransaction();
        }

        public static void CommitTransAndCloseConnection(SqlTransaction tr)
        {
            if (tr != null)
            {
                tr.Commit();
                if (tr.Connection != null)
                {
                    if (tr.Connection.State == ConnectionState.Open)
                    {
                        tr.Connection.Close();
                    }
                }
            }
        }

        public static void RollbackAndCloseConnection(SqlTransaction tr)
        {
            if (tr != null)
            {
                tr.Rollback();
                if (tr.Connection != null)
                {
                    if (tr.Connection.State == ConnectionState.Open)
                    {
                        tr.Connection.Close();
                    }
                }
            }
        }

        public static int ExecuteSqlWithTrans(string SQLString, SqlTransaction tr)
        {

            using (SqlCommand cmd = new SqlCommand(SQLString, tr.Connection))
            {
                try
                {
                    cmd.Transaction = tr;
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
            }
        }

        public static int ExecuteSqlWithTrans(string SQLString, SqlParameter[] Params, SqlTransaction tr)
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, tr.Connection))
            {
                try
                {
                    cmd.Parameters.AddRange(Params);
                    cmd.Transaction = tr;
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear(); //For parameters reuse
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
            }
        }

        public static int ExecuteSqlWithTrans(string SQLString, SqlParameter[] Params, CommandType CommandType, SqlTransaction tr)
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, tr.Connection))
            {
                try
                {
                    cmd.Transaction = tr;
                    cmd.Parameters.AddRange(Params);
                    cmd.CommandType = CommandType;
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear(); //For parameters reuse
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
            }
        }

        public static DataSet QueryWithTrans(string SQLString, SqlTransaction tr)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand(SQLString, tr.Connection, tr);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }
        /// <summary>
        /// Especially for UFIDA U8 Series
        /// </summary>
        /// <param name="RemoteId"></param>
        /// <param name="cAccount"></param>
        /// <param name="cVouchType"></param>
        /// <param name="iAmount"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static int[] GetIDOnTransaction(string RemoteId, string cAccount, string cVouchType, int iAmount, SqlTransaction tran)
        {
            //string cAcc_Id = cAccount.Substring(7, 3);
            SqlCommand myCommand = new SqlCommand("sp_GetId", tran.Connection, tran);
            myCommand.CommandType = CommandType.StoredProcedure;

            //添加存储过程输入输出参数类型及输入参数值
            myCommand.Parameters.Add("@RemoteId", SqlDbType.VarChar, 2).Value = RemoteId;
            myCommand.Parameters.Add("@cAcc_Id", SqlDbType.VarChar, 3).Value = cAccount; //U8帐套号
            myCommand.Parameters.Add("@cVouchType", SqlDbType.VarChar, 50).Value = cVouchType;
            myCommand.Parameters.Add("@iAmount", SqlDbType.Int).Value = iAmount;        //需要处理明细 记录数
            myCommand.Parameters.Add("@iFatherId", SqlDbType.Int);
            myCommand.Parameters.Add("@iChildId", SqlDbType.Int);
            //输入参数
            myCommand.Parameters["@RemoteId"].DbType = DbType.String;
            myCommand.Parameters["@RemoteId"].Direction = ParameterDirection.Input;
            myCommand.Parameters["@cAcc_Id"].DbType = DbType.String;
            myCommand.Parameters["@cAcc_Id"].Direction = ParameterDirection.Input;
            myCommand.Parameters["@cVouchType"].DbType = DbType.String;
            myCommand.Parameters["@cVouchType"].Direction = ParameterDirection.Input;
            myCommand.Parameters["@iAmount"].DbType = DbType.Int32;
            myCommand.Parameters["@iAmount"].Direction = ParameterDirection.Input;
            //输出参数
            myCommand.Parameters["@iFatherId"].DbType = DbType.Int32;
            myCommand.Parameters["@iFatherId"].Direction = ParameterDirection.Output;
            myCommand.Parameters["@iChildId"].DbType = DbType.Int32;
            myCommand.Parameters["@iChildId"].Direction = ParameterDirection.Output;

            //执行存储过程 此处类似于查询语句
            myCommand.ExecuteScalar();

            //接受执行存储过程后的返回值
            int FatherId = (int)myCommand.Parameters["@iFatherId"].Value;   //主表ID
            int ChildId = (int)myCommand.Parameters["@iChildId"].Value;     //子表ID

            int[] getID = new int[2];
            getID[0] = FatherId;
            getID[1] = ChildId;
            return getID;
        }

        public static String ChangeComment(String strData)
        {

            int li;
            String strss = "";

            for (li = 0; li <= strData.Length - 1; li++)
            {
                if (strData.Substring(li, 1).ToString() == "'")
                {
                    strss = strss + "''";
                }
                else
                {
                    strss = strss + strData.Substring(li, 1).ToString();
                }
            }
            return strss;

        }
    }

}
