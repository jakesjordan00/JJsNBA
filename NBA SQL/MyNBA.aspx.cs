using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace NBA_SQL
{
    public partial class MyNBA : System.Web.UI.Page
    {
        string favoriteTeam = "";
        string favoritePlayer = "";
        string _76ers = "(PHI) Philadelphia 76ers";  string bucks = "(MIL) Milwaukee Bucks";      string bulls = "(CHI) Chicago Bulls"; string cavaliers = "(CLE) Cleveland Cavaliers"; string celtics = "(BOS) Boston Celtics"; string clippers = "(LAC) Los Angeles Clippers";
        string grizzlies = "(MEM) Memphis Grizzlies"; string hawks = "(ATL) Atlanta Hawks"; string heat = "(MIA) Miami Heat"; string hornets = "(CHA) Charlotte Hornets"; string jazz = "(UTA) Utah Jazz"; string kings = "(SAC) Sacramento Kings"; string knicks = "(NYK) New York Knicks"; string lakers = "(LAL) Los Angeles Lakers";
        string magic = "(ORL) Orlando Magic"; string mavericks = "(DAL) Dallas Mavericks"; string nets = "(BKN) Brooklyn Nets"; string nuggets = "(DEN) Denver Nuggets"; string pacers = "(IND) Indiana Pacers"; string pelicans = "(NOP) New Orleans Pelicans"; string pistons = "(DET) Detroit Pistons"; string raptors = "(TOR) Toronto Raptors"; string rockets = "(HOU) Houston Rockets";
        string spurs = "(SAS) San Antonio Spurs"; string suns = "(PHX) Phoenix Suns"; string thunder = "(OKC) Oklahoma City Thunder"; string timberwolves = "(MIN) Minnesota Timberwolves"; string trailblazers = "(POR) Portland Trail Blazers"; string warriors = "(GSW) Golden State Warriors"; string wizards = "(WAS) Washington Wizards";

        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                lblUser.Text = Session["Admin"].ToString();
                btnEdit.Visible = true;
            }
            else if (Session["User"] != null)
            {
                lblUser.Text = Session["User"].ToString();
                btnEdit.Visible = true;
            }
            else
            {
                Session["Guest"] = "Guest";
            }
            if (Session["User"] != null || Session["Admin"] != null)
            {
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
                using (sqlConnect)
                {
                    using (SqlCommand querySearch = new SqlCommand("users"))
                    {
                        querySearch.CommandType = CommandType.StoredProcedure;
                        querySearch.Parameters.AddWithValue("@username", Session["User"]);
                        querySearch.Connection = sqlConnect;
                        sqlConnect.Open();

                        SqlDataReader readersql = querySearch.ExecuteReader(); // create a reader

                        if (readersql.HasRows) // if the username exists, it will continue
                        {
                            if (readersql.Read()) // this will read the single record that matches the entered username
                            {
                                favoriteTeam = readersql["favoriteTeam"].ToString(); // store the database password into this variable
                                favoritePlayer = readersql["favoritePlayer"].ToString();
                            }
                        }
                        sqlConnect.Close();
                    }
                }
                SqlConnection sqlConnect1 = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
                using (sqlConnect1)
                {
                    using (SqlCommand querySearch = new SqlCommand("userTeams"))
                    {

                        querySearch.CommandType = CommandType.StoredProcedure;
                        querySearch.Parameters.AddWithValue("@team", favoriteTeam);
                        using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                        {
                            querySearch.Connection = sqlConnect1;
                            sDataSearch.SelectCommand = querySearch;
                            using (DataTable dataT = new DataTable())
                            {
                                sDataSearch.Fill(dataT);
                                grdTeam.DataSource = dataT;
                                grdTeam.DataBind();
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("userPlayers"))
                    {

                        querySearch.CommandType = CommandType.StoredProcedure;
                        querySearch.Parameters.AddWithValue("@player", favoritePlayer);
                        using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                        {
                            querySearch.Connection = sqlConnect1;
                            sDataSearch.SelectCommand = querySearch;
                            using (DataTable dataT = new DataTable())
                            {
                                sDataSearch.Fill(dataT);
                                grdPlayer.DataSource = dataT;
                                grdPlayer.DataBind();
                                foreach(GridViewRow row in grdPlayer.Rows)
                                {
                                    row.Cells[0].Text = row.Cells[0].Text.Split(' ')[0];
                                }
                            }
                        }
                    }
                }
                columnTeam.Attributes.Add("style", "visibility: visible");
                columnPlayer.Attributes.Add("style", "visibility: visible");
                grdPlayer.ForeColor= Color.White;
                SqlConnection dbConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
                using (dbConnect)
                {
                    using (SqlCommand querySearch = new SqlCommand("journalEntries"))
                    {
                        querySearch.CommandType = CommandType.StoredProcedure;
                        querySearch.Parameters.AddWithValue("@username", Session["User"]);
                        querySearch.Connection = dbConnect;
                        dbConnect.Open();

                        SqlDataReader readersql = querySearch.ExecuteReader(); // create a reader

                        if (readersql.HasRows) // if the username exists, it will continue
                        {
                            if (readersql.Read()) // this will read the single record that matches the entered username
                            {
                                lblDate.Text = readersql["entryDate"].ToString();
                                lblDate.Text = lblDate.Text.Split(' ')[0];
                                lblTeam1.Text = readersql["team1"].ToString(); // store the database password into this variable
                                //favoritePlayer = readersql["favoritePlayer"].ToString();
                            }
                        }
                        dbConnect.Close();
                    }
                }

























































                if (favoriteTeam == _76ers)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #c4ced4; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #002b5c; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:#002b5c ");
                    favPlayer.Attributes.Add("style", "color:#002b5c ");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");

                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.RowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdPlayer.ForeColor = Color.Black;


                }
                if (favoriteTeam == bucks)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #eee1c6; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #00471b; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:#00471b ");
                    favPlayer.Attributes.Add("style", "color:#00471b ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#eee1c6");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#eee1c6");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#eee1c6");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00471b");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00471b");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#eee1c6");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00471b");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#eee1c6");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00471b");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");



                    grdPlayer.ForeColor = System.Drawing.Color.Black;
                }
                if (favoriteTeam == bulls)
                {
                    lblUser.ForeColor = System.Drawing.Color.Black;
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #ce1141; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: White; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:#000000 ");
                    favPlayer.Attributes.Add("style", "color:#000000 ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ce1141");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ce1141");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ce1141");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdPlayer.ForeColor = Color.Black;
                }
                if (favoriteTeam == cavaliers)
                {
                    lblUser.ForeColor = System.Drawing.Color.Black;
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #041e42; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #860038; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#041e42");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#860038");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#860038");

                    
                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#860038");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#041e42");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#860038");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#860038");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#860038");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#860038");
                    grdPlayer.ForeColor = Color.White;
                    lblUser.ForeColor = Color.White;
                }
                if (favoriteTeam == celtics)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #007a33; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #ba9653; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ba9653");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("White");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ba9653");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("White");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#007a33");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#007a33");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#007a33");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ba9653");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#007a33");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("White");
                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == clippers)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #bec0c2; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #1d428a; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:#1d428a ");
                    favPlayer.Attributes.Add("style", "color:#1d428a ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#bec0c2");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.Black;
                }
                if (favoriteTeam == hawks)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #26282a; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #e03a3e; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#26282a");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#26282a");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#26282a");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#26282a");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == heat)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#98002e ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: White; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("White");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == hornets)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#00788c ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #1d1160; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#00788c");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00788c");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00788c");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00788c");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00788c");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == grizzlies)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #5d76a9; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #12173f; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#5d76a9");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#5d76a9");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#12173f");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#12173f");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#12173f");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#5d76a9");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#12173f");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#5d76a9");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#5d76a9");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#12173f");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                
                if (favoriteTeam == jazz)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#002b5c ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #f9a01b; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == kings)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#5a2d81 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #63727a; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#5a2d81");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#5a2d81");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#63727a");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#63727a");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#63727a");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#5a2d81");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#63727a");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#5a2d81");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#63727a");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == knicks)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#006bb6 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #f58426; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#f58426");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f58426");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f58426");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f58426");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f58426");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == lakers)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#552583 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #f9a01b; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#552583");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#552583");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#552583");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#552583");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#552583");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#552583");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#f9a01b");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == magic)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#c4ced4 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #0077c0; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:Black ");
                    favPlayer.Attributes.Add("style", "color:Black ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0077c0");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.Black;
                }
                if (favoriteTeam == mavericks)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#b8c4ca ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #00538c; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:Black ");
                    favPlayer.Attributes.Add("style", "color:Black ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#00538c");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00538c");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00538c");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#00538c");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b8c4ca");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#00538c");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.Black;
                }
                if (favoriteTeam == nets)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#777d84 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: White; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#777d84");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#777d84");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#777d84");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#777d84");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#777d84");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#777d84");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == nuggets)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#0e2240 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #8b2131; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#0e2240");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#fec524");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0e2240");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#8b2131");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#8b2131");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fec524");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0e2240");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#0e2240");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#8b2131");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#8b2131");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0e2240");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fec524");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == pacers)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#002d62 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #fdbb30; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#002d62");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002d62");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#002d62");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#002d62");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#002d62");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002d62");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fdbb30");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == pelicans) // if the entered password matches what is stored, it will show success
                {
                    //#002a5c

                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #002a5c; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #C8102E; padding:0px; width:stretch");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#002a5c");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#b5985a");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b5985a");

                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#002a5c");
                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#b5985a");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b5985a");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#b5985a");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#002a5c");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002a5c");
                    grdTeam.RowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002a5c");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b5985a");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C8102E");
                }
                if (favoriteTeam == pistons) // if the entered password matches what is stored, it will show success
                {
                    //#002a5c

                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #bec0c2; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #C8102E; padding:0px; width:stretch");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");

                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#C8102E");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#C8102E");
                    grdTeam.RowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#C8102E");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d428a");
                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.Black;
                    favPlayer.Attributes.Add("style", "color: Black");
                    favTeam.Attributes.Add("style", "color: Black");
                }
                if (favoriteTeam == raptors) // if the entered password matches what is stored, it will show success
                {
                    //#002a5c

                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color: #b4975a; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #2a2723; padding:0px; width:stretch");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#b4975a");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b4975a");

                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b4975a");
                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#2a2723");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#2a2723");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#b4975a");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#C8102E");
                    grdTeam.RowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#b4975a");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                    favPlayer.Attributes.Add("style", "color: #000000");
                    favTeam.Attributes.Add("style", "color: #000000");
                }
                if (favoriteTeam == rockets)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#ce1141 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: White; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ce1141");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("White");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ce1141");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ce1141");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == spurs)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#c4ced4 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: White; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#c4ced4");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.Black;
                    favPlayer.Attributes.Add("style", "color: #000000");
                    favTeam.Attributes.Add("style", "color: #000000");
                }
                if (favoriteTeam == suns)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#1d1160 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #e56020; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#e56020");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e56020");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e56020");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e56020");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e56020");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#1d1160");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e56020");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == thunder)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#007ac1 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #ef3b24; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#007ac1");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#007ac1");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#ef3b24");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ef3b24");

                    grdTeam.BorderStyle = BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ef3b24");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#007ac1");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ef3b24");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ef3b24");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#007ac1");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ef3b24");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == timberwolves)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#0c2340 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #78be20; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#0c2340");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0c2340");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#78be20");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0c2340");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#78be20");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#78be20");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#0c2340");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#0c2340");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#78be20");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#78be20");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#0c2340");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#78be20");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == trailblazers)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#e03a3e ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: White; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e03a3e");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == warriors)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#006bb6 ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #fdb927; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdb927");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fdb927");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdb927");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("Black");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdb927");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fdb927");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#006bb6");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#fdb927");

                    lblUser.ForeColor = Color.Black;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == wizards)
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", "background-color:#002b5c ; padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", "background-color: #e31837; padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "color:White ");
                    favPlayer.Attributes.Add("style", "color:White ");
                    btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    btnEdit.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    btnEdit.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");

                    btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#e31837");
                    btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                    btnLogout.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e31837");

                    grdTeam.BorderStyle= BorderStyle.None; grdTeam.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e31837");
                    grdTeam.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("White");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e31837");
                    grdTeam.HeaderStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#98002e");
                    grdTeam.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e31837");
                    grdTeam.BorderColor = System.Drawing.ColorTranslator.FromHtml("#002b5c");
                    grdTeam.AlternatingRowStyle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#e31837");

                    lblUser.ForeColor = Color.White;
                    grdPlayer.ForeColor = Color.White;
                }
                if (favoriteTeam == "")
                {
                    journalWrapper.Attributes.Add("Style", "style=visibility:visible; color:white;");containerBodyContent.Attributes.Add("style", " padding-left:0px; padding-right:0px; width:2500px");
                    userHeader.Attributes.Add("style", " padding:0px; width:stretch");
                    favTeam.Attributes.Add("style", "visibility: hidden");
                    favPlayer.Attributes.Add("style", "visibility: hidden ");
                }
            }
            }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit");
            
        }
    }
}