<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsType.aspx.cs" Inherits="NewsPublish.ViewPage.Admin.NewsType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:CheckBoxField HeaderText="选择" />
                <asp:BoundField DataField="Id" HeaderText="编号" Visible="False" />
                <asp:BoundField DataField="NewsTypeName_zh" HeaderText="中文类别" />
                <asp:BoundField DataField="NewsTypeName_en" HeaderText="英文类别" />
                <asp:BoundField DataField="NewsTypeRemark" HeaderText="备注" />
            </Columns>
            <EmptyDataTemplate>
                &lt;H1&gt;暂时没有任何记录&lt;/H1&gt;
            </EmptyDataTemplate>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <PagerTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="29" nowrap="nowrap" width="25%">
                            <table border="0" cellpadding="0" cellspacing="0" width="342">
                                <tr>
                                    <td class="STYLE1" width="44%">
                                        当前页：1/2页 每页 
                                        <input class="STYLE1" name="textfield2" size="5" 
                            style="height:14px; width:25px;" type="text" value="15" />
                                    </td>
                                    <td class="STYLE1" width="14%">
                                        <img height="20" src="/ViewPage/Images/sz.gif" 
                            width="43" />
                                    </td>
                                    <td class="STYLE1" width="42%">
                                        <span class="STYLE7">数据总量 15 </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="STYLE1" valign="top" width="75%">
                            <div align="right">
                                <table border="0" cellpadding="0" cellspacing="0" height="20" width="352">
                                    <tr>
                                        <td height="22" valign="middle" width="62">
                                            <div align="right">
                                                <img height="20" src="/ViewPage/Images/page_first_1.gif" 
                                    width="48" />
                                            </div>
                                        </td>
                                        <td height="22" valign="middle" width="50">
                                            <div align="right">
                                                <img height="20" src="/ViewPage/Images/page_back_1.gif" 
                                    width="55" />
                                            </div>
                                        </td>
                                        <td height="22" valign="middle" width="54">
                                            <div align="right">
                                                <img height="20" src="/ViewPage/Images/page_next.gif" 
                                    width="58" />
                                            </div>
                                        </td>
                                        <td height="22" valign="middle" width="49">
                                            <div align="right">
                                                <img height="20" src="/ViewPage/Images/page_last.gif" 
                                    width="52" />
                                            </div>
                                        </td>
                                        <td height="22" valign="middle" width="59">
                                            <div align="right">
                                                转到第</div>
                                        </td>
                                        <td height="22" valign="middle" width="25">
                                            <span class="STYLE7">
                                            <input class="STYLE1" name="textfield" size="5" 
                                style="height:10px; width:25px;" type="text" />
                                            </span>
                                        </td>
                                        <td height="22" valign="middle" width="23">
                                            页</td>
                                        <td height="22" valign="middle" width="30">
                                            <img height="20" src="/ViewPage/Images/go.gif" 
                                width="26" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
