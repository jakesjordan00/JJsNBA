<%@ Page MaintainScrollPositionOnPostback="true" Title="Grizzlies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grizzlies.aspx.cs" Inherits="NBA_SQL.Grizzlies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="body_content">
    <style>
        body {background-color: #707271}
    </style>
    <h1 style="color:#12173f"><asp:Image ID="Image1" Width="100px" Height="100px" runat="server" src="Grizzlies-logo.png"/>(MEM)Memphis Grizzlies</h1>
<%-- TO BE COPIED TO ALL OTHER TEAMS --%>
    <asp:GridView ID="grdTeam" runat="server" DataKeyNames="nickname" CssClass="RosterTable"  Width="1300px"  
     RowStyle-BackColor="#12173f"  RowStyle-ForeColor="#5d76a9" OnRowDataBound="grdTeam_RowDataBound"  RowStyle-BorderColor="#12173f"
     HeaderStyle-ForeColor="White" BorderColor="White" HeaderStyle-BorderColor="#707271" AlternatingRowStyle-BorderColor="#12173f">
    </asp:GridView>
   <br />
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Per Game Statistics" OnClick="BtnPG_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="btnW" runat="server" Text="Per Game in Win" OnClick="btnW_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="btnSeason" runat="server" Text="Season Statistics" OnClick="BtnSeason_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="btnPM" runat="server" Text="Per Minute Statistics" OnClick="BtnPM_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:GridView ID="grdGrizzliesPerMin" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdGrizzliesPerMin_Sorting" 
                  AlternatingRowStyle-BackColor="#12173f" RowStyle-BackColor="#5d76a9" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="white"
                                                                                                                                                   HeaderStyle-BorderColor="#707271"
                                                                                                                                                   RowStyle-BorderColor="#5d76a9"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#12173f">
    </asp:GridView>

    <asp:GridView ID="grdGrizzliesSeason" runat="server" DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px" OnSorting="grdGrizzliesSeason_Sorting"
                  AlternatingRowStyle-BackColor="#12173f" RowStyle-BackColor="#5d76a9" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="white"
                                                                                                                                                   HeaderStyle-BorderColor="#707271"
                                                                                                                                                   RowStyle-BorderColor="#5d76a9"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#12173f">
    </asp:GridView>

    <asp:GridView ID="grdGrizzlies" runat="server" OnSorting="grdGrizzlies_Sorting"
            DataKeyNames="Roster" AllowSorting="true" CssClass="RosterTable"  Width="1300px" Height="350px"
             AlternatingRowStyle-BackColor="#12173f" RowStyle-BackColor="#5d76a9" RowStyle-ForeColor="White" AlternatingRowStyle-ForeColor="White" HeaderStyle-ForeColor="white"
                                                                                                                                                   HeaderStyle-BorderColor="#707271"
                                                                                                                                                   RowStyle-BorderColor="#5d76a9"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#12173f">
    </asp:GridView>
    <asp:GridView ID="grdW" runat="server"         DataKeyNames="Player"               OnRowDataBound="grdW_RowDataBound"  Width="1300px" OnSorting="grdW_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >

    </asp:GridView>
    <h3 style="color:#12173f">Quarter Averages</h3>
    <asp:Button class="btn btn-primary active" ID="Button1" runat="server" Text="1st" OnClick="Button1_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="Button2" runat="server" Text="2nd" OnClick="Button2_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="Button3" runat="server" Text="3rd" OnClick="Button3_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="Button4" runat="server" Text="4th" OnClick="Button4_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>

    <asp:GridView ID="GridView1" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView1_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView2_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <asp:GridView ID="GridView3" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView3_Sorting" AllowSorting="true" 
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <asp:GridView ID="GridView4" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView4_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <br />
    <h3 style="color:#12173f">Quarter Game Logs</h3>
<div style="overflow-y: scroll;height: 200px; width:820px">
    <asp:GridView ID="GridView5" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView5_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <asp:GridView ID="GridView6" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView6_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <asp:GridView ID="GridView7" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView7_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
    <asp:GridView ID="GridView8" runat="server"         DataKeyNames="Player" Width="800px"        OnSorting="GridView8_Sorting" AllowSorting="true"
                  RowStyle-ForeColor="White"            AlternatingRowStyle-ForeColor="White"       HeaderStyle-ForeColor="White"
                  RowStyle-BackColor="#5d76a9"          AlternatingRowStyle-BackColor="#12173f"     HeaderStyle-BorderColor="#707271"             
                  RowStyle-BorderColor="#5d76a9"        AlternatingRowStyle-BorderColor="#12173f" >
    </asp:GridView>
</div>
    <h3 style="color:#12173f">
        Player box score history
    </h3>
    <p style="color:#12173f">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in. <br />
        Whether the game is a win or a loss, the players' box score will be returned for each game played. <br />
        Enter as few or as many players as you would like. 
    </p>
                <asp:CheckBoxList ID="chkRoster" runat="server" DataKeyNames="player_name"  RepeatColumns="4" Width="600px" ForeColor="#12173f"></asp:CheckBoxList>    
    
    <asp:Button class="btn btn-primary active" ID="btnPlayerGames" runat="server" Text="Retrieve" OnClick="BtnPlayerGames_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="btnPlayerGamesHide" runat="server" Text="Hide" OnClick="BtnPlayerGamesHide_Click" BackColor="#707271" ForeColor="#12173f" BorderColor="#707271"/> 
        <asp:Label ID="lblPGError" runat="server" Text="" ForeColor="Red"></asp:Label><asp:GridView ID="grdPlayerGames" runat="server"  
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerGames_Sorting"
             AlternatingRowStyle-BackColor="#12173f" RowStyle-BackColor="#5d76a9" RowStyle-ForeColor="white" AlternatingRowStyle-ForeColor="white" HeaderStyle-ForeColor="white"
                                                                                                                                                   HeaderStyle-BorderColor="#12173f"
                                                                                                                                                   RowStyle-BorderColor="#5d76a9"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#12173f">
    </asp:GridView>
    


        <h3 style="color:#12173f">
            Player box score history in Wins
        </h3>
    <p style="color:#12173f">
        Enter the players' names that you would like to include in the results.<br />
        Click the 'Retrieve' button to return the specified players' box score in each game they have participated in that was a Win. <br />
        Enter as few or as many players as you would like.
    </p>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWins" runat="server" Text="Retrieve" OnClick="BtnPlayerWins_Click" BackColor="#12173f" ForeColor="White" BorderColor="#12173f"/>
    <asp:Button class="btn btn-primary active" ID="btnPlayerWinsHide" runat="server" Text="Hide" OnClick="BtnPlayerWinsHide_Click" BackColor="#707271" ForeColor="#12173f" BorderColor="#707271"/> 
        <asp:Label ID="LabelError" runat="server" Text="" ForeColor="Red"></asp:Label> <br/><asp:GridView ID="grdPlayerWins" runat="server"
            DataKeyNames="Matchup" CssClass="WideTable" Width="1800px" AllowSorting="true" OnSorting="grdPlayerWins_Sorting"
            AlternatingRowStyle-BackColor="#12173f" RowStyle-BackColor="#5d76a9" RowStyle-ForeColor="white" AlternatingRowStyle-ForeColor="white" HeaderStyle-ForeColor="white"
                                                                                                                                                   HeaderStyle-BorderColor="#12173f"
                                                                                                                                                   RowStyle-BorderColor="#5d76a9"                                                                                                                                         
                                                                                                                                                   AlternatingRowStyle-BorderColor="#12173f">
    </asp:GridView>


    </div >
</asp:Content>

