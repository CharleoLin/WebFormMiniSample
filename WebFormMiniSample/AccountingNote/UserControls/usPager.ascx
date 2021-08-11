<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usPager.ascx.cs" Inherits="AccountingNote.UserControls.usPager" %>
<div>
    <%--<a herf="#">First</a> &nbsp;
    <a herf="#">Prev</a> &nbsp;--%>

    <a runat="server" id="aLinkPage1" herf="#">1</a> &nbsp;
    <a runat="server" id="aLinkPage2" herf="#">2</a> &nbsp;
    <a runat="server" id="aLinkPage3" herf="#">3</a> &nbsp;
    <a runat="server" id="aLinkPage4" herf="#">3</a> &nbsp;
    <a runat="server" id="aLinkPage5" herf="#">3</a> &nbsp;

    <asp:Literal runat="server" ID="ltPager"></asp:Literal>
        <%--<a herf="#">Next</a> &nbsp;
    <a herf="#">Last</a> &nbsp;--%>

</div>