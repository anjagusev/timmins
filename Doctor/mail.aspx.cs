using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doctor_mail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    emailClass objEmail = new emailClass();


    protected void subClick(object sender, EventArgs e)
    {
        String _body = "Hello! <p>You received a message from " + txt_name.Text.ToString() + "</p><br /><p>The message says: </p><br />" + txt_message.Text.ToString() + "<br /><p>Reply to this mail at " + txt_mymail.Text.ToString() + "</p>";
        _strMessage(objEmail.sendMail(txt_name.Text, txt_email.Text, txt_reason.Text, _body));
        //Response.Redirect("contact.aspx"); //force refresh
    }


    private void _strMessage(bool flag)
    {
        if (flag)
        {
            lbl.Text = "Mail sent";
        }
        else
        {
            lbl.Text = "Could not send the mail";
        }
    }
}