﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/ViewPage/CSS/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="left">
		       <div id="left_menu"></div>
			   <div id="left_tree">
			        <div id="tree_icon">
					   <div id="yh"><img src="/ViewPage/Images/user.gif" />用户信息</div>
					   <div id="system"><img src="/ViewPage/Images/system.gif" />系统管理</div>
					</div>
					<div id="tree_text">
					      <li class="tree_li"><span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span>用户属性 <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span>修改密码</li>
						 <li class="tree_li"><span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span>用户查询  <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span>数据统计</li>
						 <li class="tree_li"><span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span>访问记录  <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span>操作日志</li>
					</div>
			   </div>
		<div id="tree_down"></div></div>
    </form>
</body>
</html>
