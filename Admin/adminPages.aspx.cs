using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : System.Web.UI.Page
{
   

    PageClass objPage = new PageClass();
    SiteMapClass objSiteMap = new SiteMapClass();
    SubjectClass objSub = new SubjectClass();
    DataClassesDataContext dbDC = new DataClassesDataContext();
    int _parentid;
    int subID;
    int id;
    DropDownList ddlU;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();


        }
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
             
        switch (e.CommandName)
        {
            //case "Insert":
   


            //    //int.Parse(txt_subjectidI.Text.ToString())
            //    _strMessage(objPage.commitInsert(_subject_id, txt_menunameI.Text, txt_titleI.Text, txt_pagecontentI.Text), "insert");
            //    objSiteMap.commitInsert(txt_menunameI.Text, txt_menunameI.Text, txtDesc, _parentid, 0, _subject_id);

            //    _subRebind();
            //    break;
            case "Update":
             
              //  DropDownList ddl_subjectU = (DropDownList)cph.FindControl("ddl_subjectU");
                //  int _subject_id = int.Parse(ddl_subjectU.SelectedValue.ToString());

                //    string txtDesc = "moo";


                switch (subID)
                {
                    case 1:
                        _parentid = 2;
                        break;
                    case 2:
                        _parentid = 6;
                        break;
                    case 3:
                        _parentid = 5;
                        break;
                    case 4:
                        _parentid = 7;
                        break;
                    case 5:
                        _parentid = 8;
                        break;
                    case 6:
                        _parentid = 9;
                        break;
                    default:
                        _parentid = 0;
                        break;
                }

                

                _showUpdate(int.Parse(e.CommandArgument.ToString()));
                break;
            case "Delete":
                _showDelete(int.Parse(e.CommandArgument.ToString()));
                break;
        }
    }

    string selectedSubU_id;
    protected void subUpDel(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":


                //  DropDownList ddlU = (DropDownList)e.Item.FindControl("ddl_subjectU");
                int pageID = int.Parse(((HiddenField)e.Item.FindControl("hdf_id")).Value);
                TextBox txtSubjectID = (TextBox)e.Item.FindControl("txt_subjectidU");
                TextBox txtMenuName = (TextBox)e.Item.FindControl("txt_menunameU");
                TextBox txtTitle = (TextBox)e.Item.FindControl("txt_titleU");
                TextBox txtPageContent = (TextBox)e.Item.FindControl("txt_pagecontentU");


                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList MyDropDown = (DropDownList)e.Item.FindControl("ddl_subjectU");
                    if (MyDropDown != null)
                    {
                        selectedSubU_id = MyDropDown.SelectedValue.ToString();
                    }
                }

                int subjectID = Convert.ToInt32(selectedSubU_id);

                DataClassesDataContext dbDC = new DataClassesDataContext();
                SiteMap objSM = new SiteMap();

                 List<page> subID = (from p in dbDC.pages
                             join s in dbDC.GetTable<subject>() on p.subject_id equals s.id
                             where p.id == id
                             select p).ToList();
             

                 


                _strMessage(objPage.commitUpdate(pageID, subjectID, txtMenuName.Text, txtTitle.Text, txtPageContent.Text), "update");

              

                // ddl.SelectedValue = pageID.ToString();
                // _strMessage(objPage.commitUpdate(pageID, int.Parse(txtSubjectID.Text.ToString()), txtMenuName.Text, txtTitle.Text, txtPageContent.Text), "update");
                _subRebind();
                break;
            case "Delete":

                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_idDE")).Value);
                _strMessage(objPage.commitDelete(_id), "delete");
                _subRebind();
                break;
            case "Cancel":
                _subRebind();
                break;
        }
    }

  /*  protected void subChange(object sender, EventArgs e)
    {


    }
    */
    int subjectSelectedID;
    string subjectSelectedName;

    protected void bindDropdown(int id)
    {
        ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");
             
        var ddlU = (DropDownList)cph.FindControl("ddl_subjectU");

        List<page> subID = (from p in dbDC.pages
                             join s in dbDC.GetTable<subject>() on p.subject_id equals s.id
                             where p.id == id
                             select p).ToList();



        foreach (page q in subID)
        {
            subjectSelectedID = q.id;
        }

        List<string> subName = (from s in dbDC.subjects
                                where s.id == subjectSelectedID
                                select s.menu_name).ToList();

        foreach (string s in subName)
        {
            subjectSelectedName = s.ToString();
        }

        SubjectClass objSubU = new SubjectClass();
        //attempt end

        //  ddlU.Items.Insert(id, new ListItem("- Select -", "-"));
        //ddlU.DataSource = objSubU.getSubjects();
        //ddlU.DataValueField = "id";
        //ddlU.DataTextField = "menu_name";

        //ddlU.DataBind();

    }

    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        var ddlU = (DropDownList)e.Item.FindControl("ddl_subjectU");
        HiddenField hdfid = (HiddenField)e.Item.FindControl("hdf_id");
        int id = Convert.ToInt32(hdfid.Value);
        string stringid = hdfid.Value.ToString();


        PageClass _page = new PageClass();
        rpt_update.DataSource = _page.getPageByID(id);

        List<page> subID = (from p in dbDC.pages
                           join s in dbDC.GetTable<subject>() on p.subject_id equals s.id
                           where p.id == id
                           select p).ToList();



        foreach (page q in subID)
        {
            subjectSelectedID = q.id;
        }

        List<string> subName = (from s in dbDC.subjects
                                where s.id == subjectSelectedID
                                select s.menu_name).ToList();

        foreach (string s in subName)
        {
            subjectSelectedName = s.ToString();
        }

        SubjectClass objSubU = new SubjectClass();
        //attempt end

        //  ddlU.Items.Insert(id, new ListItem("- Select -", "-"));
        ddlU.DataSource = objSubU.getSubjects();
        ddlU.DataValueField = "id";
        ddlU.DataTextField = "menu_name";
        ddlU.DataBind();
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            ((DropDownList)e.Item.FindControl("ddl_subjectU")).SelectedValue = subjectSelectedID.ToString();
        }

        //ddlU.SelectedValue = id.ToString();

        //  ddlU.Items.SelectedValue(id);
        //  ddlU.Items.Insert(id, new ListItem("- Select -", "-"));




        //  ddl.SelectedValue = ddl.Items.IndexOf(ddl.Items.FindByValue("Selecteren")); stringid;
        //   ddl.DataBind();

    }

    protected virtual void RepeaterItemCreated(object sender, RepeaterItemEventArgs e)
    {
        DropDownList MyList = (DropDownList)e.Item.FindControl("ddl_subjectU");
       MyList.SelectedIndexChanged += subChangeU;
    }

    protected void subChangeU(object sender, EventArgs e)
    {
        DropDownList d = (DropDownList)sender;
        RepeaterItem rep = (RepeaterItem)d.Parent;

      //  selectedSubU_id = d.SelectedValue;
        
        HiddenField hdfid = (HiddenField)d.FindControl("hdf_id");
        int page_id = Convert.ToInt32(hdfid.Value);
        DropDownList ddlU = (DropDownList)FindControl("ddl_subjectU");
       // selectedSubU_id = ddlU.SelectedValue;
        bindDropdown(id);


    }
    int subjectid_forpage;
    private void _showUpdate(int id)
    {

        _panelControl(pnl_update);

     




       List<page> subjectid = (from p in dbDC.pages where p.id == id select p).ToList();

        
        foreach (page q in subjectid)
        {
            subjectid_forpage = Convert.ToInt32(q.subject_id);
        }



        //attempt
        //SubjectClass objSubU = new SubjectClass();

        ////  //attempt end
        //DropDownList ddlU = (DropDownList)FindControl("ddl_subjectU");
        //////  ddlU.Items.Insert(id, new ListItem("- Select -", "-"));

        ////  //ddlU.SelectedValue = id.ToString();
        //ddlU.DataSource = objSubU.getSubjectByID(subjectid_forpage);
        //ddlU.DataTextField = "menu_name";
        //ddlU.DataValueField = "id";
        //  //  objSubU.getSubjectByID(subjectid_forpage);
        //ddlU.DataBind();
        //  ddlU.Items.Insert(id, new ListItem("- Select -", "-"));

        string pageid = id.ToString();
        PageClass _page = new PageClass();
        rpt_update.DataSource = _page.getPageByID(id);
        rpt_update.DataBind();



        //var ddlU = (DropDownList).FindControl("ddl_subjectU");

        string stringid = id.ToString();






        //ddlU.Item.SelectedValue = subjectSelectedName;
        //if ((ddlU.ItemType == ListItemType.Item) || (Item.ItemType == ListItemType.AlternatingItem))
        //{
        //    ((DropDownList)e.Item.FindControl("ddl_subjectU")).SelectedIndex = subjectSelectedID;
        //    ((DropDownList)e.Item.FindControl("ddl_subjectU")).SelectedValue = subjectSelectedName;
        //}    




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
      /*  txt_subjectidI.Text = string.Empty;
        txt_menunameI.Text = string.Empty;
        txt_titleI.Text = string.Empty;
        txt_pagecontentI.Text = string.Empty;*/
        rpt_all.DataSource = objPage.getPages();
        rpt_all.DataBind();
        _panelControl(pnl_all);

/*
        ddl_subject.DataSource = objSub.getSubjects();
        ddl_subject.DataTextField = "menu_name";//column name that you want to be viewed as text "name"
        ddl_subject.DataValueField = "id"; // "ID"
        ddl_subject.DataBind();*/


        /*   DropDownList ddl_subjectU = (DropDownList)FindControl("ddl_subjectU");
           ddl_subjectU.DataSource = objSub.getSubjects();
           ddl_subjectU.DataTextField = "menu_name";
           ddl_subjectU.DataValueField = "id"; // "ID"
           ddl_subjectU.DataBind();*/



    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_message.Text = "Product " + str + " was successful";
        else
            lbl_message.Text = "Sorry unable to " + str + " product";



    }
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddl = sender as DropDownList;
    //    if (ddl != null)
    //    {
    //        Response.Write(ddl.SelectedValue);
    //    }
    //}
}
