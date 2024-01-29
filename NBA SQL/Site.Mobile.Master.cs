using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_SQL
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        private void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                lblUser.Text = Session["Admin"].ToString();
                dropdownTest.Visible = false;
            }
            else if (Session["User"] != null)
            {
                lblUser.Text = Session["User"].ToString();
                dropdownTest.Visible = false;
            }
            else
            {
                Session["Guest"] = "Guest";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                lblUser.Text = Session["Admin"].ToString();
                dropdownTest.Visible = false;
            }
            else if (Session["User"] != null)
            {
                lblUser.Text = Session["User"].ToString();
                dropdownTest.Visible = false;
            }
            else
            {
                Session["Guest"] = "Guest";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("admin"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(user));
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
                                Session["Admin"] = txtUser.Text;
                                sqlConnect.Close();
                                dropdownTest.Visible = false;
                            }
                            else
                            {
                                sqlConnect.Close();
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Font.Bold = true;
                                lblStatus.Text = "Email and/or Password was Incorrect";
                            }
                        }
                    }
                    sqlConnect.Close();
                }
                using (SqlCommand querySearch = new SqlCommand("users"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(user));
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
                                lblUser.Text = txtUser.Text;
                                dropdownTest.Visible = false;
                            }
                            else
                            {
                                sqlConnect.Close();
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Font.Bold = true;
                                lblStatus.Text = "Email and/or Password was Incorrect";
                            }
                        }
                    }
                }
            }
        }



        protected void lblUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyNBA");
        }
    }
}