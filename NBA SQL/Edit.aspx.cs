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
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null && Session["User"] == null)
            {
                Response.Redirect("Default");
            }
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
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("updateUser"))
                {
                    querySearch.Connection = sqlConnect;
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(Session["User"].ToString()));
                    querySearch.Parameters.AddWithValue("@favoritePlayer", fp);
                    querySearch.Parameters.AddWithValue("@favoriteTeam", ft);
                    sqlConnect.Open();
                    querySearch.ExecuteScalar(); // Used for other than SELECT Queries
                    sqlConnect.Close();
                }
            }
            Response.Redirect("MyNBA");
        }       
    }
}