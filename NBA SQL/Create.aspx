<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="NBA_SQL.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color:white">Create an Account</h1>

    <asp:Label ID="lblEmail" runat="server" Font-Size="Large" Text="Email:" ></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="*" Width="122px" ForeColor="red"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblUser" runat="server" Font-Size="Large" Text="Username:" ></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="*" Width="84px" ForeColor="red"></asp:Label>
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPass" runat="server" Font-Size="Large" Text="Password:"   ></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="*" Width="88px" ForeColor="red"></asp:Label>
    <asp:TextBox ID="txtPass" runat="server" type="password"></asp:TextBox>
    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPass" ID="RegularExpressionValidator1" 
        ValidationExpression = "^[\s\S]{8,}$" runat="server" ErrorMessage="Minimum 6 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="LabelPass2" runat="server" Font-Size="Large" Text="Confirm Password:"   ></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="*" Width="20px" ForeColor="red"></asp:Label>
    <asp:TextBox ID="txtPass2" runat="server" type="password" ></asp:TextBox>
    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPass2" ID="RegularExpressionValidator2" 
        ValidationExpression = "^[\s\S]{8,}$" runat="server" ErrorMessage="Minimum 6 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
    <br />
    

    <br />
    <br />
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
    <asp:Button class="btn btn-primary active" ID="btnPG" runat="server" Text="Create Account" OnClick="btnPG_Click" BackColor="#006bb6" ForeColor="White" BorderColor="#006bb6" />
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="red"></asp:Label>
</asp:Content>
