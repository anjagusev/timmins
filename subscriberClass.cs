using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for subscriberClass
/// </summary>
public class subscriberClass
{

    public class subscribeClass
    {

        public IQueryable<tbl_subscriber> getsubscriber()
        {
            subscriberDataContext objlinq = new subscriberDataContext();
            var allsubscribes = objlinq.tbl_subscribers.Select(x => x);
            return allsubscribes;
        }

        public IQueryable<tbl_subscriber> getSubscriberByID(int _id)
        {
            subscriberDataContext objlinq = new subscriberDataContext();
            var subscriberByID = objlinq.tbl_subscribers.Where(x => x.subscriber_id == _id).Select(x => x);
            return subscriberByID;
        }

        // find if email alredy exist 
        public IQueryable<tbl_subscriber> emailExist(string _email)
        {
            subscriberDataContext objlinq = new subscriberDataContext();
            var emailcheck = objlinq.tbl_subscribers.Where(u => u.email == _email).Select(u => u);
            return emailcheck;
        }

        // verify email Used on Confirm_email.aspx 
        public bool verify(int _id)
        {
            subscriberDataContext objlinq = new subscriberDataContext();
            using (objlinq)
            {
                var verify_id = objlinq.tbl_subscribers.Single(x => x.subscriber_id == _id);
                verify_id.valid = "yes";
                objlinq.SubmitChanges();
                return true;
            }
        }



        // for admin check box email
        //public List<string> SendEmailToSubscribers()
        //{
        //    subscriberDataContext objlinq = new subscriberDataContext();
        //  var   getEmails = objlinq.tbl_subscribers.Where(x => x.valid == "yes").Select(x => new { x.email});
        //    return getEmails;
        //}


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



        public bool commitUpdate(int _subscribeID, string _name, string _email)
        {
            subscriberDataContext objlinq = new subscriberDataContext();
            using (objlinq)
            {
                var objUpsub = objlinq.tbl_subscribers.Single(x => x.subscriber_id == _subscribeID);
                objUpsub.name = _name;
                objUpsub.email = _email;
                objlinq.SubmitChanges();

                return true;
            }


        }

        public bool commitDelete(int _subscribeID)
        {

            subscriberDataContext objlinq = new subscriberDataContext();
            using (objlinq)
            {
                var objDelsub = objlinq.tbl_subscribers.Single(x => x.subscriber_id == _subscribeID);
                objlinq.tbl_subscribers.DeleteOnSubmit(objDelsub);
                objlinq.SubmitChanges();
                return true;
            }
        }
    }

    public IQueryable<tbl_subscriber> emailExist(string _email)
    {
        subscriberDataContext objlinq = new subscriberDataContext();
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


    public bool CommitInsert(string _name, string _email)
    {
        subscriberDataContext objlinq = new subscriberDataContext();
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

    public int last_id()
    {
           return lastid; 
    }
}