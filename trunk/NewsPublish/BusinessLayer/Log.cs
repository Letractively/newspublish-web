using System;
using NewsPublish.DataLayer;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace NewsPublish.BusinessLayer
{
    public class Log
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string logSource;

        public string LogSource
        {
            get { return logSource; }
            set { logSource = value; }
        }
        string logUser;

        public string LogUser
        {
            get { return logUser; }
            set { logUser = value; }
        }
        string logContent;

        public string LogContent
        {
            get { return logContent; }
            set { logContent = value; }
        }
        DateTime logTime;

        public DateTime LogTime
        {
            get { return logTime; }
            set { logTime = value; }
        }
        /// <summary>
        /// 插入日志[先数据库，若失败后文本]
        /// </summary>
        /// <param name="logSource"></param>
        /// <param name="logUser"></param>
        /// <param name="logContent"></param>
        /// <param name="logTime"></param>
        /// <returns></returns>
        public bool InsertLog()
        {
            bool flag=WriteLog.WriteLogToDb(logSource, logUser, logContent, logTime);
            if (!flag)
                flag=WriteLog.WriteLogToTxt(logSource, logUser, logContent, logTime);
            return flag;
        }
        /// <summary>
        /// 删除日志[不包含文本日志]
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static bool DeleteLogByTime(DateTime startTime, DateTime endTime)
        {
            string sql = "delete from Log where Log_Time between @startTime and @endTime";
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@startTime", SqlDbType.DateTime2);
            parms[0].Value = startTime;
            parms[1] = new SqlParameter("@endTime", SqlDbType.DateTime2);
            parms[1].Value = endTime;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }
        /// <summary>
        /// 获取日志
        /// </summary>
        /// <returns></returns>
        public static List<Log> GetItems()
        {
            List<Log> logList = new List<Log>();
            Log log = new Log();
            string sql = "select * from Log";
            DataTable dt=DataMake.DataTableRead(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    log.id = int.Parse(dt.Rows[i][0].ToString());
                    log.logSource = dt.Rows[i][1].ToString();
                    log.logUser = dt.Rows[i][2].ToString();
                    log.logContent = dt.Rows[i][3].ToString();
                    log.logTime =Convert.ToDateTime(dt.Rows[i][4]);
                    logList.Add(log);
                }
            }
            return logList;
        }
    }
}
