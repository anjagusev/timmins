using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class RequestAppointmentClass
{
    // appointmentsDataContext - data context

    public IQueryable<tbl_appointment> getAppointments()
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        // create anonymous variable with its value being instance of our LINQ object
        var allAppointment = objAppointmentsDC.tbl_appointments.Select(x => x);
        return allAppointment;
    }

    public IQueryable<tbl_appointment> getAppointmentByID(int _id)
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        var AppointmentID = objAppointmentsDC.tbl_appointments.Where(x => x.appointment_id == _id).Select(x => x);
        return AppointmentID;
    }

    // Sort columns
    public IQueryable<tbl_appointment> sortColumn(string _column)
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        // default to no sorting
        var columnSort = objAppointmentsDC.tbl_appointments.Select(x => x);

        // check which sorting the user clicked
        switch (_column)
        {
            case "id":
                columnSort = objAppointmentsDC.tbl_appointments.OrderBy(x => x.appointment_id).Select(x => x);
                break;
            case "name":
                columnSort = objAppointmentsDC.tbl_appointments.OrderBy(x => x.appointment_name).Select(x => x);
                break;
            case "email":
                columnSort = objAppointmentsDC.tbl_appointments.OrderBy(x => x.appointment_email).Select(x => x);
                break;

            case "date":
                columnSort = objAppointmentsDC.tbl_appointments.OrderByDescending(x => x.appointment_date).Select(x => x);
                break;
            case "time":
                columnSort = objAppointmentsDC.tbl_appointments.OrderBy(x => x.appointment_time).Select(x => x);
                break;
            case "confirmation":
                columnSort = objAppointmentsDC.tbl_appointments.OrderByDescending(x => x.appointment_confirmation).Select(x => x);
                break;
        }

        return columnSort;
    }


    public bool insertAppointment(string _appointment_name, string _appointment_email, DateTime _appointment_date, string _appointment_time)
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        // to ensure that all data will be disposed when finished
        using (objAppointmentsDC)
        {
            // create instance of our table object
            tbl_appointment objNewAppointment = new tbl_appointment();
            // set values
            objNewAppointment.appointment_name = _appointment_name;
            objNewAppointment.appointment_email = _appointment_email;
            objNewAppointment.appointment_date = _appointment_date;
            objNewAppointment.appointment_time = _appointment_time;
            objNewAppointment.appointment_confirmation = "Waiting to hear back";
            // insert command
            objAppointmentsDC.tbl_appointments.InsertOnSubmit(objNewAppointment);
            // commit insert against database
            objAppointmentsDC.SubmitChanges();
            return true;
        }
    }

    public bool deleteAppointment(int _id)
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        // to ensure that all data will be disposed when finished
        using (objAppointmentsDC)
        {
            var objDelAppointment = objAppointmentsDC.tbl_appointments.Single(x => x.appointment_id == _id);
            objAppointmentsDC.tbl_appointments.DeleteOnSubmit(objDelAppointment);
            objAppointmentsDC.SubmitChanges();
            return true;
        }
    }

    // set confirmation status from waiting to confirmed
    public bool confirmAppointment(int _id)
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        // to ensure that all data will be disposed when finished
        using (objAppointmentsDC)
        {
            var objNotAppointment = objAppointmentsDC.tbl_appointments.Single(x => x.appointment_id == _id);
            objNotAppointment.appointment_confirmation = "Confirmed";
            // commit update against database
            objAppointmentsDC.SubmitChanges();
            return true;
        }
    }

    public bool waitingAppointment(int _id)
    {
        // create an instance of our LINQ object
        appointmentsDataContext objAppointmentsDC = new appointmentsDataContext();
        // to ensure that all data will be disposed when finished
        using (objAppointmentsDC)
        {
            var objNotAppointment = objAppointmentsDC.tbl_appointments.Single(x => x.appointment_id == _id);
            objNotAppointment.appointment_confirmation = "Waiting to hear back";
            // commit update against database
            objAppointmentsDC.SubmitChanges();
            return true;
        }
    }

}