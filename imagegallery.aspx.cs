using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //added
using System.Data; //added
using System.IO; //added
using System.Data.OleDb; //added
using System.Text; //added

public partial class subPage1 : System.Web.UI.Page
{

    SqlConnection objcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TimminsConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_submasterSubHeading = "Hospital Image Gallery";
        if (!IsPostBack)
        {
            imageG();
        }
    }
    private void imageG()
    {
        try
        {
            //connection query to the datbase table where the paths to the images are stored.  the files themselves are stored in the img folder
            DataTable objdt = new DataTable();
            string query = "select * from Gallery;";
            SqlDataAdapter objda = new SqlDataAdapter(query, objcon);
            objcon.Open();
            objda.Fill(objdt);
            objcon.Close();
            StringBuilder objstring = new StringBuilder();
            if (objdt.Rows.Count > 0)
            {
                objstring.Append("<ul id=\"myGallery\">");
                for (int i = 0; i < objdt.Rows.Count; i++)
                {
                    objstring.Append("<li><img src=\'" + objdt.Rows[i]["MainImage"].ToString() + "' alt='" + objdt.Rows[i]["ThumbNail"].ToString() + "'\" />");
                }
                objstring.Append("</ul>");
                divgallery.InnerHtml = objstring.ToString();
            }
        }
        catch
        {

        }
    }




}