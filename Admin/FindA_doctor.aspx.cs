using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FindA_doctor : System.Web.UI.Page
{


    specialty_doctor objLinq = new specialty_doctor();

    protected void Page_Load(object sender, EventArgs e)
    {
        //ddl_sp.DataSource = objLinq.getspecialities();
        //ddl_sp.DataTextField = "specialty";
        //ddl_sp.DataValueField = "specialty_id";
        //ddl_sp.DataBind();

        //ddl_main.DataSource = objLinq.getspecialities();
        //ddl_main.DataTextField = "specialty";
        //ddl_main.DataValueField = "specialty_id";
        //ddl_main.DataBind();


        if (!Page.IsPostBack)
        {
            _subRebind();

        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        ddl_sp.DataSource = objLinq.getspecialities();
        ddl_sp.DataTextField = "specialty";
        ddl_sp.DataValueField = "specialty_id";
        ddl_sp.DataBind();

    }

    private void _subRebind()
    {
        // this is for specialty table
        txt_specialtyI.Text = string.Empty;
        all_rpt.DataSource = objLinq.getspecialities();
        all_rpt.DataBind();


        // this is for doctor's table
        txt_fnameI.Text = string.Empty;
        txt_lnameI.Text = string.Empty;
        txt_genderI.Text = string.Empty;
        txt_emailI.Text = string.Empty;
        txt_bioI.Text = string.Empty;

        ddl_main.DataSource = objLinq.getspecialities();
        ddl_main.DataTextField = "specialty";
        ddl_main.DataValueField = "specialty_id";
        ddl_main.DataBind();

        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        ltv_main.DataSource = objLinq.getdoctorbySpid(_id);
        ltv_main.DataBind();


    }


    // this insert and upaddate is for specialty table
    protected void subInsertInSP(object sender, EventArgs e)
    {
        _strMessage(objLinq.commitInsertInSp(txt_specialtyI.Text), "insert");
        _subRebind();
    }

    protected void subAdminForSP(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "subUpdate":
                TextBox txtspecialtyE = (TextBox)e.Item.FindControl("txt_specialtyE");

                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_idE");
                int proID = int.Parse(hdfID.Value.ToString());
                _strMessage(objLinq.commitUpdateInSp(proID, txtspecialtyE.Text), "update");
                _subRebind();
                break;


            case "subDelete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_idE")).Value);
                _strMessage(objLinq.commitDeleteInSp(_id), "delete");
                _subRebind();
                break;
        }
    }

    //Neurosurgery




    protected void subChange(object sender, EventArgs e)
    {
        int id = int.Parse(ddl_main.SelectedValue.ToString());
        ltv_main.DataSource = objLinq.getdoctorbySpid(id);
        ltv_main.DataBind();

    }



    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<span style='color:green;'>Inserted " + str + "  successfully</span>";
        }
        else
        {
            lbl_message.Text = "<span style='color:red;'>Sorry Unable to" + str + " Insert </span>";

        }
    }

    protected void subInsertInDC(object sender, EventArgs e)
    {
        _strMessage(objLinq.commitInsertInDoc(int.Parse(ddl_main.SelectedValue.ToString()), txt_fnameI.Text, txt_lnameI.Text, txt_genderI.Text, txt_emailI.Text, txt_bioI.Text), "insert");
        _subRebind();
    }

    protected void subAdminForDC(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "subUpdate":
                TextBox txtfnameE = (TextBox)e.Item.FindControl("txt_fnameE");
                TextBox txtlnameE = (TextBox)e.Item.FindControl("txt_lnameE");
                TextBox txtbioE = (TextBox)e.Item.FindControl("txt_bioE");
                TextBox txtemailE = (TextBox)e.Item.FindControl("txt_emailE");
                TextBox txtgenderE = (TextBox)e.Item.FindControl("txt_genderE");

                //HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id_E");
                int proID = int.Parse(ddl_main.SelectedValue.ToString());
                _strMessage(objLinq.commitUpdateInDoc(proID, txtfnameE.Text, txtlnameE.Text, txtgenderE.Text, txtemailE.Text, txtbioE.Text), "update");
                _subRebind();
                break;


            case "subDelete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_doc")).Value);
                _strMessage(objLinq.commitDeleteInDoc(_id), "delete");
                _subRebind();
                break;
        }
    }


}