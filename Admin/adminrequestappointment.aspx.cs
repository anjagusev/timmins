using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    RequestAppointmentClass objLinq = new RequestAppointmentClass();
    appointmentemailClass objEmail = new appointmentemailClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Binds gridview on page load
        if (!IsPostBack)
        {
            _subBind();
        }
    }


    // Subroutine to bind gridview
    private void _subBind()
    {
        grv_appointments.DataSource = objLinq.getAppointments();
        grv_appointments.DataBind();
    }

    // confirmation message
    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_msg.Text = "<span style='color:green'>Patient " + str + " was successful.</span>";
        else
            lbl_msg.Text = "<span style='color:red'>Unable to send " + str + " to the patient</span>";
    }

    // Set status to notified
    protected void Confirmed(object sender, EventArgs e)
    {
        LinkButton lnkConfirm = (LinkButton)sender;

        // split command arguments to get id, name, email
        var args = lnkConfirm.CommandArgument.Split('^');
        int id = Int32.Parse(args[0]);
        string appointment_name = args[1];
        string email = args[2];

        // set email subject and message
        string subject = "Timmins District Hospital Appointment confirmation";
        string message = "Hi " + appointment_name + ",<br /><br /><p>the date and time you requested for your hospital appointment have been confirmed.</p><br />"
                         + "<hr />Timmins and District Hospital";

        // email visitor with confirmation
        objEmail.sendEmail(email, subject, message);

        // change status to notified
        _strMessage(objLinq.waitingAppointment(id), "confirmation email");

        _subBind();
    }


    // Set status to pending
    protected void Waiting(object sender, EventArgs e)
    {
        LinkButton lnkWaiting = (LinkButton)sender;

        int id = Int32.Parse(lnkWaiting.CommandArgument);
        _strMessage(objLinq.waitingAppointment(id), "Waiting");
        _subBind();
    }

    // Delete visitor
    protected void Delete(object sender, EventArgs e)
    {
        LinkButton lnkDelete = (LinkButton)sender;

        int id = Int32.Parse(lnkDelete.CommandArgument);
        _strMessage(objLinq.deleteAppointment(id), "delete");
        _subBind();
    }

    // Sort selected column
    protected void subSort(object sender, CommandEventArgs e)
    {
        grv_appointments.DataSource = objLinq.sortColumn(e.CommandName);
        grv_appointments.DataBind();
    }

}
