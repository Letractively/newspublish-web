using System;
using System.Net;
using System.Text;
using System.IO;
using System.Windows;
using System.ComponentModel;
namespace TuanZhang.Core
{
    public class NetWorkHelper
    {
        private string uri;

        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }
        private int siteId;

        public int SiteId
        {
            get { return siteId; }
            set { siteId = value; }
        }
        private int cityId;

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }
        public delegate void ReadCompleteEventHandler(object sender, string e);
        public delegate void ErrorEventHandler(object sender, Exception e);
        public event ReadCompleteEventHandler ReadComplete;
        public event ErrorEventHandler Error;
        /// <summary>
        /// 读取流
        /// </summary>
        public void ReadStream()
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(this.Uri));
                request.Method = "GET";
                request.BeginGetResponse(responseCallback, request);
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    this.Error(this.Error, ex);
                    //LogHelper.Log("网络资源获取失败,HttpWebRequest", ex, true);
                }
            }
            
        }
        private void responseCallback(IAsyncResult result)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader read = new StreamReader(stream);
                    string msg = read.ReadToEnd();
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        this.ReadComplete(this, msg);
                    });
                }
            }
            catch (Exception e)
            {
                if (e != null)
                {
                    this.Error(this.Error, e);
                    //LogHelper.Log("网络资源获取失败,responseCallback", e, true);
                }
            }
        }
    }
}
