using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_services : System.Web.UI.Page
{
    services_department objservice = new services_department();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            _subRebind();


        }

    }

    // code for data pager
    protected void NavPager(object sender, DataPagerCommandEventArgs e)
    {
        lv_services.DataSource = objservice.getServices();
        lv_services.DataBind();
        e.NewMaximumRows = e.Item.Pager.MaximumRows;
        switch (e.CommandName)
        {
            case "first":
                e.NewStartRowIndex = 0;
                break;
            case "last":
                e.NewStartRowIndex = e.TotalRowCount;
                break;
            case "next":
                e.NewStartRowIndex = e.Item.Pager.StartRowIndex + 1;
                break;
            case "previous":
                e.NewStartRowIndex = e.Item.Pager.StartRowIndex - 1;
                break;
        }
    }

    private void _subRebind()
    {
        lv_services.DataSource = objservice.getServices();
        lv_services.DataBind();

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




    protected void SubSubmit(object sender, EventArgs e)
    {
        DateTime selected_date = Convert.ToDateTime(txt_date.Text);
        _strMessage(objservice.CommitInsert(txt_title.Text, txt_desc.Text, selected_date), "insert");
        _subRebind();
    }


    protected void lv_services_ItemEditing(object sender, ListViewEditEventArgs e)
    {

        lv_services.DataSource = objservice.getServices();
        lv_services.DataBind();
        lv_services.EditIndex = e.NewEditIndex;
        lv_services.DataBind();


    }
    protected void lv_services_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        lv_services.EditIndex = -1;
        lv_services.DataBind();

    }

    protected void lv_services_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        TextBox txttitleE = (TextBox)lv_services.Items[e.ItemIndex].FindControl("txt_titleU");
        TextBox txtdescE = (TextBox)lv_services.Items[e.ItemIndex].FindControl("txt_descU");
        TextBox txtdateE = (TextBox)lv_services.Items[e.ItemIndex].FindControl("txt_dateU");

        DateTime selected_date = DateTime.Parse(txtdateE.Text);
        // test.Text =  Convert.ToString(selected_date);
        //HiddenField hdfID = (HiddenField)lv_services.Items[e.ItemIndex].FindControl("hdf_idE");
        int proID = int.Parse(((HiddenField)lv_services.Items[e.ItemIndex].FindControl("hdf_idE")).Value);
        _strMessage(objservice.CommitUpdate(proID, txttitleE.Text, txtdescE.Text, selected_date.Date), "update");

        lv_services.EditIndex = -1;
        _subRebind();

    }

    protected void lv_services_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {

        int _id = int.Parse(((HiddenField)lv_services.Items[e.ItemIndex].FindControl("hdf_service")).Value);
        _strMessage(objservice.CommitDelete(_id), "delete");
        _subRebind();
    }

}