using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;

namespace NBA_SQL
{
    public partial class Hornets : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.BackColor = System.Drawing.Color.LightCyan; Button1.ForeColor = System.Drawing.Color.Black;
            Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button2.ForeColor = System.Drawing.Color.White;
            Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button3.ForeColor = System.Drawing.Color.White;
            Button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button4.ForeColor = System.Drawing.Color.White;
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = true;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button1.ForeColor = System.Drawing.Color.White;
            Button2.BackColor = System.Drawing.Color.LightCyan; Button2.ForeColor = System.Drawing.Color.Black;
            Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button3.ForeColor = System.Drawing.Color.White;
            Button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button4.ForeColor = System.Drawing.Color.White;
            GridView1.Visible = false;
            GridView2.Visible = true;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = true;
            GridView7.Visible = false;
            GridView8.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button1.ForeColor = System.Drawing.Color.White;
            Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button2.ForeColor = System.Drawing.Color.White;
            Button3.BackColor = System.Drawing.Color.LightCyan; Button3.ForeColor = System.Drawing.Color.Black;
            Button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button4.ForeColor = System.Drawing.Color.White;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = true;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = true;
            GridView8.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button1.ForeColor = System.Drawing.Color.White;
            Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button2.ForeColor = System.Drawing.Color.White;
            Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#1d1160"); Button3.ForeColor = System.Drawing.Color.White;
            Button4.BackColor = System.Drawing.Color.LightCyan; Button4.ForeColor = System.Drawing.Color.Black;
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = true;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView7.Visible = false;
            GridView8.Visible = true;
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q1AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView1.DataSource = sortedView;
                            GridView1.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q2AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView2.DataSource = sortedView;
                            GridView2.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView2.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q3AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView3.DataSource = sortedView;
                            GridView3.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView3.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void GridView4_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q4AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView4.DataSource = sortedView;
                            GridView4.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView4.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void GridView5_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q1LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView5.DataSource = sortedView;
                            GridView5.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView5.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
            }
        }
        protected void GridView6_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q2LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView6.DataSource = sortedView;
                            GridView6.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView6.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
            }
        }
        protected void GridView7_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q3LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView7.DataSource = sortedView;
                            GridView7.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView7.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
            }
        }
        protected void GridView8_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q4LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            GridView8.DataSource = sortedView;
                            GridView8.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView8.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                grdHornets.Visible = true;
                grdHornetsSeason.Visible = false;
                grdHornetsPerMin.Visible = false;
                grdW.Visible = false;
                PopulateRoster();
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                GridView5.Visible = false;
                GridView6.Visible = false;
                GridView7.Visible = false;
                GridView8.Visible = false;
            }
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
                        querySearch.Parameters.Add(new SqlParameter("@team", Title)); querySearch.Parameters.Add(new SqlParameter("@sourcePage", Title)); 
                        sqlConnect.Open();
                        querySearch.ExecuteScalar(); // Used for other than SELECT Queries
                        sqlConnect.Close();
                    }
                }
            }
        }
        protected void BindGrid()
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("q1AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView1.DataSource = dataT;
                            GridView1.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q2AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView2.DataSource = dataT;
                            GridView2.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView2.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q3AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView3.DataSource = dataT;
                            GridView3.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView3.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q4AvgP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView4.DataSource = dataT;
                            GridView4.DataBind();
                            int i = 0;
                            foreach (GridViewRow row in GridView4.Rows)
                            {
                                i++;
                                if (i >= 8)
                                {
                                    row.Visible = false;
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q1LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView5.DataSource = dataT;
                            GridView5.DataBind();
                            int i = 0;
                            int j = 0;
                            string p = "";
                            string date = "";
                            foreach (GridViewRow row in GridView5.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];

                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q2LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView6.DataSource = dataT;
                            GridView6.DataBind();
                            int i = 0; string date = "";
                            foreach (GridViewRow row in GridView6.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q3LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView7.DataSource = dataT;
                            GridView7.DataBind();
                            int i = 0; string date = "";
                            foreach (GridViewRow row in GridView7.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q4LogP"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            GridView8.DataSource = dataT;
                            GridView8.DataBind();
                            int i = 0; string date = "";
                            foreach (GridViewRow row in GridView8.Rows)
                            {
                                row.Cells[1].Text = row.Cells[1].Text.Split(' ')[0];
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("roster"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdHornets.DataSource = dataT;
                            grdHornets.DataBind();

                        }
                    }
                }

                using (SqlCommand querySearch = new SqlCommand("rosterseason"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdHornetsSeason.DataSource = dataT;
                            grdHornetsSeason.DataBind();

                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("rosterperminute"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdHornetsPerMin.DataSource = dataT;
                            grdHornetsPerMin.DataBind();

                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("teampage"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdTeam.DataSource = dataT;
                            grdTeam.DataBind();

                        }
                    }
                }

            }
        }


        protected void BtnPlayerGames_Click(object sender, EventArgs e) {if (chkRoster.SelectedValue == "") { lblPGError.Text = "Please select a player"; return; } else { lblPGError.Text = ""; 
         

            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = "Hornets";
                string player1 = chkRoster.SelectedValue;
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
                using (SqlCommand querySearch = new SqlCommand("seasonbox_playergames"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    ;
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
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
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
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
                            grdPlayerGames.DataSource = dataT;
                            grdPlayerGames.DataBind(); foreach (GridViewRow row in grdPlayerGames.Rows) { row.Cells[2].Text = row.Cells[2].Text.Split(' ')[0]; }
                            grdPlayerGames.Visible = true;
                            int i = 1;
                            foreach (GridViewRow row in grdPlayerGames.Rows)
                            {
                                if (row.Cells[1].Text != team)
                                {
                                    row.Cells[1].ForeColor = System.Drawing.Color.OrangeRed;
                                }
                                i++;
                                string matchup = row.Cells[0].Text;
                                string blazers = "vs. Trail Blazers";
                                string vs = "vs. ";
                                string team1 = row.Cells[0].Text.Split(' ')[1];
                                string teamLink = "";
                                string hex = "#1d1160"; //purple
                                string hex1 = "#00788c"; //blue
                                string white = "white";
                                if (matchup == blazers)
                                {
                                    teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    string teamLink1 = row.Cells[0].Text.Split(' ')[1] + ' ' + row.Cells[0].Text.Split(' ')[2];

                                    if (i % 2 == 0) //row
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                        row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White;\" >" + teamLink1 + "</a>";
                                    }
                                    else //alternating row
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White; \" >" +  teamLink1 + "</a>";
                                    }
                                }
                                else
                                {
                                    if (i % 2 == 0)
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                        row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" +  team1 + "</a>";

                                    }
                                    else
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                        row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" +  team1 + "</a>";
                                    }
                                }
                            }
                        }
                    }
                    }
                }
            }
        }
        protected void BtnPlayerWins_Click(object sender, EventArgs e)
        {
            if (chkRoster.SelectedValue == "")
            {
                LabelError.Text = "Please select a player";
                return;
            }
            else
            {
                LabelError.Text = "";
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
                using (sqlConnect)
                {

                    string team = "Hornets";
                    string player1 = chkRoster.SelectedValue;
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
                    using (SqlCommand querySearch = new SqlCommand("seasonbox_playersinwin"))
                    {
                        querySearch.CommandType = CommandType.StoredProcedure;
                        ;
                        querySearch.Parameters.AddWithValue("@player1", player1);
                        foreach (ListItem listitem in chkRoster.Items)
                        {
                            if (listitem.Selected)
                            {
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
                                if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && player6 == "")
                                {
                                    player6 = listitem.Text;
                                    querySearch.Parameters.AddWithValue("@player6", player6);
                                }
                                if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && player7 == "")
                                {
                                    player7 = listitem.Text;
                                    querySearch.Parameters.AddWithValue("@player7", player7);
                                }
                                if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                                {
                                    player8 = listitem.Text;
                                    querySearch.Parameters.AddWithValue("@player8", player8);
                                }
                                if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                                {
                                    player9 = listitem.Text;
                                    querySearch.Parameters.AddWithValue("@player9", player9);
                                }
                                if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                                {
                                    player10 = listitem.Text;
                                    querySearch.Parameters.AddWithValue("@player10", player10);
                                }
                                if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                                {
                                    player11 = listitem.Text;
                                    querySearch.Parameters.AddWithValue("@player11", player11);
                                }
                            }
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
                                grdPlayerWins.DataSource = dataT;
                                grdPlayerWins.DataBind(); foreach (GridViewRow row in grdPlayerWins.Rows) { row.Cells[2].Text = row.Cells[2].Text.Split(' ')[0]; }
                                grdPlayerWins.Visible = true;
                                int i = 1;
                                foreach (GridViewRow row in grdPlayerWins.Rows)
                                {
                                    if (row.Cells[1].Text != team)
                                    {
                                        row.Cells[1].ForeColor = System.Drawing.Color.OrangeRed;
                                    }
                                    i++;
                                    string matchup = row.Cells[0].Text;
                                    string blazers = "vs. Trail Blazers";
                                    string vs = "vs. ";
                                    string team1 = row.Cells[0].Text.Split(' ')[1];
                                    string teamLink = "";
                                    string hex = "#1d1160"; //purple
                                    string hex1 = "#00788c"; //blue
                                    string white = "white";
                                    if (matchup == blazers)
                                    {
                                        teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                        string teamLink1 = row.Cells[0].Text.Split(' ')[1] + ' ' + row.Cells[0].Text.Split(' ')[2];

                                        if (i % 2 == 0) //row
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                            row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White;\" >" + teamLink1 + "</a>";
                                        }
                                        else //alternating row
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White; \" >" + teamLink1 + "</a>";
                                        }
                                    }
                                    else
                                    {
                                        if (i % 2 == 0)
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                            row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" + team1 + "</a>";

                                        }
                                        else
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                            row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" + team1 + "</a>";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void BtnPlayerWinsHide_Click(object sender, EventArgs e) { grdPlayerWins.Visible = false; }
        protected void BtnPlayerGamesHide_Click(object sender, EventArgs e) { grdPlayerGames.Visible = false; }

        protected void BtnPG_Click(object sender, EventArgs e)
        {
            grdHornets.Visible = true;
            grdHornetsSeason.Visible = false; grdW.Visible = false;
            grdHornetsPerMin.Visible = false;
        }

        protected void BtnSeason_Click(object sender, EventArgs e)
        {
            grdHornets.Visible = false;
            grdHornetsSeason.Visible = true; grdW.Visible = false;
            grdHornetsPerMin.Visible = false;
        }
        protected void BtnPM_Click(object sender, EventArgs e)
        {
            grdHornets.Visible = false;
            grdHornetsSeason.Visible = false; grdW.Visible = false;
            grdHornetsPerMin.Visible = true;
        }

        protected void grdTeam_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;

        }

        protected void grdHornets_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("roster"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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

                            grdHornets.DataSource = sortedView;
                            grdHornets.DataBind();
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

        protected void grdHornetsSeason_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("rosterseason"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            grdHornetsSeason.DataSource = sortedView;
                            grdHornetsSeason.DataBind();
                        }
                    }
                }
            }

        }

        protected void grdHornetsPerMin_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("rosterperminute"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);

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
                            grdHornetsPerMin.DataSource = sortedView;
                            grdHornetsPerMin.DataBind();
                        }
                    }
                }
            }

        }

        protected void grdPlayerWins_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = "Hornets";
                string player1 = chkRoster.SelectedValue;
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
                using (SqlCommand querySearch = new SqlCommand("seasonbox_playersinwin"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    ;
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
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
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
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
                                grdPlayerWins.DataSource = sortedView;
                                grdPlayerWins.DataBind(); foreach (GridViewRow row in grdPlayerWins.Rows) { row.Cells[2].Text = row.Cells[2].Text.Split(' ')[0]; }
                                int i = 1;
                                foreach (GridViewRow row in grdPlayerWins.Rows)
                                {
                                    if (row.Cells[1].Text != team)
                                    {
                                        row.Cells[1].ForeColor = System.Drawing.Color.OrangeRed;
                                    }
                                    i++;
                                    string matchup = row.Cells[0].Text;
                                    string blazers = "vs. Trail Blazers";
                                    string vs = "vs. ";
                                    string team1 = row.Cells[0].Text.Split(' ')[1];
                                    string teamLink = "";
                                    string hex = "#1d1160"; //purple
                                    string hex1 = "#00788c"; //blue
                                    string white = "white";
                                    if (matchup == blazers)
                                    {
                                        teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                        string teamLink1 = row.Cells[0].Text.Split(' ')[1] + ' ' + row.Cells[0].Text.Split(' ')[2];

                                        if (i % 2 == 0) //row
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                            row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White;\" >" + teamLink1 + "</a>";
                                        }
                                        else //alternating row
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White; \" >" +  teamLink1 + "</a>";
                                        }
                                    }
                                    else
                                    {
                                        if (i % 2 == 0)
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                            row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" +  team1 + "</a>";

                                        }
                                        else
                                        {
                                            row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                            row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" +  team1 + "</a>";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void grdPlayerGames_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = "Hornets";
                string player1 = chkRoster.SelectedValue;
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
                using (SqlCommand querySearch = new SqlCommand("seasonbox_playergames"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    ;
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        if (listitem.Selected)
                        {
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
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && player6 == "")
                            {
                                player6 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player6", player6);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && player7 == "")
                            {
                                player7 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player7", player7);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && player8 == "")
                            {
                                player8 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player8", player8);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && player9 == "")
                            {
                                player9 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player9", player9);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && player10 == "")
                            {
                                player10 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player10", player10);
                            }
                            if (listitem.Text != player1 && listitem.Text != player2 && listitem.Text != player3 && listitem.Text != player4 && listitem.Text != player5 && listitem.Text != player6 && listitem.Text != player7 && listitem.Text != player8 && listitem.Text != player9 && listitem.Text != player10 && listitem.Text != player11 && player11 == "")
                            {
                                player11 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player11", player11);
                            }
                        }
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
                            grdPlayerGames.DataSource = sortedView;
                            grdPlayerGames.DataBind(); foreach (GridViewRow row in grdPlayerGames.Rows) { row.Cells[2].Text = row.Cells[2].Text.Split(' ')[0]; }
                            int i = 1;
                            foreach (GridViewRow row in grdPlayerGames.Rows)
                            {
                                if (row.Cells[1].Text != team)
                                {
                                    row.Cells[1].ForeColor = System.Drawing.Color.OrangeRed;
                                }
                                i++;
                                string matchup = row.Cells[0].Text;
                                string blazers = "vs. Trail Blazers";
                                string vs = "vs. ";
                                string team1 = row.Cells[0].Text.Split(' ')[1];
                                string teamLink = "";
                                string hex = "#1d1160"; //purple
                                string hex1 = "#00788c"; //blue
                                string white = "white";
                                if (matchup == blazers)
                                {
                                    teamLink = row.Cells[0].Text.Split(' ')[1] + row.Cells[0].Text.Split(' ')[2];
                                    string teamLink1 = row.Cells[0].Text.Split(' ')[1] + ' ' + row.Cells[0].Text.Split(' ')[2];

                                    if (i % 2 == 0) //row
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                        row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White;\" >" + teamLink1 + "</a>";
                                    }
                                    else //alternating row
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].Text = "<a href=\"/" + teamLink + "\" style=\"color:White; \" >" +  teamLink1 + "</a>";
                                    }
                                }
                                else
                                {
                                    if (i % 2 == 0)
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                        row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" +  team1 + "</a>";

                                    }
                                    else
                                    {
                                        row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].BorderColor = System.Drawing.ColorTranslator.FromHtml(hex1);
                                        row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml(white);
                                        row.Cells[0].Text = "<a href=\"/" + team1 + "\" style=\"color:White; \" >" +  team1 + "</a>";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void PopulateRoster()
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("Hornets"))
                {
                    querySearch.Connection = sqlConnect;

                    querySearch.CommandType = CommandType.StoredProcedure;

                    sqlConnect.Open();
                    using (SqlDataReader sdr = querySearch.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["player_name"].ToString();
                            chkRoster.Items.Add(item);
                        }
                    }
                    sqlConnect.Close();
                }
            }
        }
       
        protected void grdW_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grdW_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("winAvg"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
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
                            grdW.DataSource = sortedView;
                            grdW.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnW_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string team = "Hornets";
                using (SqlCommand querySearch = new SqlCommand("winAvg"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdW.DataSource = dataT;
                            grdW.DataBind();

                        }
                    }
                }
            }
            grdHornets.Visible = false;
            grdHornetsSeason.Visible = false;
            grdHornetsPerMin.Visible = false;
            grdW.Visible = true;
        }
    }
}

