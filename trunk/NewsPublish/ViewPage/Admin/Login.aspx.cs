using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsPublish.BusinessLayer;

namespace NewsPublish.ViewPage.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAuthCodeImg();
            }
        }
        /// <summary>
        /// 绑定验证码图片
        /// </summary>
        private void BindAuthCodeImg()
        {
            string authcode=string.Empty;
            string imgSrc=CommonFunction.CreateAuthCodeImg(70,25,out authcode);
            img_authcode.ImageUrl = imgSrc;
            Session["AuthCode"] = authcode.ToLower();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_reset_Click(object sender, EventArgs e)
        {
            tb_username.Text = string.Empty;
            tb_password.Text = string.Empty;
            tb_authcode.Text = string.Empty;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_login_Click(object sender, EventArgs e)
        {
            string userName = tb_username.Text.Trim();
            string password = tb_password.Text.Trim();
            string authCode = tb_authcode.Text.Trim().ToLower();
            if (authCode == Session["AuthCode"].ToString())
            { 
                NewsPublish.BusinessLayer.Admin admin=new BusinessLayer.Admin().SelectAdmin(userName,password);
                if(admin!=null)
                {
                    Response.Redirect("/ViewPage/Admin/Main.aspx");
                    Session["AdminName"] = admin.AdminName;
                }
            }
        }
    }
}