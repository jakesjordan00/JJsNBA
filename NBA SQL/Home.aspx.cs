using Microsoft.Ajax.Utilities;
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
    public partial class Home : System.Web.UI.Page
    {
        // ik you prolly dont care but don't use _ for name methods in c#, use CamelCase
        // Uncomment to test by using ctrl + /
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
                                directionArr[i].Src = reader["nickname"].ToString() + ".png";
                            }
                        }
                        querySearch.Connection.Close();
                    }
                    num++;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // For future reference, when you count start with 0 for programming. Indexes for arrays start at 0,
            // so its just good practice
            SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba1_18;User Id=test;Password=test123;");
            using (sqlConnect)
            {
                System.Web.UI.HtmlControls.HtmlImage[] eastArr = { e1p, e2p, e3p, e4p, e5p, e6p, e7p, e8p, e9p, e10p};
                PageLoadHelper("east", eastArr, sqlConnect);
                System.Web.UI.HtmlControls.HtmlImage[] westArr = { w1p, w2p, w3p, w4p, w5p, w6p, w7p, w8p, w9p, w10p };
                PageLoadHelper("west", westArr, sqlConnect);
                // Of this works you can delete all stuff thats basically the same below.
                //
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e1p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e2p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e3p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e4p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e5p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e6p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e7p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e8p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e9p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //E = E + 1;
                //using (SqlCommand querySearch = new SqlCommand("east"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", E);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                e10p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}



                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w1p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w2p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w3p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w4p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w5p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w6p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {

                //                w7p.Src = reader["nickname"].ToString() + ".png";
                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w8p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w9p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
                //W = W + 1;
                //using (SqlCommand querySearch = new SqlCommand("west"))
                //{
                //    querySearch.CommandType = CommandType.StoredProcedure;
                //    querySearch.Parameters.AddWithValue("@rank", W);
                //    using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                //    {
                //        querySearch.Connection = sqlConnect;
                //        sDataSearch.SelectCommand = querySearch;
                //        querySearch.Connection.Open();
                //        using (SqlDataReader reader = querySearch.ExecuteReader())
                //        {
                //            while (reader.Read())
                //            {
                //                w10p.Src = reader["nickname"].ToString() + ".png";

                //            }
                //        }
                //        querySearch.Connection.Close();
                //    }
                //}
            }
        }
    }
}