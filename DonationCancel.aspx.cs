using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subPage1 : System.Web.UI.Page
{
    // ================================================================
    /*
        * Donation Cancelled Page
        * Code Behind, displays cancelled message
        * By Anja Gusev
        */
    // ================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_submasterSubHeading = "Donation Cancelled";

    }

    protected void subClick(object sender, EventArgs e)
    {
        Response.Redirect("http://timmins.sidhusweb.com/Donation.aspx");
    }
}