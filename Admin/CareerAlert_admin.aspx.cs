/*
 * Phong Huynh - 810194340, hnhp0025
 * Timmins Hospital Website
 * Career Alert
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class Admin_Default : System.Web.UI.Page
{
    phong_careeralertLinq objLinq = new phong_careeralertLinq();
    phong_email objEmail = new phong_email();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _subBind();
        }
    }

    // Subroutine to bind to listview
    private void _subBind()
    {
        ltv_alerts.DataSource = objLinq.getAlerts();
        ltv_alerts.DataBind();
    }

    // confirmation message
    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_msg.Text = "<span style='color:green'>User " + str + " was successful.</span>";
        else
            lbl_msg.Text = "<span style='color:red'>Unable to " + str + " user.</span>";
    }

    // controls notify, pending, delete
    protected void subAdmin(object sender, ListViewCommandEventArgs e)
    {
        // get values from listview
        Label lblName = (Label)e.Item.FindControl("lbl_name");
        Label lblEmail = (Label)e.Item.FindControl("lbl_email");
        Label lblDepartment = (Label)e.Item.FindControl("lbl_department");
        Label lblResume = (Label)e.Item.FindControl("lbl_resume");
        HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_id");

        int id = Int32.Parse(hdfID.Value.ToString());

        switch (e.CommandName)
        {
            case "subNotify":
                // send email to notify user
                // set email subject and message
                string subject = "Career Alert - Job Found";
                string message = "Hello " + lblName.Text + ",<br /><br /><p>A new job opportunity in the " + lblDepartment.Text + " department has been posted. <br /><br /><a href='http://timmins.sidhusweb.com/JobPostings.aspx'>Click Here<a/> to go to our Job Postings page.</p><br />"
                                 + "<hr />Timmins and District Hospital";
                // email visitor with confirmation
                objEmail.sendEmail(lblEmail.Text, subject, message);

                // set status to notify
                _strMessage(objLinq.notifyUser(id), "notify and email");
                _subBind();
                break;
            case "subPending":
                // set status to pending
                _strMessage(objLinq.pendingUser(id), "pending");
                _subBind();
                break;
            case "subDelete":
                // delete user
                _strMessage(objLinq.deleteUser(id), "delete");

                // set file path for resume
                string resumePath = Server.MapPath("~/Resumes/") + lblResume.Text;

                // check if file exists
                if (File.Exists(resumePath))
                {
                    // delete resume file from server
                    File.Delete(resumePath);
                }

                _subBind();
                break;
        }
    }




}