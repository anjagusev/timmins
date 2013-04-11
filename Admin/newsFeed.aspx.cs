using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// added by harry
using System.Net;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;

public partial class Admin_newsFeed : System.Web.UI.Page
{
    articleClass objNews = new articleClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    private void _subRebind()
    {
        txt_headI.Text = string.Empty;
        txt_introI.Text = string.Empty;
        txt_paraI.Text = string.Empty;
        rpt_all.DataSource = objNews.getArticles();
        rpt_all.DataBind();
        _panelControl(pnl_all);
    }

    private void _panelControl(Panel pnl)
    {
        pnl_all.Visible = false;
        pnl_delete.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            Response.Redirect("~/Admin/newsFeed.aspx");
            lbl_message.Text = "Article was succesfully " + str + ".";
        }
        else
        {
            lbl_message.Text = "Sorry, unable to " + str + " the article article.";
        }
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                _strMessage(objNews.commitInsert(txt_headI.Text, txt_introI.Text, txt_paraI.Text), "inserted");
                //++++++++++++++++++++++++ Added by harry
                subscriberClass objemails = new subscriberClass();
                emailADO adoreader = new emailADO();
                if (chk_newsletter.Checked)
                {
                    var allemails = adoreader.getemails();

                    SmtpClient smtpclient = new SmtpClient();
                    MailMessage mailMessage = new MailMessage();


                    mailMessage.Priority = MailPriority.High;
                    foreach (string email in allemails)
                    {
                        if (string.IsNullOrEmpty(email))
                        {

                        }
                        else
                        {

                            mailMessage.To.Add(email);
                            mailMessage.Subject = "News letter from Timmins";
                            mailMessage.Body = txt_headI.Text+"<br/>";

                            mailMessage.Body += txt_introI.Text+"<br/>";
                            mailMessage.Body += "http://timmins.sidhusweb.com/<br/>";
                            mailMessage.Body +="<a href='http://timmins.sidhusweb.com/confirm_email.aspx?id="+email+"'>Click Here to unsubscribe</a><br/>";
                        }
                    }
                    // from address is declared on web.config 
                    
                    
                    mailMessage.IsBodyHtml = true;
                    smtpclient.Send(mailMessage);
                    sent_success.Text = "<br/>E-Mail sent successfully ! ";

                }

                break;
            case "Update":
                _showUpdate(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Delete":
                _showDelete(int.Parse(e.CommandArgument.ToString()));
                break;
        }
    }

    private void _showUpdate(int id)
    {
        _panelControl(pnl_update);
        rpt_update.DataSource = objNews.getArticleByID(id);
        rpt_update.DataBind();
    }

    private void _showDelete(int id)
    {
        _panelControl(pnl_delete);
        rpt_delete.DataSource = objNews.getArticleByID(id);
        rpt_delete.DataBind();
    }

    protected void subUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":
                TextBox txtHead = (TextBox)e.Item.FindControl("txt_headingU");
                TextBox txtIntro = (TextBox)e.Item.FindControl("txt_introU");
                TextBox txtPara = (TextBox)e.Item.FindControl("txt_paraU");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");
                int proID = int.Parse(hdfID.Value.ToString());
                _strMessage(objNews.commitUpdate(proID, txtHead.Text.ToString(), txtIntro.Text.ToString(), txtPara.Text.ToString()), "updated");
                break;
            case "Delete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                _strMessage(objNews.commitDelete(_id), "deleted");
                _subRebind();
                break;
            case "Cancel":
                _subRebind();
                break;
        }
    }
}