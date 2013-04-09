using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SurveyResponseClass
/// </summary>
public class SurveyResponseClass
{


    public IQueryable<SurveyResponse> getSurveyResponses()
    {
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allSurveyResponses = dbDC.SurveyResponses.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allSurveyResponses;
    }
  
    //  public IQueryable<SurveyResponse> CreateSurveyReseponse(int _id, int _surveyID, int _questionID, string _response)
    //{
    //     SurveyResponse SurveyResponse = new SurveyResponse();
    //        SurveyResponse.ID = id;
    //        SurveyResponse.SurveyID = surveyID;
    //        SurveyResponse.QuestionID = questionID;
    //        SurveyResponse.Response = response;
    //        SurveyResponse.FilledBy = filledBy;
    //        return allSurveyResponse;
    //}

    public IQueryable<SurveyResponse> GetSurveyResponseByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allquestions = dbDC.SurveyResponses.Where(x => x.ID == _id).Select(x => x);
        return allquestions;
    }

    public bool commitInsert(int _surveyid, int _questionid, string _value, int _filledby)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            SurveyResponse objNewSurveyResponse = new SurveyResponse();
            //set table column to new values being passed from *.aspx question
            //objNewSurveyResponse.id = _id;
            objNewSurveyResponse.SurveyID = _surveyid;
            objNewSurveyResponse.QuestionID = _questionid;
            objNewSurveyResponse.Value = _value;
            objNewSurveyResponse.FilledBy = _filledby;
          
            //insert command
            dbDC.SurveyResponses.InsertOnSubmit(objNewSurveyResponse);
            //commit insert against db
            dbDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, int _surveyid, int _questionid, string _value, int _filledby)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpSurveyResponse = dbDC.SurveyResponses.Single(x => x.ID == _id);
            objUpSurveyResponse.ID = _id;
            objUpSurveyResponse.SurveyID = _surveyid;
            objUpSurveyResponse.QuestionID = _questionid;
            objUpSurveyResponse.Value = _value;
            objUpSurveyResponse.FilledBy = _filledby;
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
            var objDelquestion = dbDC.SurveyResponses.Single(x => x.ID == _id);
            //delete command
            dbDC.SurveyResponses.DeleteOnSubmit(objDelquestion);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }
    }
}


