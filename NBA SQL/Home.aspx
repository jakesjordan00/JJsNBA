<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NBA_SQL.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        w1p:hover + w1s{
            visibility:visible;
            display:block;
        }
    </style>
   

    <div class="container" style="height:1000px; width:2000px; background-repeat:no-repeat; margin-top:-150px; 
                                  background-image: url('bracket.png'); background-size:contain; border-image-width: 0px; ">


        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px; margin-top:188px; border-radius:5px;">
            <img src="" class="w1p" runat ="server" id="w1p" style="width:172px; height:82px; border-width:0px; border-radius:5px; margin-left:3px" onmouseover="mouseover(w1s)" onmouseout="mouseout(w1s)" />
            <img src="" runat ="server" id="e1p" style="width:172px; height:82px; border-radius:5px; margin-left:923px; margin-top:-104px "/>
            <img src="" runat ="server" id="w9p" style="width:86px; height:41px; border-radius:2.5px; border-width:0px; margin-left:459px; margin-top:-180px "/>
            <img src="" runat ="server" id="e9p" style="width:86px; height:41px; border-radius:2.5px; border-width:0px; margin-left:545px; margin-top:-219px "/>
            <img src="" runat ="server" id="w10p" style="width:86px; height:41px; border-radius:2.5px; border-width:0px; margin-left:459px; margin-top:-172px "/>
            <img src="" runat ="server" id="e10p" style="width:86px; height:41px; border-radius:2.5px; border-width:0px; margin-left:545px; margin-top:-210px "/>

            <div class="stats" id="w1s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:180px; margin-top:-202px; border-radius:5px;">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w1Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label16" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w1RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label18" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w1RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label19" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w1SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
               
            </div>
            <div class="stats" id="e1s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;" >
                <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e1Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label20" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e1RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label22" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e1RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label24" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e1SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>
        
        
        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:13px;  margin-top:-1px; border-radius:5px;">
            <img src="" runat ="server" id="w8p" style="width:172px; height:82px; border-radius:5px; margin-top:5px  " />
            <img src="" runat ="server" id="e8p" style="width:172px; height:82px; border-radius:5px; margin-left:920px; margin-top:-104px "  />
            <div class="stats" id="w8s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:177px; margin-top:-102px; border-radius:5px;">
                <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w8Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label21" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w8RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label25" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w8RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label27" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w8SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
            <div class="stats" id="e8s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:743px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e8Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label23" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e8RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label28" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e8RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label30" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e8SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>
        <%-- Above rows are done --%>

        
        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px;  top:170px; border-radius:5px;">
            <img src="" runat ="server" id="w5p" style="width:172px; height:82px; border-radius:5px; margin-top:49px; margin-left:3px  "  />
            <img src="" runat ="server" id="e5p" style="width:172px; height:82px; border-radius:5px; margin-left:923px; margin-top:-104px "  />

            <div class="stats" id="w5s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:179px; margin-top:-102px; border-radius:5px;">
                <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w5Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label32" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w5RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label34" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w5RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label36" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w5SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>

            <div class="stats" id="e5s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e5Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label38" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e5RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label40" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e5RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label42" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e5SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>

        </div>



        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px;  top:170px; border-radius:5px;">
            <img src="" runat ="server" id="w4p" style="width:172px; height:82px; border-radius:5px; margin-top:53px; margin-left:3px "  />
            <img src="" runat ="server" id="e4p" style="width:172px; height:82px; border-radius:5px; margin-left:923px; margin-top:-104px "  />
            <div class="stats" id="w4s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:179px; margin-top:-102px; border-radius:5px;">
                <asp:Label ID="Label9" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w4Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label44" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w4RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label46" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w4RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label48" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w4SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
            <div class="stats" id="e4s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e4Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label50" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e4RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label52" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e4RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label54" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e4SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>



        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px;  top:170px; border-radius:5px;">
            <img src="" runat ="server" id="w3p" style="width:172px; height:82px; border-radius:5px; margin-top:97px; margin-left:3px   "  />
            <img src="" runat ="server" id="e3p" style="width:172px; height:82px; border-radius:5px;  margin-left:923px; margin-top:-105px "  />
            <div class="stats" id="w3s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:180px; margin-top:-102px; border-radius:5px;"> 
                <asp:Label ID="Label8" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w3Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label56" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w3RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label58" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w3RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label60" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w3SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
            <div class="stats" id="e3s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label11" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e3Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label62" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e3RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label64" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e3RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label66" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e3SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>



        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px;  top:170px; border-radius:5px;">
            <img src="" runat ="server" id="w6p" style="width:172px; height:82px; border-radius:5px; margin-top:100px; margin-left:2px  "  />
            <img src="" runat ="server" id="e6p" style="width:172px; height:82px; border-radius:5px; margin-left:923px; margin-top:-105px "  />
            <div class="stats" id="w6s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:180px; margin-top:-102px; border-radius:5px;"> 
                <asp:Label ID="Label10" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w6Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label68" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w6RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label70" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w6RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label72" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w6SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
            <div class="stats" id="e6s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label12" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e6Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label74" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e6RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label76" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e6RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label78" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e6SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>

       

        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px;  top:170px; border-radius:5px;">
            <img src="" runat ="server" id="w7p" style="width:172px; height:82px; border-radius:5px;  margin-top:148px;margin-left:3px  "  />
            <img src="" runat ="server" id="e7p" style="width:172px; height:82px; border-radius:5px; margin-left:923px; margin-top:-106px "  />
            <div class="stats" id="w7s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:180px; margin-top:-102px; border-radius:5px;"> 
                <asp:Label ID="Label13" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w7Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label80" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w7RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label82" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w7RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label84" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w7SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
            <div class="stats" id="e7s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label15" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e7Record" runat="server" Font-Size="Large" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label86" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e7RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label88" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e7RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label90" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e7SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>



        <div class="wrappa" style="background-color:transparent; width: 172px; height:82px; margin-left:10px;  top:170px; border-radius:5px;">
            <img src="" runat ="server" id="w2p" style="width:172px; height:82px; border-radius:5px;  margin-top:151px;margin-left:3px   "  />
            <img src="" runat ="server" id="e2p" style="width:172px; height:83px; border-radius:5px;  margin-left:923px; margin-top:-105px "  />
            <div class="stats" id="w2s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:180px; margin-top:-102px; border-radius:5px;">
                <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="w2Record" runat="server" Font-Size="Large"  Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label92" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="w2RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label94" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="w2RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label96" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="w2SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
            <div class="stats" id="e2s" style="background-color:white; width: 172px; height:82px; opacity: .5; visibility:visible;
                                      margin-left:746px; margin-top:-82px; border-radius:5px;">
                <asp:Label ID="Label17" runat="server" Font-Size="Large" Text="Record: "></asp:Label>
                <asp:Label ID="e2Record" runat="server" Font-Size="Large"  Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label98" runat="server" Font-Size="Small" Text="Home: "></asp:Label>
                <asp:Label ID="e2RecordH" runat="server" Font-Size="Small" Text="" ></asp:Label>
                &nbsp
                <asp:Label ID="Label100" runat="server" Font-Size="Small" Text="Away: "></asp:Label>
                <asp:Label ID="e2RecordA" runat="server" Font-Size="Small" Text="" ></asp:Label>
                <br />
                <asp:Label ID="Label102" runat="server" Font-Size="Small" Text="Strength of Schedule: "></asp:Label>
                <asp:Label ID="e2SoS" runat="server" Font-Size="Small" Text="" ></asp:Label>
            </div>
        </div>


        <asp:Label ID="e9Record" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="w9Record" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="e10Record" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="w10Record" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="e9RecordH" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="w9RecordH" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="e10RecordH" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="w10RecordH" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="e9RecordA" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="w9RecordA" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="e10RecordA" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="w10RecordA" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="w9SoS" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="w10SoS" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="e9SoS" runat="server" Text="" Visible="false" ></asp:Label>
        <asp:Label ID="e10SoS" runat="server" Text="" Visible="false"></asp:Label>
    </div>
</asp:Content>
