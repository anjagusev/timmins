using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This is Anja's class for the sitemap feature
/// </summary>
public class SiteMapClass
{
    public IQueryable<SiteMap> getSiteMaps()
    {
       
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allSiteMaps = dbDC.SiteMaps.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allSiteMaps;
    }

    public IQueryable<SiteMap> getSiteMapByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allSiteMaps = dbDC.SiteMaps.Where(x => x.ID == _id).Select(x => x);
        return allSiteMaps;
    }



    public bool commitInsert(string _url, string _title, string _description, int _parentid, int _ordinalposition, int _subjectid)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            SiteMap objNewSiteMap = new SiteMap();
            //set table column to new values being passed from *.aspx SiteMap
        
            objNewSiteMap.Url = _url;
            objNewSiteMap.Title = _title;
            objNewSiteMap.Description = _description;
            objNewSiteMap.ParentID = _parentid;
            objNewSiteMap.OrdinalPosition = _ordinalposition;
            objNewSiteMap.SubjectID = _subjectid;
            dbDC.SiteMaps.InsertOnSubmit(objNewSiteMap);
            //commit insert against db
            dbDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _url, string _title, string _description, int _parentid, int _ordinalposition, int _subjectid)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {


            var objUpSiteMap = dbDC.SiteMaps.Single(x => x.ID == _id);
            objUpSiteMap.ID = _id;
            objUpSiteMap.Url = _url;
            objUpSiteMap.Title = _title;
            objUpSiteMap.Description = _description;
            objUpSiteMap.ParentID = _parentid;
            objUpSiteMap.OrdinalPosition = _ordinalposition;
            objUpSiteMap.SubjectID = _subjectid;
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
            var objDelSub = dbDC.SiteMaps.Single(x => x.ID == _id);
            //delete command
            dbDC.SiteMaps.DeleteOnSubmit(objDelSub);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }



    }
}




