using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NewsPublish.DataLayer
{
    public class DataMake
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["NewsPublishConnectionString"].ToString();
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            int resultCount = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    resultCount = cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    WriteLog.WriteLogToTxt("DataMake.cs", "admin", e.Message, DateTime.Now);
                }
                conn.Close();
                return resultCount;
            }
        }
        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParameters">参数数组</param>
        /// <returns></returns>
        public static int ExecuteSql(string sql, SqlParameter[] sqlParameters)
        {
            int resultCount = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(sqlParameters);
                try
                {
                    conn.Open();
                    resultCount = cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    WriteLog.WriteLogToTxt("DataMake.cs", "admin", e.Message, DateTime.Now);
                }
                cmd.Parameters.Clear();
                conn.Close();
                return resultCount;
            }
        }
        /// <summary>
        /// 读取DataTable数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public static DataTable DataTableRead(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                }
                catch (SqlException e)
                {
                    WriteLog.WriteLogToTxt("DataMake.cs", "admin", e.Message, DateTime.Now);
                }
                return dt;
            }
        }
        /// <summary>
        /// 读取DataTable数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParameters">sql参数数组</param>
        /// <returns></returns>
        public static DataTable DataTableRead(string sql,SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(sqlParameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                }
                catch (SqlException e)
                {
                    WriteLog.WriteLogToTxt("DataMake.cs", "admin", e.Message, DateTime.Now);
                }
                cmd.Parameters.Clear();
                return dt;
            }
        }
        //public static SqlDataReader DataRead(string sql)
        //{
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataReader read;
        //        try
        //        {
        //            conn.Open();
        //            read = cmd.ExecuteReader();
        //            read.Read();
        //        }
        //        catch (SqlException e)
        //        {
        //            WriteLog.WriteLogToTxt("DataMake.cs", "admin", e.Message, DateTime.Now);
        //        }
        //        return read;
        //    }
        //}
    }
}
