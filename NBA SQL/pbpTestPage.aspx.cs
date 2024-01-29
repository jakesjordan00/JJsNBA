using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Antlr.Runtime;
using System.Security.Policy;

namespace NBA_SQL
{
    public partial class pbpTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
            int distance = 0;
            int shotVerb_id = 5;
            int shotVerb1_id = 0;
            //string sv1 = "Running";
            //string sv2 = "Driving";                                  
            //string sv3 = "Floating";
            //string sv4 = "Cutting";            
            int shotDescriptor_id = 0;
            int shotDescriptor1_id = 0;
            int shotDescriptor2_id = 0;
            //                     string sd1 = 1;
            //                     string sd2 = "Pull-Up"; string sd2a = "Pullup";
            //                     string sd3 = 3;
            //                     string sd4 = "Step Back";
            //                     string sd5 = "Tip";                   
            //                     string sd6 = 6;
            //                     string sd7 = "Finger Roll";
            //                     string sd8 = "Putback";
            //                     string sd9 = "Reverse";
            //                     string sd10= "Fadeaway";
            //                     string sd11= "Alley Oop";
            int shotType_id = 1;
            //                     string st1 = "Jump Shot"; string st1a = "Jumper";
            //                     string st2 = "Layup";
            //                     string st3 = "Dunk";
            int team_id = 0;
            int player_id = 0;
            int make = 0;
            int miss = 0;
            int fg = 0;
            string dString = "";





            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("shotsPbp"))
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
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("dropShots"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                using (SqlCommand querySearch = new SqlCommand("createShots"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                foreach (GridViewRow row in grdT.Rows)
                {
                    dString = "";
                    distance = 1;
                    shotDescriptor_id = 12;
                    shotDescriptor1_id = 12;
                    shotDescriptor2_id = 12;
                    shotVerb_id = 5;
                    shotVerb1_id = 5;
                    shotType_id = 4;
                    team_id = 0;
                    player_id = 0;
                    make = 0;
                    miss = 0;
                    fg = 0;

                    if (row.Cells[1].Text.Split(' ')[1] == "BLOCK" || row.Cells[1].Text.Split(' ')[2] == "BLOCK")
                    {
                        continue;
                    }
                    //Grabbing player_id and team_id
                    player_id = Int32.Parse(row.Cells[6].Text);
                    team_id = Int32.Parse(row.Cells[7].Text);
                    if (row.Cells[1].Text.Contains("3PT"))
                    {
                        fg = 3;
                    }
                    else
                    {
                        fg = 2;
                    }
                    //If miss
                    if (row.Cells[5].Text == "2")
                    {
                        miss = 1;
                        if (row.Cells[1].Text.Split(' ')[2] == "Jr." || row.Cells[1].Text.Split(' ')[2] == "Sr." || row.Cells[1].Text.Split(' ')[2] == "III" || row.Cells[1].Text.Split(' ')[2] == "IV")
                        {
                            if (row.Cells[1].Text.Contains("&#39; "))
                            {
                                //Grabbing shot distance
                                dString = row.Cells[1].Text.Split(' ')[3];
                                dString = dString.Replace("&#39;", "");
                                string dstring1 = dString;
                                if (int.TryParse(dstring1, out int value) == false)
                                {
                                    dString = "1";
                                }
                                distance = Int32.Parse(dString);
                            }



                            //Grabbing shotVerb
                            if (row.Cells[1].Text.Contains("Running"))
                            {
                                shotVerb_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Driving"))
                            {
                                if (row.Cells[1].Text.Contains("Floating"))
                                {
                                    shotVerb1_id = 3;
                                }
                                shotVerb_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Floating"))
                            {
                                shotVerb1_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Cutting"))
                            {
                                shotVerb_id = 4;
                            }
                            //Grabbing shotDescriptor
                            if (row.Cells[1].Text.Contains("Turnaround J"))
                            {
                                shotDescriptor_id = 1;
                            }

                            if (row.Cells[1].Text.Contains("Hook"))
                            {
                                if (row.Cells[1].Text.Contains("Turnaround"))
                                {
                                    shotDescriptor_id = 1;
                                }
                                if (row.Cells[1].Text.Contains("Bank"))
                                {
                                    shotDescriptor1_id = 6;
                                }
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Fadeaway S") || row.Cells[1].Text.Contains("Fadeaway J") || row.Cells[1].Text.Contains("Fadeaway ("))
                            {
                                shotDescriptor_id = 10;
                            }

                            if (row.Cells[1].Text.Contains("Turnaround Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank Hook S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway S") || row.Cells[1].Text.Contains("Turnaround Fadeaway ("))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway Bank J") || row.Cells[1].Text.Contains("Turnaround Fadeaway Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up J") || row.Cells[1].Text.Contains("Pullup J"))
                            {
                                shotDescriptor_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up Bank J") || row.Cells[1].Text.Contains("Pullup Bank J"))
                            {
                                shotDescriptor_id = 2;
                                shotDescriptor1_id = 6;
                            }


                            if (row.Cells[1].Text.Contains("Step Back J"))
                            {
                                shotDescriptor_id = 4;
                            }
                            if (row.Cells[1].Text.Contains("Step Back Bank J"))
                            {
                                shotDescriptor_id = 4;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Tip L"))
                            {
                                shotDescriptor_id = 5;
                            }
                            if (row.Cells[1].Text.Contains("Bank S") || row.Cells[1].Text.Contains("Bank J"))
                            {
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Finger Roll L"))
                            {
                                shotDescriptor_id = 7;
                            }
                            if (row.Cells[1].Text.Contains("Putback L") || row.Cells[1].Text.Contains("Putback D"))
                            {
                                shotDescriptor_id = 8;
                            }
                            if (row.Cells[1].Text.Contains("Reverse L") || row.Cells[1].Text.Contains("Reverse D"))
                            {
                                shotDescriptor_id = 9;
                            }

                            if (row.Cells[1].Text.Contains("Alley Oop D") || row.Cells[1].Text.Contains("Alley Oop L"))
                            {
                                shotDescriptor_id = 11;
                            }
                            //Grabbing shotType
                            if (row.Cells[1].Text.Contains("Jump"))
                            {
                                shotType_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Layup"))
                            {
                                shotType_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Dunk"))
                            {
                                shotType_id = 3;
                            }

                        }
                        else
                        {
                            //Grabbing shot distance
                            if (row.Cells[1].Text.Contains("&#39; "))
                            {
                                //Grabbing shot distance
                                dString = row.Cells[1].Text.Split(' ')[2];
                                dString = dString.Replace("&#39;", "");
                                string dstring1 = dString;
                                if (int.TryParse(dstring1, out int value) == false)
                                {
                                    dString = "1";
                                }
                                distance = Int32.Parse(dString);
                            }



                            //Grabbing shotVerb

                            if (row.Cells[1].Text.Contains("Running"))
                            {
                                shotVerb_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Driving L") || row.Cells[1].Text.Contains("Driving D") || row.Cells[1].Text.Contains("Driving R") ||
                                row.Cells[1].Text.Contains("Driving B") || row.Cells[1].Text.Contains("Driving H"))
                            {
                                shotVerb_id = 2;
                            }

                            if (row.Cells[1].Text.Contains("Driving"))
                            {
                                if (row.Cells[1].Text.Contains("Floating"))
                                {
                                    shotVerb1_id = 3;
                                }
                                shotVerb_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Floating"))
                            {
                                shotVerb1_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Cutting"))
                            {
                                shotVerb_id = 4;
                            }
                            //Grabbing shotDescriptor
                            if (row.Cells[1].Text.Contains("Turnaround J"))
                            {
                                shotDescriptor_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Hook"))
                            {
                                if (row.Cells[1].Text.Contains("Turnaround"))
                                {
                                    shotDescriptor_id = 1;
                                }
                                if (row.Cells[1].Text.Contains("Bank"))
                                {
                                    shotDescriptor1_id = 6;
                                }
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Fadeaway S") || row.Cells[1].Text.Contains("Fadeaway J") || row.Cells[1].Text.Contains("Fadeaway ("))
                            {
                                shotDescriptor_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank Hook S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway S") || row.Cells[1].Text.Contains("Turnaround Fadeaway ("))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway Bank J") || row.Cells[1].Text.Contains("Turnaround Fadeaway Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up J") || row.Cells[1].Text.Contains("Pullup J"))
                            {
                                shotDescriptor_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up Bank J") || row.Cells[1].Text.Contains("Pullup Bank J"))
                            {
                                shotDescriptor_id = 2;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Step Back J"))
                            {
                                shotDescriptor_id = 4;
                            }
                            if (row.Cells[1].Text.Contains("Step Back Bank J"))
                            {
                                shotDescriptor_id = 4;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Tip L"))
                            {
                                shotDescriptor_id = 5;
                            }
                            if (row.Cells[1].Text.Contains("Bank S") || row.Cells[1].Text.Contains("Bank J"))
                            {
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Finger Roll L"))
                            {
                                shotDescriptor_id = 7;
                            }
                            if (row.Cells[1].Text.Contains("Putback L") || row.Cells[1].Text.Contains("Putback D"))
                            {
                                shotDescriptor_id = 8;
                            }
                            if (row.Cells[1].Text.Contains("Reverse L") || row.Cells[1].Text.Contains("Reverse D"))
                            {
                                shotDescriptor_id = 9;
                            }

                            if (row.Cells[1].Text.Contains("Alley Oop D") || row.Cells[1].Text.Contains("Alley Oop L"))
                            {
                                shotDescriptor_id = 11;
                            }
                            //Grabbing shotType
                            if (row.Cells[1].Text.Contains("Jump"))
                            {
                                shotType_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Layup"))
                            {
                                shotType_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Dunk"))
                            {
                                shotType_id = 3;
                            }
                        }
                    }
                    //If Make
                    if (row.Cells[5].Text == "1")
                    {
                        make = 1;
                        if (row.Cells[1].Text.Split(' ')[1] == "Jr." || row.Cells[1].Text.Split(' ')[1] == "Sr." || row.Cells[1].Text.Split(' ')[1] == "III" || row.Cells[1].Text.Split(' ')[1] == "IV")
                        {
                            if (row.Cells[1].Text.Contains("&#39; "))
                            {
                                //Grabbing shot distance
                                dString = row.Cells[1].Text.Split(' ')[2];
                                dString = dString.Replace("&#39;", "");
                                string dstring1 = dString;
                                if (int.TryParse(dstring1, out int value) == false)
                                {
                                    dString = "1";
                                }
                                distance = Int32.Parse(dString);
                            }

                            //Grabbing shotVerb
                            if (row.Cells[1].Text.Contains("Running"))
                            {
                                shotVerb_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Driving L") || row.Cells[1].Text.Contains("Driving D") || row.Cells[1].Text.Contains("Driving R") ||
                                row.Cells[1].Text.Contains("Driving B") || row.Cells[1].Text.Contains("Driving H"))
                            {
                                shotVerb_id = 2;
                            }

                            if (row.Cells[1].Text.Contains("Driving"))
                            {
                                if (row.Cells[1].Text.Contains("Floating"))
                                {
                                    shotVerb1_id = 3;
                                }
                                shotVerb_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Floating"))
                            {
                                shotVerb1_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Cutting"))
                            {
                                shotVerb_id = 4;
                            }
                            //Grabbing shotDescriptor
                            if (row.Cells[1].Text.Contains("Turnaround J"))
                            {
                                shotDescriptor_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Hook"))
                            {
                                if (row.Cells[1].Text.Contains("Turnaround"))
                                {
                                    shotDescriptor_id = 1;
                                }
                                if (row.Cells[1].Text.Contains("Bank"))
                                {
                                    shotDescriptor1_id = 6;
                                }
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Fadeaway S") || row.Cells[1].Text.Contains("Fadeaway J") || row.Cells[1].Text.Contains("Fadeaway ("))
                            {
                                shotDescriptor_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank Hook S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway S") || row.Cells[1].Text.Contains("Turnaround Fadeaway ("))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway Bank J") || row.Cells[1].Text.Contains("Turnaround Fadeaway Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up J") || row.Cells[1].Text.Contains("Pullup J"))
                            {
                                shotDescriptor_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up Bank J") || row.Cells[1].Text.Contains("Pullup Bank J"))
                            {
                                shotDescriptor_id = 2;
                                shotDescriptor1_id = 6;
                            }

                            if (row.Cells[1].Text.Contains("Step Back J"))
                            {
                                shotDescriptor_id = 4;
                            }
                            if (row.Cells[1].Text.Contains("Step Back Bank J"))
                            {
                                shotDescriptor_id = 4;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Tip L"))
                            {
                                shotDescriptor_id = 5;
                            }
                            if (row.Cells[1].Text.Contains("Bank S") || row.Cells[1].Text.Contains("Bank J"))
                            {
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Finger Roll L"))
                            {
                                shotDescriptor_id = 7;
                            }
                            if (row.Cells[1].Text.Contains("Putback L") || row.Cells[1].Text.Contains("Putback D"))
                            {
                                shotDescriptor_id = 8;
                            }
                            if (row.Cells[1].Text.Contains("Reverse L") || row.Cells[1].Text.Contains("Reverse D"))
                            {
                                shotDescriptor_id = 9;
                            }

                            if (row.Cells[1].Text.Contains("Alley Oop D") || row.Cells[1].Text.Contains("Alley Oop L"))
                            {
                                shotDescriptor_id = 11;
                            }
                            //Grabbing shotType
                            if (row.Cells[1].Text.Contains("Jump"))
                            {
                                shotType_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Layup"))
                            {
                                shotType_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Dunk"))
                            {
                                shotType_id = 3;
                            }

                        }
                        else
                        {
                            //Grabbing shot distance
                            if (row.Cells[1].Text.Contains("&#39; "))
                            {
                                //Grabbing shot distance
                                dString = row.Cells[1].Text.Split(' ')[1];
                                dString = dString.Replace("&#39;", "");
                                string dstring1 = dString;
                                if (int.TryParse(dstring1, out int value) == false)
                                {
                                    dString = "1";
                                }
                                distance = Int32.Parse(dString);
                            }
                            //Grabbing shotVerb
                            if (row.Cells[1].Text.Contains("Running"))
                            {
                                shotVerb_id = 1;
                            }

                            if (row.Cells[1].Text.Contains("Driving"))
                            {
                                if (row.Cells[1].Text.Contains("Floating"))
                                {
                                    shotVerb1_id = 3;
                                }
                                shotVerb_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Floating"))
                            {
                                shotVerb1_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Cutting"))
                            {
                                shotVerb_id = 4;
                            }
                            //Grabbing shotDescriptor
                            if (row.Cells[1].Text.Contains("Turnaround J"))
                            {
                                shotDescriptor_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Hook"))
                            {
                                if (row.Cells[1].Text.Contains("Turnaround"))
                                {
                                    shotDescriptor_id = 1;
                                }
                                if (row.Cells[1].Text.Contains("Bank"))
                                {
                                    shotDescriptor1_id = 6;
                                }
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Fadeaway S") || row.Cells[1].Text.Contains("Fadeaway J") || row.Cells[1].Text.Contains("Fadeaway ("))
                            {
                                shotDescriptor2_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Bank Hook S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor1_id = 6;
                                shotDescriptor2_id = 3;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway S") || row.Cells[1].Text.Contains("Turnaround Fadeaway ("))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                            }
                            if (row.Cells[1].Text.Contains("Turnaround Fadeaway Bank J") || row.Cells[1].Text.Contains("Turnaround Fadeaway Bank S"))
                            {
                                shotDescriptor_id = 1;
                                shotDescriptor2_id = 10;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up J") || row.Cells[1].Text.Contains("Pullup J"))
                            {
                                shotDescriptor_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Pull-Up Bank J") || row.Cells[1].Text.Contains("Pullup Bank J"))
                            {
                                shotDescriptor_id = 2;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Step Back J"))
                            {
                                shotDescriptor_id = 4;
                            }
                            if (row.Cells[1].Text.Contains("Step Back Bank J"))
                            {
                                shotDescriptor_id = 4;
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Tip L"))
                            {
                                shotDescriptor_id = 5;
                            }
                            if (row.Cells[1].Text.Contains("Bank S") || row.Cells[1].Text.Contains("Bank J"))
                            {
                                shotDescriptor1_id = 6;
                            }
                            if (row.Cells[1].Text.Contains("Finger Roll L"))
                            {
                                shotDescriptor_id = 7;
                            }
                            if (row.Cells[1].Text.Contains("Putback L") || row.Cells[1].Text.Contains("Putback D"))
                            {
                                shotDescriptor_id = 8;
                            }
                            if (row.Cells[1].Text.Contains("Reverse L") || row.Cells[1].Text.Contains("Reverse D"))
                            {
                                shotDescriptor_id = 9;
                            }

                            if (row.Cells[1].Text.Contains("Alley Oop D") || row.Cells[1].Text.Contains("Alley Oop L"))
                            {
                                shotDescriptor_id = 11;
                            }
                            //Grabbing shotType
                            if (row.Cells[1].Text.Contains("Jump"))
                            {
                                shotType_id = 1;
                            }
                            if (row.Cells[1].Text.Contains("Layup"))
                            {
                                shotType_id = 2;
                            }
                            if (row.Cells[1].Text.Contains("Dunk"))
                            {
                                shotType_id = 3;
                            }
                        }
                    }
                    using (SqlCommand querySearch = new SqlCommand("insertShots"))
                    {
                        querySearch.CommandType = CommandType.StoredProcedure;
                        querySearch.Connection = sqlConnect;
                        querySearch.Parameters.AddWithValue("@team_id", team_id);
                        querySearch.Parameters.AddWithValue("@player_id", player_id);
                        querySearch.Parameters.AddWithValue("@distance_id", distance);
                        querySearch.Parameters.AddWithValue("@shotVerb_id", shotVerb_id);
                        querySearch.Parameters.AddWithValue("@shotVerb1_id", shotVerb1_id);
                        querySearch.Parameters.AddWithValue("@shotDescriptor_id", shotDescriptor_id);
                        querySearch.Parameters.AddWithValue("@shotDescriptor1_id", shotDescriptor1_id);
                        querySearch.Parameters.AddWithValue("@shotDescriptor2_id", shotDescriptor2_id);
                        querySearch.Parameters.AddWithValue("@shotType_id", shotType_id);
                        querySearch.Parameters.AddWithValue("@make", make);
                        querySearch.Parameters.AddWithValue("@miss", miss);
                        querySearch.Parameters.AddWithValue("@fg", fg);
                        sqlConnect.Open();
                        querySearch.ExecuteNonQuery();
                        sqlConnect.Close();
                    }
                }
            }
        }

        protected void grdEfficiency_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}