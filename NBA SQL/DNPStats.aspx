<%@ Page MaintainScrollPositionOnPostback="true" Title="DNPStats" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DNPStats.aspx.cs" Inherits="NBA_SQL.DNP_Stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {background-color:black; color:white;}
    </style>
    <h1>DNP Stats</h1>

    <asp:DropDownList       
                            ID="ddTeams" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                            runat="server" DataKeyNames="Team" AutoPostBack="true" OnSelectedIndexChanged="ddTeams_SelectedIndexChanged" BackColor="White" ForeColor="Black"
                            
    ></asp:DropDownList>

    <h3>Roster</h3>

    <asp:CheckBoxList ID="chkRoster" runat="server"    DataKeyNames="Player"  AutoPostBack="true" RepeatColumns="2"  BorderColor="#ba9653" class="form-check form-switch" ></asp:CheckBoxList>

    <asp:Button class="btn btn-primary active" ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" BackColor="Black" ForeColor="White" BorderColor="#ba9653" />
    <asp:Button class="btn btn-primary active" ID="btnRetrieve2" runat="server" Text="Retrieve 2" OnClick="btnRetrieve2_Click" BackColor="Black" ForeColor="White" BorderColor="#ba9653" />    
    <asp:Button class="btn btn-primary active" ID="btnRetrieveW" runat="server" Text="Retrieve in Wins" OnClick="btnRetrieveW_Click" BackColor="Black" ForeColor="#ba9653" BorderColor="White" />
    <asp:Button class="btn btn-primary active" ID="btnRetrieve2W" runat="server" Text="Retrieve 2 in Wins" OnClick="btnRetrieve2W_Click" BackColor="Black" ForeColor="#ba9653" BorderColor="White" />
    <br />
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    <asp:GridView ID="grdStats" runat="server" DataKeyNames="Score" Width="1000px" AlternatingRowStyle-BackColor="Gray"></asp:GridView>





</asp:Content>
