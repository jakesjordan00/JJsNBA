﻿<%@ Page MaintainScrollPositionOnPostback="true" Title="Hornets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hornets.aspx.cs" Inherits="NBA_SQL.Hornets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body_content">
    <style>
        body {background-color: Black}
    </style>
    <h1 style="color:#00788c"><asp:Image ID="Image1" Width="100px" Height="100px" runat="server" src="hornets-logo.png"/>(CHA)Charlotte Hornets</h1>
<%-- TO BE COPIED TO ALL OTHER TEAMS --%>
    <asp:GridView ID="grdTeam" runat="server" DataKeyNames="nickname" CssClass="RosterTable"  Width="1300px"  
     RowStyle-BackColor="#1d1160"  RowStyle-ForeColor="White" OnRowDataBound="grdTeam_RowDataBound"
     HeaderStyle-ForeColor="White" BorderColor="#1d1160" HeaderStyle-BorderColor="Black" AlternatingRowStyle-BorderColor="White">
    </asp:GridView>
   <br />
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Per Game Statistics" OnClick="BtnPG_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="btnW" runat="server" Text="Per Game in Win" OnClick="btnW_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    
        <asp:Button class="btn btn-primary active" ID="btnSeason" runat="server" Text="Season Statistics" OnClick="BtnSeason_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="btnPM" runat="server" Text="Per Minute Statistics" OnClick="BtnPM_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:GridView ID="grdHornetsPerMin" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdHornetsPerMin_Sorting" 
                  AlternatingRowStyle-BackColor="#00788c" RowStyle-BackColor="#1d1160" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                 HeaderStyle-BorderColor="#000000"
                                                                                                                                                 RowStyle-BorderColor="#1d1160"                                                                                                                                         
                                                                                                                                                 AlternatingRowStyle-BorderColor="#00788c">
    </asp:GridView>

    <asp:GridView ID="grdHornetsSeason" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdHornetsSeason_Sorting"
                  AlternatingRowStyle-BackColor="#00788c" RowStyle-BackColor="#1d1160" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                 HeaderStyle-BorderColor="#000000"
                                                                                                                                                 RowStyle-BorderColor="#1d1160"                                                                                                                                         
                                                                                                                                                 AlternatingRowStyle-BorderColor="#00788c">
    </asp:GridView>

    <asp:GridView ID="grdHornets" runat="server" OnSorting="grdHornets_Sorting"
            DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px"
             AlternatingRowStyle-BackColor="#00788c" RowStyle-BackColor="#1d1160" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                 HeaderStyle-BorderColor="#000000"
                                                                                                                                                 RowStyle-BorderColor="#1d1160"                                                                                                                                         
                                                                                                                                                 AlternatingRowStyle-BorderColor="#00788c">
    </asp:GridView>
    <asp:GridView ID="grdW" runat="server"         DataKeyNames="Player"               OnRowDataBound="grdW_RowDataBound"  Width="1300px" OnSorting="grdW_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >

    </asp:GridView>
    <h3 style="color:#00788c">Quarter Averages</h3>
    <asp:Button class="btn btn-primary active" ID="Button1" runat="server" Text="1st" OnClick="Button1_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="Button2" runat="server" Text="2nd" OnClick="Button2_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="Button3" runat="server" Text="3rd" OnClick="Button3_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="Button4" runat="server" Text="4th" OnClick="Button4_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />

    <asp:GridView ID="GridView1" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView1_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView2_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <asp:GridView ID="GridView3" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView3_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <asp:GridView ID="GridView4" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView4_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <br />
    <h3 style="color:#00788c">Quarter Game Logs</h3>
<div style="overflow-y: scroll;height: 200px; width:820px">
    <asp:GridView ID="GridView5" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView5_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <asp:GridView ID="GridView6" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView6_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <asp:GridView ID="GridView7" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView7_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
    <asp:GridView ID="GridView8" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView8_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#1d1160"          AlternatingRowStyle-BackColor="#00788c"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#1d1160"        AlternatingRowStyle-BorderColor="#00788c" >
    </asp:GridView>
</div>
    <h3 style="color:#00788c">
        Player box score history
    </h3>
    <p style="color:White">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in. <br />
        Whether the game is a win or a loss, the players' box score will be returned for each game played. <br />
        Enter as few or as many players as you would like. 
    </p>
                       <asp:CheckBoxList ID="chkRoster" runat="server" DataKeyNames="player_name"  RepeatColumns="4" Width="750px" ForeColor="White"></asp:CheckBoxList>    
     
    <asp:Button class="btn btn-primary active" ID="btnPlayerGames" runat="server" Text="Retrieve" OnClick="BtnPlayerGames_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="btnPlayerGamesHide" runat="server" Text="Hide" OnClick="BtnPlayerGamesHide_Click" BackColor="Black" ForeColor="#00788c" BorderColor="Black"/> 
            <asp:Label ID="lblPGError" runat="server" Text="" ForeColor="Red"></asp:Label><asp:GridView ID="grdPlayerGames" runat="server"  
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerGames_Sorting"
             AlternatingRowStyle-BackColor="#00788c" RowStyle-BackColor="#1d1160" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                 HeaderStyle-BorderColor="#1d1160"
                                                                                                                                                 RowStyle-BorderColor="#1d1160"                                                                                                                                         
                                                                                                                                                 AlternatingRowStyle-BorderColor="#00788c">
    </asp:GridView>
    


        <h3 style="color:#00788c">
            Player box score history in Wins
        </h3>
    <p style="color:White">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in that was a Win. <br />
        Enter as few or as many players as you would like.
    </p>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWins" runat="server" Text="Retrieve" OnClick="BtnPlayerWins_Click" BackColor="#00788c" ForeColor="White" BorderColor="#00788c" />
    <asp:Button class="btn btn-primary active" ID="btnPlayerWinsHide" runat="server" Text="Hide" OnClick="BtnPlayerWinsHide_Click" BackColor="Black" ForeColor="#00788c" BorderColor="Black"/> 
            <asp:Label ID="LabelError" runat="server" Text="" ForeColor="Red"></asp:Label> <br/><asp:GridView ID="grdPlayerWins" runat="server"
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerWins_Sorting"
            AlternatingRowStyle-BackColor="#00788c" RowStyle-BackColor="#1d1160" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="White"
                                                                                                                                                 HeaderStyle-BorderColor="#1d1160"
                                                                                                                                                 RowStyle-BorderColor="#1d1160"                                                                                                                                         
                                                                                                                                                 AlternatingRowStyle-BorderColor="#00788c">
    </asp:GridView>


    </div >
</asp:Content>