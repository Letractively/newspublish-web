<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <title><asp:Literal runat="server" ID="lit_pagetitle"></asp:Literal></title>
</head>
<frameset rows="60,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" />
  <frameset rows="*" cols="188,*" framespacing="0" frameborder="no" border="0">
    <frame src="Left.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" />
    <frameset rows="73,*" cols="*">
      <frame src="Right_Top.aspx" name="mainFrame" id="mainFrame" />
      <frame src="right.html" />
    </frameset>
  </frameset>
</frameset>
<noframes><body>
</body>
</noframes></html>
