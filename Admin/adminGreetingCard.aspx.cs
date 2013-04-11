using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class Admin_Default : System.Web.UI.Page
{
    CardImageClass objCard = new CardImageClass();

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
                CardImageClass objCard = new CardImageClass();

                string location = "~/img/".ToString();

                string serverFileName = Path.GetFileName(
             Uploader.PostedFile.FileName);
                string Src = serverFileName.ToString();


                objCard.commitInsert(Src, txtNameI.Text);

                _subRebind();
                break;

        }
    }

    private void _subRebind()
    {
        rpt_imgs.DataSource = objCard.getcard_images();
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


        ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("cph_admin_main");

        FileUpload uploaderE = (FileUpload)rpt_imgs.Rows[e.RowIndex].FindControl("UploaderE");



        string ImgID = ((Label)rpt_imgs.Rows[e.RowIndex].FindControl("lblImageID")).Text;
        int _imgID = int.Parse(ImgID);



        string serverFileName = Path.GetFileName(
     uploaderE.PostedFile.FileName);
        string Src = serverFileName.ToString();

        //   string src = fileupload.FileName.ToString();

        string Name = ((TextBox)rpt_imgs.Rows[e.RowIndex].FindControl("txtName")).Text;
        objCard.commitUpdate(_imgID, Src, Name);
        rpt_imgs.DataSource = objCard.GetCardImageByID(_imgID);
        rpt_imgs.DataBind();
        rpt_imgs.EditIndex = -1;
        _subRebind();


    }
}
