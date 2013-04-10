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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();


        }
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Insert")
        {

            int _subject_id = int.Parse(ddl_subject.SelectedValue.ToString());

            string txtDesc = "moo";


            switch (_subject_id)
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




            //int.Parse(txt_subjectidI.Text.ToString())
            _strMessage(objPage.commitInsert(_subject_id, txt_menunameI.Text, txt_titleI.Text, txt_pagecontentI.Text), "insert");
            objSiteMap.commitInsert(txt_menunameI.Text, txt_menunameI.Text, txtDesc, _parentid, 0, _subject_id);

            _subRebind();
        }

    }

    protected void subChange(object sender, EventArgs e)
    {


    }

    private void _subRebind()
    {
        txt_subjectidI.Text = string.Empty;
        txt_menunameI.Text = string.Empty;
        txt_titleI.Text = string.Empty;
        txt_pagecontentI.Text = string.Empty;



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
}