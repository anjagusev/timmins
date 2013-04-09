using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_cms : System.Web.UI.Page
{
    PageClass objPage = new PageClass();
    SubjectClass objSub = new SubjectClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();


        }
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                int _subject_id = int.Parse(ddl_subject.SelectedValue.ToString());

                //int.Parse(txt_subjectidI.Text.ToString())
                _strMessage(objPage.commitInsert(_subject_id, txt_menunameI.Text, txt_titleI.Text, txt_pagecontentI.Text), "insert");
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

    protected void subUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddl_subjectU");

                TextBox txtSubjectID = (TextBox)e.Item.FindControl("txt_subjectidU");
                TextBox txtMenuName = (TextBox)e.Item.FindControl("txt_menunameU");
                TextBox txtTitle = (TextBox)e.Item.FindControl("txt_titleU");
                TextBox txtPageContent = (TextBox)e.Item.FindControl("txt_pagecontentU");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");
                int pageID = int.Parse(hdfID.Value.ToString());


                string selected = ddl.SelectedValue.ToString();

                int selectedid = int.Parse(selected);


                _strMessage(objPage.commitUpdate(pageID, selectedid, txtMenuName.Text, txtTitle.Text, txtPageContent.Text), "update");

                // ddl.SelectedValue = pageID.ToString();
                // _strMessage(objPage.commitUpdate(pageID, int.Parse(txtSubjectID.Text.ToString()), txtMenuName.Text, txtTitle.Text, txtPageContent.Text), "update");
                _subRebind();
                break;
            case "Delete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                _strMessage(objPage.commitDelete(_id), "delete");
                _subRebind();
                break;
            case "Cancel":
                _subRebind();
                break;
        }
    }

    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_subject.SelectedValue.ToString());

    }
    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        var ddl = (DropDownList)e.Item.FindControl("ddl_subjectU");
        HiddenField hdfid = (HiddenField)e.Item.FindControl("hdf_id");
        string stringid = hdfid.ToString();

  //   int id =  Convert.ToInt32(stringid);

        //  ddl.SelectedValue = ddl.Items.IndexOf(ddl.Items.FindByValue("Selecteren")); stringid;
        ddl.DataSource = objSub.getSubjects();
        ddl.DataTextField = "menu_name";
      ddl.DataValueField = "id";

        ddl.DataBind();

    }

    private void _showUpdate(int id)
    {
        _panelControl(pnl_update);

        //attempt

        //attempt end
         PageClass _page = new PageClass();
          rpt_update.DataSource = _page.getPageByID(id);
          rpt_update.DataBind();
          

       // SubjectClass _subject = new SubjectClass();
        //rpt_update.DataSource = _subject.getSubjectByID(id);
        //rpt_update.DataBind();




   


    }

    /* protected void subject_DataBinding(object sender, System.EventArgs e)
     {
         DropDownList ddl = (DropDownList)(sender);
         HiddenField hdfID = (HiddenField)FindControl("hdf_id");
         string pageID = hdfID.Value.ToString();

         ddl.SelectedValue = Eval("pageID").ToString();

        }*/


    private void _showDelete(int id)
    {
        _panelControl(pnl_delete);
        rpt_delete.DataSource = objPage.getPageByID(id);
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
        txt_subjectidI.Text = string.Empty;
        txt_menunameI.Text = string.Empty;
        txt_titleI.Text = string.Empty;
        txt_pagecontentI.Text = string.Empty;
        rpt_all.DataSource = objPage.getPages();
        rpt_all.DataBind();
        _panelControl(pnl_all);


        ddl_subject.DataSource = objSub.getSubjects();
        ddl_subject.DataTextField = "menu_name";//column name that you want to be viewed as text "name"
        ddl_subject.DataValueField = "id"; // "ID"
        ddl_subject.DataBind();


    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_message.Text = "Product " + str + " was successful";
        else
            lbl_message.Text = "Sorry unable to " + str + " product";



    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        if (ddl != null)
        {
            Response.Write(ddl.SelectedValue);
        }
    }
}


