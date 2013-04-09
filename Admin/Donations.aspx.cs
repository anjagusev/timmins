using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    DonationsClass objDonation = new DonationsClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("cph_admin_main"); //(replace this with whatever the content place holder id is that you are entering data into)

       GridView grd_donations = (GridView)contentPlaceHolder.FindControl("grd_donations"); //("ddlSurveys") is the name of my dropdown list id
        grd_donations.DataSource = objDonation.getDonations();
        grd_donations.DataBind();
    }
}