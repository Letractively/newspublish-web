using System;
using System.Data;
using System.Data.SqlClient;
using NewsPublish.DataLayer;

namespace NewsPublish.BusinessLayer
{
    public class Site
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string siteName;

        public string SiteName
        {
            get { return siteName; }
            set { siteName = value; }
        }
        private string siteDescibe;

        public string SiteDescibe
        {
            get { return siteDescibe; }
            set { siteDescibe = value; }
        }
        private string siteCopyRight;

        public string SiteCopyRight
        {
            get { return siteCopyRight; }
            set { siteCopyRight = value; }
        }
        private string siteAddress;

        public string SiteAddress
        {
            get { return siteAddress; }
            set { siteAddress = value; }
        }
        private string sitePhone;

        public string SitePhone
        {
            get { return sitePhone; }
            set { sitePhone = value; }
        }
        private string siteRecord;

        public string SiteRecord
        {
            get { return siteRecord; }
            set { siteRecord = value; }
        }
        private string siteRemark;

        public string SiteRemark
        {
            get { return siteRemark; }
            set { siteRemark = value; }
        }
        private DateTime siteAddTime;

        public DateTime SiteAddTime
        {
            get { return siteAddTime; }
            set { siteAddTime = value; }
        }
        /// <summary>
        /// 添加站点信息
        /// </summary>
        /// <returns></returns>
        public bool AddSiteInfo()
        {
            string sql = "insert  into Site(Site_Name,Site_Descibe,Site_CopyRight,Site_Address,Site_Phone,Site_Record,Site_Remark,Site_AddTime)" +
                " values(@Site_Name,@Site_Descibe,@Site_CopyRight,@Site_Address,@Site_Phone,@Site_Record,@Site_Remark,@Site_AddTime)";
            SqlParameter[] parms = new SqlParameter[8];
            parms[0] = new SqlParameter("@Site_Name", SqlDbType.NVarChar, 50);
            parms[0].Value = siteName;
            parms[1] = new SqlParameter("@Site_Descibe", SqlDbType.NVarChar, 50);
            parms[1].Value = siteDescibe;
            parms[2] = new SqlParameter("@Site_CopyRight", SqlDbType.NVarChar, 50);
            parms[2].Value = siteCopyRight;
            parms[3] = new SqlParameter("@Site_Address", SqlDbType.NVarChar, 150);
            parms[3].Value = siteAddress;
            parms[4] = new SqlParameter("@Site_Phone", SqlDbType.NVarChar, 20);
            parms[4].Value = sitePhone;
            parms[5] = new SqlParameter("@Site_Record", SqlDbType.NVarChar, 50);
            parms[5].Value = siteRecord;
            parms[6] = new SqlParameter("@Site_Remark", SqlDbType.NVarChar, 50);
            parms[6].Value = siteRemark;
            parms[7] = new SqlParameter("@Site_AddTime", SqlDbType.DateTime2);
            parms[7].Value = siteAddTime;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }
        /// <summary>
        /// 更新站点信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateSiteInfo()
        {
            string sql = "update Site set Site_Name=@Site_Name,Site_Descibe=@Site_Descibe,Site_CopyRight@Site_CopyRight,Site_Address=@Site_Address," +
                "Site_Phone=@Site_Phone,Site_Record=@Site_Record,Site_Remark=@Site_Remark,Site_AddTime=@Site_AddTime where Id=@Id";
            SqlParameter[] parms = new SqlParameter[9];
            parms[0] = new SqlParameter("@Site_Name", SqlDbType.NVarChar, 50);
            parms[0].Value = siteName;
            parms[1] = new SqlParameter("@Site_Descibe", SqlDbType.NVarChar, 50);
            parms[1].Value = siteDescibe;
            parms[2] = new SqlParameter("@Site_CopyRight", SqlDbType.NVarChar, 50);
            parms[2].Value = siteCopyRight;
            parms[3] = new SqlParameter("@Site_Address", SqlDbType.NVarChar, 150);
            parms[3].Value = siteAddress;
            parms[4] = new SqlParameter("@Site_Phone", SqlDbType.NVarChar, 20);
            parms[4].Value = sitePhone;
            parms[5] = new SqlParameter("@Site_Record", SqlDbType.NVarChar, 50);
            parms[5].Value = siteRecord;
            parms[6] = new SqlParameter("@Site_Remark", SqlDbType.NVarChar, 50);
            parms[6].Value = siteRemark;
            parms[7] = new SqlParameter("@Site_AddTime", SqlDbType.DateTime2);
            parms[7].Value = siteAddTime;
            parms[8] = new SqlParameter("Id", SqlDbType.Int);
            parms[8].Value = id;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }
    }
}
