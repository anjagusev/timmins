using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        _subRebind();
    }

    private void _panelControl(Panel pnl)
    {
        pnl_paragraph.Visible = false;
        pnl_feeds.Visible = false;
        pnl.Visible = true;
    }

    private void _subRebind()
    {

        rpt_news.DataSource = objNews.getArticles();
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
            case "Feed":
                _subRebind();
                break;
        }
    }
}
