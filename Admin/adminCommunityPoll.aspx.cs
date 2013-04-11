using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    pollClass objLinq = new pollClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    protected void Admin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                _strMessage(objLinq.NewInsert(txt_questionI.Text), "insert");
                _subRebind();
                break;
            case "Update":
                _showUpdate(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Delete":
                _showDelete(int.Parse(e.CommandArgument.ToString()));
                break;
        }
    }

    protected void AdminUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":
                TextBox txtQuestion = (TextBox)e.Item.FindControl("txt_questionU");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");
                int id = int.Parse(hdfID.Value.ToString());
                _strMessage(objLinq.NewUpdate(id, txtQuestion.Text), "update");
                _subRebind();
                break;

            case "Delete":
                int _IDq = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                _strMessage(objLinq.NewDelete(_IDq), "delete");
                _subRebind();
                break;

            case "Cancel":
                _subRebind();
                break;
        }
    }

    private void _showUpdate(int id)
    {
        _panelControl(pnl_update);
        pollClass _linq = new pollClass();
        rpt_update.DataSource = _linq.getQuestionByID(id);
        rpt_update.DataBind();
    }

    private void _showDelete(int IDq)
    {
        _panelControl(pnl_delete);
        rpt_delete.DataSource = objLinq.getQuestionByID(IDq);
        rpt_delete.DataBind();
    }

    private void _panelControl(Panel pnl)
    {
        pnl_all.Visible = false;
        pnl_delete.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }

    private void _subRebind()
    {
        txt_questionI.Text = string.Empty;
        rpt_all.DataSource = objLinq.getQuestions();
        rpt_all.DataBind();
        _panelControl(pnl_all);




        ddl_main.DataSource = objLinq.getQuestions();
        ddl_main.DataTextField = "question";
        ddl_main.DataValueField = "IDq";
        ddl_main.DataBind();

        int _IDq = int.Parse(ddl_main.SelectedValue.ToString());
        rpt_all.DataSource = objLinq.getQuestionByID(_IDq);
        rpt_all.DataBind();
    }

    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        rpt_all.DataSource = objLinq.getQuestionByID(_id);
        rpt_all.DataBind();
    }


    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_message.Text = "Question " + str + " was successful";
        else
            lbl_message.Text = "Unable to " + str + " question";
    }
}