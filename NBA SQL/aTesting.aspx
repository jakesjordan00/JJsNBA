<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aTesting.aspx.cs" Inherits="NBA_SQL.aTesting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView ID="grdTest" runat="server" ForeColor="White" Width="1200px" OnRowDataBound="grdTest_RowDataBound"></asp:GridView>
</asp:Content>
