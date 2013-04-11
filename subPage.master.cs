using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subPage : System.Web.UI.MasterPage
{
    DataClassesDataContext dbDC = new DataClassesDataContext();


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

    private string _linktitle = "Related Links";
    public string pp_masterLink
    {
        get { return _linktitle; }
        set { _linktitle = value; }
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


    public void subMobile(object sender, EventArgs e)
    {
        //   SiteMap objSM = new SiteMap();
        string title = ddl_menu.SelectedItem.ToString();


        List<SiteMap> getUrl = (from s in dbDC.SiteMaps where s.Title == title select s).ToList();

        foreach (SiteMap s in getUrl)
        {
            Response.Redirect(s.Url);
        }

    }

    //public void subMobileSide(object sender, EventArgs e)
    //{
    //    //   SiteMap objSM = new SiteMap();
    //    string title = ddl_sideMenu.SelectedItem.ToString();


    //    List<SiteMap> getUrl = (from s in dbDC.SiteMaps where s.Title == title select s).ToList();

    //    foreach (SiteMap s in getUrl)
    //    {
    //        Response.Redirect(s.Url);
    //    }

    //}

}

