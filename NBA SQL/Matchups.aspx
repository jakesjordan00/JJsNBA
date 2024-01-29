<%@ Page MaintainScrollPositionOnPostback="true" Title="Matchups" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Matchups.aspx.cs" Inherits="NBA_SQL.Matchups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {background-color: black; color:white}

        .test, .test1 {
            background-color: #265a88;
            border-radius: 15px;
            display: inline-block;
            width: 400px;
            text-align: center;
        }
    </style>

    <div>
	<h1>
	Matchups
	</h1>
        <h3>
            Matchup history researcher
        </h3>
        <p>
           This page is for researching two teams matchup history, but if the two specified teams have not played each other, nothing will be returned.<br />
           The results return each player that logged minutes for either team in each specific matchup.<br />
           The results are sorted by most recent games first.
        </p>
        <asp:Label ID="Label1" runat="server" Text="Team 1:" Width="245px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Team 2:  "></asp:Label>
        <br />

        <asp:DropDownList       
                            ID="ddTeams" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                            runat="server" DataKeyNames="Team" AutoPostBack="true" OnSelectedIndexChanged="ddTeams_SelectedIndexChanged" 
        ></asp:DropDownList>
        
        
        <asp:DropDownList       
                            ID="ddTeams2" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                            runat="server" DataKeyNames="Team" AutoPostBack="true" OnSelectedIndexChanged="ddTeams2_SelectedIndexChanged" 
        ></asp:DropDownList>
        <br />
        <asp:Button class="btn btn-primary active" ID="btnRetrieve" runat="server" Text="Retreive Matchup" OnClick="BtnRetrieve_Click" BackColor="Black" ForeColor="White" BorderColor="White"/> 
        <asp:Button class="btn btn-primary active" ID="btnMatchupHide" runat="server" Text="Hide" OnClick="btnMatchupHide_Click" BackColor="White" ForeColor="#000000" BorderColor="White"/> 
        <br />
        
        <asp:GridView ID="grdMatchup" runat="server"
            DataKeyNames="Team" AllowSorting="true" OnSorting="grdMatchup_Sorting" HeaderStyle-BackColor="gray" Width="1800px" HeaderStyle-ForeColor="White"
                RowStyle-BackColor="black" AlternatingRowStyle-BackColor="gray" HeaderStyle-BorderColor="gray" AlternatingRowStyle-BorderColor="gray" RowStyle-BorderColor="black">
        </asp:GridView>

        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

        <h3>
            Player specific matchup history
        </h3>
        <p>
           This tool is for researching two teams matchup history, but with only certain players' results returned.<br />
           The results return each player specified below that logged minutes for either team in each specific matchup.<br />
           The results are sorted by most recent games first. <br />
           Enter players to be selected below
        </p>
        <asp:Label ID="test" runat="server" Text=""  Font-Bold="true" Font-Size="X-Large" class="test" ></asp:Label>

        <asp:CheckBoxList ID="chkRoster" runat="server"    DataKeyNames="Player"  RepeatColumns="4" Width ="700px" BorderColor="#ba9653" class="form-check form-switch"  ></asp:CheckBoxList>

        <br />
        <asp:Label ID="test1" runat="server" Text=""  Font-Bold="true" Font-Size="X-Large" class="test1"></asp:Label>
        <asp:CheckBoxList ID="chkRoster2" runat="server"    DataKeyNames="Player"   RepeatColumns="4" Width ="700px" BorderColor="#ba9653" class="form-check form-switch" ></asp:CheckBoxList>

        <asp:Button class="btn btn-primary active" ID="btnPlayers" runat="server" Text="Retrieve" OnClick="BtnPlayers_Click" BackColor="Black" ForeColor="White" BorderColor="White"/> 
        <asp:Button class="btn btn-primary active" ID="btnPlayersHide" runat="server" Text="Hide" OnClick="btnPlayersHide_Click" BackColor="White" ForeColor="#000000" BorderColor="White"/>
        <asp:GridView ID="grdPlayers" runat="server"
            DataKeyNames="Team" AllowSorting="true" OnSorting="grdPlayers_Sorting" HeaderStyle-BackColor="gray" Width="1800px" HeaderStyle-ForeColor="White"
                RowStyle-BackColor="black" AlternatingRowStyle-BackColor="gray" HeaderStyle-BorderColor="gray" AlternatingRowStyle-BorderColor="gray" RowStyle-BorderColor="black">
        </asp:GridView>


        <h3>
            Player specific matchup history in Wins
        </h3>
        <p>
           This tool is for researching two teams matchup history, but with only certain players' results returned and only when that player's team won.<br />
           The results return each player specified above that logged minutes for either team in a win in the specified matchup.<br />
           The results are sorted by most recent games first.
        </p>
        <asp:Button class="btn btn-primary active" ID="btnPlayersMatchupWin" runat="server" Text="Retrieve" OnClick="BtnPlayersMatchupWin_Click" BackColor="Black" ForeColor="White" BorderColor="White"/> 
        <asp:Button class="btn btn-primary active" ID="btnPlayersMatchupWinHide" runat="server" Text="Hide" OnClick="btnPlayersMatchupWinHide_Click" BackColor="White" ForeColor="#000000" BorderColor="White"/>
        <asp:GridView ID="grdPlayersMatchupWin" runat="server"
            DataKeyNames="Team" AllowSorting="true" OnSorting="grdPlayersMatchupWin_Sorting" HeaderStyle-BackColor="gray" Width="1700px" HeaderStyle-ForeColor="White"
                RowStyle-BackColor="black" AlternatingRowStyle-BackColor="gray" HeaderStyle-BorderColor="gray" AlternatingRowStyle-BorderColor="gray" RowStyle-BorderColor="black">
        </asp:GridView>

    </div>
</asp:Content>
