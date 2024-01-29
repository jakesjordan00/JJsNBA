<%@ Page MaintainScrollPositionOnPostback="true" Title="Teams" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="NBA_SQL.Teams" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {background-color: black; color:white}
    </style>
    <h1><asp:Image ID="Image1" Width="100px" Height="100px" runat="server" src="nba-logo.png"/>Teams</h1>
    <p>This page displays all 30 NBA teams and some relevant statistics.</p>

    <asp:Button class="btn btn-primary active" ID="btnTeams" runat="server" Text="Team Stats" OnClick="btnTeams_Click" />
    <asp:Button class="btn btn-primary active" ID="btnOteams" runat="server" Text="Opposition stats" OnClick="btnOteams_Click" />
<asp:GridView ID="grdTeams" runat="server" SortedAscendingHeaderStyle-ForeColor="White"
        DataKeyNames="Team" AllowSorting="true" OnSorting="grdTeams_Sorting" HeaderStyle-ForeColor="white" HeaderStyle-BorderColor="gray" HeaderStyle-BackColor="gray" 
        Width="1400px" AlternatingRowStyle-Width="300px" AlternatingRowStyle-BackColor="Gray" SelectedRowStyle-BackColor="Blue" RowStyle-BorderColor="black" AlternatingRowStyle-BorderColor="Gray"> 
        </asp:GridView>
<asp:GridView ID="grdOteams" runat="server"
        DataKeyNames="Team" AllowSorting="true" OnSorting="grdOteams_Sorting" HeaderStyle-ForeColor="white" HeaderStyle-BorderColor="black" RowStyle-BackColor="Gray"
        Width="1400px" AlternatingRowStyle-Width="300px" AlternatingRowStyle-BackColor="black" SelectedRowStyle-BackColor="Blue" RowStyle-BorderColor="Gray" AlternatingRowStyle-BorderColor="black">
        </asp:GridView>
</asp:Content>
