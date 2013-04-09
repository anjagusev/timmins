using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : System.Web.UI.Page
{


    DataClassesDataContext dbDC = new DataClassesDataContext();
    // SurveyResponseDataContext SRDC = new SurveyResponseDataContext();
    SurveyResponseClass objSurveyResponse = new SurveyResponseClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        objSurveyResponse.getSurveyResponses();

        if (!Page.IsPostBack)
        {
            ltv_results.DataSource = objSurveyResponse.getSurveyResponses();
            ltv_results.DataBind();
        };

        //Literal lbl_surveyid = (Literal)FindControl("lbl_surveyid");

        HiddenField hdf = (HiddenField)FindControl("hdfID");
        // int surveyresponseid = Convert.ToInt32(hdf.Value.ToString());
        //HiddenField hdfSID = (HiddenField)FindControl("hdf_SID");
        //int surveyID = Convert.ToInt32(hdfSID);

        //List<string> surveytitle = (from q in dbDC.Questions
        //                            join sq in dbDC.SurveyQuestions on q.ID equals sq.QuestionID
        //                            join sr in dbDC.SurveyResponses on sq.SurveyID equals sr.SurveyID
        //                            join s in dbDC.Surveys on sr.SurveyID equals s.ID
        //                            where s.ID == surveyID
        //                            select s.Title).ToList();

        //foreach (string s in surveytitle)

        //    lbl_surveyid.Text += s.ToString();


    }

    protected void subBound(object sender, RepeaterItemEventArgs e)
    {
        SurveyClass objSurvey = new SurveyClass();
        QuestionsClass objQuestion = new QuestionsClass();
        // int surveyID = Convert.ToInt32(hdfSID.Value.ToString());

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label blwl = e.Item.FindControl("lbl_sID") as Label;
            HiddenField hdfSID = e.Item.FindControl("hdf_SID") as HiddenField;
            int surveyID = Convert.ToInt32(hdfSID.Value.ToString());
            HiddenField hdfQID = e.Item.FindControl("hdf_QID") as HiddenField;
            int questionID = Convert.ToInt32(hdfQID.Value.ToString());

            // Repeater r2 = (Repeater)e.Item.FindControl("r2");
            Repeater nestedRepeater = e.Item.FindControl("rpt_surveytitle") as Repeater;
            nestedRepeater.DataSource = objSurvey.GetSurveyByID(surveyID);
            nestedRepeater.DataBind();

            Repeater nestedRepeater2 = e.Item.FindControl("rpt_question") as Repeater;
            nestedRepeater2.DataSource = objQuestion.GetQuestionByID(questionID);
            nestedRepeater2.DataBind();
        }
    }

    public string getResults()
    {
        HiddenField hdf = (HiddenField)FindControl("hdfID");
        int surveyresponseid = Convert.ToInt32(hdf);
        HiddenField hdfSID = (HiddenField)FindControl("hdf_SID");
        int surveyID = Convert.ToInt32(hdfSID);

        List<string> surveytitle = (from q in dbDC.Questions
                                    join sq in dbDC.SurveyQuestions on q.ID equals sq.QuestionID
                                    join sr in dbDC.SurveyResponses on sq.SurveyID equals sr.SurveyID
                                    join s in dbDC.Surveys on sr.SurveyID equals s.ID
                                    where s.ID == surveyID
                                    select s.Title).ToList();
        Literal lbl_surveyid = (Literal)FindControl("lbl_surveyid");
        foreach (string s in surveytitle)
        {
            lbl_surveyid.Text += s.ToString();
        };
        return lbl_surveyid.Text;


    }

    //SORTING FOR SURVEY TITLE

    protected void titleDown_Click(object sender, EventArgs e)
    {
        sortDescendingTitle();
    }

    private void sortDescendingTitle()
    {
        using (dbDC)
        {
            var select = from survey in dbDC.SurveyResponses
                         select survey;
            ltv_results.DataSource = select.OrderByDescending(item => item.SurveyID);
            ltv_results.DataBind();
            lkb_titleDown.Visible = false;
            lkb_titleUp.Visible = true;
        }
    }


    private void sortAscendingTitle()
    {
        using (dbDC)
        {
            var select = from question in dbDC.SurveyResponses
                         select question;
            ltv_results.DataSource = select.OrderBy(item => item.SurveyID);
            ltv_results.DataBind();
            lkb_titleUp.Visible = false;
            lkb_titleDown.Visible = true;
        }
    }
    protected void titleUp_Click(object sender, EventArgs e)
    {
        sortAscendingTitle();
    }

    //end sorting for title


    //SORTING FOR SurveyQuestion

    protected void questionDown_Click(object sender, EventArgs e)
    {
        sortDescendingQuestion();
    }

    private void sortDescendingQuestion()
    {
        using (dbDC)
        {
            var select = from question in dbDC.SurveyResponses
                         select question;
            ltv_results.DataSource = select.OrderByDescending(item => item.QuestionID);
            ltv_results.DataBind();
            lkb_questionDown.Visible = false;
            lkb_questionUp.Visible = true;
        }
    }


    private void sortAscendingQuestion()
    {
        using (dbDC)
        {
            var select = from question in dbDC.SurveyResponses
                         select question;
            ltv_results.DataSource = select.OrderBy(item => item.QuestionID);
            ltv_results.DataBind();
            lkb_questionUp.Visible = false;
            lkb_questionDown.Visible = true;
        }
    }
    protected void questionUp_Click(object sender, EventArgs e)
    {
        sortAscendingQuestion();
    }

    //end sorting for question

    //sorting for survey ID

    protected void srDown_Click(object sender, EventArgs e)
    {
        sortDescendingSR();
    }

    private void sortDescendingSR()
    {
        using (dbDC)
        {
            var select = from sr in dbDC.SurveyResponses
                         select sr;
            ltv_results.DataSource = select.OrderByDescending(item => item.ID);
            ltv_results.DataBind();
            lkb_srDown.Visible = false;
            lkb_srUp.Visible = true;
        }
    }


    private void sortAscendingSR()
    {
        using (dbDC)
        {
            var select = from sr in dbDC.SurveyResponses
                         select sr;
            ltv_results.DataSource = select.OrderBy(item => item.ID);
            ltv_results.DataBind();
            lkb_srUp.Visible = false;
            lkb_srDown.Visible = true;
        }
    }
    protected void srUp_Click(object sender, EventArgs e)
    {
        sortAscendingSR();
    }

}


