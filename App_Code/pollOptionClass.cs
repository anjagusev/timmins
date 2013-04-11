using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class pollOptionClass
{
    public IQueryable<poll_choice> getChoices()
    {
        pollDataContext objChoiceDC = new pollDataContext();
        var allChoices = objChoiceDC.poll_choices.Select(x => x);
        return allChoices;
    }

    public IQueryable<poll_choice> getChoiceByID(int _id)
    {
        pollDataContext objChoiceDC = new pollDataContext();
        var allChoices = objChoiceDC.poll_choices.Where(x => x.IDpc == _id).Select(x => x);
        return allChoices;
    }

    public bool pollOption(int _IDpc, string _option)
    {
        pollDataContext objChoiceDC = new pollDataContext();
        using (objChoiceDC)
        {
            poll_choice objNewChoice = new poll_choice();
            objNewChoice.IDpc = _IDpc;
            objNewChoice.option = _option;

            objChoiceDC.poll_choices.InsertOnSubmit(objNewChoice);
            objChoiceDC.SubmitChanges();
            return true;
        }
    }

}