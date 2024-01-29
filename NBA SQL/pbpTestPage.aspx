<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pbpTestPage.aspx.cs" Inherits="NBA_SQL.pbpTestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grdT" runat="server" ForeColor="White"></asp:GridView>
    <asp:GridView ID="grdEfficiency" runat="server" ForeColor="White" Width="1000px" AllowSorting="true"
        RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="Black"
        RowStyle-BackColor="#002b5c"          AlternatingRowStyle-BackColor="#e31837"     HeaderStyle-BorderColor="#c4ced4"             
        RowStyle-BorderColor="#002b5c"        AlternatingRowStyle-BorderColor="#e31837"  OnRowDataBound="grdEfficiency_RowDataBound">

    </asp:GridView>
</asp:Content>
