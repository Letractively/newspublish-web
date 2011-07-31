using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using NewsPublish.DataLayer;
using System.Collections.Generic;

namespace NewsPublish.BusinessLayer
{
    public class NewsType
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string newsTypeName_zh;

        public string NewsTypeName_zh
        {
            get { return newsTypeName_zh; }
            set { newsTypeName_zh = value; }
        }
        private string newsTypeName_en;

        public string NewsTypeName_en
        {
            get { return newsTypeName_en; }
            set { newsTypeName_en = value; }
        }
        private string newsTypeRemark;

        public string NewsTypeRemark
        {
            get { return newsTypeRemark; }
            set { newsTypeRemark = value; }
        }
        /// <summary>
        /// 插入新闻类型
        /// </summary>
        /// <returns></returns>
        public bool AddNewsType()
        {
            string sql = "insert into NewsType(NewsTypeName_zh,NewsTypeName_en,NewsType_Remark)" +
                "values(@NewsTypeName_ch,@NewsTypeName_en,@NewsType_Remark)";
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@NewsTypeName_ch", SqlDbType.VarChar, 20);
            parms[0].Value = newsTypeName_zh;
            parms[1] = new SqlParameter("@NewsTypeName_en", SqlDbType.VarChar, 20);
            parms[1].Value = newsTypeName_en;
            parms[2] = new SqlParameter("@NewsType_Remark", SqlDbType.VarChar, 150);
            parms[2].Value = newsTypeRemark;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }
        /// <summary>
        /// 更新新闻类型
        /// </summary>
        /// <returns></returns>
        public bool UpdateNewsType()
        {
            string sql = "update NewsType set NewsTypeName_zh=@NewsTypeName_ch,NewsTypeName_en=@NewsTypeName_en," +
            "NewsType_Remark=@NewsType_Remark where Id=@Id";
            SqlParameter[] parms = new SqlParameter[4];
            parms[0] = new SqlParameter("@NewsTypeName_ch", SqlDbType.VarChar, 20);
            parms[0].Value = newsTypeName_zh;
            parms[1] = new SqlParameter("@NewsTypeName_en", SqlDbType.VarChar, 20);
            parms[1].Value = newsTypeName_en;
            parms[2] = new SqlParameter("@NewsType_Remark", SqlDbType.VarChar, 150);
            parms[2].Value = newsTypeRemark;
            parms[3] = new SqlParameter("@Id", SqlDbType.Int);
            parms[3].Value = id;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }
        /// <summary>
        /// 删除新闻类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteNewsType(string id)
        {
            string sql="delete from NewsType where Id="+id;
            return DataMake.ExecuteSql(sql)>0;
        }
        /// <summary>
        /// 获取所有新闻类型
        /// </summary>
        /// <returns></returns>
        public List<NewsType> GetItems()
        {
            NewsType newsType = new NewsType();
            List<NewsType> newsTypeList = new List<NewsType>();
            string sql = "select * from NewsType";
            DataTable dt = DataMake.DataTableRead(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newsType.Id = (int)dt.Rows[i]["Id"];
                    newsType.NewsTypeName_zh = dt.Rows[i]["NewsTypeName_zh"].ToString();
                    newsType.NewsTypeName_en = dt.Rows[i]["NewsTypeName_en"].ToString();
                    newsType.NewsTypeRemark = dt.Rows[i]["NewsType_Remark"].ToString();
                    newsTypeList.Add(newsType);
                }
            }
            return newsTypeList;
        }
        /// <summary>
        /// 获取某一条新闻类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public NewsType GetItem(string id)
        {
            NewsType newsType = new NewsType();
            string sql = "select * from NewsType where Id=" + id;
            DataTable dt = DataMake.DataTableRead(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newsType.Id = (int)dt.Rows[i]["Id"];
                    newsType.NewsTypeName_zh = dt.Rows[i]["NewsTypeName_zh"].ToString();
                    newsType.NewsTypeName_en = dt.Rows[i]["NewsTypeName_en"].ToString();
                    newsType.NewsTypeRemark = dt.Rows[i]["NewsType_Remark"].ToString();
                }
            }
            return newsType;
        }
    }
}
