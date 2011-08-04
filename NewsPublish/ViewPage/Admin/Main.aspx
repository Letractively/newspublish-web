<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <%--<script type="text/javascript" src="../JS/jquery-1.6.2.min.js"></script>
  <link type="text/css" href="../CSS/main1.css" rel="Stylesheet" />--%>
  <title><asp:Literal runat="server" ID="lit_pagetitle"></asp:Literal></title>
</head>
<frameset rows="60,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" />
  <frameset  rows="*" cols="188,*" framespacing="0" frameborder="no" border="0" id="Frame">
    <frame src="Left.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" />
    <frameset rows="73,*" cols="*" id="rightFrame">
      <frame src="Right_Top.aspx" name="mainFrame" id="right_topFrame" />
      <frame src="SystemInfo.aspx" id="right_centerFrame"/>
    </frameset>
  </frameset>
</frameset>
<body>
  <%--<div id="main">
     <div id="top">
        <div id="top_logo"></div>
        <div id="top_info">欢迎您:admin  IP:192.168.0.124</div>
     </div>
     <div id="center">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
           <tr>
              <td width="188px" valign="top">
                 <div id="center_left">
                   <div id="center_left_img"></div>
                   <div id="center_left_menu">
                      <div id="center_left_menu_img">
                         <div id="basic"><img src="/ViewPage/Images/user.gif" alt="基本操作"/><a href="#">基本操作</a></div>
			             <div id="system"><img src="/ViewPage/Images/system.gif" alt="系统管理"/><a href="#">系统管理</a></div>
                      </div>
                      <div id="center_left_menu_basic">
                        <ul>
                          <li><a href="#" onclick="OpenPage('NewsType.aspx')">文章类型</a></li>
                          <li><a href="#">文章内容</a></li>
                          <li><a href="#">产品类别</a></li>
                          <li><a href="#">产品内容</a></li>
                        </ul>
                      </div>
                      <div id="center_left_menu_system">
                         <ul>
                            <li><a href="#">用户属性</a></li>  
                            <li><a href="#">修改密码</a> </li>    
					        <li><a href="#">用户查询</a></li>	   
                            <li><a href="#">数据统计</a></li>    
                            <li><a href="#">访问记录</a></li>      
                            <li><a href="#">操作日志</a></li>    
                         </ul>
                      </div>
                   </div>
                   <div id="center_left_bottom"></div>
                </div>
              </td>
              <td valign="top">
                 <div id="center_right">
                    <div id="center_right_top">
			           <div id="center_right_top_img"><img id="img_openorclose" src="/ViewPage/Images/close.gif" alt="打开/关闭左栏"/></div>
			           <div id="center_right_top_loginout">
			                <div id="center_right_top_loginout_img"><img src="/ViewPage/Images/loginout.gif" alt="退出系统" /></div>
			                <span><a href="#">退出系统</a></span>	 
			           </div>			   		
			           </div>
	                   <div id="right_font"><img src="/ViewPage/Images/main_14.gif" alt=""/> 您现在所在的位置：首页 → 用户信息 → <span class="bfont">操作日志</span></div>
                       <div id="right_iframe"><iframe id="center_right_iframe" frameborder="0" src="SystemInfo.aspx" width="100%" height="auto" scrolling="no"></iframe></div>
                </div>
              </td>
           </tr>
        </table>
     </div>
     <div id="bottom"></div>
  </div>--%>
</body>
</html>
