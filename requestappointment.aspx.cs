using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subPage1 : System.Web.UI.Page
{
    RequestAppointmentClass objLinq = new RequestAppointmentClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_submasterSubHeading = "Request an Appointment";

        //all of this stuff generates the 24 hour clock on the dropdownlist WOOT:)
        string hr, min;
        for (int h = 0; h < 24; h++)
        {
            for (int m = 0; m < 60; m++)
            {
                if (h < 10)
                {
                    hr = "0" + h.ToString();
                }
                else
                {
                    hr = h.ToString();
                }
                if (m < 10)
                {
                    min = "0" + m.ToString();
                }
                else
                {
                    min = m.ToString();
                }
                ddl_time.Items.Add(new ListItem(hr + ":" + min));
            }
        }
    }

    // Submit Button: hide form panel, insert info into visitors table
    protected void subSubmit(object sender, EventArgs e)
    {
        // hide visit form
        pnl_appointment.Visible = false;



        // check if user selected minutes or hours
        if (ddl_time.SelectedIndex == 0)
        {
            if (Page.IsValid)
            {
                // Database Insert if form is valid
                _strMessage(objLinq.insertAppointment(txt_name.Text, txt_email.Text, DateTime.ParseExact(txt_appointmentdate.Text, "dd/MM/yyyy", null), ddl_time.Text));
            }
        }
        else
        {
            // Database Insert 
            _strMessage(objLinq.insertAppointment(txt_name.Text, txt_email.Text, DateTime.ParseExact(txt_appointmentdate.Text, "dd/MM/yyyy", null), ddl_time.Text));
        }

    }

    // Clear Button: clears the form
    protected void subClear(object sender, EventArgs e)
    {
        // set textboxes to empty
        lbl_output.Text = string.Empty;
        txt_name.Text = string.Empty;
        txt_email.Text = string.Empty;
        txt_appointmentdate.Text = string.Empty;
        //txt_time.Text = string.Empty;
        pnl_appointment.Visible = true;
    }

    // Sets output message
    private void _strMessage(bool flag)
    {

        // if database insert worked then output confirmation message
        if (flag)
        {
            // if duration is empty then output different message
            if (ddl_time.Text == "")
            {
                lbl_output.Text = "Thank you, " + txt_name.Text + ", for filling out the form. You will be notified about the visit as soon as possible and an email will be sent to you.<br /><br />";
            }
            else
            {


                //output message
                lbl_output.Text = "Thank you, " + txt_name.Text + ", for providing your contact details. You will recieve a notification about your appointment as soon as possible.<br /><br />";

            }
        }
        // if database insert failed then output error message
        else
        {

            lbl_output.Text = "There is currently an error with the database.";
        }
    }

}


