using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confirm_email : System.Web.UI.Page
{
    subscriberClass objverify = new subscriberClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        // here it is  receiving id value from url  
        if (Request.QueryString["id"] != null)
        {
            // convert string to int
            int ID = Convert.ToInt16(Request["id"]);

            // this method is call from class file which will run the query to change  
            objverify.verify(ID);

        }

    }
}