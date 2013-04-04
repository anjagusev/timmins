using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindA_Doctor : System.Web.UI.Page
{
    specialty_doctor objLinq = new specialty_doctor();


    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_submasterSubHeading = "Find A Doctor";

        if (!Page.IsPostBack)
        {
            _subRebind();
        }

    }

    private void _subRebind()
    {

        no_result.Text = string.Empty;
        grd_doc.DataSource = null;

        ddl_sp.DataSource = objLinq.getspecialities();

        ddl_sp.DataTextField = "specialty";
        ddl_sp.DataValueField = "specialty_id";
        ddl_sp.DataBind();
        ddl_sp.Items.Insert(0, new ListItem("--Select Specialty--", "0"));

        //int _id = int.Parse(ddl_sp.SelectedValue.ToString());
        //grd_doc.DataSource = objLinq.getdoctorbySpid(_id);
        //grd_doc.DataBind();
    }

    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_sp.SelectedValue.ToString());
        var res = objLinq.getdoctorbySpid(_id);

        if (!res.Any()) // if no data is found in table
        {
            no_result.Text = "No Result Found";
            grd_doc.DataSource = null;
            grd_doc.DataBind();
        }
        else
        {
            no_result.Text = string.Empty;
            grd_doc.DataSource = objLinq.getdoctorbySpid(_id);
            grd_doc.DataBind();
        }

    }

    protected void search(object sender, EventArgs e)
    {

        string _fname = txt_fname.Text.ToString();
        string _lname = txt_lname.Text.ToString();
        var no_res = objLinq.docByName(_fname, _lname);
        if (!no_res.Any())
        {
            no_result.Text = "No result Found";
            grd_doc.DataSource = null;
            grd_doc.DataBind();

        }
        else
        {
            no_result.Text = string.Empty;
            grd_doc.DataSource = objLinq.docByName(_fname, _lname);
            grd_doc.DataBind();
        }
    }

}