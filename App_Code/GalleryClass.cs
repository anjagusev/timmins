using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//gallery class create by colin rickatson
public class GalleryClass
{
    public IQueryable<Gallery> getgallery()
    {
        //create an insteance of the data context class called objCardImageDC
        DataClassesDataContext objGalleryImageDC = new DataClassesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allgallery = objGalleryImageDC.Galleries.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allgallery;
    }

    public IQueryable<Gallery> GetGalleryByID(int _Id)
    {
        DataClassesDataContext objGalleryImageDC = new DataClassesDataContext();
        var allgallery = objGalleryImageDC.Galleries.Where(x => x.Id == _Id).Select(x => x);
        return allgallery;
    }

    public bool commitInsert(string _MainImage, string _ThumbNail)
    {
        DataClassesDataContext objGalleryImageDC = new DataClassesDataContext();
        //to ensure all data will be disposed when finished
        using (objGalleryImageDC)
        {
            //create an instance of the table
            Gallery objNewGalleryImage = new Gallery();
            //set table column to new values being passed from *.aspx card_image
            //objNewCardImage.id = _id;
            objNewGalleryImage.MainImage = _MainImage;
            objNewGalleryImage.ThumbNail = _ThumbNail;
            //insert command
            objGalleryImageDC.Galleries.InsertOnSubmit(objNewGalleryImage);
            //commit insert against db
            objGalleryImageDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _Id, string _MainImage, string _ThumbNail)
    {
        DataClassesDataContext objGalleryImageDC = new DataClassesDataContext();
        using (objGalleryImageDC)
        {
            var objUGallery = objGalleryImageDC.Galleries.Single(x => x.Id == _Id);
            objUGallery.Id = _Id;
            objUGallery.MainImage = _MainImage;
            objUGallery.ThumbNail = _ThumbNail;
            //commit update against db
            objGalleryImageDC.SubmitChanges();

            return true;
        }
    }
    public bool commitDelete(int _Id)
    {
        DataClassesDataContext objGalleryImageDC = new DataClassesDataContext();
        using (objGalleryImageDC)
        {
            var objDelGallery = objGalleryImageDC.Galleries.Single(x => x.Id == _Id);
            //delete command
            objGalleryImageDC.Galleries.DeleteOnSubmit(objDelGallery);
            //commit delete aginst  db
            objGalleryImageDC.SubmitChanges();
            return true;
        }



    }
}