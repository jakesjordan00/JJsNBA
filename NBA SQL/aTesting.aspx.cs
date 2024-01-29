using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Antlr.Runtime;
using System.Data.SqlTypes;

namespace NBA_SQL
{
    public partial class aTesting : System.Web.UI.Page
    {
        System.DateTime start = DateTime.MinValue;
        int team1 = 0;
                            int p1t1 = 0;
                            System.TimeSpan p1t1Min = TimeSpan.MinValue;
                            int p1t1Pts = 0;
                            int p1t1Ast = 0;
                            int p1t1Reb = 0;
                     int p2t1 = 0;
                            System.TimeSpan p2t1Min = TimeSpan.MinValue;
                            int p2t1Pts = 0;
                            int p2t1Ast = 0;
                            int p2t1Reb = 0;
                     int p3t1 = 0;
                            System.TimeSpan p3t1Min = TimeSpan.MinValue;
                            int p3t1Pts = 0;
                            int p3t1Ast = 0;
                            int p3t1Reb = 0;
                     int p4t1 = 0;
                            System.TimeSpan p4t1Min = TimeSpan.MinValue;
                            int p4t1Pts = 0;
                            int p4t1Ast = 0;
                            int p4t1Reb = 0;
                     int p5t1 = 0;
                            System.TimeSpan p5t1Min = TimeSpan.MinValue;
                            int p5t1Pts = 0;
                            int p5t1Ast = 0;
                            int p5t1Reb = 0;
                     int p6t1 = 0;
                            System.TimeSpan p6t1Min = TimeSpan.MinValue;
                            int p6t1Pts = 0;
                            int p6t1Ast = 0;
                            int p6t1Reb = 0;
                     int p7t1 = 0;
                            System.TimeSpan p7t1Min = TimeSpan.MinValue;
                            int p7t1Pts = 0;
                            int p7t1Ast = 0;
                            int p7t1Reb = 0;
                     int p8t1 = 0;
                            System.TimeSpan p8t1Min = TimeSpan.MinValue;
                            int p8t1Pts = 0;
                            int p8t1Ast = 0;
                            int p8t1Reb = 0;
                     int p9t1 = 0;
                            System.TimeSpan p9t1Min = TimeSpan.MinValue;
                            int p9t1Pts = 0;
                            int p9t1Ast = 0;
                            int p9t1Reb = 0;
                     int p10t1 = 0;
                            System.TimeSpan p10t1Min = TimeSpan.MinValue;
                            int p10t1Pts = 0;
                            int p10t1Ast = 0;
                            int p10t1Reb = 0;
                     int p11t1 = 0;
                            System.TimeSpan p11t1Min = TimeSpan.MinValue;
                            int p11t1Pts = 0;
                            int p11t1Ast = 0;
                            int p11t1Reb = 0;
                     int p12t1 = 0;
                            System.TimeSpan p12t1Min = TimeSpan.MinValue;
                            int p12t1Pts = 0;
                            int p12t1Ast= 0;
                            int p12t1Reb = 0;
                     int p13t1 = 0;
                            System.TimeSpan p13t1Min = TimeSpan.MinValue;
                            int p13t1Pts = 0;
                            int p13t1Ast = 0;
                            int p13t1Reb = 0;
                     int p14t1 = 0;
                            System.TimeSpan p14t1Min = TimeSpan.MinValue;
                            int p14t1Pts = 0;
                            int p14t1Ast = 0;
                            int p14t1Reb = 0;
                     int p15t1 = 0;
                            System.TimeSpan p15t1Min = TimeSpan.MinValue;
                            int p15t1Pts = 0;
                            int p15t1Ast = 0;
                            int p15t1Reb = 0;
        int team2 = 0;
                     int p1t2 = 0;
                            System.TimeSpan p1t2Min = TimeSpan.MinValue;
                            int p1t2Pts = 0;
                            int p1t2Ast = 0;
                            int p1t2Reb = 0;
                     int p2t2 = 0;
                            System.TimeSpan p2t2Min = TimeSpan.MinValue;
                            int p2t2Pts = 0;
                            int p2t2Ast = 0;
                            int p2t2Reb = 0;
                     int p3t2 = 0;
                            System.TimeSpan p3t2Min = TimeSpan.MinValue;
                            int p3t2Pts = 0;
                            int p3t2Ast = 0;
                            int p3t2Reb = 0;
                     int p4t2 = 0;
                            System.TimeSpan p4t2Min = TimeSpan.MinValue;
                            int p4t2Pts = 0;
                            int p4t2Ast = 0;
                            int p4t2Reb = 0;
                     int p5t2 = 0;
                            System.TimeSpan p5t2Min = TimeSpan.MinValue;
                            int p5t2Pts = 0;
                            int p5t2Ast = 0;
                            int p5t2Reb = 0;
                     int p6t2 = 0;
                            System.TimeSpan p6t2Min = TimeSpan.MinValue;
                            int p6t2Pts = 0;
                            int p6t2Ast = 0;
                            int p6t2Reb = 0;
                     int p7t2 = 0;
                            System.TimeSpan p7t2Min = TimeSpan.MinValue;
                            int p7t2Pts = 0;
                            int p7t2Ast = 0;
                            int p7t2Reb = 0;
                     int p8t2 = 0;
                            System.TimeSpan p8t2Min = TimeSpan.MinValue;
                            int p8t2Pts = 0;
                            int p8t2Ast = 0;
                            int p8t2Reb = 0;
                     int p9t2 = 0;
                            System.TimeSpan p9t2Min = TimeSpan.MinValue;
                            int p9t2Pts = 0;
                            int p9t2Ast = 0;
                            int p9t2Reb = 0;
                     int p10t2 = 0;
                            System.TimeSpan p10t2Min = TimeSpan.MinValue;
                            int p10t2Pts = 0;
                            int p10t2Ast = 0;
                            int p10t2Reb = 0;
                     int p11t2 = 0;
                            System.TimeSpan p11t2Min = TimeSpan.MinValue;
                            int p11t2Pts = 0;
                            int p11t2Ast = 0;
                            int p11t2Reb = 0;
                     int p12t2 = 0;
                            System.TimeSpan p12t2Min = TimeSpan.MinValue;
                            int p12t2Pts = 0;
                            int p12t2Ast= 0;
                            int p12t2Reb = 0;
                     int p13t2 = 0;
                            System.TimeSpan p13t2Min = TimeSpan.MinValue;
                            int p13t2Pts = 0;
                            int p13t2Ast = 0;
                            int p13t2Reb = 0;
                     int p14t2 = 0;
                            System.TimeSpan p14t2Min = TimeSpan.MinValue;
                            int p14t2Pts = 0;
                            int p14t2Ast = 0;
                            int p14t2Reb = 0;
                     int p15t2 = 0;
                            System.TimeSpan p15t2Min = TimeSpan.MinValue;
                            int p15t2Pts = 0;
                            int p15t2Ast = 0;
                            int p15t2Reb = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("lineupTest"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdTest.DataSource = dataT;
                            grdTest.DataBind();
////////////////////////////                                                This block of code is to get the two teams. Its's set to five as to not let it run unneccesarily long
                            int i = 0;
                            while (i < 5)
                            {
                                foreach (GridViewRow row in grdTest.Rows)
                                {
                                    i = i + 1;                                  
                                    if (row.Cells[12].Text != "&nbsp;")
                                    {
                                        if(team1 == 0)
                                        {
                                            team1 = Int32.Parse(row.Cells[12].Text);
                                        }                                     
                                        if (Int32.Parse(row.Cells[12].Text) != team1)
                                        {                                           
                                            team2 = Int32.Parse(row.Cells[12].Text);                                            
                                        }
                                    }                                                                      
                                }
                            }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                                                         This block of code is for getting the start time of the game
                            i = 0;
                            foreach (GridViewRow row in grdTest.Rows)
                            {
                                if (i == 0)
                                {
                                    i = i + 1;
                                    start = DateTime.Parse(row.Cells[5].Text);                                   
                                }
                            }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            foreach (GridViewRow row in grdTest.Rows)
                            {
                                if (row.Cells[12].Text != "&nbsp;")
                                {
                                    if (Int32.Parse(row.Cells[12].Text) == team1)
                                    {
                                        if (row.Cells[11].Text != "&nbsp;")
                                        {
                                            if (p1t1 == 0)
                                            {
                                                p1t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && p2t1 == 0)
                                            {
                                                p2t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && p3t1 == 0)
                                            {
                                                p3t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && p4t1 == 0)
                                            {
                                                p4t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && p5t1 == 0)
                                            {
                                                p5t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && p6t1 == 0)
                                            {
                                                p6t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && p7t1 == 0)
                                            {
                                                p7t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && p8t1 == 0          )
                                            {
                                                p8t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && p9t1 == 0)
                                            {
                                                p9t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && Int32.Parse(row.Cells[11].Text) != p9t1 && p10t1 == 0)
                                            {
                                                p10t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && Int32.Parse(row.Cells[11].Text) != p9t1 && Int32.Parse(row.Cells[11].Text) != p10t1 && p11t1 == 0)
                                            {
                                                p11t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && Int32.Parse(row.Cells[11].Text) != p9t1 && Int32.Parse(row.Cells[11].Text) != p10t1 && Int32.Parse(row.Cells[11].Text) != p11t1 && p12t1 == 0)
                                            {
                                                p12t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && Int32.Parse(row.Cells[11].Text) != p9t1 && Int32.Parse(row.Cells[11].Text) != p10t1 && Int32.Parse(row.Cells[11].Text) != p11t1 && Int32.Parse(row.Cells[11].Text) != p12t1 && p13t1 == 0)
                                            {
                                                p13t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && Int32.Parse(row.Cells[11].Text) != p9t1 && Int32.Parse(row.Cells[11].Text) != p10t1 && Int32.Parse(row.Cells[11].Text) != p11t1 && Int32.Parse(row.Cells[11].Text) != p12t1 && Int32.Parse(row.Cells[11].Text) != p13t1 && p14t1 == 0)
                                            {
                                                p14t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t1 && Int32.Parse(row.Cells[11].Text) != p2t1 && Int32.Parse(row.Cells[11].Text) != p3t1 && Int32.Parse(row.Cells[11].Text) != p4t1 && Int32.Parse(row.Cells[11].Text) != p5t1 && Int32.Parse(row.Cells[11].Text) != p6t1 && Int32.Parse(row.Cells[11].Text) != p7t1 && Int32.Parse(row.Cells[11].Text) != p8t1 && Int32.Parse(row.Cells[11].Text) != p9t1 && Int32.Parse(row.Cells[11].Text) != p10t1 && Int32.Parse(row.Cells[11].Text) != p11t1 && Int32.Parse(row.Cells[11].Text) != p12t1 && Int32.Parse(row.Cells[11].Text) != p13t1 && Int32.Parse(row.Cells[11].Text) != p14t1 && p15t1 == 0)
                                            {
                                                p15t1 = Int32.Parse(row.Cells[11].Text);
                                            }
                                        }
                                    }
                                    if (Int32.Parse(row.Cells[12].Text) == team2)
                                    {
                                        if (row.Cells[11].Text != "&nbsp;")
                                        {
                                            if (p1t2 == 0)
                                            {
                                                p1t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && p2t2 == 0)
                                            {
                                                p2t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && p3t2 == 0)
                                            {
                                                p3t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && p4t2 == 0)
                                            {
                                                p4t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && p5t2 == 0)
                                            {
                                                p5t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && p6t2 == 0)
                                            {
                                                p6t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && p7t2 == 0)
                                            {
                                                p7t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && p8t2 == 0)
                                            {
                                                p8t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && p9t2 == 0)
                                            {
                                                p9t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && Int32.Parse(row.Cells[11].Text) != p9t2 && p10t2 == 0)
                                            {
                                                p10t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && Int32.Parse(row.Cells[11].Text) != p9t2 && Int32.Parse(row.Cells[11].Text) != p10t2 && p11t2 == 0)
                                            {
                                                p11t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && Int32.Parse(row.Cells[11].Text) != p9t2 && Int32.Parse(row.Cells[11].Text) != p10t2 && Int32.Parse(row.Cells[11].Text) != p11t2 && p12t2 == 0)
                                            {
                                                p12t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && Int32.Parse(row.Cells[11].Text) != p9t2 && Int32.Parse(row.Cells[11].Text) != p10t2 && Int32.Parse(row.Cells[11].Text) != p11t2 && Int32.Parse(row.Cells[11].Text) != p12t2 && p13t2 == 0)
                                            {
                                                p13t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && Int32.Parse(row.Cells[11].Text) != p9t2 && Int32.Parse(row.Cells[11].Text) != p10t2 && Int32.Parse(row.Cells[11].Text) != p11t2 && Int32.Parse(row.Cells[11].Text) != p12t2 && Int32.Parse(row.Cells[11].Text) != p13t2 && p14t2 == 0)
                                            {
                                                p14t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                            if (Int32.Parse(row.Cells[11].Text) != p1t2 && Int32.Parse(row.Cells[11].Text) != p2t2 && Int32.Parse(row.Cells[11].Text) != p3t2 && Int32.Parse(row.Cells[11].Text) != p4t2 && Int32.Parse(row.Cells[11].Text) != p5t2 && Int32.Parse(row.Cells[11].Text) != p6t2 && Int32.Parse(row.Cells[11].Text) != p7t2 && Int32.Parse(row.Cells[11].Text) != p8t2 && Int32.Parse(row.Cells[11].Text) != p9t2 && Int32.Parse(row.Cells[11].Text) != p10t2 && Int32.Parse(row.Cells[11].Text) != p11t2 && Int32.Parse(row.Cells[11].Text) != p12t2 && Int32.Parse(row.Cells[11].Text) != p13t2 && Int32.Parse(row.Cells[11].Text) != p14t2 && p15t2 == 0)
                                            {
                                                p15t2 = Int32.Parse(row.Cells[11].Text);
                                            }
                                        }
                                    }
                                }                                   
                            }
                            foreach (GridViewRow row in grdTest.Rows)
                            {
                                if (row.Cells[2].Text == "8")
                                {
                                    if (Int32.Parse(row.Cells[11].Text) == p1t1)
                                    {
                                        p1t1Min = DateTime.Parse(row.Cells[5].Text).Subtract(start);   
                                    }
                                    if (Int32.Parse(row.Cells[11].Text) == p2t1)
                                    {
                                        p2t1Min = DateTime.Parse(row.Cells[5].Text).Subtract(start);
                                    }
                                    if (Int32.Parse(row.Cells[11].Text) == p3t1)
                                    {
                                        p3t1Min = DateTime.Parse(row.Cells[5].Text).Subtract(start);
                                    }
                                    if (Int32.Parse(row.Cells[11].Text) == p4t1)
                                    {
                                        p4t1Min = DateTime.Parse(row.Cells[5].Text).Subtract(start);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void grdTest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}