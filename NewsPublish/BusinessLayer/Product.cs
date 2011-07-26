using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using NewsPublish.DataLayer;
namespace NewsPublish.BusinessLayer
{
    [Serializable]
    public class Product
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private bool productIsHomePagePicture;

        public bool ProductIsHomePagePicture
        {
            get { return productIsHomePagePicture; }
            set { productIsHomePagePicture = value; }
        }
        private string productPictureSrc;

        public string ProductPictureSrc
        {
            get { return productPictureSrc; }
            set { productPictureSrc = value; }
        }
        private int productTypeId;

        public int ProductTypeId
        {
            get { return productTypeId; }
            set { productTypeId = value; }
        }
        private string productIntroduce;

        public string ProductIntroduce
        {
            get { return productIntroduce; }
            set { productIntroduce = value; }
        }
        private DateTime productAddTime;

        public DateTime ProductAddTime
        {
            get { return productAddTime; }
            set { productAddTime = value; }
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        public bool AddProduct()
        {
            string sql = "Insert into Product(Product_Name,Product_IsHomePagePicture,Product_PictureSrc,"+
                "Product_TypeId,Product_Introduce,Product_AddTime) values(@Product_Name,@Product_IsHomePagePicture,"+
                "@Product_PictureSrc,@Product_TypeId,@Product_Introduce,@Product_AddTime)";
            SqlParameter[] parms = new SqlParameter[6];
            parms[0] = new SqlParameter("@Product_Name", SqlDbType.VarChar, 50);
            parms[0].Value = productName;
            parms[1] = new SqlParameter("@Product_IsHomePagePicture", SqlDbType.BigInt);
            parms[1].Value = productIsHomePagePicture;
            parms[2] = new SqlParameter("@Product_PictureSrc", SqlDbType.VarChar, 150);
            parms[2].Value = productPictureSrc;
            parms[3] = new SqlParameter("@Product_TypeId", SqlDbType.Int);
            parms[3].Value = productTypeId;
            parms[4] = new SqlParameter("@Product_Introduce", SqlDbType.Text);
            parms[4].Value = productIntroduce;
            parms[5] = new SqlParameter("@Product_AddTime", SqlDbType.DateTime);
            parms[5].Value = productAddTime;
            return DataMake.ExecuteSql(sql, parms)>0;
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        public bool UpdateProduct()
        {
            string sql = "Update Product set Product_Name=@Product_Name,Product_IsHomePagePicture=@Product_IsHomePagePicture," +
                "Product_PictureSrc=@Product_PictureSrc,Product_TypeId=@Product_TypeId,Product_Introduce=@Product_Introduce," +
                "Product_AddTime=@Product_AddTime where Id=@Id";
            SqlParameter[] parms = new SqlParameter[7];
            parms[0] = new SqlParameter("@Product_Name", SqlDbType.VarChar, 50);
            parms[0].Value = productName;
            parms[1] = new SqlParameter("@Product_IsHomePagePicture", SqlDbType.Bit);
            parms[1].Value = productIsHomePagePicture;
            parms[2] = new SqlParameter("@Product_PictureSrc", SqlDbType.VarChar, 150);
            parms[2].Value = productPictureSrc;
            parms[3] = new SqlParameter("@Product_TypeId", SqlDbType.Int);
            parms[3].Value = productTypeId;
            parms[4] = new SqlParameter("@Product_Introduce", SqlDbType.Text);
            parms[4].Value = productIntroduce;
            parms[5] = new SqlParameter("@Product_AddTime", SqlDbType.DateTime);
            parms[5].Value = productAddTime;
            parms[6] = new SqlParameter("@ID", SqlDbType.Int);
            parms[6].Value = id;
            return DataMake.ExecuteSql(sql, parms) > 0;
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        public static bool DeleteProduct(string id)
        {
            string sql = "delete from Product where Id=" + id;
            return DataMake.ExecuteSql(sql)>0;
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        public static List<Product> GetItems()
        {
            string sql = "select * from Product";
            DataTable dt = DataMake.DataTableRead(sql);
            Product product = new Product();
            List<Product> productList = new List<Product>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    product.id = (int)dt.Rows[i]["Id"];
                    product.productName = dt.Rows[i]["Product_Name"].ToString();
                    product.productIsHomePagePicture = (bool)dt.Rows[i]["Product_IsHomePagePicture"];
                    product.productPictureSrc = dt.Rows[i]["Product_PictureSrc"].ToString();
                    product.productTypeId = (int)dt.Rows[i]["Product_TypeId"];
                    product.productIntroduce = dt.Rows[i]["Product_Introduce"].ToString();
                    product.productAddTime = Convert.ToDateTime(dt.Rows[i]["Product_AddTime"]);
                    productList.Add(product);
                }
            }
            return productList;
        }

        /// <summary>
        /// 获取一个产品
        /// </summary>
        public static Product GetItem(string id)
        {
            string sql = "select * from Product where Id="+id;
            DataTable dt = DataMake.DataTableRead(sql);
            Product product = new Product();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    product.id = (int)dt.Rows[i]["Id"];
                    product.productName = dt.Rows[i]["Product_Name"].ToString();
                    product.productIsHomePagePicture = (bool)dt.Rows[i]["Product_IsHomePagePicture"];
                    product.productPictureSrc = dt.Rows[i]["Product_PictureSrc"].ToString();
                    product.productTypeId = (int)dt.Rows[i]["Product_TypeId"];
                    product.productIntroduce = dt.Rows[i]["Product_Introduce"].ToString();
                    product.productAddTime = Convert.ToDateTime(dt.Rows[i]["Product_AddTime"]);
                }
            }
            return product;
        }
    }
}
