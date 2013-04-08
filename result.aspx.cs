using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //perform the search function when the page loads
        String _text = Convert.ToString(Session["search"]);//retrieves the text from textbox in search

        try
        {
            //--- instantiate employee class
            articleClass employees = new articleClass();

            //--- execute search function and bind the IQueryable result to a gridview
            gtv.DataSource = employees.searchArticles(_text);
            gtv.DataBind();
        }
        catch (Exception ex)
        {
            lbl.Text = "Could not find any result that matches your request";
        }
    }
}