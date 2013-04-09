using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Admin_Default5 : System.Web.UI.Page
{

    QuestionsClass objQuestions = new QuestionsClass();
    SurveyClass dbDC = new SurveyClass();

    // DataClassesDataContext dbDC = new DataClassesDataContext();


    //SurveyAppConString context;
    protected void Page_Load(object sender, EventArgs e)
    {
        //QuestionsClass objQuestion = new QuestionsClass();
        //context = new SurveyAppConString();
        if (!IsPostBack)
        {

            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
          
            QuestionsClass objQuestions = new QuestionsClass();
            ListBox listbox = (ListBox)contentPlaceHolder.FindControl("lbSource");
            //List<Question> questions = context.Questions.ToList();
            List<Question> questions = objQuestions.getQuestions().ToList();
            listbox.DataSource = questions;
            listbox.DataTextField = "Text";
            listbox.DataValueField = "ID";
            listbox.DataBind();

            LoadSurveys();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataClassesDataContext dbDC = new DataClassesDataContext();
            SurveyClass _survey = new SurveyClass();
            Survey survey = new Survey();


            SurveyQuestion _surveyquestion = new SurveyQuestion();
            SurveyQuestionClass SQ = new SurveyQuestionClass();
            //get the controls
            ListBox listbox = (ListBox)FindControl("lbSource");
            TextBox txtTitle = (TextBox)FindControl("txtTitle");
            TextBox txtDescription = (TextBox)FindControl("txtDesc");
            TextBox txtDate = (TextBox)FindControl("txtDate");
            DateTime later = DateTime.Today.AddDays(12);
            DateTime ExpiresOn = later;
            DateTime CreatedOn = CreatedOn = Convert.ToDateTime(DateTime.Now);
            //   int? num = null;
            ListBox Target = (ListBox)FindControl("lbTarget");
            string status = null;

            int surveyID;
            _survey.commitInsert(txtTitle.Text, txtDescription.Text, CreatedOn, ExpiresOn, status, out surveyID);


            List<SurveyQuestion> questions = new List<SurveyQuestion>();
            foreach (ListItem li in Target.Items)
            {

                // SurveyQuestionClass quest = new SurveyQuestionClass();
                _surveyquestion.QuestionID = Convert.ToInt32(li.Value);
                int sqquestionid = Convert.ToInt32(_surveyquestion.QuestionID);
                // SurveyQuestionClass surveyq = new SurveyQuestionClass();

                // surveyq.commitUpdate(1, _surveyquestion.QuestionID, survey.ID);
                //_survey.commitInsert(_surveyquestion); 

                //objSurvey.commitInsert(
                //objSurvey.questions.Add(quest);
                questions.Add(_surveyquestion);


                List<string> survey_ID = (from surveys in dbDC.Surveys
                                          select ID).ToList();

                StringBuilder id_builder = new StringBuilder();
                foreach (string s in survey_ID)
                {
                    // Append each int to the StringBuilder overload.
                    id_builder.Append(s);
                }

                string result = id_builder.ToString();

                // int sq_id;
                // SQ.commitInsert(sqquestionid, surveyID, out sq_id);

                //to make it null Convert.ToInt32(num)
                SQ.commitInsert(sqquestionid, surveyID);
                //int qID = SurveyQuestion.qID ; 
                //lblTest.Text = qID.ToString();
                // hdf_sq_id.Value = sq_id.ToString();

            }
            lbl_output.Text = "You have added a new survey";
            _subRebind();

        }
    }

    private void LoadSurveys()
    {
        SurveyClass objSurvey = new SurveyClass();
        List<Survey> surveys = objSurvey.getSurveys().ToList();
        //List<Survey> surveys = context.Surveys.ToList();
        ddlSurveys.DataSource = surveys;
        ddlSurveys.DataTextField = "Title";
        ddlSurveys.DataValueField = "ID";
        ddlSurveys.DataBind();

        ddlSurveys.Items.Insert(0, new ListItem("- Select -", "-1"));
    }

    protected void subStatus(object sender, EventArgs e)
    {


        DataClassesDataContext dbDC = new DataClassesDataContext();
        SurveyClass _survey = new SurveyClass();
        Survey survey = new Survey();

        int chosenid = Convert.ToInt32(ddlSurveys.SelectedValue);

        _survey.updateStatus(chosenid);



    }

    private void _subRebind2()
    {
        ddlSurveys.SelectedIndex = -1;
    }

    private void _subRebind()
    {
        txtDesc.Text = string.Empty;
        txtTitle.Text = string.Empty;
        txtDate.Text = string.Empty;
        lbTarget.SelectedIndex = -1;

    }

    protected void btnAddAll_Click(object sender, EventArgs e)
    {
        ListBox lbSource = (ListBox)FindControl("lbSource");
        ListBox lbTarget = (ListBox)FindControl("lbTarget");

        foreach (ListItem li in lbSource.Items)
            lbTarget.Items.Add(li);
        lbSource.Items.Clear();
        lbSource.SelectedIndex = -1;
        lbTarget.SelectedIndex = -1;
    }


    protected void btnAddOne_Click(object sender, EventArgs e)
    {
        ListBox lbSource = (ListBox)FindControl("lbSource");
        ListBox lbTarget = (ListBox)FindControl("lbTarget");

        foreach (ListItem li in lbSource.Items)
            if (li.Selected)
                lbTarget.Items.Add(li);
        foreach (ListItem li in lbTarget.Items)
            lbSource.Items.Remove(li);
        lbSource.SelectedIndex = -1;
        lbTarget.SelectedIndex = -1;
    }

    protected void subCheck(object sender, ServerValidateEventArgs e)
    {
        int count = 0;
        foreach (ListItem li in lbTarget.Items)
        {
            count++;
        }

        if (count > 3)
        {
            e.IsValid = true;
            lbl_output.Text = "true";
        }
        else
        {
            e.IsValid = false;
            lbl_output.Text = "false";
        }

    }

    protected void btnRemoveOne_Click(object sender, EventArgs e)
    {
        ListBox lbSource = (ListBox)FindControl("lbSource");
        ListBox lbTarget = (ListBox)FindControl("lbTarget");

        foreach (ListItem li in lbTarget.Items)
            if (li.Selected)
                lbSource.Items.Add(li);
        foreach (ListItem li in lbSource.Items)
            lbTarget.Items.Remove(li);
        lbSource.SelectedIndex = -1;
        lbTarget.SelectedIndex = -1;
    }


    protected void btnRemoveAll_Click(object sender, EventArgs e)
    {
        ListBox lbSource = (ListBox)FindControl("lbSource");
        ListBox lbTarget = (ListBox)FindControl("lbTarget");

        foreach (ListItem li in lbTarget.Items)
            lbSource.Items.Add(li);
        lbTarget.Items.Clear();
        lbSource.SelectedIndex = -1;
        lbTarget.SelectedIndex = -1;
    }


}