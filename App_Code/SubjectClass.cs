﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubjectClass
/// </summary>
public class SubjectClass
{
    public IQueryable<subject> getSubjects()
      {
      //create an insteance of the data context class called ObjSubjectDC
       subjectDataContext objSubjectDC = new subjectDataContext();
      //creating anonymous variable with value being instance of LINQ object
       var allSubjects = objSubjectDC.subjects.Select(x => x);
        //return IQueryable<product> for databound control to bind to
       return allSubjects;
    }

    public IQueryable<subject> getSubjectByID(int _id)
    {
        subjectDataContext objSubjectDC = new subjectDataContext();
        var allsubjects = objSubjectDC.subjects.Where(x => x.id == _id).Select(x => x);
        return allsubjects;
    }

   

    public bool commitInsert(int _id, string _menu_name)
    {
        subjectDataContext objSubjectDC = new subjectDataContext();
        //to ensure all data will be disposed when finished
        using (objSubjectDC)
        {
            //create an instance of the table
            subject objNewSubject = new subject();
            //set table column to new values being passed from *.aspx subject
            objNewSubject.id = _id;
            objNewSubject.menu_name = _menu_name;
            objSubjectDC.subjects.InsertOnSubmit(objNewSubject);
            //commit insert against db
            objSubjectDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _menu_name)
    {
        subjectDataContext objSubjectDC = new subjectDataContext();
        using (objSubjectDC)
        {
            var objUpSubject = objSubjectDC.subjects.Single(x => x.id == _id);
            objUpSubject.id =_id;
            objUpSubject.menu_name = _menu_name;
          
            //commit update against db
            objSubjectDC.SubmitChanges();

            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        subjectDataContext objSubjectDC = new subjectDataContext();
        using (objSubjectDC)
        {
            var objDelSub = objSubjectDC.subjects.Single(x => x.id == _id);
            //delete command
            objSubjectDC.subjects.DeleteOnSubmit(objDelSub);
            //commit delete aginst  db
            objSubjectDC.SubmitChanges();
            return true;
        }



	}
}




