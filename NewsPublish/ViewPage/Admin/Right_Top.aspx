<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Right_Top.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.Right_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/ViewPage/CSS/main.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="../JS/jquery-1.6.2.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#img").click(function () {
                var object = window.parent.document.getElementById("Frame");
                var value = object.getAttributeNode("cols").value;
                if (value == "188,*") {
                    object.getAttributeNode("cols").value = "0,*";
                    document.getElementById("img_openorclose").getAttributeNode("src").value = "/ViewPage/Images/open.gif";
                } else {
                    object.getAttributeNode("cols").value = "188,*";
                    document.getElementById("img_openorclose").getAttributeNode("src").value = "/ViewPage/Images/close.gif";
                }
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="right_top">
			   <div id="img"><img id="img_openorclose" src="/ViewPage/Images/close.gif" alt="打开/关闭左栏"/></div>
			   <div id="loginout">
			        <div id="loginoutimg"><img src="/ViewPage/Images/loginout.gif" alt="退出系统" /></div>
			        <span class="logintext"><a href="#">退出系统</a></span>	 
			   </div>			   		
			   </div>
			   <div id="right_font"><img src="/ViewPage/Images/main_14.gif"/> 您现在所在的位置：首页 → 用户信息 → <span class="bfont">操作日志</span></div>
    </form>
</body>
</html>
