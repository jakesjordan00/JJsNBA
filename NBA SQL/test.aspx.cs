using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NBA_SQL
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StreamReader reader = File.OpenText("C:\\test.txt");
            
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                
                string[] items2;
                string home = "";
                string away = "";
                string hLine = "";
                string aLine = "";
                foreach (string item in items)
                {
                    if (item.Contains("home_team") || item.Contains("away_team") || item.Contains("price"))
                    {
                        if (item.Contains("home_team"))
                        {
                            home = item;
                        }
                        if (item.Contains("away_team"))
                        {
                            away = item;
                        }
                        if (item.Contains("price") && hLine != "")
                        {
                            aLine = item;
                        }
                        if (item.Contains("price") && hLine == "")
                        {
                            hLine = item;
                        }
                    }
                    if(home != "" && away != "" && hLine != "" && aLine != "")
                    {
                        home = home.Remove(0, 13);
                        home = home.Replace("\"", "");

                        away = away.Remove(0, 13);
                        away = away.Replace("\"", "");

                        hLine = hLine.Remove(0, 8);
                        hLine = hLine.Replace("}", "");

                        aLine = aLine.Remove(0, 8);
                        aLine = aLine.Replace("}]}]}]}", "");




                        
                        
                        
                        
                        hLine = "";
                        aLine = "";
                    }
                }





                // if (item.StartsWith("item\\") && item.EndsWith(".ddj"))
                //path = item;




                // At this point, `myInteger` and `path` contain the values we want
                // for the current line. We can then store those values or print them,
                // or anything else we like.
            }
        }
    }
}