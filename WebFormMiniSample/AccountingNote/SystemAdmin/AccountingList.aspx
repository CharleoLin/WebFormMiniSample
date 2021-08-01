﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdimin.AccountingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>            
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a herf="UserInfo.aspx">使用者資訊</a><br />
                    <a herf="AccountingList.aspx">流水帳管理</a>
                </td>
                <td>
                   <%-- 這裡放主要內容--%>
                    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
                    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False">  
                        <Columns>
                            <asp:BoundField HeaderText="標題" DataField="Caption" />
                            <asp:BoundField HeaderText="金額" DataField="Amount" />
                            <asp:TemplateField HeaderText="In/Out">
                                <ItemTemplate>
                                    <%-- %><%# ((int)Eval("ActType") == 0)? "支出" : "收入"  %>--%>
                                    <%--<asp:Literal ID="ltActType" runat="server"></asp:Literal>--%>
                                    <asp:Label ID="lblActType" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd-}" />
                            <asp:TemplateField HeaderText="Act">
                                <InsertItemTemplate>
                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </InsertItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red; background-color:cornflowerblue">
                            No Data in your Accounting Note.
                        </p>
                    </asp:PlaceHolder>                        
                </td>     
            </tr>
          </table>
    </form>
</body>
</html>
