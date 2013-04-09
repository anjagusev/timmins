using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for patientClass
/// </summary>
public class patientClass
{
	public patientClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public IQueryable<tbl_patient> getPatients()
    {
        //creating an instance of our LINQ object
        patientsDataContext objPatDC = new patientsDataContext();//reference the LINQ object

        //creating an anonymous variable with its value being the instance of our LINQ object
        var allPatients = objPatDC.tbl_patients.Select(x => x);//method

        return allPatients;

        //order of our query is "from-table-where-select"
    }

    public IQueryable<tbl_patient> getPatientByID(int _id)
    {
        //creating an instance of our LINQ object
        patientsDataContext objPatDC = new patientsDataContext();//reference the LINQ object

        var patientID = objPatDC.tbl_patients.Where(x => x.id == _id).Select(x => x);//retrieve the row with the id being _id
        //SELECT * FROM patients WHERE id = _id

        return patientID;
    }

    //doing insert
    public bool commitInsert(string _firstname, string _lastname, string _email)
    {
        //creating an instance of our LINQ object
        patientsDataContext objPatDC = new patientsDataContext();//reference the LINQ object

        //to ensure all data will be disposed when finished
        using (objPatDC)
        {
            //create an instance of our table object
            tbl_patient objNewPat = new tbl_patient();
            //set table columns to the new values that will be passed from the *.aspx page
            objNewPat.firstname = _firstname;
            objNewPat.lastname = _lastname;
            objNewPat.email = _email;
            //insert command
            objPatDC.tbl_patients.InsertOnSubmit(objNewPat);
            //commit insert against database
            objPatDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _firstname, string _lastname, string _email)
    {
        //creating an instance of our LINQ object
        patientsDataContext objPatDC = new patientsDataContext();//reference the LINQ object

        using (objPatDC)
        {
            var objUpdPat = objPatDC.tbl_patients.Single(x => x.id == _id);//in case the id was not unique, the "single" picks only the first entry with id and changes it
            objUpdPat.firstname = _firstname;
            objUpdPat.lastname = _lastname;
            objUpdPat.email = _email;
            objPatDC.SubmitChanges();
            return true;
        }
    }

    public bool commitDelete(int _id)
    {
        //creating an instance of our LINQ object
        patientsDataContext objPatDC = new patientsDataContext();//reference the LINQ object

        using (objPatDC)
        {
            var objDelPat = objPatDC.tbl_patients.Single(x => x.id == _id);
            //delete command
            objPatDC.tbl_patients.DeleteOnSubmit(objDelPat);
            //commit delete against database
            objPatDC.SubmitChanges();
            return true;
        }
    }
}