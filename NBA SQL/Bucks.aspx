<%@ Page MaintainScrollPositionOnPostback="true" Title="Bucks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bucks.aspx.cs" Inherits="NBA_SQL.Bucks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="body_content">
    <style>
        body {background-color: #eee1c6}
    </style>
    <h1 style="color:#00471b"><asp:Image ID="Image1" Width="100px" Height="100px" runat="server" src="Bucks-logo.png"/>(MIL)Milwaukee Bucks</h1>

<%-- TO BE COPIED TO ALL OTHER TEAMS --%>
    <asp:GridView ID="grdTeam" runat="server" DataKeyNames="nickname" CssClass="RosterTable"  Width="1300px"  
     RowStyle-BackColor="#00471b"  RowStyle-ForeColor="#eee1c6" OnRowDataBound="grdTeam_RowDataBound"  RowStyle-BorderColor="#00471b"
     HeaderStyle-ForeColor="Black" BorderColor="White" HeaderStyle-BorderColor="#eee1c6" AlternatingRowStyle-BorderColor="#00471b">
    </asp:GridView>
   <br />
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Per Game Statistics" OnClick="BtnPG_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0"/>
    <asp:Button class="btn btn-primary active" ID="btnW" runat="server" Text="Per Game in Win" OnClick="btnW_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0"/>
    <asp:Button class="btn btn-primary active" ID="btnSeason" runat="server" Text="Season Statistics" OnClick="BtnSeason_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0" />
    <asp:Button class="btn btn-primary active" ID="btnPM" runat="server" Text="Per Minute Statistics" OnClick="BtnPM_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0" />
    <asp:GridView ID="grdBucksPerMin" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdBucksPerMin_Sorting" 
                  AlternatingRowStyle-BackColor="#eee1c6" RowStyle-BackColor="#00471b" RowStyle-ForeColor="#eee1c6" AlternatingRowStyle-ForeColor="#00471b" HeaderStyle-ForeColor="#00471b" BorderColor="#00471b" 
                                                                                                                                                   HeaderStyle-BorderColor="#eee1c6"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#eee1c6">
    </asp:GridView>

    <asp:GridView ID="grdBucksSeason" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdBucksSeason_Sorting"
                  AlternatingRowStyle-BackColor="#eee1c6" RowStyle-BackColor="#00471b" RowStyle-ForeColor="#eee1c6" AlternatingRowStyle-ForeColor="#00471b" HeaderStyle-ForeColor="#00471b" BorderColor="#00471b" 
                                                                                                                                                   HeaderStyle-BorderColor="#eee1c6"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#eee1c6">
    </asp:GridView>
    <asp:GridView ID="grdBucks" runat="server" OnSorting="grdBucks_Sorting"
            DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px"


             AlternatingRowStyle-BackColor="#eee1c6" RowStyle-BackColor="#00471b" RowStyle-ForeColor="#eee1c6" AlternatingRowStyle-ForeColor="#00471b" HeaderStyle-ForeColor="#00471b" BorderColor="#00471b" 
                                                                                                                                                   HeaderStyle-BorderColor="#eee1c6"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#eee1c6">
    </asp:GridView>
    <asp:GridView ID="grdW" runat="server"         DataKeyNames="Player"               OnRowDataBound="grdW_RowDataBound"  Width="1300px" OnSorting="grdW_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >

    </asp:GridView>
    <h3 style="color:#00471b">Quarter Averages</h3>
    <asp:Button class="btn btn-primary active" ID="Button1" runat="server" Text="1st" OnClick="Button1_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0"/>
    <asp:Button class="btn btn-primary active" ID="Button2" runat="server" Text="2nd" OnClick="Button2_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0"/>
    <asp:Button class="btn btn-primary active" ID="Button3" runat="server" Text="3rd" OnClick="Button3_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0"/>
    <asp:Button class="btn btn-primary active" ID="Button4" runat="server" Text="4th" OnClick="Button4_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0"/>

    <asp:GridView ID="GridView1" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView1_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView2_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <asp:GridView ID="GridView3" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView3_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <asp:GridView ID="GridView4" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView4_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <br />
    <h3 style="color:#002b5c">Quarter Game Logs</h3>
<div style="overflow-y: scroll;height: 200px; width:820px">
    <asp:GridView ID="GridView5" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView5_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <asp:GridView ID="GridView6" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView6_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <asp:GridView ID="GridView7" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView7_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b"
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
    <asp:GridView ID="GridView8" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView8_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="#eee1c6"          AlternatingRowStyle-ForeColor="#00471b"     HeaderStyle-ForeColor="#00471b" 
                  RowStyle-BackColor="#00471b"          AlternatingRowStyle-BackColor="#eee1c6"     HeaderStyle-BorderColor="#eee1c6"             
                  RowStyle-BorderColor="#00471b"        AlternatingRowStyle-BorderColor="#eee1c6" >
    </asp:GridView>
</div>
    <h3 style="color:#00471b">
        Player box score history
    </h3>
    <p style="color:#00471b">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in. <br />
        Whether the game is a win or a loss, the players' box score will be returned for each game played. <br />
        Enter as few or as many players as you would like. 
    </p>
        <asp:CheckBoxList ID="chkRoster" runat="server" DataKeyNames="player_name"  RepeatColumns="5" Width="1000px" ForeColor="#002b5c"></asp:CheckBoxList>    
    <asp:Button class="btn btn-primary active" ID="btnPlayerGames" runat="server" Text="Retrieve" OnClick="BtnPlayerGames_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0" />
    <asp:Button class="btn btn-primary active" ID="btnPlayerGamesHide" runat="server" Text="Hide" OnClick="BtnPlayerGamesHide_Click" BackColor="#eee1c6" ForeColor="#0077c0" BorderColor="#eee1c6"  /> 
    <asp:Label ID="lblPGError" runat="server" Text="" ForeColor="Red"></asp:Label><asp:GridView ID="grdPlayerGames" runat="server"  
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerGames_Sorting"
             AlternatingRowStyle-BackColor="#eee1c6" RowStyle-BackColor="#00471b" RowStyle-ForeColor="#eee1c6" AlternatingRowStyle-ForeColor="#00471b" HeaderStyle-ForeColor="#00471b" BorderColor="#00471b" 
                                                                                                                                                   HeaderStyle-BorderColor="#00471b"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#eee1c6">
    </asp:GridView>
    


        <h3 style="color:#00471b">
            Player box score history in Wins
        </h3>
    <p style="color:#00471b">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in that was a Win. <br />
        Enter as few or as many players as you would like.
    </p>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWins" runat="server" Text="Retrieve" OnClick="BtnPlayerWins_Click" BackColor="#0077c0" ForeColor="#eee1c6" BorderColor="#0077c0" />
    <asp:Button class="btn btn-primary active" ID="btnPlayerWinsHide" runat="server" Text="Hide" OnClick="BtnPlayerWinsHide_Click" BackColor="#eee1c6" ForeColor="#0077c0" BorderColor="#eee1c6"/>
        <asp:Label ID="LabelError" runat="server" Text="" ForeColor="Red"></asp:Label> <br/><asp:GridView ID="grdPlayerWins" runat="server"
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerWins_Sorting"
            AlternatingRowStyle-BackColor="#eee1c6" RowStyle-BackColor="#00471b" RowStyle-ForeColor="#eee1c6" AlternatingRowStyle-ForeColor="#00471b" HeaderStyle-ForeColor="#00471b" BorderColor="#00471b" 
                                                                                                                                                   HeaderStyle-BorderColor="#00471b"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#eee1c6">
    </asp:GridView>


    </div >
</asp:Content>
