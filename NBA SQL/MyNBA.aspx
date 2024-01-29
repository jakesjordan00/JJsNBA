<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyNBA.aspx.cs" Inherits="NBA_SQL.MyNBA" %>

<asp:Content ID="content" ContentPlaceHolderID="MainContent" runat="server">
<div class="container fluid" id="containerBodyContent" runat="server" style="padding:0px">
<div class="container" id="userHeader" runat="server" style="padding:0px; width:max-content;">
    <div class="row" style="width:stretch">
        <div class="col-sm" style="padding-left:-5px" >
            <asp:Label ID="lblUser" CssClass="lblUser1" runat="server" Text="" Font-Size="XX-Large" ForeColor="White" ></asp:Label>&emsp;&emsp;&emsp;
            <asp:Button ID="btnEdit" class="btn btn-primary active" runat="server" Text="Edit" Visible="false"  Font-Size="small" OnClick="btnEdit_Click"></asp:Button>
        </div>
        <div class="col-sm" style="padding-left:-5px">
            
        </div>
   </div>   
</div>
    
    <div class="row" style="width:stretch">
        <div class="col-sm" style="visibility:hidden" id="columnTeam" runat="server">
                <h3 style="color:white" id="favTeam" runat="server">Favorite Team</h3>
                <asp:GridView ID="grdTeam" runat="server" Width="800px" Height="350px"></asp:GridView> 
        </div>
        <div class="col-sm" style="visibility:hidden" id="columnPlayer" runat="server">
                <h3 style="color:white" id="favPlayer" runat="server">Favorite Player</h3>
                <asp:GridView ID="grdPlayer" runat="server" Width="490px" Height="353px"></asp:GridView> 
        </div>
     </div>
    <br />
    <div id="journalWrapper" runat="server" style="visibility:hidden">
    <h2 runat="server" id="journalHead" >Journal</h2>
        <asp:Label ID="lblDate" runat="server" Font-Size="Large" Text=""></asp:Label>

        <br />
        &emsp; &ensp; &emsp;  <asp:Label ID="lblTeam1" runat="server" Text=""></asp:Label>

    </div>













    <br />
    <asp:Button ID="btnLogout" class="btn btn-primary active" runat="server" Text="Logout" OnClick="btnLogout_Click" />

</div>
</asp:Content>
