using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsPublish.ViewPage.Admin
{
    public partial class NewsType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        /// 
        /// </summary>
        private void BindData()
        {
            NewsPublish.BusinessLayer.NewsType newsType = new BusinessLayer.NewsType();
            this.GridView1.DataSource = newsType.GetItems();
            this.GridView1.DataBind();
        }
    }
}