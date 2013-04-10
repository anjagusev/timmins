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


    //private void _subRebind()
    //{
    //    ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
    //    ListBox listbox = (ListBox)cph.FindControl("lbSource");
    //    TextBox txtTitle = (TextBox)cph.FindControl("txtTitle");
    //    TextBox txtDescription = (TextBox)cph.FindControl("txtDesc");
    //    TextBox txtDate = (TextBox)cph.FindControl("txtDate");
    //    ListBox Target = (ListBox)cph.FindControl("lbTarget");
    //    Target.SelectedIndex = -1;
    //    txtTitle.Text = "";
    //    txtDescription.Text = "";
    //    txtDate.Text = "";
        

    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataClassesDataContext dbDC = new DataClassesDataContext();
            SurveyClass _survey = new SurveyClass();
            Survey survey = new Survey();

            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
            SurveyQuestion _surveyquestion = new SurveyQuestion();
            SurveyQuestionClass SQ = new SurveyQuestionClass();
            //get the controls
            ListBox listbox = (ListBox)cph.FindControl("lbSource");
            TextBox txtTitle = (TextBox)cph.FindControl("txtTitle");
            TextBox txtDescription = (TextBox)cph.FindControl("txtDesc");
            TextBox txtDate = (TextBox)cph.FindControl("txtDate");
            DateTime later = DateTime.Today.AddDays(12);
            DateTime ExpiresOn = later;
            DateTime CreatedOn = CreatedOn = Convert.ToDateTime(DateTime.Now);
            //   int? num = null;
            ListBox Target = (ListBox)cph.FindControl("lbTarget");
            string status = "Inactive";

            int surveyID;
            _survey.commitInsert(txtTitle.Text, txtDescription.Text, CreatedOn, ExpiresOn, status, out surveyID);


            List<SurveyQuestion> questions = new List<SurveyQuestion>();
            foreach (ListItem li in Target.Items)
            {

                
                _surveyquestion.QuestionID = Convert.ToInt32(li.Value);
                int sqquestionid = Convert.ToInt32(_surveyquestion.QuestionID);
               
                questions.Add(_surveyquestion);


                List<string> survey_ID = (from surveys in dbDC.Surveys
                                          select ID).ToList();

                StringBuilder id_builder = new StringBuilder();
                foreach (string s in survey_ID)
                {
                   
                    id_builder.Append(s);
                }

                string result = id_builder.ToString();

                SQ.commitInsert(sqquestionid, surveyID);
                _subRebind();

            }
            lbl_output.Text = "You have added a new survey";
            

        }
    }

    private void LoadSurveys()
    {
        SurveyClass objSurvey = new SurveyClass();
        List<Survey> surveys = objSurvey.getSurveys().ToList();
      
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
        ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
        ListBox listbox = (ListBox)cph.FindControl("lbSource");
        TextBox txtTitle = (TextBox)cph.FindControl("txtTitle");
        TextBox txtDescription = (TextBox)cph.FindControl("txtDesc");
        TextBox txtDate = (TextBox)cph.FindControl("txtDate");
        ListBox Target = (ListBox)cph.FindControl("lbTarget");

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
        ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
        ListBox lbSource = (ListBox)cph.FindControl("lbSource");
        ListBox lbTarget = (ListBox)cph.FindControl("lbTarget");

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