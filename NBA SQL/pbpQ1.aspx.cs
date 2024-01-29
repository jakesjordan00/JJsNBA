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
    public partial class pbpQ1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nbaWalkthrough;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("q1P"))
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
                            sqlConnect.Close();
                            foreach (GridViewRow row in grdT.Rows)
                            {
                                int team_id = 0;
                                int matchup_id = 0;
                                int game_id = 0;
                                int player_id = 0;
                                int p = 0;
                                int a = 0;
                                int r = 0;
                                int m1 = 0;
                                int a1 = 0;
                                int m2 = 0;
                                int a2 = 0;
                                int m3 = 0;
                                int Bplayer_id = 0;
                                int a3 = 0;
                                int Bp = 0;
                                int Ba = 0;
                                int Br = 0;
                                int Bm1 = 0;
                                int Ba1 = 0;
                                int Bm2 = 0;
                                int Ba2 = 0;
                                int Bm3 = 0;
                                int Ba3 = 0;
                                string date = "";
                                player_id = Int32.Parse(row.Cells[6].Text);
                                team_id = Int32.Parse(row.Cells[7].Text);
                                game_id = Int32.Parse(row.Cells[8].Text);
                                date = row.Cells[9].Text;
                                matchup_id = Int32.Parse(row.Cells[11].Text);
                                //if (row.Cells[1].Text.Contains("BLOCK"))
                                //{
                                //    a2 += 1;
                                //}
                                if (row.Cells[1].Text.Contains("AST"))
                                {
                                    Bplayer_id = Int32.Parse(row.Cells[12].Text);
                                    Ba += 1;
                                }
                                if (row.Cells[5].Text == "1")
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        p += 3;
                                        m3 += 1;
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        p += 2;
                                        m2 += 1;
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "2" && !row.Cells[1].Text.Contains("BLOCK"))
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "3")
                                {
                                    if (row.Cells[1].Text.Contains("MISS"))
                                    {
                                        a1 += 1;
                                    }
                                    else
                                    {
                                        p += 1;
                                        m1 += 1;
                                        a1 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "4")
                                {
                                    r += 1;
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q1Insert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q1LogInsert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                    querySearch1.Parameters.AddWithValue("@date", date);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                if (Bplayer_id != 0)
                                {
                                    using (SqlCommand querySearch1 = new SqlCommand("q1Insert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                    using (SqlCommand querySearch1 = new SqlCommand("q1LogInsert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                        querySearch1.Parameters.AddWithValue("@date", date);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q2P"))
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
                            sqlConnect.Close();
                            foreach (GridViewRow row in grdT.Rows)
                            {
                                int team_id = 0;
                                int matchup_id = 0;
                                int game_id = 0;
                                int player_id = 0;
                                int p = 0;
                                int a = 0;
                                int r = 0;
                                int m1 = 0;
                                int a1 = 0;
                                int m2 = 0;
                                int a2 = 0;
                                int m3 = 0;
                                int Bplayer_id = 0;
                                int a3 = 0;
                                int Bp = 0;
                                int Ba = 0;
                                int Br = 0;
                                int Bm1 = 0;
                                int Ba1 = 0;
                                int Bm2 = 0;
                                int Ba2 = 0;
                                int Bm3 = 0;
                                int Ba3 = 0;
                                string date = "";
                                player_id = Int32.Parse(row.Cells[6].Text);
                                team_id = Int32.Parse(row.Cells[7].Text);
                                game_id = Int32.Parse(row.Cells[8].Text);
                                date = row.Cells[9].Text;
                                matchup_id = Int32.Parse(row.Cells[11].Text);
                                //if (row.Cells[1].Text.Contains("BLOCK"))
                                //{
                                //    a2 += 1;
                                //}
                                if (row.Cells[1].Text.Contains("AST"))
                                {
                                    Bplayer_id = Int32.Parse(row.Cells[12].Text);
                                    Ba += 1;
                                }
                                if (row.Cells[5].Text == "1")
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        p += 3;
                                        m3 += 1;
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        p += 2;
                                        m2 += 1;
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "2" && !row.Cells[1].Text.Contains("BLOCK"))
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "3")
                                {
                                    if (row.Cells[1].Text.Contains("MISS"))
                                    {
                                        a1 += 1;
                                    }
                                    else
                                    {
                                        p += 1;
                                        m1 += 1;
                                        a1 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "4")
                                {
                                    r += 1;
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q2Insert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q2LogInsert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                    querySearch1.Parameters.AddWithValue("@date", date);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                if (Bplayer_id != 0)
                                {
                                    using (SqlCommand querySearch1 = new SqlCommand("q2Insert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                    using (SqlCommand querySearch1 = new SqlCommand("q2LogInsert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                        querySearch1.Parameters.AddWithValue("@date", date);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q3P"))
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
                            sqlConnect.Close();
                            foreach (GridViewRow row in grdT.Rows)
                            {
                                int team_id = 0;
                                int matchup_id = 0;
                                int game_id = 0;
                                int player_id = 0;
                                int p = 0;
                                int a = 0;
                                int r = 0;
                                int m1 = 0;
                                int a1 = 0;
                                int m2 = 0;
                                int a2 = 0;
                                int m3 = 0;
                                int Bplayer_id = 0;
                                int a3 = 0;
                                int Bp = 0;
                                int Ba = 0;
                                int Br = 0;
                                int Bm1 = 0;
                                int Ba1 = 0;
                                int Bm2 = 0;
                                int Ba2 = 0;
                                int Bm3 = 0;
                                int Ba3 = 0;
                                string date = "";
                                player_id = Int32.Parse(row.Cells[6].Text);
                                team_id = Int32.Parse(row.Cells[7].Text);
                                game_id = Int32.Parse(row.Cells[8].Text);
                                date = row.Cells[9].Text;
                                matchup_id = Int32.Parse(row.Cells[11].Text);
                                //if (row.Cells[1].Text.Contains("BLOCK"))
                                //{
                                //    a2 += 1;
                                //}
                                if (row.Cells[1].Text.Contains("AST"))
                                {
                                    Bplayer_id = Int32.Parse(row.Cells[12].Text);
                                    Ba += 1;
                                }
                                if (row.Cells[5].Text == "1")
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        p += 3;
                                        m3 += 1;
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        p += 2;
                                        m2 += 1;
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "2" && !row.Cells[1].Text.Contains("BLOCK"))
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "3")
                                {
                                    if (row.Cells[1].Text.Contains("MISS"))
                                    {
                                        a1 += 1;
                                    }
                                    else
                                    {
                                        p += 1;
                                        m1 += 1;
                                        a1 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "4")
                                {
                                    r += 1;
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q3Insert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q3LogInsert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                    querySearch1.Parameters.AddWithValue("@date", date);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                if (Bplayer_id != 0)
                                {
                                    using (SqlCommand querySearch1 = new SqlCommand("q3Insert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                    using (SqlCommand querySearch1 = new SqlCommand("q3LogInsert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                        querySearch1.Parameters.AddWithValue("@date", date);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                }
                            }
                        }
                    }
                }
                using (SqlCommand querySearch = new SqlCommand("q4P"))
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
                            sqlConnect.Close();
                            foreach (GridViewRow row in grdT.Rows)
                            {
                                int team_id = 0;
                                int matchup_id = 0;
                                int game_id = 0;
                                int player_id = 0;
                                int p = 0;
                                int a = 0;
                                int r = 0;
                                int m1 = 0;
                                int a1 = 0;
                                int m2 = 0;
                                int a2 = 0;
                                int m3 = 0;
                                int Bplayer_id = 0;
                                int a3 = 0;
                                int Bp = 0;
                                int Ba = 0;
                                int Br = 0;
                                int Bm1 = 0;
                                int Ba1 = 0;
                                int Bm2 = 0;
                                int Ba2 = 0;
                                int Bm3 = 0;
                                int Ba3 = 0;
                                string date = "";
                                player_id = Int32.Parse(row.Cells[6].Text);
                                team_id = Int32.Parse(row.Cells[7].Text);
                                game_id = Int32.Parse(row.Cells[8].Text);
                                date = row.Cells[9].Text;
                                matchup_id = Int32.Parse(row.Cells[11].Text);
                                //if (row.Cells[1].Text.Contains("BLOCK"))
                                //{
                                //    a2 += 1;
                                //}
                                if (row.Cells[1].Text.Contains("AST"))
                                {
                                    Bplayer_id = Int32.Parse(row.Cells[12].Text);
                                    Ba += 1;
                                }
                                if (row.Cells[5].Text == "1")
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        p += 3;
                                        m3 += 1;
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        p += 2;
                                        m2 += 1;
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "2" && !row.Cells[1].Text.Contains("BLOCK"))
                                {
                                    if (row.Cells[1].Text.Contains("3PT"))
                                    {
                                        a3 += 1;
                                    }
                                    else
                                    {
                                        a2 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "3")
                                {
                                    if (row.Cells[1].Text.Contains("MISS"))
                                    {
                                        a1 += 1;
                                    }
                                    else
                                    {
                                        p += 1;
                                        m1 += 1;
                                        a1 += 1;
                                    }
                                }
                                if (row.Cells[5].Text == "4")
                                {
                                    r += 1;
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q4Insert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                using (SqlCommand querySearch1 = new SqlCommand("q4LogInsert"))
                                {
                                    querySearch1.CommandType = CommandType.StoredProcedure;
                                    querySearch1.Connection = sqlConnect;
                                    querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id); 
                                    querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                    querySearch1.Parameters.AddWithValue("@date", date);
                                    querySearch1.Parameters.AddWithValue("@player_id", player_id);
                                    querySearch1.Parameters.AddWithValue("@points", p);
                                    querySearch1.Parameters.AddWithValue("@assists", a);
                                    querySearch1.Parameters.AddWithValue("@rebounds", r);
                                    querySearch1.Parameters.AddWithValue("@fgm", m2);
                                    querySearch1.Parameters.AddWithValue("@fga", a2);
                                    querySearch1.Parameters.AddWithValue("@fg3m", m3);
                                    querySearch1.Parameters.AddWithValue("@fg3a", a3);
                                    querySearch1.Parameters.AddWithValue("@ftm", m1);
                                    querySearch1.Parameters.AddWithValue("@fta", a1);
                                    sqlConnect.Open();
                                    querySearch1.ExecuteNonQuery();
                                    sqlConnect.Close();
                                }
                                if (Bplayer_id != 0)
                                {
                                    using (SqlCommand querySearch1 = new SqlCommand("q4Insert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                    using (SqlCommand querySearch1 = new SqlCommand("q4LogInsert"))
                                    {
                                        querySearch1.CommandType = CommandType.StoredProcedure;
                                        querySearch1.Connection = sqlConnect;
                                        querySearch1.Parameters.AddWithValue("@team_id", team_id); querySearch1.Parameters.AddWithValue("@game_id", game_id);
                                        querySearch1.Parameters.AddWithValue("@matchup_id", matchup_id);
                                        querySearch1.Parameters.AddWithValue("@date", date);
                                        querySearch1.Parameters.AddWithValue("@player_id", Bplayer_id);
                                        querySearch1.Parameters.AddWithValue("@points", Bp);
                                        querySearch1.Parameters.AddWithValue("@assists", Ba);
                                        querySearch1.Parameters.AddWithValue("@rebounds", Br);
                                        querySearch1.Parameters.AddWithValue("@fgm", Bm2);
                                        querySearch1.Parameters.AddWithValue("@fga", Ba2);
                                        querySearch1.Parameters.AddWithValue("@fg3m", Bm3);
                                        querySearch1.Parameters.AddWithValue("@fg3a", Ba3);
                                        querySearch1.Parameters.AddWithValue("@ftm", Bm1);
                                        querySearch1.Parameters.AddWithValue("@fta", Ba1);
                                        sqlConnect.Open();
                                        querySearch1.ExecuteNonQuery();
                                        sqlConnect.Close();
                                    }
                                }
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