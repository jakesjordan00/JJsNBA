using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_SQL
{
    public partial class Teams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                grdTeams.Visible = true;
                grdOteams.Visible = false;
            }
        }

        private void BindGrid()
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand query = new SqlCommand("teamspage"))
                {
                    query.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sData = new SqlDataAdapter())
                    {
                        query.Connection = sqlConnect;
                        sData.SelectCommand = query;
                        using (DataTable dataT = new DataTable())
                        {
                            sData.Fill(dataT);
                            grdTeams.DataSource = dataT;
                            grdTeams.DataBind();
                            foreach (GridViewRow row in grdTeams.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string team = row.Cells[0].Text;
                                string teamLink = row.Cells[0].Text.Split(' ')[1];
                                string teamLinkSpace = "";                               
                                if (team == knicks   || team == pelicans || team == warriors ||
                                    team == clippers || team == thunder  || team == lakers   || team == spurs)
                                {
                                    teamLinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLinkSpace + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else if (team == blazers)
                                {
                                    teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }                             
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                } 
                            }
                        }
                    }
                }
                using (SqlCommand query = new SqlCommand("oTeamspage"))
                {
                    query.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sData = new SqlDataAdapter())
                    {
                        query.Connection = sqlConnect;
                        sData.SelectCommand = query;
                        using (DataTable dataT = new DataTable())
                        {
                            sData.Fill(dataT);
                            grdOteams.DataSource = dataT;
                            grdOteams.DataBind();
                            foreach (GridViewRow row in grdOteams.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string team = row.Cells[0].Text;
                                string teamLink = row.Cells[0].Text.Split(' ')[1];
                                string teamLinkSpace = "";
                                if (team == knicks || team == pelicans || team == warriors ||
                                    team == clippers || team == thunder || team == lakers || team == spurs)
                                {
                                    teamLinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLinkSpace + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else if (team == blazers)
                                {
                                    teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void grdTeams_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand query = new SqlCommand("teamspage"))
                {
                    query.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sData = new SqlDataAdapter())
                    {
                        query.Connection = sqlConnect;
                        sData.SelectCommand = query;
                        using (DataTable dataT = new DataTable())
                        {
                            sData.Fill(dataT);
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
                            grdTeams.DataSource = sortedView;
                            grdTeams.DataBind();
                            foreach (GridViewRow row in grdTeams.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string team = row.Cells[0].Text;
                                string teamLink = row.Cells[0].Text.Split(' ')[1];
                                string teamLinkSpace = "";
                                if (team == knicks || team == pelicans || team == warriors ||
                                    team == clippers || team == thunder || team == lakers || team == spurs)
                                {
                                    teamLinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLinkSpace + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else if (team == blazers)
                                {
                                    teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }
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

        protected void grdOteams_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand query = new SqlCommand("oTeamspage"))
                {
                    query.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sData = new SqlDataAdapter())
                    {
                        query.Connection = sqlConnect;
                        sData.SelectCommand = query;
                        using (DataTable dataT = new DataTable())
                        {
                            sData.Fill(dataT);
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
                            grdOteams.DataSource = sortedView;
                            grdOteams.DataBind();
                            foreach (GridViewRow row in grdOteams.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string pelicans = "(NOP)New Orleans Pelicans";
                                string warriors = "(GSW)Golden State Warriors";
                                string clippers = "(LAC)Los Angeles Clippers";
                                string blazers = "(POR)Portland Trail Blazers";
                                string thunder = "(OKC)Oklahoma City Thunder";
                                string lakers = "(LAL)Los Angeles Lakers";
                                string spurs = "(SAS)San Antonio Spurs";

                                string team = row.Cells[0].Text;
                                string teamLink = row.Cells[0].Text.Split(' ')[1];
                                string teamLinkSpace = "";
                                if (team == knicks || team == pelicans || team == warriors ||
                                    team == clippers || team == thunder || team == lakers || team == spurs)
                                {
                                    teamLinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLinkSpace + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else if (team == blazers)
                                {
                                    teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnTeams_Click(object sender, EventArgs e)
        {
            grdTeams.Visible = true;
            grdOteams.Visible = false;
        }

        protected void btnOteams_Click(object sender, EventArgs e)
        {
            grdTeams.Visible = false;
            grdOteams.Visible = true;
        }
    }
}