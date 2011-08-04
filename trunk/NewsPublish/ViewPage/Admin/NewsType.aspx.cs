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
            int pageSize = int.Parse(lb_pagesize.Text.Trim());
            int pageIndex = int.Parse(tb_pageindex.Text.Trim());
            NewsPublish.BusinessLayer.NewsType newsType = new BusinessLayer.NewsType();
            this.rp_content.DataSource = newsType.GetItems(pageIndex, pageSize);
            this.rp_content.DataBind();
        }
    }
}