<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/ViewPage/CSS/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../JS/jquery-1.6.2.min.js"></script>
    <script type="text/jscript" language="javascript">
        $(document).ready(function () {
            $("#system>a").click(function () {
                $("#tree_basic").hide();
                $("#tree_icon").css("background-image", "url(/ViewPage/Images/main_12_2.gif)");
                $("#tree_system").show();
            });
            $("#basic>a").click(function () {
                $("#tree_system").hide();
                $("#tree_icon").css("background-image", "url(/ViewPage/Images/main_12.gif)");
                $("#tree_basic").show();
            });
            $(".tree_li > a").click(function () {
                var value = $(this).attr("id");
                if (value != null) {
                    var object = window.parent.document.getElementById("right_centerFrame");
                    object.getAttributeNode("src").value = value;
                }
            })
        })
        //在主窗口打开页面
        function OpenPage(pageName) {
            var object = window.parent.document.getElementById("right_centerFrame");
            object.getAttributeNode("src").value = value;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="left">
		       <div id="left_menu"></div>
			   <div id="left_tree">
			        <div id="tree_icon">
					   <div id="basic"><img src="/ViewPage/Images/user.gif" alt="基本操作"/><a href="#">基本操作</a></div>
					   <div id="system"><img src="/ViewPage/Images/system.gif" alt="系统管理"/><a href="#">系统管理</a></div>
					</div>
                    <div id="tree_basic">
					     <li class="tree_li">
                              <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#" onclick="OpenPage('NewsType.aspx')">文章类型</a> 
                              <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">文章内容</a>
                         </li>
						 <li class="tree_li">
                               <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">产品类型</a>  
                               <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">产品内容</a>
                         </li>
					</div>
					<div id="tree_system">
					     <li class="tree_li">
                                <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">用户属性</a>  
                                <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">修改密码</a> 
                         </li>
						 <li class="tree_li">
                                <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">用户查询</a>  
                                <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">数据统计</a>
                         </li>
						 <li class="tree_li">
                                <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">访问记录</a>  
                                <span class="list_img"><img src="/ViewPage/Images/list_img.gif" /></span><a href="#">操作日志</a>
                         </li>
					</div>
			   </div>
		<div id="tree_down"></div></div>
    </form>
</body>
</html>
