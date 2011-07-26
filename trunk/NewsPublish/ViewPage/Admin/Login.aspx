<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../CSS/login.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
	
	     <div id="top">
		      <div id="top_left"><img src="../Images/login_03.gif" alt=""/></div>
			  <div id="top_center"></div>
		 </div>
		 
		 <div id="center">
		      <div id="center_left"></div>
			  <div id="center_middle">
			       <div id="user"><p>用  户:<asp:TextBox runat="server" ID="tb_username" CssClass="input"></asp:TextBox></p></div>
				   <div id="password"><p>密    码:<asp:TextBox runat="server" ID="tb_password" TextMode="Password" CssClass="input"></asp:TextBox></p></div>
                   <div id="authcode"><p>验证码:<asp:TextBox runat="server" ID="tb_authcode" CssClass="input_shot"></asp:TextBox><asp:Image runat="server" ID="img_authcode"/></p></div>
				   <div id="btn">
                      <asp:Button runat="server" ID="bt_login" Text="登录" CssClass="btn_a" 
                           onclick="bt_login_Click"/>
                      <asp:Button runat="server" ID="bt_reset" Text="重置" CssClass="btn_a" 
                           onclick="bt_reset_Click" />
                   </div>
			  </div>
			  <div id="center_right"></div>		 
		 </div>
		 <div id="down">
		      <div id="down_left">
			      <div id="inf">
                       <span class="inf_text">版本信息</span>
					   <span class="copyright">文章信息发布系统 2011 v1.0 Design By：level</span>
			      </div>
			  </div>
			  <div id="down_center"></div>		 
		 </div>
	</div>
    </form>
</body>
</html>
