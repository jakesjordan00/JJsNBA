<%@ Page MaintainScrollPositionOnPostback="true" Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="NBA_SQL.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        body {background-color:black; color:white;}
    </style>
<h1>Suggestions</h1>

<br />
    <paragraph>
        If you have any statistics you would like to see or use when placing bets or for your own research, please submit a suggestion below. <br />
        I will reach back out to you to let you know when I begin working on it or if I need additional details. <br />
        Thank you!

    </paragraph>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Email:" Font-Size="X-Large"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server" Enabled="true" MaxLength="40" Text="" ForeColor="black" ></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Stat Suggestion:" Font-Size="X-Large"></asp:Label>
    <br />
    <asp:TextBox ID="txtSuggestion" runat="server" TextMode="MultiLine" ForeColor="Black"></asp:TextBox>
    <br />
    <asp:Button class="btn btn-primary active" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ForeColor="white" BackColor="black"/>
</asp:Content>
