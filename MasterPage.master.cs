using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class MasterPage : System.Web.UI.MasterPage
{

    DataClassesDataContext dbDC = new DataClassesDataContext();
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
        getActive();
        if (!Page.IsPostBack)
        {
            _subRebind();

        }
        this.MsgBoxContinue.Value = Page.ClientScript.GetPostBackEventReference(ShowSurvey, string.Empty);
        PopulateSurvey();
    }

    public void subMobile(object sender, EventArgs e)
    {
        //   SiteMap objSM = new SiteMap();
        string title = ddl_menu.SelectedItem.ToString();

        List<SiteMap> getUrl = (from s in dbDC.SiteMaps where s.Title == title select s).ToList();

        foreach (SiteMap s in getUrl)
        {
            Response.Redirect(s.Url);
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


    //((((((((((((((((( newsletter feature ))))))))))))))))
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

        // receiving text value enter by user 
        string Username = txt_name.Text;
        string Useremail = txt_email.Text;
        // checking againt table it is all ready exists
        var exist = objsubscribe.emailExist(Useremail);

        if (exist.Any())
        {
            _strMessage(false, "subscribed");
            _subRebind();
        }
        else
            // if those values doesn't exist
        {
            // passing value to insert method to insert in subscriber table
            _strMessage(objsubscribe.CommitInsert(Username, Useremail), "subscribed");
            _subRebind();


            // variable lastID is getting last inserted id
            int lastID = Convert.ToInt16(objsubscribe.last_id().ToString());
            string subject_email = "Confirm Your Registration with Timmins and District Hospital";
            string body_email = "<a href='http://timmins.sidhusweb.com/confirm_email.aspx?id=" + lastID + "'>Click here act your service.</a>";

            // send mail which will carry last inserted id
            email objemail = new email();

           // using email class object and calling emailconfig method, passing argrument
            objemail.emailconFig(Useremail, subject_email, body_email);

        }
    }

    //sends the search text to "results.aspx" to perform search function and display the results
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["test"] = searchbox.Text;
        Response.Redirect("result.aspx");//sends the text to result.aspx and opens it
    }

    /******BEGIN SURVEY FEEDBACK FEATURE******************/


    //set the survey id that is active for the whole form
    int surveyid;
    // SurveysDataContext surveyDC = new SurveysDataContext();
    SurveyResponse surveyresponse = new SurveyResponse();

    private void getActive()
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        List<int> activesurvey = (from s in dbDC.Surveys
                                  where s.Status == "Active"
                                  select s.ID).ToList();

        surveyid = activesurvey[0];
    }



    protected void ddlSurveys_SelectedIndexChanged(object sender, EventArgs e)
    {


    }



    private void PopulateSurvey()
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();

        SurveyQuestion surveyquestions = new SurveyQuestion();
        SurveyQuestionClass sQC = new SurveyQuestionClass();


        SurveyResponseClass objSurveyResponse = new SurveyResponseClass();

        btnSubmit.Enabled = true;


        List<Question> questions = (from p in dbDC.Questions
                                    join q in dbDC.GetTable<SurveyQuestion>() on p.ID equals q.QuestionID
                                    where q.SurveyID == surveyid
                                    select p).ToList();


        Table tbl = new Table();
        tbl.ID = "tbl_response";
        tbl.Width = Unit.Percentage(100);
        TableRow tr;
        TableCell tc;
        TextBox txt;
        CheckBox cbk;
        DropDownList ddl;
        ListBox lb;
        RequiredFieldValidator rfv;

        foreach (Question q in questions)
        {
            tr = new TableRow();
            tc = new TableCell();
            tc.Width = Unit.Percentage(25);
            tc.Text = q.Text;
            tc.Attributes.Add("id", q.ID.ToString());
            tr.Cells.Add(tc);
            tc = new TableCell();

            if (q.QuestionType.ToLower() == "singlelinetextbox")
            {
                txt = new TextBox();
                txt.ID = "txt_" + q.ID;
                txt.Width = Unit.Percentage(40);
                tc.Controls.Add(txt);

                rfv = new RequiredFieldValidator();
                rfv.ID = "rfv_" + txt.ID;
                rfv.ControlToValidate = txt.ID;
                rfv.Text = "*Required";
                tc.Controls.Add(rfv);

            }

            if (q.QuestionType.ToLower() == "multiline")
            {
                txt = new TextBox();
                txt.ID = "txt_" + q.ID;
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Width = Unit.Percentage(40);
                tc.Controls.Add(txt);
                rfv = new RequiredFieldValidator();
                rfv.ID = "rfv_" + txt.ID;
                rfv.ControlToValidate = txt.ID;
                rfv.Text = "*Required";
                tc.Controls.Add(rfv);
            }

            if (q.QuestionType.ToLower() == "yesorno")
            {
                cbk = new CheckBox();
                cbk.ID = "cbk_" + q.ID;
                cbk.AutoPostBack = false;
                tc.Controls.Add(cbk);
                rfv = new RequiredFieldValidator();
                rfv.ID = "rfv_" + cbk.ID;
                rfv.ControlToValidate = cbk.ID;
                rfv.Text = "*Required";
                tc.Controls.Add(rfv);
            }

            if (q.QuestionType.ToLower() == "singleselect")
            {
                ddl = new DropDownList();
                ddl.ID = "ddl_" + q.ID;
                ddl.Width = Unit.Percentage(41);
                if (!string.IsNullOrEmpty(q.Options))
                {
                    string[] values = q.Options.Split(',');
                    foreach (string v in values)
                        ddl.Items.Add(v.Trim());
                }
                tc.Controls.Add(ddl);

                rfv = new RequiredFieldValidator();
                rfv.ID = "rfv_" + ddl.ID;
                rfv.ControlToValidate = ddl.ID;
                rfv.Text = "*Required";
                tc.Controls.Add(rfv);
            }

            if (q.QuestionType.ToLower() == "multiselect")
            {
                lb = new ListBox();
                lb.ID = "lb" + q.ID;
                lb.Width = Unit.Percentage(41);
                lb.SelectionMode = ListSelectionMode.Multiple;
                // lb.SelectionMode = SelectionMode.MultiExtended;
                if (!string.IsNullOrEmpty(q.Options))
                {
                    string[] values = q.Options.Split(',');
                    foreach (string v in values)
                        lb.Items.Add(v.Trim());
                }
                tc.Controls.Add(lb);

                rfv = new RequiredFieldValidator();
                rfv.ID = "rfv_" + lb.ID;
                rfv.ControlToValidate = lb.ID;
                rfv.Text = "*Required";
                tc.Controls.Add(rfv);
            }

            tc.Width = Unit.Percentage(80);
            tr.Cells.Add(tc);
            tbl.Rows.Add(tr);
        }
        pnlSurvey.Controls.Add(tbl);
        pnlSurvey.Visible = true;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        SurveyResponseClass objSurveyResponse = new SurveyResponseClass();


        List<SurveyResponse> response = GetSurveyReponse().ToList();
        foreach (SurveyResponse sres in response)
        {
            int _surveyid = sres.SurveyID;
            int _questionid = sres.QuestionID;
            string _value = sres.Value;
            int _filledby = Convert.ToInt32(sres.FilledBy);

            objSurveyResponse.commitInsert(_surveyid, _questionid, _value, _filledby);
           
           
        }

    }

   
    private List<SurveyResponse> GetSurveyReponse()
    {
        
        List<SurveyResponse> response = new List<SurveyResponse>();

        pnlSurvey.FindControl("tbl_response");

        foreach (Control ctr in pnlSurvey.Controls)
        {
            if (ctr is Table)
            {
                Table tbl = ctr as Table;

                foreach (TableRow tr in tbl.Rows)
                {

                    SurveyResponse sres = new SurveyResponse();
                    sres.FilledBy = 2;
                    sres.SurveyID = surveyid;
                    sres.QuestionID = Convert.ToInt32(tr.Cells[0].Attributes["ID"]);
                    TableCell tc = tr.Cells[1];
                    foreach (Control ctrc in tc.Controls)
                    {
                        if (ctrc is TextBox)
                        {
                            sres.Value = (ctrc as TextBox).Text.ToString();
                        }
                        else if (ctrc is DropDownList)
                        {
                            sres.Value = (ctrc as DropDownList).SelectedValue;
                        }

                        else if (ctrc is CheckBox)
                        {
                            sres.Value = (ctrc as CheckBox).Checked.ToString();
                        }


                        else if (ctrc is ListBox)
                        {
                            sres.Value = "";
                            foreach (ListItem item in (ctrc as ListBox).Items)
                            {
                                if (item.Selected)
                                {
                                    sres.Value += " " + item.Text;
                                }
                            }


                        }

                    }

                    response.Add(sres);

                }

            }
        }
        return response.ToList();
    }

}
