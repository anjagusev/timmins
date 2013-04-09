using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Anja's Class for the CMS, not currently in use
/// </summary>
public class PageClass
{
    public IQueryable<page> getPageByName(string _menu_name)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allPages = dbDC.pages.Where(x => x.menu_name == _menu_name).Select(x => x);
        return allPages;
    }

    public IQueryable<page> getPages()
    {
        //create an insteance of the data context class called dbDC
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allPages = dbDC.pages.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allPages;
    }

    public IQueryable<page> getPageByID(int _id)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        var allpages = dbDC.pages.Where(x => x.id == _id).Select(x => x);
        return allpages;
    }

    public bool commitInsert(int _subject_id, string _menu_name, string _title, string _content)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (dbDC)
        {
            //create an instance of the table
            page objNewPage = new page();
            //set table column to new values being passed from *.aspx page
            objNewPage.subject_id = _subject_id;
            objNewPage.menu_name = _menu_name;
            objNewPage.title = _title;
            objNewPage.page_content = _content;
            //insert command
            dbDC.pages.InsertOnSubmit(objNewPage);
            //commit insert against db
            dbDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, int _subject_id, string _menu_name, string _title, string _content)
    {
        DataClassesDataContext dbDC = new DataClassesDataContext();
        using (dbDC)
        {
            var objUpPage = dbDC.pages.Single(x => x.id == _id);
            objUpPage.subject_id = _subject_id;
            objUpPage.menu_name = _menu_name;
            objUpPage.title = _title;
            objUpPage.page_content = _content;
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
            var objDelPage = dbDC.pages.Single(x => x.id == _id);
            //delete command
            dbDC.pages.DeleteOnSubmit(objDelPage);
            //commit delete aginst  db
            dbDC.SubmitChanges();
            return true;
        }



    }
}




