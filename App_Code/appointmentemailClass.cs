using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail; //added
using System.Net; //added


public class appointmentemailClass
{
    // sends email using timminshospital@gmail.com
    public bool sendEmail(string _email, string _subject, string _message)
    {

        // create message
        MailMessage objMail = new MailMessage();
        MailAddress fromEmail = new MailAddress("timminshospital@gmail.com");
        SmtpClient objSMTP = new SmtpClient("smtp.gmail.com");
        objMail.From = fromEmail;
        objMail.To.Add(new MailAddress(_email));
        objMail.Subject = _subject;
        objMail.Body = _message;
        objMail.IsBodyHtml = true;

        // smtp settings
        objSMTP.Credentials = new System.Net.NetworkCredential("timminshospital@gmail.com", "group_four");
        objSMTP.Port = 587;
        objSMTP.EnableSsl = true;

        // send email
        objSMTP.Send(objMail);

        return true;
    }
}