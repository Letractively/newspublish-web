using System;
using System.Collections.ObjectModel;
using HtmlAgilityPack;
using TuanZhang.DataModel;

namespace TuanZhang.Analysis
{
    public class _55tuan
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
                    if (dataNode.Name == "deal")
                    {
                        Product product = new Product();
                        product._webSiteId = siteId;
                        product._cityId = cityId;
                        HtmlNodeCollection dealCollection = dataNode.ChildNodes;
                        product.Guid = dealCollection["id"].InnerText;
                        if (dealCollection["title"].InnerText.Length > 35)
                            product.Title = "【窝窝团】" + dealCollection["title"].InnerText.Substring(0, 35) + "...";
                        else
                            product.Title = "【窝窝团】" + dealCollection["title"].InnerText;
                        product.Url = dealCollection["deal_url"].InnerText;
                        product.WapUrl = dealCollection["deal_url"].InnerText;
                        product.Image = dealCollection["medium_image_url"].InnerText;
                        product.SmallImage = dealCollection["small_image_url"].InnerText;
                        product.StartTime = Core.JsonTimeConvert.ConvertTo(dealCollection["start_date"].InnerText);
                        product.EndTime = Core.JsonTimeConvert.ConvertTo(dealCollection["end_date"].InnerText);
                        if (dealCollection["is_top"].InnerText == "1")
                            product.Major = true;
                        else
                            product.Major = false;
                        float value = 0;
                        float.TryParse(dealCollection["value"].InnerText, out value);
                        product.Value = value;
                        product.Price = float.Parse(dealCollection["price"].InnerText);
                        product.Rebate = float.Parse(dealCollection["discount_percent"].InnerText);
                        product.Bought = dealCollection["quantity_sold"].InnerText;

                        product._categoryId = Core.CategoryConvert.ConvertFrom(dealCollection["title"].InnerText);
                        product.Detail = dealCollection["title"].InnerText;

                        HtmlNodeCollection shopsCollection = dealCollection["vendors"].ChildNodes;
                        product.Seller = shopsCollection["vendor_name"].InnerText;
                        HtmlNodeCollection shopCollection = shopsCollection["vendor"].ChildNodes;
                        //product.DpShopId = shopCollection["shop_dpid"].InnerText;
                        product.Range = shopCollection["area"].InnerText;
                        product.Address = shopCollection["address"].InnerText;
                        product.Longitude = shopCollection["lng"].InnerText;
                        product.Latitude = shopCollection["lat"].InnerText;
                        product.Phone = shopCollection["phone"].InnerText;

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
