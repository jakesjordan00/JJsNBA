<%@ Page Title="Prop Checker v2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PropChecker2.aspx.cs" Inherits="NBA_SQL.PropChecker2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {background-color: black; color:white}
        .btnJournal {
    display: inline-block;
    font-weight: 400;
    line-height: 1.5;
    color: #212529;
    text-align: center;
    text-decoration: none;
    vertical-align: middle;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    user-select: none;
    background-color: transparent;
    border: 1px solid transparent;
    padding: 0.375rem 0.75rem;
    font-size: 1rem;
    border-radius: 0.25rem;
    transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
        .btnJournalDisabled{
    pointer-events: none;
    opacity: 0.65;
    cursor: not-allowed;
    background-color:grey;
    color:white;
}
</style>
    <h1>Prop Checker</h1>
    <abbr title="Select a team. Once a team has been selected, the four player dropdowns will populate." style="font-size:Large; text-decoration-color:grey">Select Team:</abbr>
    <asp:DropDownList       
                     ID="ddTeams" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                     runat="server" DataKeyNames="Team" AutoPostBack="true" OnSelectedIndexChanged="ddTeams_SelectedIndexChanged"
                     BackColor="White" BorderColor="Black" Font-Size="Large" Width="350px" ForeColor="Black">
       </asp:DropDownList>
    <br />
    <abbr title="Select the player who you would like to include in your prop" style="font-size:Large; text-decoration-color:grey">Select Player:</abbr>
    <asp:DropDownList 
        ID="ddlRoster" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4" Width="300px" BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlRoster_SelectedIndexChanged">
        <asp:ListItem Text="Player" Value="" />
    </asp:DropDownList>

    

    <abbr title="If a teammate of the 'Prop Player' is ruled out and you would like to check games meeting this criteria, select that ruled out player" style="font-size:Large; text-decoration-color:grey">Select Injured Player:</abbr> 
    <asp:DropDownList 
        ID="ddlInjured" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4" Width="300px" BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlInjured_SelectedIndexChanged">
        <asp:ListItem Text="Injured Player" Value="" />
    </asp:DropDownList>
    
    <br />
    <div class="row">
        <div class="col-md-1" style="width:50px">
            <abbr title="Select the props to include. By selecting multiple, you can test the percentage of a particular parlay." style="font-size:small; width:30px; text-decoration-color:grey">Props:</abbr>
        </div>
        <div class="col-md-1">
            <asp:CheckBox ID="chkP" runat="server" Text="&nbsp;Points" ForeColor="White" Width="80px" TextAlign="right" OnCheckedChanged="chkP_CheckedChanged" AutoPostBack="true"/>
        </div>
        <div class="col-md-1">
            <asp:CheckBox ID="chkA" runat="server" Text="&nbsp;Assists" ForeColor="White" Width="80px" TextAlign="right" OnCheckedChanged="chkA_CheckedChanged" AutoPostBack="true"/>
        </div>
        <div class="col-md-1">
            <asp:CheckBox ID="chkR" runat="server" Text="&nbsp;Rebounds" ForeColor="White" Width="100px" TextAlign="right" OnCheckedChanged="chkR_CheckedChanged" AutoPostBack="true"/>
        </div>
        <div class="col-md-1" style="width:120px;">
            <asp:CheckBox ID="chk3" runat="server" Text="&nbsp;Threes Made" ForeColor="White" Width="120px" TextAlign="right" OnCheckedChanged="chk3_CheckedChanged" AutoPostBack="true"/>
        </div>
        <div class="col-md-1">
            <asp:CheckBox ID="chkB" runat="server" Text="&nbsp;Blocks" ForeColor="White" Width="80px" TextAlign="right" OnCheckedChanged="chkB_CheckedChanged" AutoPostBack="true"/>
        </div>
        <div class="col-md-1">
            <asp:CheckBox ID="chkS" runat="server" Text="&nbsp;Steals" ForeColor="White" Width="80px" TextAlign="right" OnCheckedChanged="chkS_CheckedChanged" AutoPostBack="true"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1" style="width:50px;">
            <abbr title="Enter the values for the props. Say you expect your player to score over 22.5 points, enter 22.5 or 23, and so on for the other values. If you leave the box blank, it will default to 0." style="font-size:small; width:30px; text-decoration-color:grey;">Values:</abbr>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtP" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtA" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtR" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1" style="width:120px;">
            <asp:TextBox ID="txt3" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtB" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtS" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
    </div>
    <abbr title="If you would like to include props for multiple players, select a player from this dropdown. Textboxes for their specific prop values will appear upon making a selection." style="font-size:Large; text-decoration-color:grey">Select 2nd Player:</abbr>
    <asp:DropDownList 
        ID="ddlRoster2" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4" Width="300px" BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlRoster2_SelectedIndexChanged">
        <asp:ListItem Text="Player" Value="" />
    </asp:DropDownList>
    <br />
    <div class="row">
        <div class="col-md-1" style="width:50px;">
            <asp:Label ID="Label1" runat="server" Text="Values:" ForeColor="White" Font-Size="Small" Visible="false"></asp:Label>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtP2" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtA2" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtR2" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1" style="width:120px;">
            <asp:TextBox ID="txt32" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtB2" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtS2" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
    </div>

    <abbr title="Same thing as the 2nd Player dropdown above. Textboxes for their specific prop values will appear upon making a selection." style="font-size:Large; text-decoration-color:grey">Select 3rd Player:</abbr>
    <asp:DropDownList 
        ID="ddlRoster3" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4" Width="300px" BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlRoster3_SelectedIndexChanged">
        <asp:ListItem Text="Player" Value="" />
    </asp:DropDownList>
    <br />
    <div class="row">
        <div class="col-md-1" style="width:50px;">
            <asp:Label ID="Label2" runat="server" Text="Values:" ForeColor="White" Font-Size="Small" Visible="false"></asp:Label>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtP3" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtA3" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtR3" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1" style="width:120px;">
            <asp:TextBox ID="txt33" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtB3" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
        <div class="col-md-1">
            <asp:TextBox ID="txtS3" runat="server" BackColor="White" ForeColor="Black" Visible="false" Width="40px" MaxLength="4"></asp:TextBox>
        </div>
    </div>





    <asp:Button class="btn btn-primary active" ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" BackColor="Black" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="btnRetrieveW" runat="server" Text="Retrieve in Wins" OnClick="btnRetrieveW_Click" BackColor="Black" ForeColor="#ba9653" BorderColor="White" />
<abbr title="Click Retrieve to pull statistics with one player or one player with an injured player selected. Click Retrieve in Wins to do the same, but only returning games won." style="font-size:small; width:30px; text-decoration-color:grey;">Help</abbr>

    <br />
    <asp:Button class="btn btn-primary active" ID="btnRetrieve2" runat="server" Text="Retrieve 2" OnClick="btnRetrieve2_Click" BackColor="Black" ForeColor="White" BorderColor="#ba9653" /> 
    <asp:Button class="btn btn-primary active" ID="btnRetrieve2W" runat="server" Text="Retrieve 2 in Wins" OnClick="btnRetrieve2W_Click" BackColor="Black" ForeColor="#ba9653" BorderColor="White" />
    <abbr title="Same as above but with two players" style="font-size:small; width:30px; text-decoration-color:grey;">Help</abbr>

    <br />
    <asp:Button class="btn btn-primary active" ID="btnRetrieve3" runat="server" Text="Retrieve 3" OnClick="btnRetrieve3_Click" BackColor="Black" ForeColor="White" BorderColor="#ba9653" /> 
    <asp:Button class="btn btn-primary active" ID="btnRetrieve3W" runat="server" Text="Retrieve 3 in Wins" OnClick="btnRetrieve3W_Click" BackColor="Black" ForeColor="#ba9653" BorderColor="White" />
    <abbr title="Same as above but with three players" style="font-size:small; width:30px; text-decoration-color:grey;">Help</abbr>
    <br />
    <div class="wrapper" id="wrapper" runat="server">
        <asp:Button CssClass="btnJournal"  ID="btnjournal" runat="server" Text="Save to Journal" OnClick="btnjournal_Click" BackColor="#ba9653" ForeColor="Black" BorderColor="White"/> 
    </div>
    <br />
    <asp:Label ID="lblError" runat="server" Text="" forecolor="Red"></asp:Label>
    <asp:GridView ID="grd" runat="server" ForeColor="White" Width="800px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"></asp:GridView> 
    
</asp:Content>
