using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.HtmlControls;
using UserControlHandlerDemo;
using System.Web.SessionState;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
public partial class subPage1 : System.Web.UI.Page
{
    CardImageClass objCard = new CardImageClass();



    protected void Page_Load(object sender, System.EventArgs e)
    {

        Master.pp_submasterSubHeading = "Create a Greeting Card";
        if (this.IsPostBack == false)
        {
            _subRebind();
            // Get the list of colors.

            lstBackColor.DataSource = objCard.getcard_images();
            lstBackColor.DataTextField = "name";
            lstBackColor.DataValueField = "src";
            lstBackColor.DataBind();
            //string[] colorArray = Enum.GetNames(typeof(System.Drawing.KnownColor));
            //lstBackColor.DataSource = colorArray;
            //lstBackColor.DataBind();
            string[] colorArray = Enum.GetNames(typeof(System.Drawing.KnownColor));
            BackgroundColour.DataSource = colorArray;
            BackgroundColour.DataBind();

            // string[] colorArray = Enum.GetNames(typeof(System.Drawing.KnownColor));
            lstForeColor.DataSource = colorArray;
            lstForeColor.DataBind();
            lstForeColor.SelectedIndex = 34;
            lstBackColor.SelectedIndex = 163;

            // Get the list of available fonts and add them to the font list.
            System.Drawing.Text.InstalledFontCollection fonts;
            fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                lstFontName.Items.Add(family.Name);
            }

            // Set border style options.
            string[] borderStyleArray = Enum.GetNames(typeof(BorderStyle));
            lstBorder.DataSource = borderStyleArray;
            lstBorder.DataBind();

            // Select the first border option.
            lstBorder.SelectedIndex = 0;

        }
        else
        {
            // Call the button event handler to refresh the greeting card.
            UpdateCard();
        }
    }

    private void UpdateCard()
    {
        //finally
        // Update the color.
        pnlCard.BackColor = Color.FromName(lstBackColor.SelectedItem.Text);
        lblGreeting.ForeColor = Color.FromName(lstForeColor.SelectedItem.Text);
        img_background.ImageUrl = "http://timmins.sidhusweb.com/img/" + lstBackColor.SelectedValue.ToString();


        // Update the font.
        lblGreeting.Font.Name = lstFontName.SelectedItem.Text;
        try
        {
            if (Int32.Parse(txtFontSize.Text) > 0)
            {
                lblGreeting.Font.Size = FontUnit.Point(Int32.Parse(txtFontSize.Text));
            }
        }
        catch
        {
            // Ignore invalid value.
        }

        try
        {
            if (Int32.Parse(txtFontSize.Text) > 0)
            {
                lblGreeting.Font.Size =
                    FontUnit.Point(Int32.Parse(txtFontSize.Text));
            }
        }
        catch
        {
            // Ignore invalid value.
        }

        // Find the appropriate TypeConverter for the BorderStyle enumeration.
        TypeConverter cnvrt = TypeDescriptor.GetConverter(typeof(BorderStyle));

        // Update the border style using the value from the converter.
        pnlCard.BorderStyle = (BorderStyle)cnvrt.ConvertFromString(
            lstBorder.SelectedItem.Text);


        //// Update the picture.
        //if (chkPicture.Checked == true)
        //{
        //    imgDefault.Visible = true;
        //}
        //else
        //{
        //    imgDefault.Visible = false;
        //}

        // Set the text.
        lblGreeting.Text = txtGreeting.Text;
        lblSender.Text = txt_sender.Text;
        lblPatient.Text = txt_patient.Text;
        lblSubject.Text = "A Virtual Card from  " + txt_name.Text;

    }

    /// <summary>
    /// Returns the generated HTML markup for a Control object
    /// </summary>
    private string RenderControl(Panel pnlCard)
    {

        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);

        pnlCard.RenderControl(writer);
        return sb.ToString();

    }

    emailClass objEmail = new emailClass();

    protected void subClick(object sender, EventArgs e)
    {

        ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Master.FindControl("cph_main"); //

       
        TextBox txtName = (TextBox)contentPlaceHolder.FindControl("txt_name");
        TextBox txtPatient = (TextBox)contentPlaceHolder.FindControl("txt_patient");
        TextBox txtMessage = (TextBox)contentPlaceHolder.FindControl("txt_message");
        string txtReason = "Greetings from " + txtName.Text;
        Panel pnlCard = (Panel)contentPlaceHolder.FindControl("pnlCard");
        string panel_html = RenderControl(pnlCard);
        string background = "img/" + lstBackColor.SelectedValue.ToString();


        string mappath = Server.MapPath(@background); // my image is placed in images folder

        Response.Write(mappath);
        _strMessage(objEmail.sendEmail(txtName.Text, background, txtPatient.Text.ToString(), txtReason, panel_html));// name, email, subject, message
    }

    private void _subRebind()
    {
        lblGreeting.Text = string.Empty;
        lblSender.Text = string.Empty;
        lblName.Text = string.Empty;
        lblPatient.Text = string.Empty;
        lblSubject.Text = string.Empty;
    }


    //this code returns true if it was a success, so you can use this to check if it was success:

    private void _strMessage(bool flag)
    {
        if (flag)
        {
            lbl_emailmessage.Text = "<span style='color:green;'>Your email was sent successfully!!!</span>";
        }
        else
        {
            lbl_emailmessage.Text = "<span style='color:red;'>Sorry unable to send Email</span>";
        }
    }
}
