using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This is Anja's Class for the Greeting Card
/// </summary>
public class CardImageClass
{
    public IQueryable<card_image> getcard_images()
    {
        //create an insteance of the data context class called objCardImageDC
        card_imagesDataContext objCardImageDC = new card_imagesDataContext();
        //creating anonymous variable with value being instance of LINQ object
        var allcard_images = objCardImageDC.card_images.Select(x => x);
        //return IQueryable<product> for databound control to bind to
        return allcard_images;
    }

    public IQueryable<card_image> GetCardImageByID(int _id)
    {
        card_imagesDataContext objCardImageDC = new card_imagesDataContext();
        var allcardimages = objCardImageDC.card_images.Where(x => x.id == _id).Select(x => x);
        return allcardimages;
    }

    public bool commitInsert( string _src, string _name)
    {
        card_imagesDataContext objCardImageDC = new card_imagesDataContext();
        //to ensure all data will be disposed when finished
        using (objCardImageDC)
        {
            //create an instance of the table
            card_image objNewCardImage = new card_image();
            //set table column to new values being passed from *.aspx card_image
            //objNewCardImage.id = _id;
            objNewCardImage.src = _src;
            objNewCardImage.name = _name;
            //insert command
            objCardImageDC.card_images.InsertOnSubmit(objNewCardImage);
            //commit insert against db
            objCardImageDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _src, string _name)
    {
        card_imagesDataContext objCardImageDC = new card_imagesDataContext();
        using (objCardImageDC)
        {
            var objUpcard_image = objCardImageDC.card_images.Single(x => x.id == _id);
            objUpcard_image.id = _id;
            objUpcard_image.src = _src;
            objUpcard_image.name = _name;
            //commit update against db
            objCardImageDC.SubmitChanges();

            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        card_imagesDataContext objCardImageDC = new card_imagesDataContext();
        using (objCardImageDC)
        {
            var objDelcard_image = objCardImageDC.card_images.Single(x => x.id == _id);
            //delete command
            objCardImageDC.card_images.DeleteOnSubmit(objDelcard_image);
            //commit delete aginst  db
            objCardImageDC.SubmitChanges();
            return true;
        }



    }
}




