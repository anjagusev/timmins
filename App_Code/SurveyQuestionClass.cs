using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SurveySurveyQuestionClass
/// </summary>
public class SurveyQuestionClass
{
    public IQueryable<SurveyQuestion> getSurveyQuestions()
    {
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allSurveyQuestions = dbDC.SurveyQuestions.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allSurveyQuestions;
    }

    public IQueryable<SurveyQuestion> GetSurveyQuestionByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allquestions = dbDC.SurveyQuestions.Where(x => x.ID == _id).Select(x => x);
        return allquestions;
    }
   
    public bool commitInsert(int _questionid, int _surveyid)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            SurveyQuestion objNewSurveyQuestion = new SurveyQuestion();
            //set table column to new values being passed from *.aspx question
            //objNewSurveyQuestion.id = _id;
            objNewSurveyQuestion.QuestionID = _questionid;
            objNewSurveyQuestion.SurveyID = _surveyid;
            //objNewSurveyQuestion.OrderID = _orderid;
            //insert command
            dbDC.SurveyQuestions.InsertOnSubmit(objNewSurveyQuestion);
            //commit insert against db
            dbDC.SubmitChanges();
            int _surveyquestionID = objNewSurveyQuestion.ID;

          //  id = objNewSurveyQuestion.ID;
            return true;

        }
    }


    private int _surveyquestionID;
    public int SurveyQuestionID
    {
        get
        {


            return _surveyquestionID;
        }
        set
        {


            _surveyquestionID = value;
        }
    }

   
    
    public int getID(int qID)
    {
        return qID;
    }


        

    public bool commitUpdate(int _id, int _questionid, int _surveyid)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpSurveyQuestion = dbDC.SurveyQuestions.Single(x => x.ID == _id);
            objUpSurveyQuestion.ID = _id;
            objUpSurveyQuestion.QuestionID = _questionid;
            objUpSurveyQuestion.SurveyID = _surveyid;
         //   objUpSurveyQuestion.OrderID = _orderid;
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
            var objDelquestion = dbDC.SurveyQuestions.Single(x => x.ID == _id);
            //delete command
            dbDC.SurveyQuestions.DeleteOnSubmit(objDelquestion);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }
    }
}





/////////////////////----- OLD VERSION -----////////////////////////////////
//public bool commitInsert(int _questionid, int _surveyid, out int id)
//    {
//        DataClassesDataContext dbDC = new DataClassesDataContext();
//        //to ensure all data will be disposed when finished
//        using (dbDC)
//        {
//            //create an instance of the table
//            SurveyQuestion objNewSurveyQuestion = new SurveyQuestion();
//            //set table column to new values being passed from *.aspx question
//            //objNewSurveyQuestion.id = _id;
//            objNewSurveyQuestion.QuestionID = _questionid;
//            objNewSurveyQuestion.SurveyID = _surveyid;
//            //objNewSurveyQuestion.OrderID = _orderid;
//            //insert command
//            dbDC.SurveyQuestions.InsertOnSubmit(objNewSurveyQuestion);
//            //commit insert against db
//            dbDC.SubmitChanges();
//            int _surveyquestionID = objNewSurveyQuestion.ID;

//            id = objNewSurveyQuestion.ID;
//            return true;

//        }
//    }
