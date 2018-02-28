using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace TAddWinform
{
    internal class DataAccessUtil
    {
        private static readonly string Connstr = ConfigurationManager.ConnectionStrings["jxc"].ConnectionString;
        public static object ExecuteScalar(string sql, List<SqlParameter> paramList)
        {
            object o;
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramList.ToArray());
                o = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }

            return o;}

        public static object ExecuteScalar(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlCommand cmd = trans.Connection.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteScalar();
        }


        public static int ExecuteNonQuery(string sql, List<SqlParameter> paramList )
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramList.ToArray());
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
           return cmd.ExecuteNonQuery();
        }


        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paramList )
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramList.ToArray());
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }


        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paramList, SqlTransaction trans)
        {
            SqlConnection conn = trans.Connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = trans;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(paramList.ToArray());
            return cmd.ExecuteReader();
        }

        public static DataSet ExecuteDataSet(string sql, List<SqlParameter> paramList)
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramList.ToArray());

                DataSet ds = new DataSet();
                SqlDataAdapter dapter = new SqlDataAdapter(cmd);
                dapter.Fill(ds);
                return ds;
            }
        }

        public static DataTable ExecuteDataTable(string sql, List<SqlParameter> paramList) 
        {
            using (SqlConnection conn = new SqlConnection(Connstr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramList.ToArray());

                DataTable dt = new DataTable();
                SqlDataAdapter dapter = new SqlDataAdapter(cmd);
                dapter.Fill(dt);
                return dt;
            }
           
        }
    }
}
