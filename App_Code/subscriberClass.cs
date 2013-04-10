using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for subscriberClass
/// </summary>
public class subscriberClass
{

    

        public IQueryable<tbl_subscriber> getsubscriber()
        {
            DataClassesDataContext objlinq = new DataClassesDataContext();
            var allsubscribes = objlinq.tbl_subscribers.Select(x => x);
            return allsubscribes;
        }

        public IQueryable<tbl_subscriber> getSubscriberByID(int _id)
        {
            DataClassesDataContext objlinq = new DataClassesDataContext();
            var subscriberByID = objlinq.tbl_subscribers.Where(x => x.subscriber_id == _id).Select(x => x);
            return subscriberByID;
        }

        

        
    

    // this method will check if email is already in database or not
    public IQueryable<tbl_subscriber> emailExist(string _email)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        var emailcheck = objlinq.tbl_subscribers.Where(u => u.email == _email).Select(u => u);
        return emailcheck;
    }


    // get last inserted id

    private int _lastid;
    public int lastid
    {
        get { return _lastid; }
        set { value = _lastid; }
    }

    public int last_id()
    {
        return lastid;
    }

    // Inser method to insert in subscriber table. for valid coloum it will insert no 
    public bool CommitInsert(string _name, string _email)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            tbl_subscriber objNewSub = new tbl_subscriber();
            objNewSub.name = _name;
            objNewSub.email = _email;
            objNewSub.valid = "no";
            objlinq.tbl_subscribers.InsertOnSubmit(objNewSub);
            objlinq.SubmitChanges();
            _lastid = objNewSub.subscriber_id;
            return true;
        }
    }

    // Adminside side insert
    public bool CommitInsertByAdmin(string _name, string _email, string _valid)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            tbl_subscriber objNewSub = new tbl_subscriber();
            objNewSub.name = _name;
            objNewSub.email = _email;
            objNewSub.valid = _valid;
            objlinq.tbl_subscribers.InsertOnSubmit(objNewSub);
            objlinq.SubmitChanges();
            _lastid = objNewSub.subscriber_id;
            return true;
        }
    }


    // verify email Used on Confirm_email.aspx 
    public bool verify(int _id)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            var verify_id = objlinq.tbl_subscribers.Single(x => x.subscriber_id == _id);
            verify_id.valid = "yes";
            objlinq.SubmitChanges();
            return true;
        }
    }

    // unsubscriber method 
    public bool unsubscribe(string _email)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            var objunsub = objlinq.tbl_subscribers.Single(x => x.email == _email);
            objunsub.valid = "no";
            objlinq.SubmitChanges();
            return true;
        }
    }

    // reason for unsubscribe
    public bool reasonOfUnsub(string _email, string _reason)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            var objRea = objlinq.tbl_subscribers.Single(x => x.email == _email);
            objRea.reseanOfunsub = _reason;
            objlinq.SubmitChanges();
            return true;


        }
    }



    //public object getsubscriber()
    //{
    //    DataClassesDataContext objlinq = new DataClassesDataContext();
    //    var allsubscribes = objlinq.tbl_subscribers.Select(x => x);
    //    return allsubscribes;
    //}


    public bool commitUpdate(int _subscribeID, string _name, string _email, string _valid)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            var objUpsub = objlinq.tbl_subscribers.Single(x => x.subscriber_id == _subscribeID);
            objUpsub.name = _name;
            objUpsub.email = _email;
            objUpsub.valid = _valid;
            objlinq.SubmitChanges();

            return true;
        }
    }

    public bool commitDelete(int _subscribeID)
    {
        DataClassesDataContext objlinq = new DataClassesDataContext();
        using (objlinq)
        {
            var objDelsub = objlinq.tbl_subscribers.Single(x => x.subscriber_id == _subscribeID);
            objlinq.tbl_subscribers.DeleteOnSubmit(objDelsub);
            objlinq.SubmitChanges();
            return true;
        }
    }
}