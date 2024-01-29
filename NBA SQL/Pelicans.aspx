<%@ Page MaintainScrollPositionOnPostback="true" Title="Pelicans" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pelicans.aspx.cs" Inherits="NBA_SQL.Pelicans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        body {background-color: Black}
    </style>
    <div class="row">
        <div class="col-lg-6">
            <h1 style="color:White"><asp:Image ID="Image1" Width="100px" Height="100px" runat="server" src="pelicans-logo.png"/>(NOP)New Orleans Pelicans</h1>
        </div>
        <div class="col-lg-1">
            
        </div>
    </div>
        
    
    
<%-- TO BE COPIED TO ALL OTHER TEAMS --%>
    <asp:GridView ID="grdTeam" runat="server" DataKeyNames="nickname" CssClass="RosterTable"  Width="1300px"  
     RowStyle-BackColor="#002a5c"  RowStyle-ForeColor="#b5985a" OnRowDataBound="grdTeam_RowDataBound"  RowStyle-BorderColor="#002a5c"
     HeaderStyle-ForeColor="White" BorderColor="White" HeaderStyle-BorderColor="Black" AlternatingRowStyle-BorderColor="White">
    </asp:GridView>
   <br />
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Per Game Statistics" OnClick="BtnPG_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
        <asp:Button class="btn btn-primary active" ID="btnW" runat="server" Text="Per Game in Win" OnClick="btnW_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
    <asp:Button class="btn btn-primary active" ID="btnSeason" runat="server" Text="Season Statistics" OnClick="BtnSeason_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
    <asp:Button class="btn btn-primary active" ID="btnPM" runat="server" Text="Per Minute Statistics" OnClick="BtnPM_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
    <asp:GridView ID="grdPelicansPerMin" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdPelicansPerMin_Sorting" 
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>

    <asp:GridView ID="grdPelicansSeason" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdPelicansSeason_Sorting"
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>

    <asp:GridView ID="grdPelicans" runat="server" OnSorting="grdPelicans_Sorting"
            DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px"
        AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="grdW" runat="server"         DataKeyNames="Player"               OnRowDataBound="grdW_RowDataBound"  Width="1300px" OnSorting="grdW_Sorting" AllowSorting="true"
                   AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">

    </asp:GridView>
    <h3 style="color:#C8102E">Quarter Averages</h3>
    <asp:Button class="btn btn-primary active" ID="Button1" runat="server" Text="1st" OnClick="Button1_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
    <asp:Button class="btn btn-primary active" ID="Button2" runat="server" Text="2nd" OnClick="Button2_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
    <asp:Button class="btn btn-primary active" ID="Button3" runat="server" Text="3rd" OnClick="Button3_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>
    <asp:Button class="btn btn-primary active" ID="Button4" runat="server" Text="4th" OnClick="Button4_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="Black"/>

    <asp:GridView ID="GridView1" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView1_Sorting" AllowSorting="true" 
                            AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView2_Sorting" AllowSorting="true"
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="GridView3" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView3_Sorting" AllowSorting="true" 
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="GridView4" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView4_Sorting" AllowSorting="true"
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <br />
    <h3 style="color:#C8102E">Quarter Game Logs</h3>
<div style="overflow-y: scroll;height: 200px; width:820px">
    <asp:GridView ID="GridView5" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView5_Sorting" AllowSorting="true"
                AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="GridView6" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView6_Sorting" AllowSorting="true"
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="GridView7" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView7_Sorting" AllowSorting="true"
                  AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    <asp:GridView ID="GridView8" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView8_Sorting" AllowSorting="true"
                AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="Black"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
</div>
    <h3 style="color:#C8102E">
        Player box score history
    </h3>
    <p style="color:#b5985a">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in. <br />
        Whether the game is a win or a loss, the players' box score will be returned for each game played. <br />
        Enter as few or as many players as you would like. 
    </p>
                        <asp:CheckBoxList ID="chkRoster" runat="server" DataKeyNames="player_name"  RepeatColumns="5" Width="750px" ForeColor="White"></asp:CheckBoxList>    
     
    <asp:Button class="btn btn-primary active" ID="btnPlayerGames" runat="server" Text="Retrieve" OnClick="BtnPlayerGames_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="#b5985a"/>
    <asp:Button class="btn btn-primary active" ID="btnPlayerGamesHide" runat="server" Text="Hide" OnClick="BtnPlayerGamesHide_Click" ForeColor="#b5985a" BackColor="Black" BorderColor="Black"/> 
    <asp:Label ID="lblPGError" runat="server" Text="" ForeColor="Red"></asp:Label><asp:GridView ID="grdPlayerGames" runat="server" 
            DataKeyNames="Matchup" AllowSorting="true" OnSorting="grdPlayerGames_Sorting"
            CssClass="WideTable" Width="1800px" AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="#C8102E"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>
    


        <h3 style="color:#C8102E">
            Player box score history in Wins
        </h3>
    <p style="color:#b5985a">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in that was a Win. <br />
        Enter as few or as many players as you would like.
    </p>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWins" runat="server" Text="Retrieve" OnClick="BtnPlayerWins_Click" ForeColor="#002a5c" BackColor="#b5985a" BorderColor="#b5985a"/>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWinsHide" runat="server" Text="Hide" OnClick="BtnPlayerWinsHide_Click" ForeColor="#b5985a" BackColor="Black" BorderColor="Black"/>
    <asp:Label ID="LabelError" runat="server" Text="" ForeColor="Red"></asp:Label> <br/><asp:GridView ID="grdPlayerWins" runat="server"
            DataKeyNames="Matchup" AllowSorting="true" OnSorting="grdPlayerWins_Sorting"
            CssClass="WideTable" Width="1800px" AlternatingRowStyle-BackColor="#b5985a" RowStyle-BackColor="#002a5c" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                   HeaderStyle-BorderColor="#C8102E"
                                                                                                                                                   RowStyle-BorderColor="#002a5c"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#b5985a">
    </asp:GridView>

 
    
</asp:Content>
