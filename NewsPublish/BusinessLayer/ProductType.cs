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
    public class ProductType
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string productTypeName_zh;

        public string ProductTypeName_zh
        {
            get { return productTypeName_zh; }
            set { productTypeName_zh = value; }
        }
        private string productTypeName_en;

        public string ProductTypeName_en
        {
            get { return productTypeName_en; }
            set { productTypeName_en = value; }
        }
        private string productTypeRemark;

        public string ProductTypeRemark
        {
            get { return productTypeRemark; }
            set { productTypeRemark = value; }
        }

        /// <summary>
        /// 添加产品类型
        /// </summary>
        public bool AddProductTyype()
        {
            string sql = "Insert into ProductType(ProductTypeName_zh,ProductTypeName_en,ProductType_Remark)"+
                " values(@ProductTypeName_zh,@ProductTypeName_en,@ProductType_Remark)";
            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter("@ProductType_zh", SqlDbType.NVarChar, 50);
            parms[0].Value = productTypeName_zh;
            parms[1] = new SqlParameter("@ProductType_en", SqlDbType.NVarChar, 50);
            parms[1].Value = productTypeName_en;
            parms[2] = new SqlParameter("@ProductType_Remark", SqlDbType.NVarChar, 150);
            parms[2].Value = productTypeRemark;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }

        /// <summary>
        /// 更新产品类型
        /// </summary>
        public bool UpdateProductType()
        {
            string sql = "Update ProductType set ProductTypeName_zh=@ProductTypeName_zh,ProductTypeName_en=@ProductTypeName_en," +
                "ProductType_Remark=@ProductType_Remark where Id=@Id";
            SqlParameter[] parms = new SqlParameter[4];
            parms[0] = new SqlParameter("@ProductType_zh", SqlDbType.NVarChar, 50);
            parms[0].Value = productTypeName_zh;
            parms[1] = new SqlParameter("@ProductType_en", SqlDbType.NVarChar, 50);
            parms[1].Value = productTypeName_en;
            parms[2] = new SqlParameter("@ProductType_Remark", SqlDbType.NVarChar, 150);
            parms[2].Value = productTypeRemark;
            parms[3] = new SqlParameter("@Id", SqlDbType.Int);
            parms[3].Value = id;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }

        /// <summary>
        /// 删除产品类型
        /// </summary>
        public static bool DeleteProductType(string id)
        {
            string sql = "delete from ProductType where Id="+id;
            return DataMake.ExecuteSql(sql) > 0;
        }

        /// <summary>
        /// 得到所有产品类型
        /// </summary>
        public static List<ProductType> GetItems()
        {
            string sql = "select * from ProductType";
            DataTable dt = DataMake.DataTableRead(sql);
            ProductType productType = new ProductType();
            List<ProductType> productTypeList = new List<ProductType>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    productType.id = (int)dt.Rows[i]["Id"];
                    productType.productTypeName_zh = dt.Rows[i]["ProductTypeName_zh"].ToString();
                    productType.productTypeName_en = dt.Rows[i]["ProductTypeName_en"].ToString();
                    productType.productTypeRemark = dt.Rows[i]["ProductType_Remark"].ToString();
                    productTypeList.Add(productType);
                }
            }
            return productTypeList;
        }

        /// <summary>
        /// 获取某一个产品类型
        /// </summary>
        public static ProductType GetItem(string id)
        {
            string sql = "select * from ProductType where Id="+id;
            DataTable dt = DataMake.DataTableRead(sql);
            ProductType productType = new ProductType(); 
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    productType.id = (int)dt.Rows[i]["Id"];
                    productType.productTypeName_zh = dt.Rows[i]["ProductTypeName_zh"].ToString();
                    productType.productTypeName_en = dt.Rows[i]["ProductTypeName_en"].ToString();
                    productType.productTypeRemark = dt.Rows[i]["ProductType_Remark"].ToString();
                }
            }
            return productType;
        }
    }
}
