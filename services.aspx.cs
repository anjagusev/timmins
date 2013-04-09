using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class services : System.Web.UI.Page
{

    services_department objserClass = new services_department();
    protected void Page_Load(object sender, EventArgs e)
    {

        lv_services.DataSource = objserClass.getServices();
        //  lv_services.SortDirection = SortDirection.Ascending;
        // lv_services.Sorting += SortDirection.Ascending;
        lv_services.DataBind();

        if (!Page.IsPostBack)
        {
            _subRebind();

        }


    }

    private void _subRebind()
    {
        // Filter alphabetically
        lv_services.DataSource = objserClass.getServices();
        lv_services.DataBind();

        // filter by date
        lv_services.DataSource = objserClass.getservicesBydate();
        lv_services.DataBind();

    }



    protected void btn_date_Click(object sender, EventArgs e)
    {
        lv_services.DataSource = objserClass.getservicesBydate();
        lv_services.DataBind();



    }
    protected void lnb_alphabetically_Click(object sender, EventArgs e)
    {
        lv_services.DataSource = objserClass.getServices();
        lv_services.DataBind();

    }
}