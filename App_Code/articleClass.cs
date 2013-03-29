using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for articleClass
/// </summary>
public class articleClass
{
    //creating an instance of our LINQ object
    articlesDataContext objNewsDC = new articlesDataContext();//reference the LINQ object

    public IQueryable<tbl_article> getArticles()
    {
        //creating an anonymous variable with its value being the instance of our LINQ object
        //"anonymous" because there is no data type associated
        var allArticles = objNewsDC.tbl_articles.Select(x => x);//method

        return allArticles;

        //order of our query is "from-table-where-select"
    }

    public IQueryable<tbl_article> getArticleByID(int _id)
    {
        var articleID = objNewsDC.tbl_articles.Where(x => x.id == _id).Select(x => x);//retrieve the row with the id being _id
        //SELECT * FROM tbl_article WHERE id = _id

        return articleID;
    }

    //doing insert
    public bool commitInsert(string _heading, string _intro, string _para)
    {
        //to ensure all data will be disposed when finished
        using (objNewsDC)
        {
            //create an instance of our table object
            tbl_article objNewArt = new tbl_article();
            //set table columns to the new values that will be passed from the *.aspx page
            objNewArt.heading = _heading;
            objNewArt.intro = _intro;
            objNewArt.paragraph = _para;
            //insert command
            objNewsDC.tbl_articles.InsertOnSubmit(objNewArt);
            //commit insert against database
            objNewsDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _heading, string _intro, string _para)
    {
        using (objNewsDC)
        {
            var objUpdArt = objNewsDC.tbl_articles.Single(x => x.id == _id);//in case the id was not unique, the "single" picks only the first entry with id and changes it
            objUpdArt.heading = _heading;
            objUpdArt.intro = _intro;
            objUpdArt.paragraph = _para;
            objNewsDC.SubmitChanges();
            return true;
        }
    }

    public bool commitDelete(int _id)
    {
        using (objNewsDC)
        {
            var objDelArt = objNewsDC.tbl_articles.Single(x => x.id == _id);
            //delete command
            objNewsDC.tbl_articles.DeleteOnSubmit(objDelArt);
            //commit delete against database
            objNewsDC.SubmitChanges();
            return true;
        }
    }
}