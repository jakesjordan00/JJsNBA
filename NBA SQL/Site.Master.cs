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
using Microsoft.Ajax.Utilities;

namespace NBA_SQL
{
    public partial class SiteMaster : MasterPage
    {
        private static void PageLoadHelper(string direction,
                                            System.Web.UI.HtmlControls.HtmlImage[] directionArr,
                                            SqlConnection sqlConnect)
        {
            int num = 1;
            // this may go inside the for loop, but honestly dont know too much about using or sqlcommand
            for (int i = 0; i < directionArr.Length; i++)
            {
                using (SqlCommand querySearch = new SqlCommand(direction))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@rank", num);
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        querySearch.Connection.Open();
                        using (SqlDataReader reader = querySearch.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                directionArr[i].Src = reader["nickname"].ToString() + "-logo.png";
                            }
                        }
                        querySearch.Connection.Close();
                    }
                    num++;
                }
            }
        }
        private void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                lblUser.Text = Session["Admin"].ToString();
                dropdownTest.Visible= false;
            }
            else if (Session["User"] != null)
            {
                lblUser.Text = Session["User"].ToString();
                dropdownTest.Visible = false;
            }
            else
            {
                Session["Guest"] = "Guest";
                lblUser.Text = Session["Guest"].ToString();
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
                lblUser.Text = Session["Guest"].ToString();
            }
            //SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            //using (sqlConnect)
            //{
               // System.Web.UI.HtmlControls.HtmlImage[] eastArr = { h1p };
                //using (SqlCommand querySearch = new SqlCommand("liveLines"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Connection = sqlConnect;
                //    sqlConnect.Open();
                //    int a = 0;
                //    string[] home = { };
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        using (DataTable dataT = new DataTable())
                //        {
                //            sDataSearch.Fill(dataT);
                //            foreach (DataRow row in dataT.Rows)
                //            {

                //            }

                //            //if (readersql.NextResult()) // this will read the single record that matches the entered username
                //            //{
                //            //    return;

                //            //}
                //        }
                //    }
                //    sqlConnect.Close();
                //}
            //}
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
                                Response.Redirect(Request.RawUrl);
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