using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_SQL
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("east_rank"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdEast.DataSource = dataT;
                            grdEast.DataBind();
                            foreach (GridViewRow row in grdEast.Rows)
                            {
                                string knicks = "(NYK)New York Knicks";
                                string team = row.Cells[0].Text;
                                string teamLink = row.Cells[0].Text.Split(' ')[1];
                                string teamLinkSpace = "";
                                if (team == knicks)
                                {
                                    teamLinkSpace = row.Cells[0].Text.Split(' ')[2];
                                    row.Cells[0].Text = "<a href=\"/" + teamLinkSpace + "\" style=\"color:white \" >" + team + "</a>";
                                }                               
                                else
                                {
                                    row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:white \" >" + team + "</a>";
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("west_rank"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdWest.DataSource = dataT;
                            grdWest.DataBind();
                            foreach (GridViewRow row in grdWest.Rows)
                            {                              
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
                                if (team == pelicans || team == warriors || team == lakers ||
                                    team == clippers || team == thunder  || team == spurs)
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
                using (SqlCommand querySearch = new SqlCommand("yesterdaygames"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdYesterday.DataSource = dataT;
                            grdYesterday.DataBind();
                            foreach (GridViewRow row in grdYesterday.Rows)
                            {
                                string team  = row.Cells[0].Text;
                                string team2 = row.Cells[2].Text;
                                row.Cells[0].Text = "<a href=\"/" + team + "\" style=\"color:white \" >" + team + "</a>";
                                row.Cells[2].Text = "<a href=\"/" + team2 + "\" style=\"color:white \" >" + team2 + "</a>";
                            }

                        }
                    }
                }



            }
        }
    }
}
