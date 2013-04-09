﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string _title = "Timmins and District Hospital";
    public string pp_submasterTitle
    {
        get { return _title; }
        set { _title = value; }
    }

    private string _subheading = "Default Heading";
    public string pp_submasterSubHeading
    {
        get { return _subheading; }
        set { _subheading = value; }
    }

    protected void imgClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    //sends the search text to "results.aspx" to perform search function and display the results
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["test"] = searchbox.Text;
        Response.Redirect("result.aspx");//sends the text to result.aspx and opens it
    }

}

