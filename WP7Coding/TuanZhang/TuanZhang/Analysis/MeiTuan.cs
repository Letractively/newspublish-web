using HtmlAgilityPack;
using TuanZhang.DataModel;
using System.Collections.ObjectModel;
using System;

namespace TuanZhang.Analysis
{
    public class MeiTuan
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
            HtmlNodeCollection dataNodeList = xml.DocumentNode.ChildNodes["response"].ChildNodes["deals"].ChildNodes;
            if (dataNodeList.Count > 0)
            {
                foreach (HtmlNode dataNode in dataNodeList)
                {
                    if (dataNode.Name == "data")
                    {
                        Product product = new Product();
                        product._webSiteId = siteId;
                        product._cityId = cityId;
                        HtmlNodeCollection dealCollection = dataNode.ChildNodes["deal"].ChildNodes;
                        product.Guid = dealCollection["deal_id"].InnerText;
                        if (dealCollection["deal_desc"].InnerText.Length > 35)
                            product.Title = "【" + dealCollection["website"].InnerText + "】" + dealCollection["deal_desc"].InnerText.Substring(0, 35) + "...";
                        else
                            product.Title = "【" + dealCollection["website"].InnerText + "】" + dealCollection["deal_desc"].InnerText;
                        product.Url = dealCollection["deal_url"].InnerText;
                        product.WapUrl = dealCollection["deal_wap_url"].InnerText;
                        product.Image = dealCollection["deal_img"].InnerText;
                        product.SmallImage = dealCollection["deal_img"].InnerText;
                        product._categoryId = Core.CategoryConvert.ConvertTo(dealCollection["deal_cate"].InnerText); //有问题
                        product.Detail = dealCollection["deal_desc"].InnerText;
                        float value = 0;
                        float.TryParse(dealCollection["value"].InnerText, out value);
                        product.Value = value;
                        product.Price = float.Parse(dealCollection["price"].InnerText);
                        product.Rebate = float.Parse(dealCollection["rebate"].InnerText);
                        product.Bought = dealCollection["sales_num"].InnerText;
                        product.StartTime = Core.JsonTimeConvert.ConvertTo(dealCollection["start_time"].InnerText);
                        product.EndTime = Core.JsonTimeConvert.ConvertTo(dealCollection["end_time"].InnerText);
                        product.Tips = dealCollection["deal_tips"].InnerText;
                        product.Range = dealCollection["deal_range"].InnerText;
                        product.Address = dealCollection["deal_address"].InnerText;
                        product.Longitude = dealCollection["deal_lng"].InnerText;
                        product.Latitude = dealCollection["deal_lat"].InnerText;
                        product.Seller = dealCollection["deal_seller"].InnerText;
                        product.Phone = dealCollection["deal_phones"].InnerText;
                        HtmlNodeCollection shopsCollection = dataNode.ChildNodes["shops"].ChildNodes;
                        HtmlNodeCollection shopCollection = shopsCollection["shop"].ChildNodes;
                        product.DpShopId = shopCollection["shop_dpid"].InnerText;
                        product.Traffic = shopCollection["shop_trafficinfo"].InnerText;
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
