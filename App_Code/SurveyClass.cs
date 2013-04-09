using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SurveyClass
/// </summary>
public class SurveyClass
{
    DataClassesDataContext dbDC = new DataClassesDataContext();

    public IQueryable<Survey> getSurveys()
    {
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allSurveys = dbDC.Surveys.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allSurveys;
    }

   

    public IQueryable<Survey> GetSurveyByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allsurveys = dbDC.Surveys.Where(x => x.ID == _id).Select(x => x);
        return allsurveys;
    }

    public bool commitInsert(string _title, string _description, DateTime _createddate, DateTime _expireson, string _status, out int survey_id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            Survey objNewSurvey = new Survey();
            //set table column to new values being passed from *.aspx question
            //objNewSurvey.id = _id;
            objNewSurvey.Title = _title;
            objNewSurvey.Description = _description;
            objNewSurvey.CreatedDate = _createddate;
            objNewSurvey.ExpiresOn = _expireson;
            objNewSurvey.Status = _status;
            //objNewSurvey.CreatedBy = _createdby;
            //insert command
            dbDC.Surveys.InsertOnSubmit(objNewSurvey);
            //commit insert against db
            dbDC.SubmitChanges();
            int _surveyID = objNewSurvey.ID;

           survey_id = objNewSurvey.ID;
            return true;
        }
    }

    public bool commitUpdate(int _id, string _title, string _description, DateTime _createddate, DateTime _expireson, int _createdby, string _status)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpSurvey = dbDC.Surveys.Single(x => x.ID == _id);
            objUpSurvey.ID = _id;
            objUpSurvey.Title = _title;
            objUpSurvey.Description = _description;
            objUpSurvey.CreatedDate = _createddate;
            objUpSurvey.ExpiresOn = _expireson;
            objUpSurvey.CreatedBy = _createdby;
            objUpSurvey.Status = _status;
            //commit update against db
            dbDC.SubmitChanges();

            return true;
        }
    }

    public bool updateStatus(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpSurvey = dbDC.Surveys.Single(x => x.ID == _id);
            objUpSurvey.ID = _id;
            objUpSurvey.Status = "Active";
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
            var objDelquestion = dbDC.Surveys.Single(x => x.ID == _id);
            //delete command
            dbDC.Surveys.DeleteOnSubmit(objDelquestion);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }
    }
}


