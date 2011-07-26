using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NewsPublish.DataLayer;

namespace NewsPublish.BusinessLayer
{
    [Serializable]
    public class Admin
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string adminName;

        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }
        private string adminPassword;

        public string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
        private string adminRemark;

        public string AdminRemark
        {
            get { return adminRemark; }
            set { adminRemark = value; }
        }
        /// <summary>
        /// 增加管理员
        /// </summary>
        /// <returns>是否增加成功</returns>
        public bool AddAdmin()
        {
            string sql = "insert into Admin(Admin_Name,Admin_PassWord,Admin_Remark) values(@adminName,@adminPassword,@adminRemark)";
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@adminName", SqlDbType.VarChar, 50);
            parms[0].Value = adminName;
            parms[1] = new SqlParameter("@adminPassword", SqlDbType.VarChar, 150);
            parms[1].Value = adminPassword;
            parms[2] = new SqlParameter("@adminRemark", SqlDbType.VarChar, 150);
            parms[2].Value = adminRemark;
            return DataMake.ExecuteSql(sql, parms)>0;
        }
        /// <summary>
        /// 更新管理员
        /// </summary>
        /// <returns></returns>
        public bool UpdateAdmin()
        {
            string sql = "update Admin set Admin_Name=@adminName,Admin_PassWord=@adminPassword,Admin_Remark=@adminRemark where Id=@Id";
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@adminName", SqlDbType.VarChar, 50);
            parms[0].Value = adminName;
            parms[1] = new SqlParameter("@adminPassword", SqlDbType.VarChar, 150);
            parms[1].Value = adminPassword;
            parms[2] = new SqlParameter("@adminRemark", SqlDbType.VarChar, 150);
            parms[2].Value = adminRemark;
            parms[2] = new SqlParameter("@Id", SqlDbType.Int);
            parms[2].Value = id;
            return DataMake.ExecuteSql(sql, parms)>0;
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteAdmin(int id)
        {
            string sql = "delete from Admin where Id=" + id;
            return DataMake.ExecuteSql(sql)>0;
        }
        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <returns></returns>
        public List<Admin> SelectAdmins()
        {
            List<Admin> list = new List<Admin>();
            Admin admin = new Admin();
            string sql = "select * from Admin";
            DataTable dt = DataMake.DataTableRead(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    admin.Id = int.Parse(dt.Rows[i][0].ToString());
                    admin.AdminName = dt.Rows[i][1].ToString();
                    admin.AdminPassword = dt.Rows[i][2].ToString();
                    admin.AdminRemark = dt.Rows[i][3].ToString();
                    list.Add(admin);
                }
            }
            return list;
        }
        /// <summary>
        /// 是否管理员
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsAdmin(string userName,string password)
        {
            string sql = "select Admin_Name,Admin_PassWord from Admin where Admin_Name=@userName and Admin_PassWord=@password";
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            parms[0].Value = userName;
            parms[1] = new SqlParameter("@password", SqlDbType.NVarChar, 150);
            parms[1].Value = password;
            return DataMake.ExecuteSql(sql, parms)>0;
        }
        public bool IsAdmin2(string userName, string password)
        {
            string sql = "select Admin_Name,Admin_PassWord from Admin where Admin_Name='"+userName+"' and Admin_PassWord='"+password+"'";
            return DataMake.ExecuteSql(sql) > 0;
        }
        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserNameExist(string userName)
        {
            string sql = "select Admin_Name from Admin";
            return DataMake.ExecuteSql(sql) > 0;
        }
    }
}
