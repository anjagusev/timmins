/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Job Postings Feature: Advanced Search
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subPage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_submasterSubHeading = "Job Postings Advanced Search";

    }

    // do advanced search
    protected void subSearch(object sender, EventArgs e)
    {
        // send appropriate query strings to job postings page
        Response.Redirect("JobPostings.aspx?as=true&asearch=" + txt_search.Text + "&department=" + ddl_department.SelectedValue.ToString() + "&hours=" + ddl_hours.SelectedValue.ToString() + "&deadline=" + txt_deadline.Text);
    }

}