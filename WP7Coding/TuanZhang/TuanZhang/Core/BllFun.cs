using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using TuanZhang.DataModel;

namespace TuanZhang.Core
{
    public class BllFun
    {
        #region  站点操作
        /// <summary>
        /// 插入站点数据
        /// </summary>
        /// <param name="cityObservableCollection"></param>
        /// <returns></returns>
        public bool InsertSite(ObservableCollection<Site> siteObservableCollection)
        {
            bool result = false;
            try
            {
                b_data.T_Site.InsertAllOnSubmit<Site>(siteObservableCollection);
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        /// <summary>
        /// 获取站点
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Site> SelectSites()
        {
            var siteObservableCollection = from Site site in b_data.T_Site
                                           select site;
            return new ObservableCollection<Site>(siteObservableCollection);
        }
        /// <summary>
        /// 删除站点
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public bool DeleteSite(Site site)
        {
            b_data.T_Site.DeleteOnSubmit(site);
            bool result = false;
            try
            {
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        #endregion
        #region 产品类别操作
        /// <summary>
        /// 插入类别数据
        /// </summary>
        /// <param name="cityObservableCollection"></param>
        /// <returns></returns>
        public bool InsertCategory(ObservableCollection<Category> categoryObservableCollection)
        {
            bool result = false;
            try
            {
                b_data.T_Category.InsertAllOnSubmit<Category>(categoryObservableCollection);
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        /// <summary>
        /// 获取类别
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Category> SelectCategorys()
        {
            var categoryObservableCollection = from Category category in b_data.T_Category
                                               select category;
            return new ObservableCollection<Category>(categoryObservableCollection);
        }
        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool DeleteCategory(Category category)
        {
            b_data.T_Category.DeleteOnSubmit(category);
            bool result = false;
            try
            {
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        #endregion
        #region 城市操作
        /// <summary>
        /// 插入城市数据
        /// </summary>
        /// <param name="cityObservableCollection"></param>
        /// <returns></returns>
        public bool InsertCity(ObservableCollection<City> cityObservableCollection)
        {
            bool result = false;
            try
            {
                b_data.T_City.InsertAllOnSubmit<City>(cityObservableCollection);
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        /// <summary>
        /// 获取城市
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<City> SelectCitys()
        {
            var cityObservableCollection = from City city in b_data.T_City
                                           select city;
            return new ObservableCollection<City>(cityObservableCollection);
        }
        /// <summary>
        /// 获取某个城市
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public City SelectCity(int cityId)
        {
            var city = from City cit in b_data.T_City
                       where cit.Id == cityId
                       select cit;
            ObservableCollection<City> cityObservableCollection = new ObservableCollection<City>(city);
            return cityObservableCollection.Count > 0 ? cityObservableCollection[0] : null;
        }
        /// <summary>
        /// 删除城市
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public bool DeleteCity(City city)
        {
            b_data.T_City.DeleteOnSubmit(city);
            bool result = false;
            try
            {
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        #endregion
        #region 配置操作[暂时没用]
        ///// <summary>
        ///// 获取配置
        ///// </summary>
        ///// <returns></returns>
        //public Config SelectConfig()
        //{
        //    var config = from Config conf in b_data.T_Config
        //                 select conf;
        //    return new ObservableCollection<Config>(config)[0];
        //}
        ///// <summary>
        ///// 插入配置
        ///// </summary>
        ///// <param name="config"></param>
        ///// <returns></returns>
        //public bool InsertConfig(Config config)
        //{
        //    bool result = false;
        //    try
        //    {
        //        b_data.T_Config.InsertOnSubmit(config);
        //        b_data.SubmitChanges();
        //        result = true;
        //    }
        //    catch (Exception e)
        //    {
        //        //todo
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 更新配置
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="config"></param>
        ///// <returns></returns>
        //public bool UpdateConfig(string id, Config config)
        //{
        //    int configId = int.Parse(id);
        //    bool result = true;
        //    var query = from conf in b_data.T_Config
        //                where conf.Id == configId
        //                select conf;
        //    try
        //    {
        //        foreach (Config conf in query)
        //        {
        //            conf.CityId = config.CityId;
        //            //其他属性在此更新
        //        }

        //        b_data.SubmitChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 删除配置
        ///// </summary>
        ///// <param name="config"></param>
        ///// <returns></returns>
        //public bool DeleteConfig(Config config)
        //{
        //    b_data.T_Config.DeleteOnSubmit(config);
        //    bool result = false;
        //    try
        //    {
        //        b_data.SubmitChanges();
        //        result = true;
        //    }
        //    catch (Exception e)
        //    {
        //        //todo
        //    }
        //    return result;
        //}
        #endregion
        #region 产品操作
        /// <summary>
        /// 插入产品数据
        /// </summary>
        /// <param name="cityObservableCollection"></param>
        /// <returns></returns>
        public bool InsertProduct(ObservableCollection<Product> productObservableCollection)
        {
            bool result = false;
            try
            {
                b_data.T_Product.InsertAllOnSubmit<Product>(productObservableCollection);
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        /// <summary>
        /// 删除过期产品
        /// </summary>
        /// <param name="priduct"></param>
        /// <returns></returns>
        public bool DeleteProduct()
        {
            var temp = from product in b_data.T_Product
                       where product.EndTime < DateTime.Now
                       select product;
            b_data.T_Product.DeleteAllOnSubmit(temp);
            bool result = false;
            try
            {
                b_data.SubmitChanges();
                result = true;
            }
            catch (Exception e)
            {
                //todo
            }
            return result;
        }
        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <returns></returns>
        //public ObservableCollection<Product> SelectProducts()
        //{
        //    var productObservableCollection = from Product product in b_data.T_Product
        //                      select product;
        //    return new ObservableCollection<Product>(productObservableCollection);
        //}
        /// <summary>
        /// 获取最新的产品
        /// </summary>
        /// <param name="count">条数</param>
        /// <returns></returns>
        //public ObservableCollection<Product> SelectProducts(int count)
        //{
        //    var productObservableCollection = (from Product product in b_data.T_Product
        //                       orderby product.Time
        //                       select product).Take(count);
        //    return new ObservableCollection<Product>(productObservableCollection);
        //}
        /// <summary>
        /// 获取某一个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Product SelectProduct(string id)
        //{ 
        //    int productId=int.Parse(id);
        //    var productTemp = from Product product in b_data.T_Product
        //                  where product.Id == productId
        //                  select product;
        //    ObservableCollection<Product> ObservableCollection = new ObservableCollection<Product>(productTemp);
        //    return ObservableCollection.Count>0?ObservableCollection[0]:null;
        //}
        /// <summary>
        /// 获取某一大类的某一个小类产品
        /// </summary>
        /// <param name="type">category、city、site</param>
        /// <param name="typeid">小类</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public ObservableCollection<Product> SelectProducts(bool isCity, int cityId, bool isSite, int siteId, int categoryId, int count)
        {
            ObservableCollection<Product> ObservableCollection = new ObservableCollection<Product>();
            if (isCity && !isSite)
            {
                var temp = (from Product product in b_data.T_Product
                            where product._cityId == cityId && product._categoryId == categoryId
                            orderby product.Time descending
                            select product).Take(count);
                ObservableCollection.Union(new ObservableCollection<Product>(temp));
            }
            else if (!isCity && isSite)
            {
                var temp = (from Product product in b_data.T_Product
                            where product._webSiteId == siteId && product._categoryId == categoryId
                            orderby product.Time descending
                            select product).Take(count);
                ObservableCollection.Union(new ObservableCollection<Product>(temp));
            }
            else if (isCity && isSite)
            {
                var temp = (from Product product in b_data.T_Product
                            where product._webSiteId == siteId && product._cityId == cityId && product._categoryId == categoryId
                            orderby product.Time descending
                            select product).Take(count);
                ObservableCollection.Union(new ObservableCollection<Product>(temp));
            }
            else
            {
                var temp = (from Product product in b_data.T_Product
                            where product._categoryId == categoryId
                            orderby product.Time descending
                            select product).Take(count);
                ObservableCollection.Union(new ObservableCollection<Product>(temp));
            }
            return ObservableCollection;
        }
        /// <summary>
        /// 获取推荐产品
        /// </summary>
        /// <param name="count">获取个数</param>
        /// <returns></returns>
        public ObservableCollection<Product> SelectMajorProducts(int cityId, int count)
        {
            var temp = (from Product product in b_data.T_Product
                        where product._cityId == cityId && product.Major
                        select product).Take(count);
            ObservableCollection<Product> ObservableCollection = new ObservableCollection<Product>(temp);
            return ObservableCollection;
        }
        /// <summary>
        /// 获取收藏产品
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public ObservableCollection<Product> SelectCollectProducts(int count)
        {
            ObservableCollection<Product> ObservableCollection = new ObservableCollection<Product>();
            var temp = (from Product product in b_data.T_Product
                        where product.Collect == true
                        select product).Take(count);
            ObservableCollection.Union(new ObservableCollection<Product>(temp));
            return ObservableCollection;
        }
        /// <summary>
        /// 筛选出某一列表中的一类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeId"></param>
        /// <param name="ObservableCollection"></param>
        /// <returns></returns>
        //public ObservableCollection<Product> SelectProductsFromObservableCollection(string type,int typeId, ObservableCollection<Product> ObservableCollection)
        //{
        //    ObservableCollection<Product> tempObservableCollection = new ObservableCollection<Product>();
        //    switch (type)
        //    {
        //        case "category":
        //            ObservableCollection.ForEach(a =>
        //            {
        //                if (a._categoryId == typeId) tempObservableCollection.Add(a);
        //            });
        //            break;
        //        case "city":
        //            ObservableCollection.ForEach(a =>
        //            {
        //                if (a._categoryId == typeId) tempObservableCollection.Add(a);
        //            });
        //            break;
        //        case "site":
        //            ObservableCollection.ForEach(a =>
        //            {
        //                if (a._categoryId == typeId) tempObservableCollection.Add(a);
        //            });
        //            break;
        //        default: break;
        //    }
        //    return tempObservableCollection;
        //}
        /// <summary>
        /// 收藏某个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SetCollectProduct(string id)
        {
            int proId = int.Parse(id);
            bool result = true;
            var query = from pro in b_data.T_Product
                        where pro.Id == proId
                        select pro;
            try
            {
                foreach (Product prod in query)
                {
                    if (prod.Collect) prod.Collect = false;
                    else prod.Collect = true;
                }
                b_data.SubmitChanges();
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
        #endregion 
    }
}
