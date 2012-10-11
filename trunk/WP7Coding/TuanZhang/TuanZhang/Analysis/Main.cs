using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using TuanZhang.DataModel;
using System.Threading;

namespace TuanZhang.Analysis
{
    /// <summary>
    /// 主要处理数据获取
    /// </summary>
    public class Main
    {
        private ViewModel.ProductViewModel fun = App.ViewModel; 
        
        public delegate void GetCompleteHandler(object sender, ObservableCollection<Product> ObservableCollection,string siteName,bool isOver);
        public event GetCompleteHandler GetComplete;

        private ObservableCollection<Product> curentList = new ObservableCollection<Product>();
        private ObservableCollection<Site> siteCollection = new ObservableCollection<Site>();
        private City currentCity = new City();
        private int currrentGetIndex = 0;
        
        public Main()
        {
        }
        /// <summary>
        /// 从网络开始获取
        /// </summary>
        /// <param name="cityId"></param>
        public void GetFromNet()
        {
            siteCollection = fun.SelectSites();
            currentCity = fun.SelectCitys().First(a => a.Id == App.ViewModel.Config.CityId);
            SiteNetGet(currrentGetIndex);
        }
        /// <summary>
        /// 每个站点获取
        /// </summary>
        /// <param name="site"></param>
        /// <param name="city"></param>
        public void SiteNetGet(int currentGetIndex)
        {
            if (currrentGetIndex < siteCollection.Count)
            {
                Core.NetWorkHelper net = new Core.NetWorkHelper();
                Site site = siteCollection[currrentGetIndex];
                net.SiteId = site.Id;
                net.CityId = currentCity.Id;
                switch (site.Id)
                {
                    case 1:
                        net.Uri = string.Format(site.ApiUri, currentCity.Name);
                        break;
                    case 2:
                        net.Uri = string.Format(site.ApiUri, currentCity.PinYin);
                        break;
                    case 3:
                        net.Uri = string.Format(site.ApiUri, currentCity.PinYin);
                        break;
                    case 4:
                        net.Uri = string.Format(site.ApiUri, currentCity.PinYin);
                        break;
                    default:
                        break;
                }
                net.ReadComplete += new Core.NetWorkHelper.ReadCompleteEventHandler(net_ReadComplete);
                net.Error += new Core.NetWorkHelper.ErrorEventHandler(net_Error);
                net.ReadStream();
            }
        }
        /// <summary>
        /// 对获取到的数据进行解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void net_ReadComplete(object sender, string e)
        {
            Core.NetWorkHelper net = sender as Core.NetWorkHelper;
            ObservableCollection<Product> ObservableCollection = new ObservableCollection<Product>();
            switch (net.SiteId)
            {
                case 1:
                    Analysis.LaShou laShou = new LaShou();
                    ObservableCollection = laShou.Analysis(net.SiteId, net.CityId, e);
                    break;
                case 2:
                    Analysis.MeiTuan meiTuan = new MeiTuan();
                    ObservableCollection = meiTuan.Analysis(net.SiteId, net.CityId, e);
                    break;
                case 3:
                    Analysis.NuoMi nuoMi = new NuoMi();
                    ObservableCollection = nuoMi.Analysis(net.SiteId, net.CityId, e);
                    break;
                case 4:
                    Analysis._55tuan wwTuan = new _55tuan();
                    ObservableCollection = wwTuan.Analysis(net.SiteId, net.CityId, e);
                    break;
                default: break;
            }
            GC.Collect();
            InsertOrUpdateDB(net.SiteId, ObservableCollection);
        }
        /// <summary>
        /// 网络获取异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void net_Error(object sender, Exception e)
        {
            //Core.LogHelper.Log("Analysis.Main", e, true);
            this.currrentGetIndex++;
            SiteNetGet(this.currrentGetIndex);
        }
        /// <summary>
        /// 插入或更新数据库信息
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ObservableCollection"></param>
        /// <returns>返回新增加的条目</returns>
        private void InsertOrUpdateDB(int p, ObservableCollection<Product> ObservableCollection)
        {
            bool isOver=false;
            if (this.currrentGetIndex == siteCollection.Count-1) isOver = true; //获取结束
            curentList = IsNotHaveList(p, ObservableCollection);
            fun.InsertProduct(curentList);
            this.GetComplete(this, curentList, siteCollection[this.currrentGetIndex].Name,isOver);
            GC.Collect();
            Thread.Sleep(200);
            this.currrentGetIndex++;
            SiteNetGet(this.currrentGetIndex);
        }
        /// <summary>
        /// 某一个站的产品是否存在
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        private ObservableCollection<Product> IsNotHaveList(int siteId, ObservableCollection<Product> list)
        {
            ObservableCollection<Product> productObservableCollection = fun.SelectSiteProducts(siteId);
            ObservableCollection<Product> tempCollection = new ObservableCollection<Product>();
            bool flag = true;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < productObservableCollection.Count; j++)
                {
                    if (list[i].Guid == productObservableCollection[j].Guid)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) tempCollection.Insert(0, list[i]);
            }
            return tempCollection;
        }
    }
}
