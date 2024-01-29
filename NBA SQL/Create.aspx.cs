using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace NBA_SQL
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null || Session["User"] != null)
            {
                Response.Redirect("Default");
            }
            if(!this.IsPostBack)
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
                            ddlTeam.DataTextField = dataT.Tables[0].Columns["Team"].ToString();
                            ddlTeam.DataSource = dataT;
                            ddlTeam.DataBind();
                            ListItem emptyItem = new ListItem("Team", "");
                            ddlTeam.Items.Insert(0, emptyItem);
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("allPlayers"))
                {
                    querySearch.Connection = sqlConnect;
                    querySearch.CommandType = CommandType.StoredProcedure;
                    sqlConnect.Open();
                    using (SqlDataReader sdr = querySearch.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Player"].ToString();
                            ddlPlayer.Items.Add(item);
                        }
                    }
                    ListItem emptyItem = new ListItem("Player", "");
                    ddlPlayer.Items.Insert(0, emptyItem);
                    sqlConnect.Close();
                }
            }
        }
        protected void btnPG_Click(object sender, EventArgs e)
        {
            string fp = ddlPlayer.SelectedValue.ToString(); 
            string ft = ddlTeam.SelectedValue.ToString();
            string ver = "";
            if (txtPass.Text == txtPass2.Text)
            {
                if(txtEmail.Text != "" && txtUser.Text != "" && txtPass.Text != "" && txtPass2.Text != "")
                {
                    SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
                    using (sqlConnect)
                    {
                        using (SqlCommand querySearch = new SqlCommand("users"))
                        {
                            querySearch.Connection = sqlConnect;
                            querySearch.CommandType = CommandType.StoredProcedure;
                            querySearch.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(txtUser.Text));
                            sqlConnect.Open();
                            SqlDataReader readersql = querySearch.ExecuteReader(); // create a reader

                            if (readersql.HasRows) // if the username exists, it will continue
                            {
                                if (readersql.Read()) // this will read the single record that matches the entered username
                                {
                                    ver = readersql["username"].ToString();
                                    lblError.Text = "Username already taken, please choose a different value";
                                    txtUser.Text = "";
                                }
                            }
                            sqlConnect.Close();
                            
                        }
                        if (ver == "")
                        {
                            using (SqlCommand querySearch = new SqlCommand("createUser"))
                            {
                                querySearch.Connection = sqlConnect;
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@email", HttpUtility.HtmlEncode(txtEmail.Text));
                                querySearch.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(txtUser.Text));
                                querySearch.Parameters.Add(new SqlParameter("@password", PasswordHash.HashPassword(txtPass.Text)));
                                querySearch.Parameters.AddWithValue("@favoritePlayer", fp);
                                querySearch.Parameters.AddWithValue("@favoriteTeam", ft);
                                sqlConnect.Open();
                                querySearch.ExecuteScalar(); // Used for other than SELECT Queries
                                sqlConnect.Close();
                            }
                            using (SqlCommand querySearch = new SqlCommand("users"))
                            {
                                querySearch.CommandType = CommandType.StoredProcedure;
                                querySearch.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(txtUser.Text));
                                querySearch.Connection = sqlConnect;
                                sqlConnect.Open();

                                SqlDataReader readersql = querySearch.ExecuteReader(); // create a reader

                                if (readersql.HasRows) // if the username exists, it will continue
                                {
                                    if (readersql.Read()) // this will read the single record that matches the entered username
                                    {
                                        string storedHash = readersql["password"].ToString(); // store the database password into this variable

                                        if (PasswordHash.ValidatePassword(txtPass.Text, storedHash)) // if the entered password matches what is stored, it will show success
                                        {
                                            Session["User"] = txtUser.Text;
                                            sqlConnect.Close();
                                        }
                                        else
                                        {
                                            sqlConnect.Close();
                                        }
                                    }
                                }
                            }
                            txtEmail.Text = "";
                            txtUser.Text = "";
                            txtPass.Text = "";
                            txtPass2.Text = "";
                            Response.Redirect("MyNBA");
                        }
                    }
                }  
            }
            else
            {
                if (txtPass.Text != txtPass2.Text)
                {
                    lblError.Text = "Please ensure passwords are the same";
                    if (txtEmail.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtPass2.Text == "")
                    {
                        lblError.Text = "Please fill out all required fields";
                    }
                }
            }
        }
    }
}
