using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class QuestAnswerClass
{
    public bool answerInsert(int _answer_id, string _answer)
    {
        pollDataContext objQuestAnsDC = new pollDataContext();
        using (objQuestAnsDC)
        {
            poll_answer objNewQuestAns = new poll_answer();
            objNewQuestAns.answer_id = _answer_id;
            objNewQuestAns.answer = _answer;


            objQuestAnsDC.poll_answers.InsertOnSubmit(objNewQuestAns);
            objQuestAnsDC.SubmitChanges();
            return true;
        }
    }
}