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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=comments;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("insertP"))
                {
                    querySearch.Connection = sqlConnect;
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Parameters.AddWithValue("@email", txtEmail.Text);
                    querySearch.Parameters.AddWithValue("@suggestion", txtSuggestion.Text);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();

                }
            }
            txtEmail.Text = "";
            txtSuggestion.Text = "";
        }
        
    }
}