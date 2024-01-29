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
    public partial class DNP_Stats : System.Web.UI.Page
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
        protected void PopulateRoster()
        {
            lblError.Text = "";
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
                            chkRoster.Items.Add(item);
                        }
                    }
                    sqlConnect.Close();
                }
            }
        }
      
        protected void ddTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            chkRoster.ClearSelection();
            chkRoster.Items.Clear();
            PopulateRoster();
            grdStats.DataSource = null; 
            grdStats.DataBind(); 
            if (Session["User"] != null || Session["Admin"] != null)
            {
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;"); 
                using (sqlConnect)
                {
                    using (SqlCommand querySearch = new SqlCommand("INSERT INTO userTeams (username, team, sourcePage, datetime) VALUES(@username, @team, @sourcePage, CAST(GETDATE() as datetime))"))
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

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = ddTeams.SelectedValue;
                string player1 = chkRoster.SelectedValue;

                using (SqlCommand querySearch = new SqlCommand("dnp"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdStats.DataSource = dataT;
                            grdStats.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnRetrieve2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = ddTeams.SelectedValue;
                string player1 = chkRoster.SelectedValue;
                string player2 = "";


                using (SqlCommand querySearch = new SqlCommand("dnp2p"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    foreach (ListItem listitem in chkRoster.Items)
                    {
                        
                        if (listitem.Selected)
                        {

                            if (listitem.Text != player1)
                            {
                                player2 = listitem.Text;
                                
                                querySearch.Parameters.AddWithValue("@player2", player2);
                            }                                                    
                        }                                                     
                    } 
                    
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        if (player2 == "")
                        {
                            lblError.Text = "Please select a second player";
                            return;
                        }
                        else
                        {
                            lblError.Text = "";

                            querySearch.Connection = sqlConnect;
                            sDataSearch.SelectCommand = querySearch;
                            using (DataTable dataT = new DataTable())
                            {
                                sDataSearch.Fill(dataT);
                                grdStats.DataSource = dataT;
                                grdStats.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void btnRetrieveW_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = ddTeams.SelectedValue;
                string player1 = chkRoster.SelectedValue;

                using (SqlCommand querySearch = new SqlCommand("dnpW"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdStats.DataSource = dataT;
                            grdStats.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnRetrieve2W_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                string team = ddTeams.SelectedValue;
                string player1 = chkRoster.SelectedValue;
                string player2 = "";


                using (SqlCommand querySearch = new SqlCommand("dnp2pW"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@team", team);
                    querySearch.Parameters.AddWithValue("@player1", player1);
                    foreach (ListItem listitem in chkRoster.Items)
                    {

                        if (listitem.Selected)
                        {

                            if (listitem.Text != player1)
                            {
                                player2 = listitem.Text;
                                querySearch.Parameters.AddWithValue("@player2", player2);
                            }
                        }
                    }

                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        if (player2 == "")
                        {
                            lblError.Text = "Please select a second player";
                            return;
                        }
                        else
                        {
                            lblError.Text = "";
                            querySearch.Connection = sqlConnect;
                            sDataSearch.SelectCommand = querySearch;
                            using (DataTable dataT = new DataTable())
                            {
                                sDataSearch.Fill(dataT);
                                grdStats.DataSource = dataT;
                                grdStats.DataBind();
                            }
                        }
                    }
                }
            }
        }
    }
}