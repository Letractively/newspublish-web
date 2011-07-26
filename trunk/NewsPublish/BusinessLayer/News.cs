using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using NewsPublish.DataLayer;

namespace NewsPublish.BusinessLayer
{
    public class News
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private bool isSpecial;

        public bool IsSpecial
        {
            get { return isSpecial; }
            set { isSpecial = value; }
        }
        private bool isHomePagePicture;

        public bool IsHomePagePicture
        {
            get { return isHomePagePicture; }
            set { isHomePagePicture = value; }
        }
        private string pictureSrc;

        public string PictureSrc
        {
            get { return pictureSrc; }
            set { pictureSrc = value; }
        }
        private int typeId;

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string source;

        public string Source
        {
            get { return source; }
            set { source = value; }
        }
        private int views;

        public int Views
        {
            get { return views; }
            set { views = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private DateTime addTime;

        public DateTime AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }
        /// <summary>
        /// 增加新闻
        /// </summary>
        /// <returns></returns>
        public bool AddNews()
        {
            string sql = "insert into News(News_Title,News_IsSpecial,News_IsHomePagePicture,News_PictureSrc," +
                "News_TypeId,News_Author,News_Source,News_Views,News_Content,News_AddTime) values(@title," +
                "@isSpecial,@isHomePagePicture,@pictureSrc,@typeId,@author,@source,@views,@content,@addTime)";
            SqlParameter[] parms = new SqlParameter[9];
            parms[0] = new SqlParameter("@title", SqlDbType.NVarChar, 60);
            parms[0].Value = title;
            parms[1] = new SqlParameter("@isSpecial", SqlDbType.Bit);
            parms[1].Value = isSpecial;
            parms[2] = new SqlParameter("@isHomePagePicture", SqlDbType.Bit);
            parms[2].Value = isHomePagePicture;
            parms[3] = new SqlParameter("@pictureSrc", SqlDbType.NVarChar, 100);
            parms[3].Value = pictureSrc;
            parms[4] = new SqlParameter("@typeId", SqlDbType.Int);
            parms[4].Value = typeId;
            parms[5] = new SqlParameter("@author", SqlDbType.NVarChar, 50);
            parms[5].Value = author;
            parms[6] = new SqlParameter("@source", SqlDbType.NVarChar, 50);
            parms[6].Value = source;
            parms[7] = new SqlParameter("@views", SqlDbType.Int);
            parms[7].Value = views;
            parms[8] = new SqlParameter("@content", SqlDbType.Text);
            parms[8].Value = content;
            parms[9] = new SqlParameter("@title", SqlDbType.DateTime2);
            parms[9].Value = addTime;
            return DataMake.ExecuteSql(sql, parms)>=0;
        }
        /// <summary>
        /// 更新新闻
        /// </summary>
        /// <returns></returns>
        public bool UpdateNews()
        {
            string sql = "update News set News_Title=@title,News_IsSpecial=@isSpecial,News_IsHomePagePicture=@isHomePagePicture,News_PictureSrc=@pictureSrc," +
                "News_TypeId=@typeId,News_Author=@author,News_Source=@source,News_Views=@views,News_Content=@content,News_AddTime=@addTime where Id=@Id";
            SqlParameter[] parms = new SqlParameter[10];
            parms[0] = new SqlParameter("@title", SqlDbType.NVarChar, 60);
            parms[0].Value = title;
            parms[1] = new SqlParameter("@isSpecial", SqlDbType.Bit);
            parms[1].Value = isSpecial;
            parms[2] = new SqlParameter("@isHomePagePicture", SqlDbType.Bit);
            parms[2].Value = isHomePagePicture;
            parms[3] = new SqlParameter("@pictureSrc", SqlDbType.NVarChar, 100);
            parms[3].Value = pictureSrc;
            parms[4] = new SqlParameter("@typeId", SqlDbType.Int);
            parms[4].Value = typeId;
            parms[5] = new SqlParameter("@author", SqlDbType.NVarChar, 50);
            parms[5].Value = author;
            parms[6] = new SqlParameter("@source", SqlDbType.NVarChar, 50);
            parms[6].Value = source;
            parms[7] = new SqlParameter("@views", SqlDbType.Int);
            parms[7].Value = views;
            parms[8] = new SqlParameter("@content", SqlDbType.Text);
            parms[8].Value = content;
            parms[9] = new SqlParameter("@title", SqlDbType.DateTime2);
            parms[9].Value = addTime;
            parms[10] = new SqlParameter("@Id", SqlDbType.Int);
            parms[10].Value = id;
            return DataMake.ExecuteSql(sql, parms) >= 0;
        }
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool DeleteNews(string id)
        {
            string sql = "delete from News where Id=" + id;
            return DataMake.ExecuteSql(sql)>0;
        }
        /// <summary>
        /// 获取所有新闻
        /// </summary>
        /// <returns></returns>
        public static List<News> GetItems()
        {
            News news = new News();
            List<News> newsList = new List<News>();
            string sql = "select * from News";
            DataTable dt = DataMake.DataTableRead(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    news.Id = (int)dt.Rows[i]["Id"];
                    news.Title = dt.Rows[i]["News_Title"].ToString();
                    news.IsSpecial = (int)dt.Rows[i]["News_IsSpecial"] == 1 ? true : false;
                    news.IsHomePagePicture = (int)dt.Rows[i]["News_IsHomePagePicture"] == 1 ? true : false;
                    news.PictureSrc = dt.Rows[i]["News_PictureSrc"].ToString();
                    news.TypeId = (int)dt.Rows[i]["News_TypeId"];
                    news.Author = dt.Rows[i]["News_Author"].ToString();
                    news.Source = dt.Rows[i]["News_Source"].ToString();
                    news.Views = (int)dt.Rows[i]["News_Views"];
                    news.Content = dt.Rows[i]["News_Content"].ToString();
                    news.AddTime = Convert.ToDateTime(dt.Rows[i]["News_AddTime"]);
                    newsList.Add(news);
                }
            }
            return newsList;
        }
        /// <summary>
        /// 获取某一条新闻
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static News GetItem(string id)
        {
            News news = new News();
            string sql = "select * from News where Id="+id;
            DataTable dt = DataMake.DataTableRead(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    news.Id = (int)dt.Rows[i]["Id"];
                    news.Title = dt.Rows[i]["News_Title"].ToString();
                    news.IsSpecial = (int)dt.Rows[i]["News_IsSpecial"]== 1 ? true : false;
                    news.IsHomePagePicture = (int)dt.Rows[i]["News_IsHomePagePicture"] == 1 ? true : false;
                    news.PictureSrc = dt.Rows[i]["News_PictureSrc"].ToString();
                    news.TypeId = (int)dt.Rows[i]["News_TypeId"];
                    news.Author = dt.Rows[i]["News_Author"].ToString();
                    news.Source = dt.Rows[i]["News_Source"].ToString();
                    news.Views = (int)dt.Rows[i]["News_Views"];
                    news.Content = dt.Rows[i]["News_Content"].ToString();
                    news.AddTime = Convert.ToDateTime(dt.Rows[i]["News_AddTime"]);
                }
            }
            return news;
        }
    }
}
