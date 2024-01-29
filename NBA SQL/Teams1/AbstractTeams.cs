/*
 Abstract Team Class.

 @Author Jacob
 @Version 3/25/2023
 @Inteface ITeam
 @Inteface Sysem.Web.UI.Page
*/
abstract class AbstractTeam : ITeam, System.Web.UI.Page 
{


    private color primary = System.Drawing.Color.Black;
    private color seconday = System.Drawing.Color.White;
    private static final string team = "DEFAULT";

    // Do these buttons all do the same shit?
    // Can it be reduced to 1 action listener?
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.BackColor = System.Drawing.Color.White; Button1.ForeColor = System.Drawing.Color.Black;
        Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000"); Button2.ForeColor = System.Drawing.Color.White;
        Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000"); Button3.ForeColor = System.Drawing.Color.White;
        Button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000"); Button4.ForeColor = System.Drawing.Color.White;
        GridView1.Visible = true;
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = true;
        GridView6.Visible = false;
        GridView7.Visible = false;
        GridView8.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button1.ForeColor = System.Drawing.Color.White;
        Button2.BackColor = System.Drawing.Color.LightCyan; Button2.ForeColor = System.Drawing.Color.Black;
        Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button3.ForeColor = System.Drawing.Color.White;
        Button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button4.ForeColor = System.Drawing.Color.White;
        GridView1.Visible = false;
        GridView2.Visible = true;
        GridView3.Visible = false;
        GridView4.Visible = false;
        GridView5.Visible = false;
        GridView6.Visible = true;
        GridView7.Visible = false;
        GridView8.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button1.ForeColor = System.Drawing.Color.White;
        Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button2.ForeColor = System.Drawing.Color.White;
        Button3.BackColor = System.Drawing.Color.LightCyan; Button3.ForeColor = System.Drawing.Color.Black;
        Button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button4.ForeColor = System.Drawing.Color.White;
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = true;
        GridView4.Visible = false;
        GridView5.Visible = false;
        GridView6.Visible = false;
        GridView7.Visible = true;
        GridView8.Visible = false;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button1.ForeColor = System.Drawing.Color.White;
        Button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button2.ForeColor = System.Drawing.Color.White;
        Button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#006bb6"); Button3.ForeColor = System.Drawing.Color.White;
        Button4.BackColor = System.Drawing.Color.LightCyan; Button4.ForeColor = System.Drawing.Color.Black;
        GridView1.Visible = false;
        GridView2.Visible = false;
        GridView3.Visible = false;
        GridView4.Visible = true;
        GridView5.Visible = false;
        GridView6.Visible = false;
        GridView7.Visible = false;
        GridView8.Visible = true;
    }

    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (team.equals("DEFAULT")) return;
        SqlConnection sqlConnect = new SqlConnection("Server=localhost;Database=nba;User Id=test;Password=test123;");
        using (sqlConnect)
        {
            string team = "76ers";
            string id = GetHTMLID(sender);
            string command = GetSQLGridCommand(id);
            using (SqlCommand querySearch = new SqlCommand(command)
            {
                querySearch.CommandType = CommandType.StoredProcedure;
                querySearch.Parameters.AddWithValue("@team", team);
                using (SqlDataAdapter sDataSearch = new SqlDataAdapter())
                {
                    querySearch.Connection = sqlConnect;
                    sDataSearch.SelectCommand = querySearch;
                    using (DataTable dataT = new DataTable())
                    {
                        sDataSearch.Fill(dataT);
                        string sortDir = SortDirection();
                        DataView sortedView = new DataView(dataT);
                        sortedView.Sort = e.SortExpression + " " + sortDir;
                        GridView1.DataSource = sortedView;
                        GridView1.DataBind();
                        int i = 0;
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            i++;
                            if (i >= 8)
                            {
                                row.Visible = false;
                            }
                        }
                    }
                }
            }
        }
    }
    
    /*
        Gets the sql command based of which gridview is calling it.

        @param string id
        @return string
    */
    private static string GetSQLGridCommand(string id)
    {
        string str = "";
        switch (id)
        {
            case "GridView1":
                str = "q1AvgP"
                break;
            case "GridView2":
                str = "q2AvgP"
                break;
            case "GridView3":
                str = "q3AvgP"
                break;
            case "GridView4":
                str = "q4AvgP"
                break;
            case "GridView5":
                str = "q5AvgP"
                break;
            case "GridView6":
                str = "q6AvgP"
                break;
            case "GridView7":
                str = "q7AvgP"
                break;
            case "GridView8":
                str = "q8AvgP"
                break;
            default:
                break;
        }
        return str;
    }

    /*
        Generates the ID for a html component in case a certain command needs to be ran.
        @param object sender
        @return string
    */
    private static string GetHTMLID(object sender)
    {
        HtmlGenericControl input = (HtmlGenericControl)sender as HtmlGenericControl;
        string str = input.ID.ToString();
        if (String.IsNullOrEmpty(str)) return "";
        return str;
    }

    /*
        Decides the direction to sort Grids in.
        Also this could be fucked up.
        @returns string
    */
    private string sortDirection()
    {
        if (dir == SortDirection.Ascending)
        {
            dir = SortDirection.Descending;
            return "Desc";
        }
        else
        {
            dir = SortDirection.Ascending;
            return "Asc";
        }
    }
}