using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminSiteMapClass
/// </summary>
public class AdminSiteMapClass
{
    public IQueryable<AdminSiteMap> getAdminSiteMaps()
    {

        //create an insteance of the data context class called ObjAdminSiteMapDC
        adminsitemapDataContext objAdminSiteMapDC = new adminsitemapDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allAdminSiteMaps = objAdminSiteMapDC.AdminSiteMaps.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allAdminSiteMaps;
    }

    public IQueryable<AdminSiteMap> getAdminSiteMapByID(int _id)
    {
        adminsitemapDataContext objAdminSiteMapDC = new adminsitemapDataContext();
        var allAdminSiteMaps = objAdminSiteMapDC.AdminSiteMaps.Where(x => x.ID == _id).Select(x => x);
        return allAdminSiteMaps;
    }



    public bool commitInsert(string _url, string _title, string _description, int _parentid, int _ordinalposition)
    {
        adminsitemapDataContext objAdminSiteMapDC = new adminsitemapDataContext();
        //to ensure all data will be disposed when finished
        using (objAdminSiteMapDC)
        {
            //create an instance of the table
            AdminSiteMap objNewAdminSiteMap = new AdminSiteMap();
            //set table column to new values being passed from *.aspx AdminSiteMap

            objNewAdminSiteMap.Url = _url;
            objNewAdminSiteMap.Title = _title;
            objNewAdminSiteMap.Description = _description;
            objNewAdminSiteMap.ParentID = _parentid;
            objNewAdminSiteMap.OrdinalPosition = _ordinalposition;
          
            objAdminSiteMapDC.AdminSiteMaps.InsertOnSubmit(objNewAdminSiteMap);
            //commit insert against db
            objAdminSiteMapDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _url, string _title, string _description, int _parentid, int _ordinalposition)
    {
        adminsitemapDataContext objAdminSiteMapDC = new adminsitemapDataContext();
        using (objAdminSiteMapDC)
        {


            var objUpAdminSiteMap = objAdminSiteMapDC.AdminSiteMaps.Single(x => x.ID == _id);
            objUpAdminSiteMap.ID = _id;
            objUpAdminSiteMap.Url = _url;
            objUpAdminSiteMap.Title = _title;
            objUpAdminSiteMap.Description = _description;
            objUpAdminSiteMap.ParentID = _parentid;
            objUpAdminSiteMap.OrdinalPosition = _ordinalposition;
         
            //commit update against db
            objAdminSiteMapDC.SubmitChanges();

            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        adminsitemapDataContext objAdminSiteMapDC = new adminsitemapDataContext();
        using (objAdminSiteMapDC)
        {
            var objDelSub = objAdminSiteMapDC.AdminSiteMaps.Single(x => x.ID == _id);
            //delete command
            objAdminSiteMapDC.AdminSiteMaps.DeleteOnSubmit(objDelSub);
            //commit delete aginst  db
            objAdminSiteMapDC.SubmitChanges();
            return true;
        }



    }
}




