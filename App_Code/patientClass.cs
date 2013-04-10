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
        DataClassesDataContext objPatDC = new DataClassesDataContext();

        var allPatients = objPatDC.tbl_patients.Select(x => x);//method

        return allPatients;
    }


    public IQueryable<tbl_patient> getPatientByID(int _id)
    {
        //creating an instance of our LINQ object
        DataClassesDataContext objPatDC = new DataClassesDataContext();//reference the LINQ object

        var patientID = objPatDC.tbl_patients.Where(x => x.id == _id).Select(x => x);//retrieve the row with the id being _id
        //sql command for "SELECT * FROM patients WHERE id = _id"

        return patientID;
    }

    

    //doing insert
    public bool commitInsert(string _name, string _email)
    {
        DataClassesDataContext objPatDC = new DataClassesDataContext();

        using (objPatDC)
        {
            //create an instance of our table object
            tbl_patient objNewPat = new tbl_patient();
            objNewPat.name = _name;
            objNewPat.email = _email;
            //insert command
            objPatDC.tbl_patients.InsertOnSubmit(objNewPat);
            //commit insert against database
            objPatDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _name, string _email)
    {
        DataClassesDataContext objPatDC = new DataClassesDataContext();

        using (objPatDC)
        {
            var objUpdPat = objPatDC.tbl_patients.Single(x => x.id == _id);//in case the id was not unique, the "single" picks only the first entry with id and changes it
            objUpdPat.name = _name;
            objUpdPat.email = _email;
            objPatDC.SubmitChanges();
            return true;
        }
    }

    public bool commitDelete(int _id)
    {
        DataClassesDataContext objPatDC = new DataClassesDataContext();

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