<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pbpQ1.aspx.cs" Inherits="NBA_SQL.pbpQ1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="grdT" runat="server" ForeColor="White"></asp:GridView>
    <asp:GridView ID="grdAvg" runat="server"  Width="1000px" AllowSorting="true" OnRowDataBound="grdAvg_RowDataBound"
        RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="Black"
        RowStyle-BackColor="#002b5c"          AlternatingRowStyle-BackColor="#e31837"     HeaderStyle-BorderColor="#c4ced4"             
        RowStyle-BorderColor="#002b5c"        AlternatingRowStyle-BorderColor="#e31837"   ForeColor="White" >
    </asp:GridView>
    <asp:GridView ID="grdGames" runat="server"  Width="1000px" AllowSorting="true" OnRowDataBound="grdGames_RowDataBound"
        RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="Black"
        RowStyle-BackColor="#002b5c"          AlternatingRowStyle-BackColor="#e31837"     HeaderStyle-BorderColor="#c4ced4"             
        RowStyle-BorderColor="#002b5c"        AlternatingRowStyle-BorderColor="#e31837"   ForeColor="White" >
    </asp:GridView>
</asp:Content>
