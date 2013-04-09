using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subPage1 : System.Web.UI.Page
{   public string paymentGross;
    //  public string Amount { get { return "moo"; } }
    //public string Amount;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_submasterSubHeading = "Thank you for donating!";


        //id = Request.QueryString ["id"]; 
        //   NameValueCollection nvc = Request.Form;

        if (!string.IsNullOrEmpty(Request["amt"]))
        {

            paymentGross = Request["amt"].ToString();
            //     lbl_received.Text = (string)Session["fName"].ToString();

        }

        else
        {
          //  Response.Redirect("http://timmins.sidhusweb.com/Donation.aspx");
            // string fname = Request["email"];
            // lbl_amount.Text += fname;
        }

        lbl_amount.Text += paymentGross;


        // Databind this to ensure user controls will behave
        this.DataBind();

    }

}

