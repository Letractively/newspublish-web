using System;
using System.Collections.ObjectModel;
using HtmlAgilityPack;
using TuanZhang.DataModel;

namespace TuanZhang.Analysis
{
    public class NuoMi
    {
        /// <summary>
        /// 分析数据
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <returns></returns>
        public ObservableCollection<Product> Analysis(int siteId, int cityId, string xmlDoc)
        {
            ObservableCollection<Product> productList = new ObservableCollection<Product>();
            HtmlDocument xml = new HtmlDocument();
            xml.LoadHtml(xmlDoc.Replace("<![CDATA[", "").Replace("]]>", ""));
            HtmlNodeCollection dataNodeList = xml.DocumentNode.ChildNodes["urlset"].ChildNodes;
            if (dataNodeList.Count > 0)
            {
                foreach (HtmlNode dataNode in dataNodeList)
                {
                    if (dataNode.Name == "url")
                    {
                        Product product = new Product();
                        product._webSiteId = siteId;
                        product._cityId = cityId;
                        product.Url = dataNode.ChildNodes["loc"].InnerText;
                        product.WapUrl = product.Url;
                        product.Guid = product.Url;
                        HtmlNodeCollection dealCollection = dataNode.ChildNodes["data"].ChildNodes["display"].ChildNodes;
                        if (dealCollection["title"].InnerText.Length > 35)
                            product.Title = "【" + dealCollection["website"].InnerText + "】" + dealCollection["title"].InnerText.Substring(0, 35) + "...";
                        else
                            product.Title = "【" + dealCollection["website"].InnerText + "】" + dealCollection["title"].InnerText;
                        if (!string.IsNullOrEmpty(dealCollection["category"].InnerText))
                            product._categoryId = int.Parse(dealCollection["category"].InnerText);
                        else
                            product._categoryId = 6;
                        product.DpShopId = dealCollection["dpshopid"].InnerText;
                        product.Address = dealCollection["address"].InnerText;
                        if (dealCollection["major"].InnerText == "1")
                            product.Major = true;
                        else
                            product.Major = false;
                        product.Image = dealCollection["image"].InnerText;
                        product.SmallImage = dealCollection["image"].InnerText;
                        product.StartTime = Core.JsonTimeConvert.ConvertTo(dealCollection["startTime"].InnerText);
                        product.EndTime = Core.JsonTimeConvert.ConvertTo(dealCollection["endTime"].InnerText);
                        float value = 0;
                        float.TryParse(dealCollection["value"].InnerText, out value);
                        product.Value = value;
                        product.Price = float.Parse(dealCollection["price"].InnerText);
                        product.Rebate = float.Parse(dealCollection["rebate"].InnerText);
                        product.Bought = dealCollection["bought"].InnerText;
                        product.Detail = dealCollection["title"].InnerText;

                        HtmlNodeCollection shopsCollection = dealCollection["shops"].ChildNodes;
                        HtmlNodeCollection shopCollection = shopsCollection["shop"].ChildNodes;
                        product.Longitude = shopCollection["longitude"].InnerText;
                        product.Latitude = shopCollection["latitude"].InnerText;
                        product.Seller = shopCollection["name"].InnerText;
                        string[] phoneArray = shopCollection["tel"].InnerText.Split('|');
                        if (phoneArray.Length > 1)
                        {
                            foreach (string phone in phoneArray)
                            {
                                product.Phone += phone + ",";
                            }
                        }
                        else
                            product.Phone = shopCollection["tel"].InnerText;
                        product.Range = shopCollection["area"].InnerText;
                        product.Traffic = shopCollection["direction"].InnerText;
                        product.Collect = "未收藏";
                        product.CollectPic = "/Images/30xStar_Gray.png";
                        product.Time = DateTime.Now;
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
    }
}
