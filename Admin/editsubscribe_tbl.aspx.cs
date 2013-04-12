using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_editsubscribe_tbl : System.Web.UI.Page
{
    subscriberClass objsub = new subscriberClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();


            //dt_main.DataSourdt_main.DataSource = objsub.getsubscriber();
            
        }

    }
    private void _subRebind()
    {


        dt_main.DataSource = objsub.getsubscriber();

        dt_main.DataBind(); 
  }




    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<span style='color:green;'>Inserted " + str + "successfully</span>";
        }
        else
        {
            lbl_message.Text = "<span style='color:red;'>Sorry Unable to" + str + " Insert </span>";


        }
    }

    protected void subInsert(object sender, EventArgs e)
    {
        _strMessage(objsub.CommitInsertByAdmin(txt_nameI.Text, txt_emailI.Text, ddl_list.SelectedValue.ToString(),txt_reaI.Text), "insert");

        dt_main.DataSource = objsub.getsubscriber();
        dt_main.DataBind();
        _subRebind();
    }


    protected void subShowEditTemplate(object sender, DataListCommandEventArgs e)
    {
        dt_main.DataSource = objsub.getsubscriber();
        dt_main.DataBind();
        dt_main.EditItemIndex = e.Item.ItemIndex;
        dt_main.DataBind();

    }

    protected void subCancel(object sender, DataListCommandEventArgs e)
    {
        dt_main.EditItemIndex = -1;
        dt_main.DataSource = objsub.getsubscriber();
        dt_main.DataBind();
    }
    protected void subCommitUpdate(object sender, DataListCommandEventArgs e)
    {


        TextBox txtname = (TextBox)e.Item.FindControl("txt_nameE");
        TextBox txtemail = (TextBox)e.Item.FindControl("txt_emailE");
        TextBox txtvalid = (TextBox)e.Item.FindControl("txt_validE");
        TextBox txtComm = (TextBox)e.Item.FindControl("txt_reasonE");
        DropDownList selectedValidation = (DropDownList)e.Item.FindControl("ddl_listE");
        //string SelectedValid =  ddl_listE.SelectedValue.ToString();

        HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_idE");
        int proID = int.Parse(hdfID.Value.ToString());
        _strMessage(objsub.commitUpdate(proID, txtname.Text, txtemail.Text, selectedValidation.Text,txtComm.Text), "update");

        dt_main.EditItemIndex = -1;

        _subRebind();

    }

    protected void subCommitDelete(object sender, DataListCommandEventArgs e)
    {
        int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_idE")).Value);
        _strMessage(objsub.commitDelete(_id), "delete");

        _subRebind();

    }
}