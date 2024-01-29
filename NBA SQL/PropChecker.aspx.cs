using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.Ajax.Utilities;

namespace NBA_SQL
{
    public partial class PropChecker : System.Web.UI.Page
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
            ddlInjured.ClearSelection();
            ddlInjured.Items.Clear();
            PopulateInjuries();
            grdpts.DataSource = null;
            grdpts.Visible = false;
            grdast.Visible = false;
            grdreb.Visible = false;
            grdstl.Visible = false;
            grd3.Visible = false;
            grdblk.Visible = false;
            //grdShots10_30.Visible = false;
            //grd3.Visible = false;
            //grd10_23.Visible = false;
            grdstlplus.Visible = false;
            grdptsplus.Visible = false;
            grdrebplus.Visible = false;
            grdastplus.Visible = false;
            grdblkplus.Visible = false;
            grd3plus.Visible = false;
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
        protected void PopulateInjuries()
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
                            ddlInjured.Items.Add(item);
                            
                        }
                    }
                    ListItem emptyItem = new ListItem("Injured Teammate", "");
                    ddlInjured.Items.Insert(0, emptyItem);
                    sqlConnect.Close();
                }
            }
        }

        protected void ddlRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grdShots.DataSource = null;
            //grdShots.DataBind();
            PopulateProps();
            grdpts.Visible = true;
            grdast.Visible = true;
            grdreb.Visible = true;
            grdstl.Visible = true;
            grd3.Visible = true;
            grdblk.Visible = true;
            //grd3.Visible = true;
            //grd10_23.Visible = true;
            grdstlplus.Visible = false;
            grdptsplus.Visible = false;
            grdrebplus.Visible = false;
            grdastplus.Visible = false;
            grdblkplus.Visible = false;
            grd3plus.Visible = false;
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
        protected void PopulateProps()
        {
            Label1.Text = "All Games";
            btnwins.Visible = true;
            btnp.Visible = true;
            btna.Visible = true;
            btnr.Visible = true;
            btn3s.Visible = true;
            btnb.Visible = true;
            btns.Visible = true;
            btnAll.Visible = false;
            grdpts.Visible = true;
            grdast.Visible = true;
            grdreb.Visible = true;
            grdstl.Visible = true;
            grd3.Visible = true;
            grdblk.Visible = true;


            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {

                if (chkInjury.Checked == true)
                {
                    ArrayList players = new ArrayList();
                    ArrayList iPlayers = new ArrayList();
                    foreach (ListItem item in ddlRoster.Items)
                    {
                        players.Add(ddlInjured.Items);
                    }
                    foreach (ListItem item in ddlInjured.Items)
                    {
                        iPlayers.Add(ddlInjured.Items);
                    }

                    string player = ddlRoster.SelectedValue;
                    string injured = ddlInjured.SelectedValue;
                    if (player == injured)
                    {
                        lblError.Text = "Please select two different players"; ;
                    }
                    else
                    {
                        lblError.Text = "";
                        using (SqlCommand querySearch = new SqlCommand("propptsInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdpts.DataSource = dataT;
                                    grdpts.DataBind();
                                    foreach (GridViewRow row in grdpts.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propastInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdast.DataSource = dataT;
                                    grdast.DataBind();
                                    foreach (GridViewRow row in grdast.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("proprebInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdreb.DataSource = dataT;
                                    grdreb.DataBind();
                                    foreach (GridViewRow row in grdreb.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3Injured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grd3.DataSource = dataT;
                                    grd3.DataBind();
                                    foreach (GridViewRow row in grd3.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }

                        }
                        using (SqlCommand querySearch = new SqlCommand("propblkInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdblk.DataSource = dataT;
                                    grdblk.DataBind();
                                    foreach (GridViewRow row in grdblk.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propstlInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdstl.DataSource = dataT;
                                    grdstl.DataBind();
                                    foreach (GridViewRow row in grdstl.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblError.Text = "";
                    string player = ddlRoster.SelectedValue;
                    using (SqlCommand querySearch = new SqlCommand("propPoints"))
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
                                grdpts.DataSource = dataT;
                                grdpts.DataBind();
                                foreach (GridViewRow row in grdpts.Rows)
                                {
                                    if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                    {
                                        row.Cells[4].Text = "+" + row.Cells[4].Text;
                                    }
                                }
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("propAssists"))
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
                                grdast.DataSource = dataT;
                                grdast.DataBind();
                                foreach (GridViewRow row in grdast.Rows)
                                {
                                    if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                    {
                                        row.Cells[4].Text = "+" + row.Cells[4].Text;
                                    }
                                }
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("propRebounds"))
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
                                grdreb.DataSource = dataT;
                                grdreb.DataBind();
                                foreach (GridViewRow row in grdreb.Rows)
                                {
                                    if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                    {
                                        row.Cells[4].Text = "+" + row.Cells[4].Text;
                                    }
                                }
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("prop3s"))
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
                                foreach (GridViewRow row in grd3.Rows)
                                {
                                    if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                    {
                                        row.Cells[4].Text = "+" + row.Cells[4].Text;
                                    }
                                }
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("propBlocks"))
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
                                grdblk.DataSource = dataT;
                                grdblk.DataBind();
                                foreach (GridViewRow row in grdblk.Rows)
                                {
                                    if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                    {
                                        row.Cells[4].Text = "+" + row.Cells[4].Text;
                                    }
                                }
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("propSteals"))
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
                                grdstl.DataSource = dataT;
                                grdstl.DataBind();
                                foreach (GridViewRow row in grdstl.Rows)
                                {
                                    if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                    {
                                        row.Cells[4].Text = "+" + row.Cells[4].Text;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnwins_Click(object sender, EventArgs e)
        {
            ArrayList players = new ArrayList();
            ArrayList iPlayers = new ArrayList();
            grdpts.DataSource = null;
            grdpts.DataBind();
            grdast.DataSource = null;
            grdast.DataBind();
            grdreb.DataSource = null;
            grdreb.DataBind();


            Label1.Text = "Wins";
            btnAll.Visible = true;
            btnwins.Visible = false;
            int i = 0;
            int j = 0;
            foreach (ListItem item in ddlRoster.Items)
            {
                players.Add(ddlInjured.Items);
            }
            foreach (ListItem item in ddlInjured.Items)
            {
                iPlayers.Add(ddlInjured.Items);
            }

            string player = ddlRoster.SelectedValue;
            string injured = ddlInjured.SelectedValue;
            if (player == injured)
            {
                lblError.Text = "Please select two different players"; ;
            }
            else
            {
                lblError.Text = "";


                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
                using (sqlConnect)
                {
                    if (chkInjury.Checked == true)
                    {
                        using (SqlCommand querySearch = new SqlCommand("propptsInjuredW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdpts.DataSource = dataT;
                                    grdpts.DataBind();
                                    foreach (GridViewRow row in grdpts.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propastInjuredW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdast.DataSource = dataT;
                                    grdast.DataBind();
                                    foreach (GridViewRow row in grdast.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("proprebInjuredW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdreb.DataSource = dataT;
                                    grdreb.DataBind();
                                    foreach (GridViewRow row in grdreb.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3InjuredW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grd3.DataSource = dataT;
                                    grd3.DataBind();
                                    foreach (GridViewRow row in grd3.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propblkInjuredW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdblk.DataSource = dataT;
                                    grdblk.DataBind();
                                    foreach (GridViewRow row in grdblk.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propstlInjuredW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdstl.DataSource = dataT;
                                    grdstl.DataBind();
                                    foreach (GridViewRow row in grdstl.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propptsInjuredPlusW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdptsplus.DataSource = dataT;
                                    grdptsplus.DataBind();
                                    foreach (GridViewRow row in grdptsplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propastInjuredPlusW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdastplus.DataSource = dataT;
                                    grdastplus.DataBind();
                                    foreach (GridViewRow row in grdastplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("proprebInjuredPlusW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdrebplus.DataSource = dataT;
                                    grdrebplus.DataBind();
                                    foreach (GridViewRow row in grdrebplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3InjuredPlusW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grd3plus.DataSource = dataT;
                                    grd3plus.DataBind();
                                    foreach (GridViewRow row in grd3plus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propblkInjuredPlusW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdblkplus.DataSource = dataT;
                                    grdblkplus.DataBind();
                                    foreach (GridViewRow row in grdblkplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propstlInjuredPlusW"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdstlplus.DataSource = dataT;
                                    grdstlplus.DataBind();
                                    foreach (GridViewRow row in grdstlplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                        lblError.Text = "";
                        using (SqlCommand querySearch = new SqlCommand("propPointsW"))
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
                                    grdpts.DataSource = dataT;
                                    grdpts.DataBind();
                                    foreach (GridViewRow row in grdpts.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propAssistsW"))
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
                                    grdast.DataSource = dataT;
                                    grdast.DataBind();
                                    foreach (GridViewRow row in grdast.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propReboundsW"))
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
                                    grdreb.DataSource = dataT;
                                    grdreb.DataBind();
                                    foreach (GridViewRow row in grdreb.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3sW"))
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
                                    foreach (GridViewRow row in grd3.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propBlocksW"))
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
                                    grdblk.DataSource = dataT;
                                    grdblk.DataBind();
                                    foreach (GridViewRow row in grdblk.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propStealsW"))
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
                                    grdstl.DataSource = dataT;
                                    grdstl.DataBind();
                                    foreach (GridViewRow row in grdstl.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propPointsPlusW"))
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
                                    grdptsplus.DataSource = dataT;
                                    grdptsplus.DataBind();
                                    foreach (GridViewRow row in grdptsplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propAssistsPlusW"))
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
                                    grdastplus.DataSource = dataT;
                                    grdastplus.DataBind();
                                    foreach (GridViewRow row in grdastplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propReboundsPlusW"))
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
                                    grdrebplus.DataSource = dataT;
                                    grdrebplus.DataBind();
                                    foreach (GridViewRow row in grdrebplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3sPlusW"))
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
                                    grd3plus.DataSource = dataT;
                                    grd3plus.DataBind();
                                    foreach (GridViewRow row in grd3plus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propStealsPlusW"))
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
                                    grdstlplus.DataSource = dataT;
                                    grdstlplus.DataBind();
                                    foreach (GridViewRow row in grdstlplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propBlocksPlusW"))
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
                                    grdblkplus.DataSource = dataT;
                                    grdblkplus.DataBind();
                                    foreach (GridViewRow row in grdblkplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            grdpts.DataSource = null;
            grdpts.DataBind();
            grdast.DataSource = null;
            grdast.DataBind();
            grdreb.DataSource = null;
            grdreb.DataBind();
            ArrayList players = new ArrayList();
            ArrayList iPlayers = new ArrayList();

            Label1.Text = "All games";
            btnAll.Visible = false;
            btnwins.Visible = true;
            int i = 0;
            int j = 0;
            foreach (ListItem item in ddlRoster.Items)
            {
                players.Add(ddlInjured.Items);
            }
            foreach (ListItem item in ddlInjured.Items)
            {
                iPlayers.Add(ddlInjured.Items);
            }

            string player = ddlRoster.SelectedValue;
            string injured = ddlInjured.SelectedValue;
            if (player == injured)
            {
                lblError.Text = "Please select two different players"; ;
            }
            else
            {
                lblError.Text = "";
                SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
                using (sqlConnect)
                {
                    if (chkInjury.Checked == true)
                    {
                        using (SqlCommand querySearch = new SqlCommand("propptsInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdpts.DataSource = dataT;
                                    grdpts.DataBind();
                                    foreach (GridViewRow row in grdpts.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propastInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdast.DataSource = dataT;
                                    grdast.DataBind();
                                    foreach (GridViewRow row in grdast.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("proprebInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdreb.DataSource = dataT;
                                    grdreb.DataBind();
                                    foreach (GridViewRow row in grdreb.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3Injured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grd3.DataSource = dataT;
                                    grd3.DataBind();
                                    foreach (GridViewRow row in grd3.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propblkInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdblk.DataSource = dataT;
                                    grdblk.DataBind();
                                    foreach (GridViewRow row in grdblk.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propstlInjured"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdstl.DataSource = dataT;
                                    grdstl.DataBind();
                                    foreach (GridViewRow row in grdstl.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propptsInjuredPlus"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdptsplus.DataSource = dataT;
                                    grdptsplus.DataBind();
                                    foreach (GridViewRow row in grdptsplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propastInjuredPlus"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdastplus.DataSource = dataT;
                                    grdastplus.DataBind();
                                    foreach (GridViewRow row in grdastplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("proprebInjuredPlus"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdrebplus.DataSource = dataT;
                                    grdrebplus.DataBind();
                                    foreach (GridViewRow row in grdrebplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3InjuredPlus"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grd3plus.DataSource = dataT;
                                    grd3plus.DataBind();
                                    foreach (GridViewRow row in grd3plus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propblkInjuredPlus"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdblkplus.DataSource = dataT;
                                    grdblkplus.DataBind();
                                    foreach (GridViewRow row in grdblkplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propstlInjuredPlus"))
                        {
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@player", player);
                            querySearch.Parameters.AddWithValue("@injured", injured);
                            using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                            {
                                querySearch.Connection = sqlConnect;
                                sDataSearch.SelectCommand = querySearch;
                                using (DataTable dataT = new DataTable())
                                {
                                    sDataSearch.Fill(dataT);
                                    grdstlplus.DataSource = dataT;
                                    grdstlplus.DataBind();
                                    foreach (GridViewRow row in grdstlplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        using (SqlCommand querySearch = new SqlCommand("propPoints"))
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
                                    grdpts.DataSource = dataT;
                                    grdpts.DataBind();
                                    foreach (GridViewRow row in grdpts.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propAssists"))
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
                                    grdast.DataSource = dataT;
                                    grdast.DataBind();
                                    foreach (GridViewRow row in grdast.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propRebounds"))
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
                                    grdreb.DataSource = dataT;
                                    grdreb.DataBind();
                                    foreach (GridViewRow row in grdreb.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3s"))
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
                                    foreach (GridViewRow row in grd3.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propBlocks"))
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
                                    grdblk.DataSource = dataT;
                                    grdblk.DataBind();
                                    foreach (GridViewRow row in grdblk.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propSteals"))
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
                                    grdstl.DataSource = dataT;
                                    grdstl.DataBind();
                                    foreach (GridViewRow row in grdstl.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propPointsPlus"))
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
                                    grdptsplus.DataSource = dataT;
                                    grdptsplus.DataBind();
                                    foreach (GridViewRow row in grdptsplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propAssistsPlus"))
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
                                    grdastplus.DataSource = dataT;
                                    grdastplus.DataBind();
                                    foreach (GridViewRow row in grdastplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propReboundsPlus"))
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
                                    grdrebplus.DataSource = dataT;
                                    grdrebplus.DataBind();
                                    foreach (GridViewRow row in grdrebplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("prop3sPlus"))
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
                                    grd3plus.DataSource = dataT;
                                    grd3plus.DataBind();
                                    foreach (GridViewRow row in grd3plus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propStealsPlus"))
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
                                    grdstlplus.DataSource = dataT;
                                    grdstlplus.DataBind();
                                    foreach (GridViewRow row in grdstlplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                        using (SqlCommand querySearch = new SqlCommand("propBlocksPlus"))
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
                                    grdblkplus.DataSource = dataT;
                                    grdblkplus.DataBind();
                                    foreach (GridViewRow row in grdblkplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btns_Click(object sender, EventArgs e)
        {
            grdstlplus.Visible = true;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string player = ddlRoster.SelectedValue;
                string injured = ddlInjured.SelectedValue;
                if (player == injured)
                {
                    lblError.Text = "Please select two different players"; ;
                }
                else
                {
                    if (chkInjury.Checked == true)
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("propstlInjuredPlus"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdstlplus.DataSource = dataT;
                                        grdstlplus.DataBind();
                                        foreach (GridViewRow row in grdstlplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("propstlInjuredPlusW"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdstlplus.DataSource = dataT;
                                        grdstlplus.DataBind();
                                        foreach (GridViewRow row in grdstlplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (Label1.Text == "All Games")
                    {
                        using (SqlCommand querySearch = new SqlCommand("propStealsPlus"))
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
                                    grdstlplus.DataSource = dataT;
                                    grdstlplus.DataBind();
                                    foreach (GridViewRow row in grdstlplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand querySearch = new SqlCommand("propStealsPlusW"))
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
                                    grdstlplus.DataSource = dataT;
                                    grdstlplus.DataBind();
                                    foreach (GridViewRow row in grdstlplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void btnb_Click(object sender, EventArgs e)
        {
            grdblkplus.Visible = true;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string player = ddlRoster.SelectedValue;
                string injured = ddlInjured.SelectedValue;
                if (player == injured)
                {
                    lblError.Text = "Please select two different players"; ;
                }
                else
                {
                    if (chkInjury.Checked == true)
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("propblkInjuredPlus"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdblkplus.DataSource = dataT;
                                        grdblkplus.DataBind();
                                        foreach (GridViewRow row in grdblkplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("propblkInjuredPlusW"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdblkplus.DataSource = dataT;
                                        grdblkplus.DataBind();
                                        foreach (GridViewRow row in grdblkplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Label1.Text == "All Games")
                    {
                        using (SqlCommand querySearch = new SqlCommand("propBlocksPlus"))
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
                                    grdblkplus.DataSource = dataT;
                                    grdblkplus.DataBind();
                                    foreach (GridViewRow row in grdblkplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand querySearch = new SqlCommand("propBlocksPlusW"))
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
                                    grdblkplus.DataSource = dataT;
                                    grdblkplus.DataBind();
                                    foreach (GridViewRow row in grdblkplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btn3s_Click(object sender, EventArgs e)
        {
            grd3plus.Visible = true;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string player = ddlRoster.SelectedValue;
                string injured = ddlInjured.SelectedValue;
                if (player == injured)
                {
                    lblError.Text = "Please select two different players"; ;
                }
                else
                {
                    if (chkInjury.Checked == true)
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("prop3InjuredPlus"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grd3plus.DataSource = dataT;
                                        grd3plus.DataBind();
                                        foreach (GridViewRow row in grd3plus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("prop3InjuredPlusW"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grd3plus.DataSource = dataT;
                                        grd3plus.DataBind();
                                        foreach (GridViewRow row in grd3plus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Label1.Text == "All Games")
                    {
                        using (SqlCommand querySearch = new SqlCommand("prop3sPlus"))
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
                                    grd3plus.DataSource = dataT;
                                    grd3plus.DataBind();
                                    foreach (GridViewRow row in grd3plus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand querySearch = new SqlCommand("prop3sPlusW"))
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
                                    grd3plus.DataSource = dataT;
                                    grd3plus.DataBind();
                                    foreach (GridViewRow row in grd3plus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnr_Click(object sender, EventArgs e)
        {
            grdrebplus.Visible = true; 
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string player = ddlRoster.SelectedValue;
                string injured = ddlInjured.SelectedValue;
                if (player == injured)
                {
                    lblError.Text = "Please select two different players"; ;
                }
                else
                {
                    if (chkInjury.Checked == true)
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("proprebInjuredPlus"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdrebplus.DataSource = dataT;
                                        grdrebplus.DataBind();
                                        foreach (GridViewRow row in grdrebplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("proprebInjuredPlusW"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdrebplus.DataSource = dataT;
                                        grdrebplus.DataBind();
                                        foreach (GridViewRow row in grdrebplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Label1.Text == "All Games")
                    {
                        using (SqlCommand querySearch = new SqlCommand("propReboundsPlus"))
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
                                    grdrebplus.DataSource = dataT;
                                    grdrebplus.DataBind();
                                    foreach (GridViewRow row in grdrebplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand querySearch = new SqlCommand("propReboundsPlusW"))
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
                                    grdrebplus.DataSource = dataT;
                                    grdrebplus.DataBind();
                                    foreach (GridViewRow row in grdrebplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btna_Click(object sender, EventArgs e)
        {
            grdastplus.Visible = true;
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string player = ddlRoster.SelectedValue;
                string injured = ddlInjured.SelectedValue;
                if (player == injured)
                {
                    lblError.Text = "Please select two different players"; ;
                }
                else
                {
                    if (chkInjury.Checked == true)
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("propastInjuredPlus"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdastplus.DataSource = dataT;
                                        grdastplus.DataBind();
                                        foreach (GridViewRow row in grdastplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("propastInjuredPlusW"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdastplus.DataSource = dataT;
                                        grdastplus.DataBind();
                                        foreach (GridViewRow row in grdastplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Label1.Text == "All Games")
                    {
                        using (SqlCommand querySearch = new SqlCommand("propAssistsPlus"))
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
                                    grdastplus.DataSource = dataT;
                                    grdastplus.DataBind();
                                    foreach (GridViewRow row in grdastplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand querySearch = new SqlCommand("propAssistsPlusW"))
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
                                    grdastplus.DataSource = dataT;
                                    grdastplus.DataBind();
                                    foreach (GridViewRow row in grdastplus.Rows)
                                    {
                                        if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                        {
                                            row.Cells[4].Text = "+" + row.Cells[4].Text;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnp_Click(object sender, EventArgs e)
        {
            grdptsplus.Visible = true;
           
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                string player = ddlRoster.SelectedValue;
                string injured = ddlInjured.SelectedValue;
                if (player == injured)
                {
                    lblError.Text = "Please select two different players"; ;
                }
                else
                {
                    if (chkInjury.Checked == true)
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("propptsInjuredPlus"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdptsplus.DataSource = dataT;
                                        grdptsplus.DataBind();
                                        foreach (GridViewRow row in grdptsplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("propptsInjuredPlusW"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@injured", injured);
                                querySearch.Parameters.AddWithValue("@player", player);
                                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                                {
                                    querySearch.Connection = sqlConnect;
                                    sDataSearch.SelectCommand = querySearch;
                                    using (DataTable dataT = new DataTable())
                                    {
                                        sDataSearch.Fill(dataT);
                                        grdptsplus.DataSource = dataT;
                                        grdptsplus.DataBind();
                                        foreach (GridViewRow row in grdptsplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Label1.Text == "All Games")
                        {
                            using (SqlCommand querySearch = new SqlCommand("propPointsPlus"))
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
                                        grdptsplus.DataSource = dataT;
                                        grdptsplus.DataBind();
                                        foreach (GridViewRow row in grdptsplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (SqlCommand querySearch = new SqlCommand("propPointsPlusW"))
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
                                        grdptsplus.DataSource = dataT;
                                        grdptsplus.DataBind();
                                        foreach (GridViewRow row in grdptsplus.Rows)
                                        {
                                            if (row.Cells[4].Text.Contains('+') == false && row.Cells[4].Text.Contains('-') == false)
                                            {
                                                row.Cells[4].Text = "+" + row.Cells[4].Text;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void ddlInjured_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkInjury.Checked == true)
            {
                PopulateProps();



                grdpts.Visible = true;
                grdast.Visible = true;
                grdreb.Visible = true;
                grdstl.Visible = true;
                grd3.Visible = true;
                grdblk.Visible = true;
                //grd3.Visible = true;
                //grd10_23.Visible = true;
                grdstlplus.Visible = false;
                grdptsplus.Visible = false;
                grdrebplus.Visible = false;
                grdastplus.Visible = false;
                grdblkplus.Visible = false;
                grd3plus.Visible = false;
            }

        }

        protected void chkInjury_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInjury.Checked == true)
            {
                PopulateProps();
            }
            else
            {
                PopulateProps();
            }
        }
    }
}