using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //oriding an attribute from the label control on the master page
        Master.sub_lbl_subContent.Font.Size = 18;

    }
}