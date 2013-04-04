using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void subClick(object sender, EventArgs e)
    {

        SmtpClient client = new SmtpClient("localhost");
        client.Send("anjag@anja-gusev.com", "anjag@anja-gusev.com", "mooo", "mooo");

    }
}
 
//    protected void btnSendmail_Click(object sender, EventArgs e)
//        {
//            // System.Web.Mail.SmtpMail.SmtpServer is obsolete in 2.0
//            // System.Net.Mail.SmtpClient is the alternate class for this in 2.0
//            SmtpClient smtpClient = new SmtpClient();
//            MailMessage message = new MailMessage();

//            try
//            {
//                MailAddress fromAddress = new MailAddress(txtEmail.Text, txtName.Text);

//                // You can specify the host name or ipaddress of your server
//                // Default in IIS will be localhost 
//                smtpClient.Host = "localhost";

//                //Default port will be 25
//                smtpClient.Port = 25;
                

//                //From address will be given as a MailAddress Object
//                message.From = fromAddress;

//                // To address collection of MailAddress
//                message.To.Add("anja.gusev@gmail.com");
//                message.Subject = "Feedback";

//                // CC and BCC optional
//                // MailAddressCollection class is used to send the email to various users
//                // You can specify Address as new MailAddress("admin1@yoursite.com")
//              //  message.CC.Add("muthu17green@gmail.com");
//                //message.CC.Add("muthu17green@gmail.com");

//                // You can specify Address directly as string
//               // message.Bcc.Add(new MailAddress("muthu17green@gmail.com"));
//                message.Bcc.Add(new MailAddress("anja.gusev@gmail.com"));

//                //Body can be Html or text format
//                //Specify true if it  is html message
//                message.IsBodyHtml = false;

//                // Message body content
//                message.Body = txtMessage.Text;

//                // Send SMTP mail
//                smtpClient.Send(message);

//                lblStatus.Text = "Email successfully sent.";
//            }
//            catch (Exception ex)
//            {
//                lblStatus.Text = "Send Email Failed.<br>" + ex.Message;
//            }
//        }
//        #endregion

//        #region "Reset"
//        protected void btnReset_Click(object sender, EventArgs e)
//        {
//            txtName.Text = "";
//            txtMessage.Text = "";
//            txtEmail.Text = "";
//        }
//        #endregion
//    }


////    protected void SendMessage(object sender, EventArgs e)
////    {

////        MailMessage msg = new MailMessage(fromAddress, toAddress, subject, body);
////        msg.CC.Add(new MailAddress(ccAddress);

////    }

////    protected void SendConfirmation()
////    {
////        MailMessage msg = new MailMessage("halloween@murach.com", toAddress);
////        msg.Subkect = "Order Confirmation";
////        msg.Body = this.GetConfirmationMessage();
////        msg.IsBodyHtml = true;
////        SmtpClient client = new SmtpClient("localhost");
////        clcient.Send(msg);
////    }

////    private string GetConfirmatoinMessage();
////{
////    string message = "Thank you for your oder, "
////        return MailMessageEventArgs;
//}

