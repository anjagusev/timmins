using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default3 : System.Web.UI.Page
{
    patientClass objArt = new patientClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    private void _subRebind()
    {
        txt_nameI.Text = string.Empty;
        txt_emailI.Text = string.Empty;
        rpt_all.DataSource = objArt.getPatients();
        rpt_all.DataBind();
        _panelControl(pnl_all);
    }

    private void _panelControl(Panel pnl)
    {
        pnl_all.Visible = false;
        pnl_delete.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            Response.Redirect("~/Admin/AddPatient.aspx");
            lbl_message.Text = "Request to  " + str + " the patient info has been executed.";
        }
        else
        {
            lbl_message.Text = "Sorry, we were unable to " + str + " the patient data into the database.";
        }
    }


    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                _strMessage(objArt.commitInsert(txt_nameI.Text, txt_emailI.Text), "insert");
                break;
            case "Update":
                _showUpdate(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Delete":
                _showDelete(int.Parse(e.CommandArgument.ToString()));
                break;
        }
    }

    private void _showUpdate(int id)
    {
        _panelControl(pnl_update);
        rpt_update.DataSource = objArt.getPatientByID(id);
        rpt_update.DataBind();
    }

    private void _showDelete(int id)
    {
        _panelControl(pnl_delete);
        rpt_delete.DataSource = objArt.getPatientByID(id);
        rpt_delete.DataBind();
    }

    protected void subUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":
                TextBox txtName = (TextBox)e.Item.FindControl("txt_nameU");
                TextBox txtEmail = (TextBox)e.Item.FindControl("txt_emailU");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");
                int proID = int.Parse(hdfID.Value.ToString());
                _strMessage(objArt.commitUpdate(proID, txtName.Text.ToString(), txtEmail.Text.ToString()), "update");
                break;
            case "Delete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                _strMessage(objArt.commitDelete(_id), "delete");
                _subRebind();
                break;
            case "Cancel":
                _subRebind();
                break;
        }
    }
}