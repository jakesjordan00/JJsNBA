using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;

namespace NBA_SQL
{
    public partial class Matchups : System.Web.UI.Page
    {
        protected SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }

        protected void ddTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            chkRoster.ClearSelection();
            chkRoster.Items.Clear();
            PopulateRoster1();
            grdMatchup.DataSource = null;
            grdMatchup.DataBind();
            grdPlayers.DataSource = null;
            grdPlayers.DataBind();
            grdPlayersMatchupWin.DataSource = null;
            grdPlayersMatchupWin.DataBind();
            if (Session["User"] != null || Session["Admin"] != null)
            {
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
                using (sqlConnect)
                {
                    using (SqlCommand querySearch = new SqlCommand("INSERT INTO userTeams (username, team, sourcePage, datetime) VALUES(@username, @team, @sourcePage,  CAST(GETDATE() as datetime))"))
                    {
                        querySearch.Connection = sqlConnect;
                        querySearch.CommandType = CommandType.Text;
                        querySearch.Parameters.AddWithValue("@username", Session["User"]);
                        querySearch.Parameters.Add(new SqlParameter("@team", ddTeams.SelectedValue.ToString())); querySearch.Parameters.Add(new SqlParameter("@sourcePage", Title)); 
                        sqlConnect.Open();
                        querySearch.ExecuteScalar(); // Used for other than SELECT Queries
                        sqlConnect.Close();
                    }
                }
            }
        }

        protected void ddTeams2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            chkRoster2.ClearSelection();
            chkRoster2.Items.Clear();
            PopulateRoster2();
            grdMatchup.DataSource = null;
            grdMatchup.DataBind();
            grdPlayers.DataSource = null;
            grdPlayers.DataBind();
            grdPlayersMatchupWin.DataSource = null;
            grdPlayersMatchupWin.DataBind();
            if (Session["User"] != null || Session["Admin"] != null)
            {
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
                using (sqlConnect)
                {
                    using (SqlCommand querySearch = new SqlCommand("INSERT INTO userTeams (username, team, sourcePage, datetime) VALUES(@username, @team, @sourcePage,  CAST(GETDATE() as datetime))"))
                    {
                        querySearch.Connection = sqlConnect;
                        querySearch.CommandType = CommandType.Text;
                        querySearch.Parameters.AddWithValue("@username", Session["User"]);
                        querySearch.Parameters.Add(new SqlParameter("@team", ddTeams2.SelectedValue.ToString())); querySearch.Parameters.Add(new SqlParameter("@sourcePage", Title)); 
                        sqlConnect.Open();
                        querySearch.ExecuteScalar(); // Used for other than SELECT Queries
                        sqlConnect.Close();
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
    
        protected void PopulateRoster1()
        {
            lblError.Text = "";
            string team = ddTeams.SelectedValue;
            test.Text = team;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("dnpRoster"))
                {
                    querySearch.Connection = sqlConnect;

                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    sqlConnect.Open();
                    using (SqlDataReader sdr = querySearch.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Player"].ToString();
                            chkRoster.Items.Add(item);
                        }
                    }
                    sqlConnect.Close();
                }    
            }
        }
        protected void PopulateRoster2()
        {
            lblError.Text = "";
            string team = ddTeams2.SelectedValue;
            test1.Text = team;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("dnpRoster"))
                {
                    querySearch.Connection = sqlConnect;

                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    sqlConnect.Open();
                    using (SqlDataReader sdr = querySearch.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Player"].ToString();
                            chkRoster2.Items.Add(item);
                        }
                    }
                    sqlConnect.Close();
                }
            }
        }




        protected void BindGrid()
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("dnpTeams"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataSet dataT = new DataSet())
                        {
                            sDataSearch.Fill(dataT);
                            ddTeams.DataTextField = dataT.Tables[0].Columns["Team"].ToString();
                            ddTeams.DataSource = dataT;
                            ddTeams.DataBind();
                            ListItem emptyItem = new ListItem("Team", "");
                            ddTeams.Items.Insert(0, emptyItem);
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("dnpTeams"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataSet dataT = new DataSet())
                        {
                            sDataSearch.Fill(dataT);
                            ddTeams2.DataTextField = dataT.Tables[0].Columns["Team"].ToString();
                            ddTeams2.DataSource = dataT;
                            ddTeams2.DataBind();
                            ListItem emptyItem = new ListItem("Team 2", "");
                            ddTeams2.Items.Insert(0, emptyItem);
                        }
                    }
                }
            }
        }
        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team1 = ddTeams.SelectedValue;

                string team2 = ddTeams2.SelectedValue;

                using (SqlCommand querySearch = new SqlCommand("seasonbox"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team1", team1);
                    querySearch.Parameters.AddWithValue("@team2", team2);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdMatchup.DataSource = dataT;
                            grdMatchup.DataBind(); foreach (GridViewRow row in grdMatchup.Rows) { row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0]; }
                            grdMatchup.Visible = true;
                            foreach (GridViewRow row in grdMatchup.Rows) { string knicks = "(NYK)New York Knicks"; string pelicans = "(NOP)New Orleans Pelicans"; string warriors = "(GSW)Golden State Warriors"; string clippers = "(LAC)Los Angeles Clippers"; string blazers = "(POR)Portland Trail Blazers"; string thunder = "(OKC)Oklahoma City Thunder"; string lakers = "(LAL)Los Angeles Lakers"; string spurs = "(SAS)San Antonio Spurs"; string teamA = row.Cells[0].Text; string teamALink = row.Cells[0].Text.Split(' ')[0]; string teamALinkSpace = ""; if (teamA == knicks || teamA == pelicans || teamA == warriors || teamA == clippers || teamA == thunder || teamA == lakers || teamA == spurs) { teamALinkSpace = row.Cells[0].Text.Split(' ')[2]; row.Cells[0].Text = "<a href=\"/" + teamALinkSpace + "\" style=\"color:white \" >" + teamA + "</a>"; } else if (teamA == blazers) { teamALink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2]; row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>"; } else { row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>"; } }
                        }
                    }
                }
            }

        }
        protected void BtnPlayers_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team1 = ddTeams.SelectedValue;
                string team2 = ddTeams2.SelectedValue;
                string player = "";
                string player1 = "";
                string player2 = "";
                string player3 = "";
                string player4 = "";
                string player5 = "";
                string player6 = "";
                string player7 = "";
                string player8 = "";
                string player9 = "";
                string player10 = "";
                string player11 = "";

                using (SqlCommand querySearch = new SqlCommand("seasonbox_6players"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team1", team1);
                    querySearch.Parameters.AddWithValue("@team2", team2);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
                            if(player == "")
                            {
                                player = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player", player);
                            }
                            if (listitem.Text != player1 && player1 == "")
                            {
                                player1 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player1", player1);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && player2 == "")
                            {
                                player2 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player2", player2);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && player3 == "")
                            {
                                player3 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player3", player3);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && player4 == "")
                            {
                                player4 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player4", player4);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && player5 == "")
                            {
                                player5 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player5", player5);
                            }
                        }
                    }
                    foreach (ListItem listitem in chkRoster2.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player6  && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
                    }
                    if (player == "")
                    {
                        querySearch.Parameters.AddWithValue("@player", player);
                    }
                    if (player1 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player1", player1);
                    }
                    if (player2 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player2", player2);
                    }
                    if (player3 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player3", player3);
                    }
                    if (player4 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player4", player4);
                    }
                    if (player5 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player5", player5);
                    }
                    if (player6 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player6", player6);
                    }
                    if (player7 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player7", player7);
                    }
                    if (player8 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player8", player8);
                    }
                    if (player9 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player9", player9);
                    }
                    if (player10 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player10", player10);
                    }
                    if (player11 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player11", player11);
                    }
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdPlayers.DataSource = dataT;
                            grdPlayers.DataBind();
                            grdPlayers.Visible = true;
                            foreach (GridViewRow row in grdPlayers.Rows)
                            { row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0]; }
                            foreach (GridViewRow row in grdPlayers.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string teamA = row.Cells[0].Text;
                                string teamALink = row.Cells[0].Text.Split(' ')[0];
                                string teamALinkSpace = "";
                                if (teamA == knicks || teamA == pelicans || teamA == warriors ||
                                    teamA == clippers || teamA == thunder || teamA == lakers || teamA == spurs)
                                {
                                    teamALinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALinkSpace + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else if (teamA == blazers)
                                {
                                    teamALink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void BtnPlayersMatchupWin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team1 = ddTeams.SelectedValue;
                string team2 = ddTeams2.SelectedValue;
                string player = "";
                string player1 = "";
                string player2 = "";
                string player3 = "";
                string player4 = "";
                string player5 = "";
                string player6 = "";
                string player7 = "";
                string player8 = "";
                string player9 = "";
                string player10 = "";
                string player11 = "";

                using (SqlCommand querySearch = new SqlCommand("seasonbox_playersinmatchupwin"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team1", team1);
                    querySearch.Parameters.AddWithValue("@team2", team2);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player == "")
                            {
                                player = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player", player);
                            }
                            if (listitem.Text != player1 && player1 == "")
                            {
                                player1 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player1", player1);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && player2 == "")
                            {
                                player2 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player2", player2);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && player3 == "")
                            {
                                player3 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player3", player3);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && player4 == "")
                            {
                                player4 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player4", player4);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && player5 == "")
                            {
                                player5 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player5", player5);
                            }
                        }
                    }
                    foreach (ListItem listitem in chkRoster2.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player6 && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
                    }
                    if (player == "")
                    {
                        querySearch.Parameters.AddWithValue("@player", player);
                    }
                    if (player1 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player1", player1);
                    }
                    if (player2 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player2", player2);
                    }
                    if (player3 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player3", player3);
                    }
                    if (player4 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player4", player4);
                    }
                    if (player5 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player5", player5);
                    }
                    if (player6 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player6", player6);
                    }
                    if (player7 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player7", player7);
                    }
                    if (player8 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player8", player8);
                    }
                    if (player9 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player9", player9);
                    }
                    if (player10 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player10", player10);
                    }
                    if (player11 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player11", player11);
                    }
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdPlayersMatchupWin.DataSource = dataT;
                            grdPlayersMatchupWin.DataBind();
                            grdPlayersMatchupWin.Visible = true;
                            foreach (GridViewRow row in grdPlayersMatchupWin.Rows)
                            { row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0]; }
                            foreach (GridViewRow row in grdPlayersMatchupWin.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string teamA = row.Cells[0].Text;
                                string teamALink = row.Cells[0].Text.Split(' ')[0];
                                string teamALinkSpace = "";
                                if (teamA == knicks || teamA == pelicans || teamA == warriors ||
                                    teamA == clippers || teamA == thunder || teamA == lakers || teamA == spurs)
                                {
                                    teamALinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALinkSpace + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else if (teamA == blazers)
                                {
                                    teamALink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnMatchupHide_Click(object sender, EventArgs e)
        {
            grdMatchup.Visible = false;
        }

        protected void btnPlayersHide_Click(object sender, EventArgs e)
        {
            grdPlayers.Visible = false;
        }

        protected void btnPlayersMatchupWinHide_Click(object sender, EventArgs e)
        {
            grdPlayersMatchupWin.Visible = false;
        }

        protected void grdMatchup_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team1 = ddTeams.SelectedValue;
                string team2 = ddTeams2.SelectedValue;

                using (SqlCommand querySearch = new SqlCommand("seasonbox"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team1", team1);
                    querySearch.Parameters.AddWithValue("@team2", team2);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            string SortDir = string.Empty;
                            if (dir == SortDirection.Ascending)
                            {
                                dir = SortDirection.Descending;
                                SortDir = "Desc";
                            }
                            else
                            {
                                dir = SortDirection.Ascending;
                                SortDir = "Asc";
                            }
                            DataView sortedView = new DataView(dataT);
                            sortedView.Sort = e.SortExpression + " " + SortDir;
                            grdMatchup.DataSource = sortedView;
                            grdMatchup.DataBind(); foreach (GridViewRow row in grdMatchup.Rows) { row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0]; }
                            foreach (GridViewRow row in grdMatchup.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string teamA = row.Cells[0].Text;
                                string teamALink = row.Cells[0].Text.Split(' ')[0];
                                string teamALinkSpace = "";
                                if (teamA == knicks || teamA == pelicans || teamA == warriors ||
                                    teamA == clippers || teamA == thunder || teamA == lakers || teamA == spurs)
                                {
                                    teamALinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALinkSpace + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else if (teamA == blazers)
                                {
                                    teamALink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void grdPlayers_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team1 = ddTeams.SelectedValue;
                string team2 = ddTeams2.SelectedValue;
                string player = "";
                string player1 = "";
                string player2 = "";
                string player3 = "";
                string player4 = "";
                string player5 = "";
                string player6 = "";
                string player7 = "";
                string player8 = "";
                string player9 = "";
                string player10 = "";
                string player11 = "";

                using (SqlCommand querySearch = new SqlCommand("seasonbox_6players"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team1", team1);
                    querySearch.Parameters.AddWithValue("@team2", team2);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player == "")
                            {
                                player = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player", player);
                            }
                            if (listitem.Text != player1 && player1 == "")
                            {
                                player1 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player1", player1);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && player2 == "")
                            {
                                player2 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player2", player2);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && player3 == "")
                            {
                                player3 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player3", player3);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && player4 == "")
                            {
                                player4 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player4", player4);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && player5 == "")
                            {
                                player5 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player5", player5);
                            }
                        }
                    }
                    foreach (ListItem listitem in chkRoster2.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player6 && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
                    }
                    if (player == "")
                    {
                        querySearch.Parameters.AddWithValue("@player", player);
                    }
                    if (player1 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player1", player1);
                    }
                    if (player2 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player2", player2);
                    }
                    if (player3 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player3", player3);
                    }
                    if (player4 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player4", player4);
                    }
                    if (player5 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player5", player5);
                    }
                    if (player6 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player6", player6);
                    }
                    if (player7 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player7", player7);
                    }
                    if (player8 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player8", player8);
                    }
                    if (player9 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player9", player9);
                    }
                    if (player10 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player10", player10);
                    }
                    if (player11 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player11", player11);
                    }
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            string SortDir = string.Empty;
                            if (dir == SortDirection.Ascending)
                            {
                                dir = SortDirection.Descending;
                                SortDir = "Desc";
                            }
                            else
                            {
                                dir = SortDirection.Ascending;
                                SortDir = "Asc";
                            }
                            DataView sortedView = new DataView(dataT);
                            sortedView.Sort = e.SortExpression + " " + SortDir;
                            grdPlayers.DataSource = sortedView;
                            grdPlayers.DataBind();
                            foreach (GridViewRow row in grdPlayers.Rows)
                            { row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0]; }
                            foreach (GridViewRow row in grdPlayers.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string teamA = row.Cells[0].Text;
                                string teamALink = row.Cells[0].Text.Split(' ')[0];
                                string teamALinkSpace = "";
                                if (teamA == knicks || teamA == pelicans || teamA == warriors ||
                                    teamA == clippers || teamA == thunder || teamA == lakers || teamA == spurs)
                                {
                                    teamALinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALinkSpace + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else if (teamA == blazers)
                                {
                                    teamALink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void grdPlayersMatchupWin_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team1 = ddTeams.SelectedValue;
                string team2 = ddTeams2.SelectedValue;
                string player = "";
                string player1 = "";
                string player2 = "";
                string player3 = "";
                string player4 = "";
                string player5 = "";
                string player6 = "";
                string player7 = "";
                string player8 = "";
                string player9 = "";
                string player10 = "";
                string player11 = "";

                using (SqlCommand querySearch = new SqlCommand("seasonbox_playersinmatchupwin"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team1", team1);
                    querySearch.Parameters.AddWithValue("@team2", team2);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player == "")
                            {
                                player = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player", player);
                            }
                            if (listitem.Text != player1 && player1 == "")
                            {
                                player1 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player1", player1);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && player2 == "")
                            {
                                player2 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player2", player2);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && player3 == "")
                            {
                                player3 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player3", player3);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && player4 == "")
                            {
                                player4 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player4", player4);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && player5 == "")
                            {
                                player5 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player5", player5);
                            }
                        }
                    }
                    foreach (ListItem listitem in chkRoster2.Items)
                    {
                        if (listitem.Selected)
                        {
                            if (player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player6 && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
                    }
                    if (player == "")
                    {
                        querySearch.Parameters.AddWithValue("@player", player);
                    }
                    if (player1 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player1", player1);
                    }
                    if (player2 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player2", player2);
                    }
                    if (player3 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player3", player3);
                    }
                    if (player4 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player4", player4);
                    }
                    if (player5 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player5", player5);
                    }
                    if (player6 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player6", player6);
                    }
                    if (player7 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player7", player7);
                    }
                    if (player8 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player8", player8);
                    }
                    if (player9 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player9", player9);
                    }
                    if (player10 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player10", player10);
                    }
                    if (player11 == "")
                    {
                        querySearch.Parameters.AddWithValue("@player11", player11);
                    }
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            string SortDir = string.Empty;
                            if (dir == SortDirection.Ascending)
                            {
                                dir = SortDirection.Descending;
                                SortDir = "Desc";
                            }
                            else
                            {
                                dir = SortDirection.Ascending;
                                SortDir = "Asc";
                            }
                            DataView sortedView = new DataView(dataT);
                            sortedView.Sort = e.SortExpression + " " + SortDir;
                            grdPlayersMatchupWin.DataSource = sortedView;
                            grdPlayersMatchupWin.DataBind();
                            foreach (GridViewRow row in grdPlayersMatchupWin.Rows)
                            { row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0]; }
                            foreach (GridViewRow row in grdPlayersMatchupWin.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string teamA = row.Cells[0].Text;
                                string teamALink = row.Cells[0].Text.Split(' ')[0];
                                string teamALinkSpace = "";
                                if (teamA == knicks || teamA == pelicans || teamA == warriors ||
                                    teamA == clippers || teamA == thunder || teamA == lakers || teamA == spurs)
                                {
                                    teamALinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALinkSpace + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else if (teamA == blazers)
                                {
                                    teamALink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamALink + "\" style=\"color:white \" >" + teamA + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }  
    }
}