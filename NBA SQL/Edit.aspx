<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NBA_SQL.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Profile</h1>
<asp:Label ID="Label5" runat="server" Text="Favorite Team:" Width="93"></asp:Label>
    <asp:DropDownList ID="ddlTeam" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                     runat="server" DataKeyNames="Team" AutoPostBack="true" Width="300px"
                     Font-Size="Large" BackColor="White" ForeColor="Black"
    ></asp:DropDownList>

    <br />
    <asp:Label ID="Label6" runat="server" Text="Favorite Player:"></asp:Label>
    <asp:DropDownList ID="ddlPlayer" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                     runat="server" DataKeyNames="Team" AutoPostBack="true" Width="300px"
                     Font-Size="Large" BackColor="White" ForeColor="Black"
    ></asp:DropDownList>
    <br />
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Submit" OnClick="btnPG_Click" BackColor="#006bb6" ForeColor="White" BorderColor="#006bb6" />
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="red"></asp:Label>
</asp:Content>
