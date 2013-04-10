using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{

    int surveyid;
    // SurveysDataContext surveyDC = new SurveysDataContext();
    SurveyResponse surveyresponse = new SurveyResponse();
    //SurveyAppConString context;



    protected void Page_Load(object sender, EventArgs e)
    {
        //context = new SurveyAppConString();
        if (!IsPostBack)
        {
            // ddlSurveys.SelectedIndex = 0;
            LoadSurveys();
            btnSubmit.Enabled = false;


            if (ddlSurveys.SelectedIndex > 0)
            {
                surveyid = int.Parse(ddlSurveys.SelectedValue);



            }
        }
        PopulateSurvey();
    }

    private void getActive()
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        List<int> activesurvey = (from s in dbDC.Surveys
                                  where s.Status == "Active"
                                  select s.ID).ToList();

        surveyid = activesurvey[0];
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

    protected void ddlSurveys_SelectedIndexChanged(object sender, EventArgs e)
    {
        //PopulateSurvey();

    }



    private void PopulateSurvey()
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();

        SurveyQuestion surveyquestions = new SurveyQuestion();
        SurveyQuestionClass sQC = new SurveyQuestionClass();
        ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_main");
        ddlSurveys = (DropDownList)cph.FindControl("ddlSurveys");

        int surveyid = Convert.ToInt32(ddlSurveys.SelectedValue);
        //lblYes.Text = surveyid + "helo";


        //creating anonymous variable with value being instance of LINQ object
        //SurveysDataContext objSurveyDC = new SurveysDataContext();
        //creating anonymous variable with value being instance of LINQ object
        //return IQueryable<product> for databound control to bind to
        SurveyResponseClass objSurveyResponse = new SurveyResponseClass();
        /* SurveyResponseDataContext objSurveyDC = new SurveyResponseDataContext();
         SurveyResponse _response = new SurveyResponse();*/
        //List<SurveyResponse> response = objSurveyResponse.getSurveyResponses().ToList();
        btnSubmit.Enabled = true;
        //var orders = DC2.Orders.Where(a => a.Customer_ID == (DC1.Customers.Where(a => a.Customer_ID == 7).Customer_ID);
        //objQuestionsDC.Questions.Where(a=>a.ID == (dbDC.SurveyQuestions.Where(a=>a.ID == a.SurveyID).

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
            }

            if (q.QuestionType.ToLower() == "multiline")
            {
                txt = new TextBox();
                txt.ID = "txt_" + q.ID;
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Width = Unit.Percentage(40);
                tc.Controls.Add(txt);
            }

            if (q.QuestionType.ToLower() == "yesorno")
            {
                cbk = new CheckBox();
                cbk.ID = "cbk_" + q.ID;
                cbk.AutoPostBack = false;
                tc.Controls.Add(cbk);
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
        //SurveyResponse sres = new SurveyResponse();

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
        int surveyID = Convert.ToInt32(ddlSurveys.SelectedValue);
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
                    sres.SurveyID = surveyID;
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
