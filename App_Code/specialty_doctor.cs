using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for specialty_doctor
/// </summary>
public class specialty_doctor
{
   // Get all doctors from table
    public IQueryable<tbl_doctor> getdoctors()
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        //creating an anonymous variable with its value being the instance of our LINQ object
        var alldoctors = objdocDC.tbl_doctors.Select(x => x);// method syntax //products is the name of the actual table. //==> means goes to, x means column name
        //var allProducts = from x in objProdDC.products select x; //query syntax
        return alldoctors;
    }

    // get all specialities
    public IQueryable<tbl_specialty> getspecialities()
    {
        specialties_doctorsDataContext objspDC = new specialties_doctorsDataContext();
        //creating an anonymous variable with its value being the instance of our LINQ object
        var allspecialities = objspDC.tbl_specialties.Select(x => x);// method syntax //products is the name of the actual table. //==> means goes to, x means column name
        //var allProducts = from x in objProdDC.products select x; //query syntax
        return allspecialities;
    }


    // get doctors by ID
    public IQueryable<tbl_doctor> getdoctorByID(int _id)
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        var doctorID = objdocDC.tbl_doctors.Where(x => x.doctor_id == _id).Select(x => x);
        return doctorID;
    }

    // get specialty by ID
    public IQueryable<tbl_specialty> getspecialtyByID(int _id)
    {
        specialties_doctorsDataContext objspDC = new specialties_doctorsDataContext();
        var specialtyID = objspDC.tbl_specialties.Where(x => x.specialty_id == _id).Select(x => x);
        return specialtyID;
    }


    // specialty dropdown selecting doctors by specialty id
    public IQueryable<tbl_doctor> getdoctorbySpid( int _id)
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        var ret_doc = objdocDC.tbl_doctors.Where(x => x.specialty_id == _id).Select(x => x);
        return ret_doc;
    }

    public string ret_doc;

    public int docCount()
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        var found = ret_doc.Count();
        return found;
    }


    //search by name
    public IQueryable<tbl_doctor> docByName(string _fname, string _lname )
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        var names = objdocDC.tbl_doctors.Where(x =>x.first_name.Contains(_fname)).Where (x =>x.last_name.Contains(_lname));
        return names;
    
    }




    // insert part for doctors table

    public bool commitInsertInDoc(int _specialtyID, string _firstname, string _lastname, string _gender, string _email, string _bio)
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        using (objdocDC)
        {
            tbl_doctor objNewdoc = new tbl_doctor();
            objNewdoc.first_name = _firstname;
            objNewdoc.last_name = _lastname;
            objNewdoc.specialty_id = _specialtyID;
            objNewdoc.bio = _bio;
            objNewdoc.email = _email;
            objNewdoc.gender = _gender;
            //insert command
            objdocDC.tbl_doctors.InsertOnSubmit(objNewdoc);
            //commit insert against database
            objdocDC.SubmitChanges();
            return true;
        }
    }
    //insert for specialty

    public bool commitInsertInSp( string _specialty)
    {
        specialties_doctorsDataContext objspDC = new specialties_doctorsDataContext();
        using (objspDC)
        {
            tbl_specialty objNewsp = new tbl_specialty();
           
            objNewsp.specialty = _specialty;
            objspDC.tbl_specialties.InsertOnSubmit(objNewsp);
            objspDC.SubmitChanges();
            return true;
        }
    }

    // doctors insert
    public bool commitUpdateInDoc(int _specialtyID, string _firstname, string _lastname, string _gender, string _email, string _bio)
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        using (objdocDC)
        {
            var objUpdoc = objdocDC.tbl_doctors.Single(x => x.specialty_id == _specialtyID);
            objUpdoc.first_name = _firstname;
            objUpdoc.last_name = _lastname;
            objUpdoc.bio = _bio;
            objUpdoc.email = _email;
            objUpdoc.gender = _gender;
            objdocDC.SubmitChanges();
            return true;
        }
    }

// update for specialty table

    public bool commitUpdateInSp(int _specialtyID, string _specialty)
    {
        specialties_doctorsDataContext objspDC = new specialties_doctorsDataContext();
        using (objspDC)
        {
            var objUpdoc = objspDC.tbl_specialties.Single(x => x.specialty_id == _specialtyID);
            objUpdoc.specialty = _specialty;
            objspDC.SubmitChanges();
            return true;
        }
    }


    // delete for specialty and doctors

    public bool commitDeleteInDoc(int _doctorID)
    {
        specialties_doctorsDataContext objdocDC = new specialties_doctorsDataContext();
        using (objdocDC)
        {
            var objDeldoc = objdocDC.tbl_doctors.Single(x => x.doctor_id == _doctorID);
            objdocDC.tbl_doctors.DeleteOnSubmit(objDeldoc);
            objdocDC.SubmitChanges();
            return true;
        }
    }




    //public bool commitDeleteInSp(int _specialtyID)
    //{
    //    specialties_doctorsDataContext objspDC = new specialties_doctorsDataContext();
    //    using (objspDC)
    //    {
    //        var objDelsp = objspDC.tbl_doctors.Single(x => x.specialty_id == _specialtyID);
    //        objspDC.tbl_specialties.DeleteOnSubmit(objDelsp);
    //        objspDC.SubmitChanges();
    //        return true;
    //    }
    //}

    //public bool commitInsertInSp(string p1, string p2)
    //{
    //    throw new NotImplementedException();
    //}
}
