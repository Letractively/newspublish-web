<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsType.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.NewsType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link type="text/css" rel="Stylesheet" href="../CSS/other.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <table cellpadding="0" cellspacing="1" border="0" id="table_content" class="table_content" width="100%">
           <tr>
              <td align="right" colspan="5">
                 <table cellpadding="0" cellspacing="0" border="0" id="tb_toolbar" class="table_toolbar">
                    <tr>
                       <td><img src="/ViewPage/Images/001.gif" width="14" height="14" alt=""/><a href="#">新增</a></td>
                       <td><img src="/ViewPage/Images/114.gif" width="14" height="14" alt=""/><a href="#">编辑</a></td>
                       <td><img src="/ViewPage/Images/083.gif" width="14" height="14" alt=""/><a href="#">删除</a></td>
                    </tr>
                 </table>
              </td>
           </tr>
           <tr id="tr_title">
              <td width="10px"><input type="checkbox" id="checkall"/></td>
              <td width="30px" style=" display:none">编号</td>
              <td align="center" width="20%">中文名称</td>
              <td align="center" width="20%">英文名称</td>
              <td align="center">备注</td>
           </tr>
           <asp:Repeater runat="server" ID="rp_content">
              <ItemTemplate>
                <tr id="tr_list">
                    <td><input type="checkbox" id="checkall"/></td>
                    <td style=" display:none"><%#DataBinder.Eval(Container.DataItem,"Id")%></td>
                    <td align="center"><%#DataBinder.Eval(Container.DataItem,"NewsTypeName_zh")%></td>
                    <td align="center"><%#DataBinder.Eval(Container.DataItem,"NewsTypeName_en")%></td>
                    <td align="center"><%#DataBinder.Eval(Container.DataItem,"NewsTypeRemark")%></td>
                </tr> 
              </ItemTemplate>
           </asp:Repeater>
           <tr>
              <td align="left" colspan="5">
                <table cellpadding="0" cellspacing="0" border="0" id="tb_pagebar" class="table_pagebar">
                   <tr>
                     <td>当前<asp:Label runat="server" ID="lb_pageindex"></asp:Label>页</td>
                     <td>每页<asp:Label runat="server" ID="lb_pagesize" Text="20"></asp:Label>条</td>
                     <td></td>
                     <td><asp:LinkButton runat="server" Text="首页" ID="lb_home"></asp:LinkButton></td>
                     <td><asp:LinkButton runat="server" Text="上一页" ID="lb_up"></asp:LinkButton></td>
                     <td><asp:LinkButton runat="server" Text="下一页" ID="lb_down"></asp:LinkButton></td>
                     <td><asp:LinkButton runat="server" Text="末页" ID="lb_end"></asp:LinkButton></td>
                     <td><asp:TextBox runat="server" ID="tb_pageindex" Text="1" Width="50px"></asp:TextBox></td>
                     <td><asp:Button runat="server" ID="bt_goto" Text="转到"/></td>
                   </tr>
                </table>
              </td>
           </tr>
        </table>
    </div>
    </form>
</body>
</html>
