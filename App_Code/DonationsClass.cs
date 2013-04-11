using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///This is Anja's Donation Class 
/// </summary>
public class DonationsClass
{
  DataClassesDataContext dbDC = new DataClassesDataContext();


//gets the sum of the donations
  public decimal getTotalDonations()
  {
      DataClassesDataContext db = new DataClassesDataContext();

      var donationSum = (from d in dbDC.tbl_donations select d.amount).Sum();
      return donationSum;
  }
               

    public IQueryable<tbl_donation> getDonations()
    {
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allDonations = dbDC.tbl_donations.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allDonations;
    }

    public IQueryable<tbl_donation> GetDonationByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allDonations = dbDC.tbl_donations.Where(x => x.id == _id).Select(x => x);
        return allDonations;
    }

    public bool commitInsert(string _fname, string _lname, string _email, decimal _amount, DateTime _date)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            tbl_donation objNewDonation = new tbl_donation();
            //set table column to new values being passed from *.aspx Donation
            //objNewDonation.id = _id;
            objNewDonation.fname = _fname;
            objNewDonation.lname = _lname;
            objNewDonation.email = _email;
            objNewDonation.amount = _amount;
            objNewDonation.date = _date;
            //insert command
            dbDC.tbl_donations.InsertOnSubmit(objNewDonation);
            //commit insert against db
            dbDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _fname, string _lname, string _email, decimal _amount, DateTime _date)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpDonation = dbDC.tbl_donations.Single(x => x.id == _id);
            objUpDonation.id = _id;
            objUpDonation.fname = _fname;
            objUpDonation.lname = _lname;
            objUpDonation.email = _email;
            objUpDonation.amount = _amount;
            objUpDonation.date = _date;
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
            var objDelDonation = dbDC.tbl_donations.Single(x => x.id == _id);
            //delete command
            dbDC.tbl_donations.DeleteOnSubmit(objDelDonation);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }
    }

    
}




