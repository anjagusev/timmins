using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

public class email
{
	// instance of mailmessage class is created
	MailMessage obj_Mail = new MailMessage();

    public bool emailconFig(string _email, string _subject, string email_body)
    {
        SmtpClient smtpclient = new SmtpClient();
        MailMessage mailMessage = new MailMessage();

        mailMessage.Priority = MailPriority.High;

        //mailMessage.From = new MailAddress(_email);
        mailMessage.To.Add(_email);

        mailMessage.Subject = _subject;
        mailMessage.Body = email_body;
        mailMessage.IsBodyHtml = true;

        smtpclient.Send(mailMessage);

        return true;

    }

}