<%@ Page Title="Shot Efficiency" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShotEfficiency.aspx.cs" Inherits="NBA_SQL.shotTesting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {background-color: black; color:white}
</style>
    <h1>
	Shot Efficiency
	</h1>
    
    
    <asp:DropDownList       
                     ID="ddTeams" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                     runat="server" DataKeyNames="Team" AutoPostBack="true" OnSelectedIndexChanged="ddTeams_SelectedIndexChanged"
                     Font-Size="Large" BackColor="White" ForeColor="Black"
    ></asp:DropDownList>
    <br />
    <asp:DropDownList 
        ID="ddlRoster" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4"  BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlRoster_SelectedIndexChanged">
        <asp:ListItem Text="Player" Value="" />
    </asp:DropDownList>

 <br />
    


    <div class="row" >   
        <div class="col-md-3">
			<asp:Label ID="Label1" runat="server" Text="Shots" Font-Size="X-Large" ForeColor="White" Width="290px"></asp:Label>
            <asp:GridView ID="grdShots" runat="server" ForeColor="White" Width="295px" ></asp:GridView>
        </div>
        <div class="col-md-4">
		    <asp:Label ID="Label2" runat="server" Text="1-5 Feet" Font-Size="X-Large" ForeColor="White" Width="395px"></asp:Label>
            <asp:GridView ID="grdShots1_10" runat="server" ForeColor="White" Width="395px"></asp:GridView>
        </div>
        <div class="col-md-4">
		    <asp:Label ID="Label3" runat="server" Text="5-10 Feet" Font-Size="X-Large" ForeColor="White" Width="395px"></asp:Label>
            <asp:GridView ID="grdShots10_30" runat="server" ForeColor="White" Width="450px"></asp:GridView>
        </div>
    </div>

    <br />

    <div class="row" >  
        <div class="col-md-3">
		    <asp:Label ID="Label4" runat="server" Text="10-23 Feet" Font-Size="X-Large" ForeColor="White" Width="290px"></asp:Label>
            <asp:GridView ID="grd10_23" runat="server" ForeColor="White" Width="295px"></asp:GridView>
        </div>
        <div class="col-md-4">
		    <asp:Label ID="Label5" runat="server" Text="3 Point Attempts" Font-Size="X-Large" ForeColor="White" Width="395px"></asp:Label>
            <asp:GridView ID="grd3" runat="server" ForeColor="White" Width="395px"></asp:GridView>
        </div>
    </div>
        <br />
</asp:Content>
