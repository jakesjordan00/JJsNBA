<%@ Page MaintainScrollPositionOnPostback="true" Title="Celtics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Celtics.aspx.cs" Inherits="NBA_SQL.Celtics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="body_content">
    <style>
        body {background-color: Black}
    </style>
    <h1 style="color:#007a33"><asp:Image ID="Image1" Width="100px" Height="100px" runat="server" src="Celtics-logo.png"/>(BOS)Boston Celtics</h1>
<%-- TO BE COPIED TO ALL OTHER TEAMS --%>
    <asp:GridView ID="grdTeam" runat="server" DataKeyNames="nickname" CssClass="RosterTable"  Width="1300px"  
     RowStyle-BackColor="#007a33"  RowStyle-ForeColor="white" OnRowDataBound="grdTeam_RowDataBound" 
     HeaderStyle-ForeColor="white" BorderColor="#007a33" HeaderStyle-BorderColor="black" AlternatingRowStyle-BorderColor="White">
    </asp:GridView>
   <br />
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Per Game Statistics" OnClick="BtnPG_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="btnW" runat="server" Text="Per Game in Win" OnClick="btnW_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="btnSeason" runat="server" Text="Season Statistics" OnClick="BtnSeason_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="btnPM" runat="server" Text="Per Minute Statistics" OnClick="BtnPM_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:GridView ID="grdCelticsPerMin" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdCelticsPerMin_Sorting" 
                  AlternatingRowStyle-BackColor="White" RowStyle-BackColor="#007a33" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="#007a33"
                  HeaderStyle-ForeColor="White" BorderColor="#007a33" 
                                                                                                                                                   HeaderStyle-BorderColor="Black"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="White">
    </asp:GridView>

    <asp:GridView ID="grdCelticsSeason" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdCelticsSeason_Sorting"
                  AlternatingRowStyle-BackColor="White" RowStyle-BackColor="#007a33" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="#007a33"
                  HeaderStyle-ForeColor="White" BorderColor="#007a33" 
                                                                                                                                                   HeaderStyle-BorderColor="Black"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="White">
    </asp:GridView>

    <asp:GridView ID="grdCeltics" runat="server" OnSorting="grdCeltics_Sorting"
            DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px"
             AlternatingRowStyle-BackColor="White" RowStyle-BackColor="#007a33" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="#007a33"
                  HeaderStyle-ForeColor="White" BorderColor="#007a33" 
                                                                                                                                                   HeaderStyle-BorderColor="Black"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="White">
    </asp:GridView>
 <asp:GridView ID="grdW" runat="server"         DataKeyNames="Player"               OnRowDataBound="grdW_RowDataBound"  Width="1300px" OnSorting="grdW_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >

    </asp:GridView>
    <h3 style="color:#007a33">Quarter Averages</h3>
    <asp:Button class="btn btn-primary active" ID="Button1" runat="server" Text="1st" OnClick="Button1_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="Button2" runat="server" Text="2nd" OnClick="Button2_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="Button3" runat="server" Text="3rd" OnClick="Button3_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="Button4" runat="server" Text="4th" OnClick="Button4_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />

    <asp:GridView ID="GridView1" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView1_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView2_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <asp:GridView ID="GridView3" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView3_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <asp:GridView ID="GridView4" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView4_Sorting" AllowSorting="true"
                 RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <br />
    <h3 style="color:#007a33">Quarter Game Logs</h3>
<div style="overflow-y: scroll;height: 200px; width:820px">
    <asp:GridView ID="GridView5" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView5_Sorting" AllowSorting="true"
                 RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <asp:GridView ID="GridView6" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView6_Sorting" AllowSorting="true"
                 RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <asp:GridView ID="GridView7" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView7_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
    <asp:GridView ID="GridView8" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView8_Sorting" AllowSorting="true"
                 RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="#007a33"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#007a33"          AlternatingRowStyle-BackColor="White"     HeaderStyle-BorderColor="#000000"             
                  RowStyle-BorderColor="#007a33"        AlternatingRowStyle-BorderColor="White" >
    </asp:GridView>
</div>
      <h3 style="color:#ba9653">
        Player box score history
    </h3>
    <p style="color:#007a33">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in. <br />
        Whether the game is a win or a loss, the players' box score will be returned for each game played. <br />
        Enter as few or as many players as you would like. 
    </p>
              <asp:CheckBoxList ID="chkRoster" runat="server" DataKeyNames="player_name"  RepeatColumns="4" Width="600px" ForeColor="#007a33"></asp:CheckBoxList>    
    
    <asp:Button class="btn btn-primary active" ID="btnPlayerGames" runat="server" Text="Retrieve" OnClick="BtnPlayerGames_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653"/>
    <asp:Button class="btn btn-primary active" ID="btnPlayerGamesHide" runat="server" Text="Hide" OnClick="BtnPlayerGamesHide_Click" BackColor="Black" ForeColor="White" BorderColor="Black"/> 
        <asp:Label ID="lblPGError" runat="server" Text="" ForeColor="Red"></asp:Label><asp:GridView ID="grdPlayerGames" runat="server"  
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerGames_Sorting"
            AlternatingRowStyle-BackColor="White" RowStyle-BackColor="#007a33" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="#007a33"
                  HeaderStyle-ForeColor="White" BorderColor="#007a33" 
                                                                                                                                                   HeaderStyle-BorderColor="Black"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="White">
    </asp:GridView>
    


        <h3 style="color:#ba9653">
            Player box score history in Wins
        </h3>
    <p style="color:#007a33">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in that was a Win. <br />
        Enter as few or as many players as you would like.
    </p>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWins" runat="server" Text="Retrieve" OnClick="BtnPlayerWins_Click" BackColor="#007a33" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="btnPlayerWinsHide" runat="server" Text="Hide" OnClick="BtnPlayerWinsHide_Click" BackColor="Black" ForeColor="White" BorderColor="Black"/> 
        <asp:Label ID="LabelError" runat="server" Text="" ForeColor="Red"></asp:Label> <br/><asp:GridView ID="grdPlayerWins" runat="server"
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerWins_Sorting"
            AlternatingRowStyle-BackColor="White" RowStyle-BackColor="#007a33" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="#007a33"
                  HeaderStyle-ForeColor="White" BorderColor="#007a33" 
                                                                                                                                                   HeaderStyle-BorderColor="Black"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="White">
    </asp:GridView>


    </div >
</asp:Content>

