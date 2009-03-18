using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Site : System.Web.UI.MasterPage
{
    LarsBottenDataContext dc = new LarsBottenDataContext();

    private string evil_html;

    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateEvilRepeaterOfDOOM();
    }

    public string EVIL_HTML_OF_DOOM
    {
        get
        {
            return evil_html;
        }
    }

    private void PopulateEvilRepeaterOfDOOM()
    {
        var cells = from rc in dc.CellsTBLs
                         orderby rc.priority ascending
                         select rc;

        foreach (var root_cell in cells.Where(rc => rc.parent_id == 0))
        {
            int i = 1;
            evil_html += "<li><a href=\"Sequence.aspx?id=" + root_cell.cell_id + "\">" + root_cell.name.ToUpper() + "</a></li>\n";
            foreach (var sub_cell in cells.Where(sc => sc.parent_id == root_cell.cell_id))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    if (Convert.ToInt32(Request.QueryString["subid"]) == sub_cell.cell_id)
                    {
                        evil_html += "<li><a href=\"Sequence.aspx?id=" + root_cell.cell_id + "&subid=" + sub_cell.cell_id + "\" style=\"padding-left: 10px; font-weight: bold; color: #000000;\">   " + sub_cell.name + "</a></li>\n";
                        if (i == cells.Where(sc => sc.parent_id == root_cell.cell_id).Count())
                            evil_html += "<div style=\"height: 5px;\"></div>\n";
                    }
                    else if (Convert.ToInt32(Request.QueryString["id"]) == root_cell.cell_id)
                    {
                        evil_html += "<li><a href=\"Sequence.aspx?id=" + root_cell.cell_id + "&subid=" + sub_cell.cell_id + "\" style=\"padding-left: 10px;\">   " + sub_cell.name + "</a></li>\n";
                        if (i == cells.Where(sc => sc.parent_id == root_cell.cell_id).Count())
                            evil_html += "<div style=\"height: 5px;\"></div>\n";
                    }
                }
                i++;
            }
        }
    }
}