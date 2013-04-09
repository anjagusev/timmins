using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;


    // ================================================================
    /*
     * Donation Feature
     * Code Behind, gets user information, redirects to paypal page, stores
     * the donation information in the database if it is sucessful.
     * Redirects to the cancel or success page.
     * By Anja Gusev
     */
    // ================================================================
public partial class subPage1 : System.Web.UI.Page
{
    

        DataClassesDataContext db = new DataClassesDataContext();
        DonationsClass objDonations = new DonationsClass();
        tbl_donation donation = new tbl_donation();
        public string complete;
        public string amount;

        protected void Page_Load(object sender, EventArgs e)
        {
             Master.pp_submasterSubHeading = "Donations";

            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["st"]))
                {

                    complete = Request["st"].ToString();

                    amount = Request["amt"].ToString();

                }

                if (complete == "Completed")
                {
                    string email = (string)Session["email"];
                    string fname = (string)Session["fName"];

                    string lname = (string)Session["lname"];

                    DateTime now = DateTime.Now;

                    if (((email != null) & (fname != null) & (lname != null)))
                    {
                        objDonations.commitInsert(fname, lname, email, decimal.Parse(amount), now);

                    }
                    //http://timmins.sidhusweb.com/DonationCompleted.aspx?email={0}&fname={1}&st={2}&amt={3}", email, fname, complete, amount old

                    var url = String.Format("http://timmins.sidhusweb.com/DonationCompleted.aspx?email={0}&fname={1}&st={2}&amt={3}", email, fname, complete, amount);
                    Response.Redirect(url);


                    // Response.Redirect("http://timmins.sidhusweb.com/DonationCompleted.aspx");
                    // lbl_output.Text = "Yay";
                }


            }

        }

        // public List<string> getInfo(string fname, string lname, string email)
        // {
        //     List<string> info = new List<string>();
        //     info.Add(fname);
        //     info.Add(lname);
        //     info.Add(email);

        //   return info;
        //}
        protected void subClick(object sender, EventArgs e)
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("cph_main"); //(replace this with whatever the content place holder id is that you are entering data into)

            TextBox txtEmail = (TextBox)contentPlaceHolder.FindControl("txtEmail");
            TextBox txtFname = (TextBox)contentPlaceHolder.FindControl("txtFname");
            TextBox txtlName = (TextBox)contentPlaceHolder.FindControl("txtLname");

         
            // if (Session["Numbers"] != null)
            //{
            // int _num = (int)Session["Numbers"];
            //  Session["Numbers"] = _num + 1; //increment session
            Session["fName"] = txtFname.Text;
            Session["email"] = txtEmail.Text;
            Session["lName"] = txtlName.Text;

            string _fname = (string)Session["fName"];

            // }
            //email = txtEmail.Text;
            //fname = txtFname.Text;
            //string lname = txtLname.Text;


            //  getInfo(fname, lname, email);

            //this is the online version of the button
            Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XRQ633HENA86C&return=http://timmins.sidhusweb.com/Donation.aspx&notify_url=http://www.anja-gusev.com/test3.aspx&cancel_return=http://timmins.sidhusweb.com/DonationCancel.aspx");


        }
        //creating public properties
        public TextBox pp_fname
        {
            get { return txtFname; }
        }

        public TextBox pp_lname
        {
            get { return txtLname; }
        }

        public TextBox pp_email
        {
            get { return txtEmail; }
        }
    }



