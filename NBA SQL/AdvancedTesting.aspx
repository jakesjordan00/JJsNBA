<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdvancedTesting.aspx.cs" Inherits="NBA_SQL.AdvancedTesting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <asp:GridView ID="grdTest" runat="server" Visible="false"></asp:GridView>
    <asp:GridView ID="grdFirstQ" runat="server"         DataKeyNames="Player"                       OnRowDataBound="grdFirstQ_RowDataBound"  Width="300px"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#e03a3e"          AlternatingRowStyle-BackColor="#000000"     HeaderStyle-BorderColor="Black"             
                  RowStyle-BorderColor="#e03a3e"        AlternatingRowStyle-BorderColor="#000000" >

    </asp:GridView>
</asp:Content>
