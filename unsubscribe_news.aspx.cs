using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class unsubscribe_news : System.Web.UI.Page
{
    subscriberClass objunsub = new subscriberClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["email"] != null)
        {
            string email_received = Request["email"];

            objunsub.unsubscribe(email_received);

        }
        else
        {

            lbl_text.Text = "<strong>not a valid user</strong>";
        }

    }

    protected void subsubmit(object sender, EventArgs e)
    {
        if (Request.QueryString["email"] != null)
        {
            string email_received = Request["email"];

            string reason = txt_comment.Text;

            objunsub.reasonOfUnsub(email_received, reason);

            lbl_id.Visible = true;
        }

    }
}