using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteMapClass
/// </summary>
public class SiteMapClass
{
    public IQueryable<SiteMap> getSiteMaps()
    {
       
        //create an insteance of the data context class called ObjSiteMapDC
        sitemapDataContext objSiteMapDC = new sitemapDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allSiteMaps = objSiteMapDC.SiteMaps.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allSiteMaps;
    }

    public IQueryable<SiteMap> getSiteMapByID(int _id)
    {
        sitemapDataContext objSiteMapDC = new sitemapDataContext();
        var allSiteMaps = objSiteMapDC.SiteMaps.Where(x => x.ID == _id).Select(x => x);
        return allSiteMaps;
    }



    public bool commitInsert(string _url, string _title, string _description, int _parentid, int _ordinalposition, int _subjectid)
    {
        sitemapDataContext objSiteMapDC = new sitemapDataContext();
        //to ensure all data will be disposed when finished
        using (objSiteMapDC)
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
            objSiteMapDC.SiteMaps.InsertOnSubmit(objNewSiteMap);
            //commit insert against db
            objSiteMapDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _url, string _title, string _description, int _parentid, int _ordinalposition, int _subjectid)
    {
        sitemapDataContext objSiteMapDC = new sitemapDataContext();
        using (objSiteMapDC)
        {


            var objUpSiteMap = objSiteMapDC.SiteMaps.Single(x => x.ID == _id);
            objUpSiteMap.ID = _id;
            objUpSiteMap.Url = _url;
            objUpSiteMap.Title = _title;
            objUpSiteMap.Description = _description;
            objUpSiteMap.ParentID = _parentid;
            objUpSiteMap.OrdinalPosition = _ordinalposition;
            objUpSiteMap.SubjectID = _subjectid;
            //commit update against db
            objSiteMapDC.SubmitChanges();

            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        sitemapDataContext objSiteMapDC = new sitemapDataContext();
        using (objSiteMapDC)
        {
            var objDelSub = objSiteMapDC.SiteMaps.Single(x => x.ID == _id);
            //delete command
            objSiteMapDC.SiteMaps.DeleteOnSubmit(objDelSub);
            //commit delete aginst  db
            objSiteMapDC.SubmitChanges();
            return true;
        }



    }
}




