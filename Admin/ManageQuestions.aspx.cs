using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : System.Web.UI.Page
{

    DataClassesDataContext dbDC = new DataClassesDataContext();
    QuestionsClass objQuestion = new QuestionsClass();
    questionTypeClass objQTClass = new questionTypeClass();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            _subRebind();
            DropDownList ddl = (DropDownList)FindControl("ddlTypes");
            ddlTypes.DataSource = objQTClass.getQuestionTypes();
            ddlTypes.DataBind();
            ddlTypes.Items.Insert(0, new ListItem("- Select -", "-"));

            lv_questions.DataSource = objQuestion.getQuestions();
            lv_questions.DataBind();

        }
    }

    private void _subRebind()
    {
        txtQuestion.Text = string.Empty;
        //txtTitle.Text = string.Empty;
        txtValues.Text = string.Empty;

    }



    protected void subCheck(object sender, EventArgs e)
    {
        string type = ddlTypes.SelectedValue.ToString();
        switch (type.ToLower())
        {
            case "multiselect":
                lbl_values.Visible = true;
                txtValues.Visible = true;
                lbl_valueinfo.Visible = true;
                break;
            case "singleselect":
                lbl_values.Visible = true;
                txtValues.Visible = true;
                lbl_valueinfo.Visible = true;
                break;
            case "singlelinetextbox":
                lbl_values.Visible = false;
                txtValues.Visible = false;
                lbl_valueinfo.Visible = false;
                break;
            case "multiline":
                lbl_values.Visible = false;
                txtValues.Visible = false;
                lbl_valueinfo.Visible = false;
                break;
            case "yesorno":
                lbl_values.Visible = false;
                break;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {


            string questionType = ddlTypes.SelectedValue.ToString();
            objQuestion.commitInsert(questionType, txtQuestion.Text, txtValues.Text);


            lbl_output.Text = "You have successfully added the question " + txtQuestion.Text;
            _subRebind();



        }

    }
}