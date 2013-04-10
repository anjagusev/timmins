using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration; //added
using System.IO; //added



public partial class Admin_Default : System.Web.UI.Page
{
    GalleryClass objCard = new GalleryClass();

    protected void Page_Load(object sender, EventArgs e)
    {

        uploadDirectory = Path.Combine(Request.PhysicalApplicationPath, "img");

        if (!Page.IsPostBack)
        {
            _subRebind();


        }
    }

    protected void subAdmin(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Insert":
                GalleryClass objGallery = new GalleryClass();

                string location = "img/".ToString();

                string serverFileName = Path.GetFileName(
             Uploader.PostedFile.FileName);
                string MainImage = location + serverFileName.ToString(); //added location stuff for gallery usage


                //TextBox txtName = (TextBox)FindControl("txtNameI");
                //string txtName2 = txtName.Text;

                objGallery.commitInsert(MainImage, txtThumbNailI.Text);

                _subRebind();
                break;

        }
    }

    private void _subRebind()
    {
        rpt_imgs.DataSource = objCard.getgallery();
        rpt_imgs.DataBind();
    }

    public string uploadDirectory;
    protected void cmdUpload_Click(object sender, EventArgs e)
    {
        // Check that a file is actually being submitted.
        if (Uploader.PostedFile.FileName == "")
        {
            lblInfo.Text = "No file specified.";
        }
        else
        {


            // Check the extension.
            string extension = Path.GetExtension(Uploader.PostedFile.FileName);
            switch (extension.ToLower())
            {
                case ".bmp":
                case ".gif":
                case ".jpg":
                    break;
                default:
                    lblInfo.Text = "This file type is not allowed.";
                    return;
            }
            // Using this code, the saved file will retain its original
            // file name, but be stored in the current server
            // application directory.
            string serverFileName = Path.GetFileName(
              Uploader.PostedFile.FileName);
            string fullUploadPath = Path.Combine(uploadDirectory,
              serverFileName);


            try
            {
                // This overwrites any existing file with the same name.
                // Use File.Exists() to check first if this is a concern.
                Uploader.PostedFile.SaveAs(fullUploadPath);

                lblInfo.Text = "File " + serverFileName;
                lblInfo.Text += " uploaded successfully to ";
                lblInfo.Text += fullUploadPath;



            }
            catch (Exception err)
            {
                lblInfo.Text = err.Message;
            }
        }
    }



    protected void DeleteCustomer(object sender, EventArgs e)
    {

        Button lnkRemove = (Button)sender;

        int _imgID = Int32.Parse(((Label)lnkRemove.FindControl("lblImageID")).Text);

        objCard.commitDelete(_imgID);

        _subRebind();

    }
    protected void EditCustomer(object sender, GridViewEditEventArgs e)
    {
        rpt_imgs.EditIndex = e.NewEditIndex;
        _subRebind();
    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        rpt_imgs.EditIndex = -1;
        _subRebind();
    }
    protected void UpdateCustomer(object sender, GridViewUpdateEventArgs e)
    {




        string ImgID = ((Label)rpt_imgs.Rows[e.RowIndex].FindControl("lblImageID")).Text;
        int _imgID = int.Parse(ImgID);

        string Src = ((TextBox)rpt_imgs.Rows[e.RowIndex].FindControl("txtMainImage")).Text;
        string Name = ((TextBox)rpt_imgs.Rows[e.RowIndex].FindControl("txtThumbNail")).Text;
        objCard.commitUpdate(_imgID, Src, Name);
        rpt_imgs.DataSource = objCard.GetGalleryByID(_imgID);
        rpt_imgs.DataBind();
        rpt_imgs.EditIndex = -1;
        _subRebind();


    }
}
