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
    public partial class shotTesting : System.Web.UI.Page
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
            }
        }

        protected void ddTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlRoster.ClearSelection();
            ddlRoster.Items.Clear();
            PopulateRoster();
            //grdStats.DataSource = null;
            //grdStats.DataBind();
            grdShots.Visible = false;
            grdShots1_10.Visible = false;
            grdShots10_30.Visible = false;
            grd3.Visible = false;
            grd10_23.Visible = false;
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

        protected void PopulateRoster()
        {
            string team = ddTeams.SelectedValue;
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
                            ddlRoster.Items.Add(item);
                        }
                    }
                    ListItem emptyItem = new ListItem("Player", "");
                    ddlRoster.Items.Insert(0, emptyItem);
                    sqlConnect.Close();
                }
            }
        }

        protected void ddlRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdShots.DataSource = null;
            grdShots.DataBind();
            PopulateShots();
            grdShots.Visible = true;
            grdShots1_10.Visible = true;
            grdShots10_30.Visible = true;
            grd3.Visible = true;
            grd10_23.Visible = true;
            if (Session["User"] != null || Session["Admin"] != null)
            {
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
                using (sqlConnect)
                {
                    using (SqlCommand querySearch = new SqlCommand("INSERT INTO userPlayers(username, player, sourcePage, datetime) VALUES(@username, @player, @sourcePage, CAST(GETDATE() as datetime))"))
                    {
                        querySearch.Connection = sqlConnect;
                        querySearch.CommandType = CommandType.Text;
                        querySearch.Parameters.AddWithValue("@username", Session["User"]);
                        querySearch.Parameters.Add(new SqlParameter("@player", ddlRoster.SelectedValue.ToString())); querySearch.Parameters.Add(new SqlParameter("@sourcePage", Title)); 
                        sqlConnect.Open();
                        querySearch.ExecuteScalar(); // Used for other than SELECT Queries
                        sqlConnect.Close();
                    }
                }
            }
        }
        protected void PopulateShots()
        {
            string player = ddlRoster.SelectedValue;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                using (SqlCommand querySearch = new SqlCommand("shotsProcedure"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;

                    querySearch.Parameters.AddWithValue("@player", player);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdShots.DataSource = dataT;
                            grdShots.DataBind();
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("shotsP1_5"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;

                    querySearch.Parameters.AddWithValue("@player", player);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdShots10_30.DataSource = dataT;
                            grdShots10_30.DataBind();
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("shotsP5_10"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;

                    querySearch.Parameters.AddWithValue("@player", player);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdShots1_10.DataSource = dataT;
                            grdShots1_10.DataBind();
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("shotsP10_23"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;

                    querySearch.Parameters.AddWithValue("@player", player);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grd10_23.DataSource = dataT;
                            grd10_23.DataBind();
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("shotsP3pt"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;

                    querySearch.Parameters.AddWithValue("@player", player);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grd3.DataSource = dataT;
                            grd3.DataBind();
                        }
                    }
                }
            }
        }
    }
}
