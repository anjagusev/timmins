﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Net.Mime;


// ================================================================
/*Anja Gusev's Class
 * Email Class
 * 
 * Instantiate this class to use the gmail emailer for Nortre Dame 
 * Hospital. Currently uses gmail as the smtp server, allows user
 * to have flexibility with gmail client. Can be changed by altering
 * the settings below
 * 
 */



public class emailClass
{
    public bool sendEmail(string _conName, string background, string _conEmail, string _conReason, string _conMessage)
    {
        MailMessage objMail = new MailMessage(_conEmail, _conEmail, _conReason, _conMessage);
        NetworkCredential objNC = new NetworkCredential("timminshospital@gmail.com", "group_four");
        SmtpClient objSMTP = new SmtpClient("smtp.gmail.com", 587); // smptp server for gmail



        string imgdisplay = "http://timmins.sidhusweb.com/" + background;

        //LinkedResource backgroundimg = new LinkedResource(imgdisplay);
        //backgroundimg.ContentId = "background";
        // done HTML formatting in the next line to display my logo
        AlternateView av1 = AlternateView.CreateAlternateViewFromString("<html><body><br>" + _conMessage + "</body></html>", null, MediaTypeNames.Text.Html);

        using (objSMTP)
        {
          //    av1.LinkedResources.Add(backgroundimg);
            objMail.AlternateViews.Add(av1);
            objMail.IsBodyHtml = true; // allows use of html in body
            objSMTP.EnableSsl = true; // enable ssl, required for gmail
            objSMTP.Credentials = objNC;
            objSMTP.Send(objMail);
            return true;
        }
    }


    //Joel: I added this "sendMail" section
    public bool sendMail(string _conName, string _conEmail, string _conReason, string _conMessage)
    {
        MailMessage objMail = new MailMessage(_conEmail, _conEmail, _conReason, _conMessage);
        NetworkCredential objNC = new NetworkCredential("timminshospital@gmail.com", "group_four");
        SmtpClient objSMTP = new SmtpClient("smtp.gmail.com", 587); // smtp server for gmail

        using (objSMTP)
        {
            objMail.IsBodyHtml = true; // allows use of html in body
            objSMTP.EnableSsl = true; // enable ssl, required for gmail
            objSMTP.Credentials = objNC;
            objSMTP.Send(objMail);
            return true;
        }
    }
}


