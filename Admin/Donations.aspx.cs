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
        grd_donations.DataSource = objDonation.getDonations();
        grd_donations.DataBind();
    }
}