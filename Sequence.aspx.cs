using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Sequence : System.Web.UI.Page
{
    private LarsBottenDataContext dc = new LarsBottenDataContext();
    private IOrderedQueryable<ImagesTBL> images;

    private string js;
    private string evil_pager;

    private int iterator = 0;

    private const string SCRIPT_TEMPLATE = "<script type=\"text/javascript\">\nvar Images = new Array();\n{0}\n</script>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString["subid"]))
        {
            //PROTEGEES
            int id = Convert.ToInt32(Request.QueryString["id"]);
            images = LinqGetProtegees(id);
            //SETTING THUMBNAILS LINK
            hl_thumbnails.NavigateUrl = "~/Thumbnails.aspx?id=" + Request.QueryString["id"];
        }
        else
        {
            //SUBCELLS
            int id = Convert.ToInt32(Request.QueryString["subid"]);
            images = LinqGetSubcells(id);
            //SETTING THUMBNAILS LINK
            hl_thumbnails.NavigateUrl = "~/Thumbnails.aspx?id=" + Request.QueryString["id"] + "&subid=" + Request.QueryString["subid"];
        }
        //GENERATE IMAGES TO PRELOAD
        foreach(var image in images)
        {
            js += "\tImages[" + iterator + "] = new Image(750, 500).src = \"Admin/_dynimg/Image/" + image.image_id + ".jpg\";\n";
            iterator++;
        }
        js = string.Format(SCRIPT_TEMPLATE, js);
        if (images.FirstOrDefault() != null)
        {
            main_image.ImageUrl = "~/Admin/_dynimg/Image/" + images.FirstOrDefault().image_id + ".jpg";
        }

        //SETTING CURRENT PAGER || FROM THUMBNAILS
        if(!String.IsNullOrEmpty(Request.QueryString["pid"]))
        {
            evil_pager = "var pager = " + Request.QueryString["pid"] + ";";
        }

        //SETTING CREDITS
        GetCredits();
    }
    
    public String JS
    {
        get
        {
            return js;
        }
    }

    public String EVIL_PAGER_OF_DOOM
    {
        get
        {
            return evil_pager;
        }
    }

    private IOrderedQueryable<ImagesTBL> LinqGetProtegees(int id)
    {
        var img = from i in dc.ImagesTBLs
                  where i.promote_id == id
                  orderby i.promotepriority ascending
                  select i;
        return img;
    }

    private IOrderedQueryable<ImagesTBL> LinqGetSubcells(int id)
    {
        var img = from ci in dc.ImagesTBLs
                  where ci.cell_id == id
                  orderby ci.priority ascending
                  select ci;
        return img;
    }

    private void GetCredits()
    {
        int current_id = 0;

        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            current_id = Convert.ToInt32(Request.QueryString["id"]);
        if (!String.IsNullOrEmpty(Request.QueryString["subid"]))
            current_id = Convert.ToInt32(Request.QueryString["subid"]);

        var cell = dc.CellsTBLs.First(c => c.cell_id == current_id);

        l_credits_1_t.Text = cell.credit_1_t;
        l_credits_2_t.Text = cell.credit_2_t;
        l_credits_3_t.Text = cell.credit_3_t;
        l_credits_4_t.Text = cell.credit_4_t;
        l_credits_5_t.Text = cell.credit_5_t;
        l_credits_6_t.Text = cell.credit_6_t;
        l_credits_1.Text = cell.credit_1;
        l_credits_2.Text = cell.credit_2;
        l_credits_3.Text = cell.credit_3;
        l_credits_4.Text = cell.credit_4;
        l_credits_5.Text = cell.credit_5;
        l_credits_6.Text = cell.credit_6;
    }
}