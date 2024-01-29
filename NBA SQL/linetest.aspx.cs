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
    public partial class linetest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("line"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdT.DataSource = dataT;
                            grdT.DataBind();
                            foreach(GridViewRow row in grdT.Rows)
                            {
                                float pct = float.Parse(row.Cells[3].Text.Split('%')[0])/100;
                                if (pct > .5)
                                {
                                    pct = pct/(1 - pct) * (-100);
                                }
                                else
                                {
                                   pct = (1 - pct) /pct * 100;
                                }


                                int pctInt = (int)Math.Round(pct);
                                row.Cells[3].Text = pctInt.ToString();
                               
                            }
                        }
                    }
                }
            }
        }

        protected void grdAvg_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdGames_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}