using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class pollClass
{
    public IQueryable<poll_question> getQuestions()
    {
        pollDataContext objQuestDC = new pollDataContext();
        var allQuestions = objQuestDC.poll_questions.Select(x => x);
        return allQuestions;
    }

    public IQueryable<poll_question> getQuestionByID(int _id)
    {
        pollDataContext objQuestDC = new pollDataContext();
        var allQuestions = objQuestDC.poll_questions.Where(x => x.IDq == _id).Select(x => x);
        return allQuestions;
    }

    public bool NewInsert(string _question)
    {
        pollDataContext objQuestDC = new pollDataContext();
        using (objQuestDC)
        {
            poll_question objNewQuest = new poll_question();
            objNewQuest.question = _question;
            objQuestDC.poll_questions.InsertOnSubmit(objNewQuest);
            objQuestDC.SubmitChanges();
            return true;
        }
    }

    public bool NewUpdate(int _id, string _question)
    {
        pollDataContext objQuestDC = new pollDataContext();
        using (objQuestDC)
        {
            var objUpQuest = objQuestDC.poll_questions.Single(x => x.IDq == _id);
            objUpQuest.question = _question;
            objQuestDC.SubmitChanges();
            return true;
        }
    }

    public bool NewDelete(int _IDq)
    {
        pollDataContext objQuestDC = new pollDataContext();
        using (objQuestDC)
        {
            var objDelQuest = objQuestDC.poll_questions.Single(x => x.IDq == _IDq);
            objQuestDC.poll_questions.DeleteOnSubmit(objDelQuest);
            objQuestDC.SubmitChanges();
            return true;
        }
    }

}