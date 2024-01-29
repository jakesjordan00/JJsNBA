<%@ Page Title="Prop Checker" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PropChecker.aspx.cs" Inherits="NBA_SQL.PropChecker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
<style>
        body {background-color: black; color:white}
</style>
    <h1>Prop Checker</h1>
    <asp:Label ID="LabelSelect1" runat="server" font-size="Large" Text="Select Team:" ></asp:Label> 
    <asp:DropDownList       
                     ID="ddTeams" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" 
                     runat="server" DataKeyNames="Team" AutoPostBack="true" OnSelectedIndexChanged="ddTeams_SelectedIndexChanged"
                     BackColor="White" BorderColor="Black" Font-Size="Large" Width="350px" ForeColor="Black">
       </asp:DropDownList>
    <br />
    <asp:Label ID="LabelSelect2" runat="server" font-size="Large" Text="Select Player:" ></asp:Label> 
    <asp:DropDownList 
        ID="ddlRoster" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4" Width="300px" BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlRoster_SelectedIndexChanged">
        <asp:ListItem Text="Player" Value="" />
    </asp:DropDownList>
    <br />
    <asp:CheckBox ID="chkInjury" runat="server" OnCheckedChanged="chkInjury_CheckedChanged" AutoPostBack="true"/>
    <asp:Label ID="Label2" runat="server" font-size="Large" Text="Select Injured Player:" ></asp:Label> 
    <asp:DropDownList 
        ID="ddlInjured" runat="server"    DataKeyNames="Player"  AutoPostBack="true" BackColor="White" ForeColor="Black"
        RepeatColumns="4" Width="300px" BorderColor="Black"  class="btn btn-primary dropdown-toggle" data-toggle="dropdown" 
        aria-haspopup="true" aria-expanded="false" OnSelectedIndexChanged="ddlInjured_SelectedIndexChanged"  >
        <asp:ListItem Text="Injured Teammate" Value="" />
    </asp:DropDownList>
    <asp:Label ID="lblError" runat="server" Text="" forecolor="Red"></asp:Label>
    <br />
    <asp:Label ID="Label1"  runat="server" Text="" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="XX-Large"></asp:Label>
    <br />
    <asp:Button ID="btnAll" class="btn btn-primary active" runat="server" Text="All games" OnClick="btnAll_Click" BackColor="White" ForeColor="Black" BorderColor="White" Visible="false"/>
    <asp:Button ID="btnwins" class="btn btn-primary active" runat="server" Text="Wins only" OnClick="btnwins_Click" BackColor="White" ForeColor="Black" BorderColor="White" Visible="false"/>
    
    
    <div class="row" >        
        <div class="col-md-5">
            <asp:Label ID="LabelP"  runat="server" Text="Points" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnp" runat="server" class="btn btn-primary active"  Text="Expand" BackColor="Black" ForeColor="White" BorderColor="Black" Visible="false" Font-Size="X-Small" Width="60px" onclick="btnp_Click" />
            <asp:GridView ID="grdpts" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black" ></asp:GridView>
            <asp:Label ID="LabelA"  runat="server" Text="Assists" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btna" runat="server" class="btn btn-primary active"  Text="Expand" BackColor="Black" ForeColor="White" BorderColor="Black" Visible="false" Font-Size="X-Small" Width="60px"  onclick="btna_Click"/>
            <asp:GridView ID="grdast" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"></asp:GridView>
            <asp:Label ID="LabelR"  runat="server" Text="Rebounds" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnr" runat="server" class="btn btn-primary active"  Text="Expand" BackColor="Black" ForeColor="White" BorderColor="Black" Visible="false" Font-Size="X-Small" Width="60px"  onclick="btnr_Click"/>
            <asp:GridView ID="grdreb" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"></asp:GridView>
            <asp:Label ID="Label3s"  runat="server" Text="Threes Made" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btn3s" runat="server" class="btn btn-primary active"  Text="Expand" BackColor="Black" ForeColor="White" BorderColor="Black" Visible="false" Font-Size="X-Small" Width="60px" onclick="btn3s_Click" />
            <asp:GridView ID="grd3" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"></asp:GridView>
            <asp:Label ID="LabelB"  runat="server" Text="Blocks" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnb" runat="server" class="btn btn-primary active"  Text="Expand" BackColor="Black" ForeColor="White" BorderColor="Black" Visible="false" Font-Size="X-Small" Width="60px" onclick="btnb_Click" />
            <asp:GridView ID="grdblk" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"></asp:GridView>
            <asp:Label ID="LabelS"  runat="server" Text="Steals" BackColor="Black" ForeColor="White" BorderColor="black" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btns" runat="server" class="btn btn-primary active"  Text="Expand" BackColor="Black" ForeColor="White" BorderColor="Black" Visible="false" Font-Size="X-Small" Width="60px" onclick="btns_Click" />
            <asp:GridView ID="grdstl" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"></asp:GridView>
        </div>
        <div class="col-md-5">
            <asp:GridView ID="grdptsplus" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black"  ></asp:GridView>       
            <asp:GridView ID="grdastplus" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black" ></asp:GridView>       
            <asp:GridView ID="grdrebplus" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black" ></asp:GridView>       
            <asp:GridView ID="grd3plus" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black" ></asp:GridView>        
            <asp:GridView ID="grdblkplus" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black" ></asp:GridView>              
            <asp:GridView ID="grdstlplus" runat="server" ForeColor="White" Width="400px" HeaderStyle-BackColor="White" HeaderStyle-BorderColor="White" HeaderStyle-ForeColor="Black" ></asp:GridView>

        </div>
    </div>
    
            
        

</asp:Content>
