using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

public class email
{
	// instance of mailmessage class is created
	MailMessage obj_Mail = new MailMessage();

	public bool emailMethod(string _emailTo , int _lastInsertID)
	{
		// email to 
		obj_Mail.To.Add(_emailTo);
	// email from and instance of mailAddress
		MailAddress mailAddress = new MailAddress("timmins@sidhusweb.com");
		obj_Mail.From = mailAddress;
		// Subject and Body
		obj_Mail.Subject = "Confirm Your Registration with Timmins and District Hospital";
		obj_Mail.Body = "<html><body><h1></h1><a href='Confirm_email.aspx?id=" + _lastInsertID + 
						">Click here to activate your service.</a><br/><p>Thanks</p></body></html>";
		obj_Mail.IsBodyHtml = true;
		

		// Init SmtpClient and send on port 587 in my case. (Usual=port25)
		SmtpClient smtpClient = new SmtpClient("mail.snare.arvixe.com", 587);

		System.Net.NetworkCredential credentials =
		   new System.Net.NetworkCredential("timmins@sidhusweb", "group");
		smtpClient.Credentials = credentials;

		smtpClient.Send(obj_Mail);

		return true;

	}

}