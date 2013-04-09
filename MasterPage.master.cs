using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class MasterPage : System.Web.UI.MasterPage
{
    private string _title = "Timmins and District Hospital";
    public string pp_masterTitle
    {
        get { return _title; }
        set { _title = value; }
    }

    protected void imgClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    //creating an instance of the article class
    articleClass objNews = new articleClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }
    

    private void _panelControl(Panel pnl)
    {
        pnl_paragraph.Visible = false;
        pnl_feeds.Visible = false;
        pnl.Visible = true;
    }

    private void _subRebind()
    {

        /*rpt_news.DataSource = objNews.getArticles();*/
        rpt_news.DataSource = objNews.getLastFiveArticles();
        
        rpt_news.DataBind();
        _panelControl(pnl_feeds);
    }

    private void _showNews(int id)
    {
        _panelControl(pnl_paragraph);
        rpt_paragraph.DataSource = objNews.getArticleByID(id);
        rpt_paragraph.DataBind();
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Showall":
                _showNews(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Feeds":
                _subRebind();
                break;
        }
    }


    // this code is for newsletter feature
    subscriberClass objsubscribe = new subscriberClass();

    MailMessage objMail = new MailMessage();

   

    public void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            email_Exist.Text = "<span style='color:green;'>Successfully  " + str + "<br/> Please check your email to verify.</span>";
            pnl_sub.Visible = false;        
        }
        else
        {
            email_Exist.Text = "<span style='color:red;'>You're already  " + str + " </span>";
        }
    }


    // code for submit button
    protected void subsubmit(object sender, EventArgs e)
    {
        

        string Username = txt_name.Text;
        string Useremail = txt_email.Text;
        var exist = objsubscribe.emailExist(Useremail);

        if (exist.Any())
        {
            _strMessage(false, "subscribed");
            _subRebind();
        }
        else
        {
            // insert through linq 
            _strMessage(objsubscribe.CommitInsert(Username, Useremail), "subscribed");
            _subRebind();

            // test last inserted id
            // lbl_lastid.Text = objsubClass.last_id().ToString();

            int lastID = Convert.ToInt16(objsubscribe .last_id().ToString());

            // send mail which will carry last inserted id
            email objemail = new email();

            objemail.emailMethod(Useremail, lastID);
        }

    }

    //sends the search text to "results.aspx" to perform search function and display the results
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["test"] = searchbox.Text;
        Response.Redirect("result.aspx");//sends the text to result.aspx and opens it
    }
}
