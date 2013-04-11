using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;

public partial class subPage1 : System.Web.UI.Page
{
    pollClass objLinq = new pollClass();
    QuestAnswerClass objNewQuestAns = new QuestAnswerClass();
    pollOptionClass objNewChoice = new pollOptionClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)

            _subRebind();



    }

    private void _subRebind()
    {
        rpt_all.DataSource = objLinq.getQuestions();
        rpt_all.DataBind();
    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_message.Text = "Thank you for your response. your answers will be kept confidential and help us improve service";
        else
            lbl_message.Text = "Please fill in a response";
    }

    protected void RepDataBind(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RadioButtonList radioButtonList = e.Item.FindControl("rbl_list") as RadioButtonList;
            HiddenField hdf = e.Item.FindControl("hdf_") as HiddenField;

            if (radioButtonList != null)
            {
                using (pollDataContext context = new pollDataContext())
                {
                    radioButtonList.DataSource = context.poll_choices.Select(x => x);
                    radioButtonList.DataTextField = "option";
                    radioButtonList.DataValueField = "option";
                    radioButtonList.DataBind();
                }
            }
        }
    }

    protected void subInsert(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":

                foreach (RepeaterItem question in rpt_all.Items)
                {
                    if (question.ItemType == ListItemType.Item || question.ItemType == ListItemType.AlternatingItem)
                    {
                        RadioButtonList radioButtonList = question.FindControl("rbl_list") as RadioButtonList;
                        HiddenField hdf = question.FindControl("hdf") as HiddenField;

                        string answer = radioButtonList.SelectedValue.ToString();
                        int IDq = Int32.Parse(hdf.Value);

                        QuestAnswerClass objQuestAnsDC = new QuestAnswerClass();

                        _strMessage(objQuestAnsDC.answerInsert(IDq, answer), "insert");
                    }
                }
                break;
        }
    }


}
