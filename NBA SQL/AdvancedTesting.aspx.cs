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
    public partial class AdvancedTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 1;
            string sixers = "76ers"; int team_id = 0; int player_id = 0;
            string joel = "Embiid";        double joelP = 0;    double joelA = 0;    int joelGP = 0;     double joelR = 0;         int joelID = 0;
            string james = "Harden";        double jamesP = 0;  double jamesA = 0;  int jamesGP = 0;   double jamesR = 0;       int jamesID = 0;
            string tyrese = "Maxey";     double tyreseP = 0;double tyreseA = 0;int tyreseGP = 0; double tyreseR = 0;     int tyreseID = 0;
            string tobias = "Harris";        double tobiasP = 0;   double tobiasA = 0;   int tobiasGP = 0;    double tobiasR = 0;        int tobiasID = 0;
            string deanthony = "Melton";           double deanthonyP = 0;    double deanthonyA = 0;    int deanthonyGP = 0;     double deanthonyR = 0;         int deanthonyID = 0;
            string shake = "Milton";      double shakeP = 0; double shakeA = 0; int shakeGP = 0;  double shakeR = 0;      int shakeID = 0;
            string pj = "Tucker";       double pjP = 0;    double pjA = 0;    int pjGP = 0;     double pjR = 0; int pjID = 0;
            string georges = "Niang";       double georgesP = 0;    double georgesA = 0;    int georgesGP = 0;     double georgesR = 0; int georgesID = 0;
            string danuel = "House";         double danuelP = 0;   double danuelA = 0;   int danuelGP = 0;    double danuelR = 0; int danuelID = 0;
            string montrezl = "Harrell";        double montrezlP = 0;  double montrezlA = 0;  int montrezlGP = 0;   double montrezlR = 0; int montrezlID = 0;
            string matisse = "Thybulle";      double matisseP = 0; double matisseA = 0; int matisseGP = 0;  double matisseR = 0; int matisseID = 0;
            string furkan = "Korkmaz";          double furkanP = 0;    double furkanA = 0;    int furkanGP = 0;     double furkanR = 0; int furkanID = 0;
            string paul = "Reed";       double paulP = 0;   double paulA = 0;   int paulGP = 0;    double paulR = 0; int paulID = 0;

            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                using (SqlCommand querySearch = new SqlCommand("q1pbp"))
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
                            foreach (GridViewRow row in grdTest.Rows)
                            {
                                i++;
                                string type = row.Cells[5].Text;
                                string team = row.Cells[2].Text;
                                string player = row.Cells[1].Text.Split(' ')[0];
                                int points = 0;
                                if (team == "76ers")
                                {
                                    string team_id_string = row.Cells[7].Text;
                                    team_id = Int32.Parse(team_id_string);
                                    //Free throws
                                    if(type == "3")
                                    {
                                        if (row.Cells[1].Text.Split(' ')[0] == "MISS")
                                        {
                                            player = row.Cells[1].Text.Split(' ')[1];
                                            points = 0;
                                        }
                                        else
                                        {
                                            points = 1;
                                            string player_id_string = row.Cells[6].Text;
                                            player_id = Int32.Parse(player_id_string);
                                            if (player == joel)
                                            {
                                                string joelGPs = row.Cells[3].Text;
                                                joelGP = Int32.Parse(joelGPs);
                                                joelP += points;
                                                joelID = player_id;
                                            }
                                            if (player == james)
                                            {
                                                string jamesGPs = row.Cells[3].Text;
                                                jamesGP = Int32.Parse(jamesGPs);
                                                jamesP += points;
                                                georgesID = player_id;
                                            }
                                            if (player == tyrese)
                                            {
                                                string tyreseGPs = row.Cells[3].Text;
                                                tyreseGP = Int32.Parse(tyreseGPs);
                                                tyreseP += points;
                                                tyreseID = player_id;
                                            }
                                            if (player == tobias)
                                            {
                                                string tobiasGPs = row.Cells[3].Text;
                                                tobiasGP = Int32.Parse(tobiasGPs);
                                                tobiasP += points;
                                                tobiasID = player_id;
                                            }
                                            if (player == deanthony)
                                            {
                                                string deanthonyGPs = row.Cells[3].Text;
                                                deanthonyGP = Int32.Parse(deanthonyGPs);
                                                deanthonyP += points;
                                                deanthonyID = player_id;
                                            }
                                            if (player == shake)
                                            {
                                                string shakeGPs = row.Cells[3].Text;
                                                shakeGP = Int32.Parse(shakeGPs);
                                                shakeP += points;
                                                shakeID = player_id;
                                            }
                                            if (player == pj)
                                            {
                                                string pjGPs = row.Cells[3].Text;
                                                pjGP = Int32.Parse(pjGPs);
                                                pjP += points;
                                                pjID = player_id;
                                            }
                                            if (player == georges)
                                            {
                                                string georgesGPs = row.Cells[3].Text;
                                                georgesGP = Int32.Parse(georgesGPs);
                                                georgesP += points;
                                                georgesID = player_id;
                                            }
                                            if (player == danuel)
                                            {
                                                string danuelGPs = row.Cells[3].Text;
                                                danuelGP = Int32.Parse(danuelGPs);
                                                danuelP += points;
                                                danuelID = player_id;
                                            }
                                            if (player == montrezl)
                                            {
                                                string montrezlGPs = row.Cells[3].Text;
                                                montrezlGP = Int32.Parse(montrezlGPs);
                                                montrezlP += points;
                                                montrezlID = player_id;
                                            }
                                            if (player == matisse)
                                            {
                                                string matisseGPs = row.Cells[3].Text;
                                                matisseGP = Int32.Parse(matisseGPs);
                                                matisseP += points;
                                                matisseID = player_id;
                                            }
                                            if (player == furkan)
                                            {
                                                string furkanGPs = row.Cells[3].Text;
                                                furkanGP = Int32.Parse(furkanGPs);
                                                furkanP += points;
                                                furkanID = player_id;
                                            }
                                            if (player == paul)
                                            {
                                                string paulGPs = row.Cells[3].Text;
                                                paulGP = Int32.Parse(paulGPs);
                                                paulP += points;
                                                paulID = player_id;
                                            }
                                        }
                                    }
                                    //Field Goals
                                    if (type == "1")
                                    {
                                        if(row.Cells[1].Text.Split(' ')[2] == "3PT" || row.Cells[1].Text.Split(' ')[3] == "3PT")
                                        {
                                            points = 3;
                                        }
                                        else
                                        {
                                            points = 2;
                                        }
                                        string pointsString = row.Cells[1].Text.Split('(')[1];
                                        int assists = 1;
                                        if (row.Cells[1].Text.Split('(').Length > 2)
                                        {
                                            string player2 = row.Cells[1].Text.Split('(')[2];
                                            string assistString = player2.Split(' ')[1];
                                            
                                            player2 = player2.Split(' ')[0];
                                            if (player2 == joel)
                                            {
                                               
                                                joelA += assists;
                                            }
                                            if (player2 == james)
                                            {
                                                jamesA += assists;
                                            }
                                            if (player2 == tyrese)
                                            {
                                                tyreseA += assists;
                                            }
                                            if (player2 == tobias)
                                            {
                                                tobiasA += assists;
                                            }
                                            if (player2 == deanthony)
                                            {
                                                deanthonyA += assists;
                                            }
                                            if (player2 == shake)
                                            {
                                                shakeA += assists;
                                            }
                                            if (player2 == pj)
                                            {
                                                pjA += assists;
                                            }
                                            if (player2 == georges)
                                            {
                                                georgesA += assists;
                                            }
                                            if (player2 == danuel)
                                            {
                                                danuelA += assists;
                                            }
                                            if (player2 == montrezl)
                                            {
                                                montrezlA += assists;
                                            }
                                            if (player2 == matisse)
                                            {
                                                matisseA += assists;
                                            }
                                            if (player2 == furkan)
                                            {
                                                furkanA += assists;
                                            }
                                            if (player2 == paul)
                                            {
                                                paulA += assists;
                                            }                                           
                                        }
                                        pointsString = pointsString.Split(' ')[0];
                                        
                                        string player_id_string = row.Cells[6].Text;
                                        player_id = Int32.Parse(player_id_string);
                                        if (player == joel)
                                        {
                                            string joelGPs = row.Cells[3].Text;
                                            joelGP = Int32.Parse(joelGPs);
                                            joelP += points ;
                                            joelID = player_id;
                                        }
                                        if (player == james)
                                        {
                                            string jamesGPs = row.Cells[3].Text;
                                            jamesGP = Int32.Parse(jamesGPs);
                                            jamesP += points;
                                            georgesID = player_id;
                                        }
                                        if (player == tyrese)
                                        {
                                            string tyreseGPs = row.Cells[3].Text;
                                            tyreseGP = Int32.Parse(tyreseGPs);
                                            tyreseP += points;
                                            tyreseID = player_id;
                                        }
                                        if (player == tobias)
                                        {
                                            string tobiasGPs = row.Cells[3].Text;
                                            tobiasGP = Int32.Parse(tobiasGPs);
                                            tobiasP += points;
                                            tobiasID = player_id;
                                        }
                                        if (player == deanthony)
                                        {
                                            string deanthonyGPs = row.Cells[3].Text;
                                            deanthonyGP = Int32.Parse(deanthonyGPs);
                                            deanthonyP += points;
                                            deanthonyID = player_id;
                                        }
                                        if (player == shake)
                                        {
                                            string shakeGPs = row.Cells[3].Text;
                                            shakeGP = Int32.Parse(shakeGPs);
                                            shakeP += points;
                                            shakeID = player_id;
                                        }
                                        if (player == pj)
                                        {
                                            string pjGPs = row.Cells[3].Text;
                                            pjGP = Int32.Parse(pjGPs);
                                            pjP += points;
                                            pjID = player_id;
                                        }
                                        if (player == georges)
                                        {
                                            string georgesGPs = row.Cells[3].Text;
                                            georgesGP = Int32.Parse(georgesGPs);
                                            georgesP += points;
                                            georgesID = player_id;
                                        }
                                        if (player == danuel)
                                        {
                                            string danuelGPs = row.Cells[3].Text;
                                            danuelGP = Int32.Parse(danuelGPs);
                                            danuelP += points;
                                            danuelID = player_id;
                                        }
                                        if (player == montrezl)
                                        {
                                            string montrezlGPs = row.Cells[3].Text;
                                            montrezlGP = Int32.Parse(montrezlGPs);
                                            montrezlP += points;
                                            montrezlID = player_id;
                                        }
                                        if (player == matisse)
                                        {
                                            string matisseGPs = row.Cells[3].Text;
                                            matisseGP = Int32.Parse(matisseGPs);
                                            matisseP += points;
                                            matisseID = player_id;
                                        }
                                        if (player == furkan)
                                        {
                                            string furkanGPs = row.Cells[3].Text;
                                            furkanGP = Int32.Parse(furkanGPs);
                                            furkanP += points;
                                            furkanID = player_id;
                                        }
                                        if (player == paul)
                                        {
                                            string paulGPs = row.Cells[3].Text;
                                            paulGP = Int32.Parse(paulGPs);
                                            paulP += points;
                                            paulID = player_id;
                                        }
                                    }
                                    if(type == "4")
                                    {
                                        int rebounds = 0;
                                        int oReb = 0;
                                        int dReb = 0;
                                        string rebString = row.Cells[1].Text.Split('(')[1];
                                        rebString = rebString.Trim(')');
                                        string oRebString = rebString.Split(':')[1];
                                        oRebString = oRebString.Split(' ')[0];
                                        
                                        oReb = Int32.Parse(oRebString);
                                        
                                        string dRebString = rebString.Split(':')[2];
                                        dReb = Int32.Parse(dRebString);
                                        rebounds = oReb + dReb;
                                        if (player == joel)
                                        {
                                            joelR += rebounds;
                                        }
                                        if (player == james)
                                        {
                                            jamesR += rebounds;
                                        }
                                        if (player == tyrese)
                                        {
                                            tyreseR += rebounds;
                                        }
                                        if (player == tobias)
                                        {
                                            tobiasR += rebounds;
                                        }
                                        if (player == deanthony)
                                        {
                                            deanthonyR += rebounds;
                                        }
                                        if (player == shake)
                                        {
                                            shakeR += rebounds;
                                        }
                                        if (player == pj)
                                        {
                                            pjR += rebounds;
                                        }
                                        if (player == georges)
                                        {
                                            georgesR += rebounds;
                                        }   
                                        if (player == danuel)
                                        {
                                            danuelR += rebounds;
                                        }
                                        if (player == montrezl)
                                        {
                                            montrezlR += rebounds;
                                        }
                                        if (player == matisse)
                                        {
                                            matisseR += rebounds;
                                        }
                                        if (player == furkan)
                                        {
                                            furkanR += rebounds;
                                        }
                                        if (player == paul)
                                        {
                                            paulR += rebounds;
                                        }

                                    }
                                }                                                              
                                furkanGP = 1;
                            }
                            joelP = joelP / joelGP;
                            joelP = Math.Round(joelP, 2);
                            joelA = joelA / joelGP;
                            joelA = Math.Round(joelA, 2);
                            joelR = joelR / joelGP;
                            joelR = Math.Round(joelR, 2);
                            jamesP = jamesP / jamesGP;
                            jamesP = Math.Round(jamesP, 2);
                            jamesA = jamesA / jamesGP;
                            jamesA = Math.Round(jamesA, 2);
                            jamesR = jamesR / jamesGP;
                            jamesR = Math.Round(jamesR, 2);
                            tyreseP = tyreseP / tyreseGP;
                            tyreseP = Math.Round(tyreseP, 2);
                            tyreseA = tyreseA / tyreseGP;
                            tyreseA =  Math.Round(tyreseA, 2);
                            tyreseR = tyreseR / tyreseGP;
                            tyreseR =  Math.Round(tyreseR, 2);
                            tobiasP = tobiasP / tobiasGP;
                            tobiasP = Math.Round(tobiasP, 2);
                            tobiasA = tobiasA / tobiasGP;
                            tobiasA = Math.Round(tobiasA, 2);
                            tobiasR = tobiasR / tobiasGP;
                            tobiasR = Math.Round(tobiasR, 2);
                            deanthonyP = deanthonyP / deanthonyGP;
                            deanthonyP = Math.Round(deanthonyP, 2);
                            deanthonyA = deanthonyA / deanthonyGP;
                            deanthonyA = Math.Round(deanthonyA, 2);
                            deanthonyR = deanthonyR / deanthonyGP;
                            deanthonyR = Math.Round(deanthonyR, 2);
                            shakeP = shakeP / shakeGP;
                            shakeP = Math.Round(shakeP, 2);
                            shakeA = shakeA / shakeGP;
                            shakeA = Math.Round(shakeA, 2);
                            shakeR = shakeR / shakeGP;
                            shakeR = Math.Round(shakeR, 2);
                            pjP = pjP / pjGP;
                            pjP = Math.Round(pjP, 2);
                            pjA = pjA / pjGP;
                            pjA = Math.Round(pjA, 2);
                            pjR = pjR / pjGP;
                            pjR = Math.Round(pjR, 2);
                            georgesP = georgesP / georgesGP;
                            georgesP = Math.Round(georgesP, 2);
                            georgesA = georgesA / georgesGP;
                            georgesA = Math.Round(georgesA);
                            georgesR = georgesR / georgesGP;
                            
                            danuelP = danuelP / danuelGP;
                            
                            danuelA = danuelA / danuelGP;
                            
                            danuelR = danuelR / danuelGP;
                            
                            montrezlP = montrezlP / montrezlGP;
                            
                            montrezlA = montrezlA / montrezlGP;
                            
                            montrezlR = montrezlR / montrezlGP;
                            
                            matisseP = matisseP / matisseGP;
                            
                            matisseA = matisseA / matisseGP;
                            
                            matisseR = matisseR / matisseGP;
                            
                            furkanP = furkanP / furkanGP;
                            
                            furkanA = furkanA / furkanGP;
                            
                            furkanR = furkanR / furkanGP;
                            
                            paulP = paulP / paulGP;
                            paulP = Math.Round(paulP, 2);
                            paulA = paulA / paulGP;
                            paulA = Math.Round(paulA, 2);
                            paulR = paulR / paulGP;
                            paulR = Math.Round(paulR, 2);

                        }
                    }
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //joel
                using (SqlCommand querySearch = new SqlCommand("dropQ1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                using (SqlCommand querySearch = new SqlCommand("tableCreation"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", joel);
                    querySearch.Parameters.AddWithValue("@points", joelP);
                    querySearch.Parameters.AddWithValue("@assists", joelA);
                    querySearch.Parameters.AddWithValue("@rebounds", joelR);
                    querySearch.Parameters.AddWithValue("@player_id", joelID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //tyrese              
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", tyrese);
                    querySearch.Parameters.AddWithValue("@points", tyreseP);
                    querySearch.Parameters.AddWithValue("@assists", tyreseA);
                    querySearch.Parameters.AddWithValue("@rebounds", tyreseR);
                    querySearch.Parameters.AddWithValue("@player_id", tyreseID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //james
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", james);
                    querySearch.Parameters.AddWithValue("@points", jamesP);
                    querySearch.Parameters.AddWithValue("@assists", jamesA);
                    querySearch.Parameters.AddWithValue("@rebounds", jamesR);
                    querySearch.Parameters.AddWithValue("@player_id", jamesID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //tobias
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", tobias);
                    querySearch.Parameters.AddWithValue("@points", tobiasP);
                    querySearch.Parameters.AddWithValue("@assists", tobiasA);
                    querySearch.Parameters.AddWithValue("@rebounds", tobiasR);
                    querySearch.Parameters.AddWithValue("@player_id", tobiasID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //shake              
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", shake);
                    querySearch.Parameters.AddWithValue("@points", shakeP);
                    querySearch.Parameters.AddWithValue("@assists", shakeA);
                    querySearch.Parameters.AddWithValue("@rebounds", shakeR);
                    querySearch.Parameters.AddWithValue("@player_id", shakeID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //deanthony
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", deanthony);
                    querySearch.Parameters.AddWithValue("@points", deanthonyP);
                    querySearch.Parameters.AddWithValue("@assists", deanthonyA);
                    querySearch.Parameters.AddWithValue("@rebounds", deanthonyR);
                    querySearch.Parameters.AddWithValue("@player_id", deanthonyID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////
                //pj
                using (SqlCommand querySearch = new SqlCommand("insert1"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    querySearch.Connection = sqlConnect;
                    querySearch.Parameters.AddWithValue("@team", sixers);
                    querySearch.Parameters.AddWithValue("@player", pj);
                    querySearch.Parameters.AddWithValue("@points", pjP);
                    querySearch.Parameters.AddWithValue("@assists", pjA);
                    querySearch.Parameters.AddWithValue("@rebounds", pjR);
                    querySearch.Parameters.AddWithValue("@player_id", pjID);
                    querySearch.Parameters.AddWithValue("@team_id", team_id);
                    sqlConnect.Open();
                    querySearch.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                using (SqlCommand querySearch = new SqlCommand("q1ForNow"))
                {
                    querySearch.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                    {
                        querySearch.Connection = sqlConnect;
                        sDataSearch.SelectCommand = querySearch;
                        using (DataTable dataT = new DataTable())
                        {
                            sDataSearch.Fill(dataT);
                            grdFirstQ.DataSource = dataT;
                            grdFirstQ.DataBind();
                        }
                    }
                }
            }           
        }


      
        protected void grdFirstQ_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}