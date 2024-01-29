<%@ Page MaintainScrollPositionOnPostback="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NBA_SQL._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {background-color: black; color:white}
    </style>
<h1>
JJ's NBA - Advanced Stats, Props and More
</h1>
    <div class="row md" style="width:1350px">
        <div class="col-lg-3">
            <h2>
                NBA Rankings
            </h2>
            
            <asp:GridView ID="grdEast" runat="server"
                DataKeyNames="Eastern Conference" Width="350px" ForeColor="white" HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true"
                RowStyle-BackColor="black" AlternatingRowStyle-BackColor="blue" HeaderStyle-BorderColor="White" AlternatingRowStyle-BorderColor="blue" RowStyle-BorderColor="black">
            </asp:GridView>
        </div>
        <div class="col-lg-4">
            <h2>
                &nbsp;
            </h2>
            <asp:GridView ID="grdWest" runat="server"
                DataKeyNames="Western Conference" Width="350px" HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true"
                RowStyle-BackColor="black" AlternatingRowStyle-BackColor="red" HeaderStyle-BorderColor="White" AlternatingRowStyle-BorderColor="red" RowStyle-BorderColor="black">
            </asp:GridView>
            </div>      
        <div class="col-lg-3">
            <h2>
                Yesterday's Games
            </h2> 
            <asp:GridView ID="grdYesterday" runat="server"
                DataKeyNames="Matchup" Width="400px" HeaderStyle-BackColor="gray"
                RowStyle-BackColor="black" AlternatingRowStyle-BackColor="gray" HeaderStyle-BorderColor="gray" AlternatingRowStyle-BorderColor="gray" RowStyle-BorderColor="black">
            </asp:GridView>
        </div>
   </div>
</asp:Content>
