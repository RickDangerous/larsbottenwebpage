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

public partial class Contact : System.Web.UI.Page
{
    private LarsBottenDataContext dc = new LarsBottenDataContext();

    private string output;

    protected void Page_Load(object sender, EventArgs e)
    {
        var contacts = from c in dc.ContactsTBLs
                      orderby c.priority ascending
                      select c;

        int i = 0;
        foreach (var contact in contacts)
        {
            output += "<div style='width: 230px; height: 150px; float: left; font: 12px  Trebuchet MS, arial, helvetica, sans-serif; padding-left: 10px; padding-right: 10px; padding-top: 8px;'>";
            if (contact.name.Length > 0)
                output += "<b>" + contact.name.ToUpper() + "</b><br />";
            output += "<img src='_img/CHR.png' style='padding-top: 0px; margin-top: 0px; height: 1;' border='0'/><br />";
            if (contact.address.Length > 0)
                output += contact.address + "<br />";
            if (contact.postnumber.Length > 0)
                output += contact.postnumber + " ";
            if (contact.place.Length > 0)
                output += contact.place + " ";
            if (contact.country.Length > 0)
                output += contact.country + "<br />";
            if (contact.phone.Length > 0)
                output += "phone:" + contact.phone + "<br />";
            if (contact.fax.Length > 0)
                output += "fax:" + contact.fax + "<br />";
            if (contact.email.Length > 0)
                output += "<a href=\"mailto:" + contact.email + "\">" + contact.email + "<a/><br />";
            if (contact.www.Length > 0)
                output += "<a href=\"http://" + contact.www + "\" target=\"_blank\">" + contact.www + "</a><br />";
            if(i == 0)
                output += "<br />";
            output += "</div>";
            i++;
        }
    }

    public string EVIL_HTML
    {
        get
        {
            return output;
        }
    }

    private IList GetContacts(int row, int size)
    {
        var contacts = from c in dc.ContactsTBLs
                       orderby c.priority ascending
                       select c;

        return contacts.Skip(row).Take(size).ToList();
    }
}