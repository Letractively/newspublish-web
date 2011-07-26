using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace NewsPublish.DataLayer
{
    public class WriteLog
    {
        private static string textLogFilePath = ConfigurationManager.AppSettings["txtLogPath"];
        private static string  fileName= @HttpContext.Current.Server.MapPath(string.Format("~//{0}",textLogFilePath));
        /// <summary>
        /// 写日志到数据库
        /// </summary>
        /// <param name="source"></param>
        /// <param name="user"></param>
        /// <param name="content"></param>
        /// <param name="logTime"></param>
        public static bool WriteLogToDb(string source,string user,string content,DateTime logTime)
        {
            string sql="insert into Log(Log_Source,Log_User,Log_Content,Log_Time) values(@source,@user,@content,@logTime)";
            SqlParameter[] sqlParameters=new SqlParameter[4];
            sqlParameters[0]= new SqlParameter("@source", SqlDbType.VarChar,50);
            sqlParameters[0].Value = source;
            sqlParameters[1] = new SqlParameter("@user", SqlDbType.VarChar, 50);
            sqlParameters[1].Value = user;
            sqlParameters[2] = new SqlParameter("@content", SqlDbType.VarChar, 150);
            sqlParameters[2].Value = content;
            sqlParameters[3] = new SqlParameter("@logTime", SqlDbType.DateTime);
            sqlParameters[3].Value = logTime;
            int flag=DataMake.ExecuteSql(sql, sqlParameters);
            return flag < 0 ? false : true;
        }
        /// <summary>
        /// 写日志到文本文件[待优化2in1]
        /// </summary>
        /// <param name="source"></param>
        /// <param name="user"></param>
        /// <param name="content"></param>
        /// <param name="logTime"></param>
        public static bool WriteLogToTxt(string source, string user, string content, DateTime logTime)
        {
            //string fileName=filePath+"Log_"+DateTime.Now.Date.ToShortDateString()+".txt";
            string contentStr = string.Format("{0}|{1}|{2}|{3}", logTime, source, user, content);
            bool flag = false;
            if (!File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(contentStr);
                sw.Close();
                fs.Close();
                flag=true;
            }
            else
            {
                FileStream fs = new FileStream(fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
                sw.WriteLine(contentStr);
                sw.Close();
                fs.Close();
                flag=true;
            }
            return flag;
        }
        /// <summary>
        /// 从文本日志中读取日志内容
        /// </summary>
        /// <returns></returns>
        public static DataTable ReadLogContentFromTxt()
        {
            DataTable dt = new DataTable("LogInfo");
            dt.Columns.Add("Log_Source", typeof(System.String));
            dt.Columns.Add("Log_User", typeof(System.String));
            dt.Columns.Add("Log_Content", typeof(System.String));
            dt.Columns.Add("Log_Time", typeof(System.DateTime));
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open,FileAccess.Read);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                string strLine = sr.ReadLine();
                while (strLine!=null)
                {
                    string[] words=strLine.Split('|');
                    dt.Rows.Add(words[1], words[2], words[3], words[0]);
                    strLine = sr.ReadLine();
                }
                return dt;
            }
            else
                return dt;
        }
    }
}
