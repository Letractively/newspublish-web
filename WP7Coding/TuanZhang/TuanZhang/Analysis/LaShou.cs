using System;
using TuanZhang.DataModel;
using HtmlAgilityPack;
using System.Collections.ObjectModel;

namespace TuanZhang.Analysis
{
    public class LaShou
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
            HtmlNodeCollection urlSetNodeList = xml.DocumentNode.LastChild.ChildNodes;
            if (urlSetNodeList.Count > 0)
            {
                foreach (HtmlNode urlNode in urlSetNodeList)
                {
                    if (urlNode.Name == "url")
                    {
                        Product product = new Product();
                        HtmlNodeCollection urlNodeList = urlNode.ChildNodes;
                        product.Url = urlNodeList["loc"].InnerText;
                        product.WapUrl = urlNodeList["wap_url"].InnerText;
                        product._webSiteId=siteId;
                        product._cityId=cityId;
                        HtmlNodeCollection displayNodeList = urlNodeList["data"].FirstChild.NextSibling.ChildNodes;
                        product._categoryId = Core.CategoryConvert.ConvertFrom(displayNodeList["title"].InnerText);  //todo
                        product.Guid = displayNodeList["gid"].InnerText;
                        if (displayNodeList["title"].InnerText.Length > 35)
                            product.Title = "【" + displayNodeList["website"].InnerText + "】" + displayNodeList["title"].InnerText.Substring(0, 35) + "...";
                        else
                            product.Title = "【" + displayNodeList["website"].InnerText + "】" + displayNodeList["title"].InnerText;
                        product.Image = displayNodeList["image"].InnerText;
                        product.SmallImage = displayNodeList["small_image"].InnerText;
                        product.StartTime = Core.JsonTimeConvert.ConvertTo(displayNodeList["startTime"].InnerText);
                        product.EndTime = Core.JsonTimeConvert.ConvertTo(displayNodeList["endTime"].InnerText);
                        product.Value = float.Parse(displayNodeList["value"].InnerText,System.Globalization.NumberStyles.AllowDecimalPoint);
                        product.Price = float.Parse(displayNodeList["price"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint);
                        product.Rebate = float.Parse(displayNodeList["rebate"].InnerText);
                        product.Bought = displayNodeList["bought"].InnerText;
                        product.Detail = displayNodeList["title"].InnerText;
#warning 拉手推荐问题
                        product.Major = false;   //todo
                        HtmlNodeCollection shopsNodeList = displayNodeList["shops"].ChildNodes;
                        if (shopsNodeList.Count > 1)
                        {
                            HtmlNodeCollection shopNodeList = shopsNodeList[1].ChildNodes;       //这里存在一个问题，目前只提取第一个商家
                            product.Seller = shopNodeList["name"].InnerText;
                            product.Address = shopNodeList["addr"].InnerText;
                            string[] phoneArray=shopNodeList["tel"].InnerText.Split('|');
                            if(phoneArray.Length>1)
                            {
                                foreach(string phone in phoneArray)
                                {
                                    product.Phone += phone+",";
                                }
                            }
                            else
                                product.Phone=shopNodeList["tel"].InnerText;
                            product.Longitude = shopNodeList["longitude"].InnerText;
                            product.Latitude = shopNodeList["latitude"].InnerText;
                        }
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
