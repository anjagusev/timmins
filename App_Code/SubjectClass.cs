using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Anja'S Class for the CMS, not currently in use
/// </summary>
public class SubjectClass
{
    public IQueryable<subject> getSubjects()
      {
      //create an insteance of the data context class called dbDC
       DataClassesDataContext dbDC = new DataClassesDataContext();
      //creating anonymous variable with value being instance of LINQ object
       var allSubjects = dbDC.subjects.Select(x => x);
        //return IQueryable<product> for databound control to bind to
       return allSubjects;
    }

    public IQueryable<subject> getSubjectByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allsubjects = dbDC.subjects.Where(x => x.id == _id).Select(x => x);
        return allsubjects;
    }

   

    public bool commitInsert(int _id, string _menu_name)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            subject objNewSubject = new subject();
            //set table column to new values being passed from *.aspx subject
            objNewSubject.id = _id;
            objNewSubject.menu_name = _menu_name;
            dbDC.subjects.InsertOnSubmit(objNewSubject);
            //commit insert against db
            dbDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _menu_name)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpSubject = dbDC.subjects.Single(x => x.id == _id);
            objUpSubject.id =_id;
            objUpSubject.menu_name = _menu_name;
          
            //commit update against db
            dbDC.SubmitChanges();

            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objDelSub = dbDC.subjects.Single(x => x.id == _id);
            //delete command
            dbDC.subjects.DeleteOnSubmit(objDelSub);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }



	}
}




