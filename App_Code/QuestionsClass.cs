using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuestionsClass
/// </summary>
public class QuestionsClass
{

    DataClassesDataContext dbDC = new DataClassesDataContext();

    public IQueryable<Question> getQuestions()
    {
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allQuestions = dbDC.Questions.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allQuestions;
    }

    public IQueryable<Question> GetQuestionByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();

        var allquestions = dbDC.Questions.Where(x => x.ID == _id).Select(x => x);
        return allquestions;
    }

    public bool commitInsert(string _questiontype, string _text, string _options)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            Question objNewQuestion = new Question();
            //set table column to new values being passed from *.aspx question
            //objNewQuestion.id = _id;
            objNewQuestion.QuestionType = _questiontype;
            objNewQuestion.Text = _text;
            objNewQuestion.Options = _options;
            //insert command
            dbDC.Questions.InsertOnSubmit(objNewQuestion);
            //commit insert against db
            dbDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _text, string _questiontype, string _options)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpQuestion = dbDC.Questions.Single(x => x.ID == _id);
            objUpQuestion.ID = _id;
            objUpQuestion.Text = _text;
            objUpQuestion.QuestionType = _questiontype;
            objUpQuestion.Options = _options;
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
            var objDelquestion = dbDC.Questions.Single(x => x.ID == _id);
            //delete command
            dbDC.Questions.DeleteOnSubmit(objDelquestion);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }
    }

    
}




