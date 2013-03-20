using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;

namespace UserControlHandlerDemo.Web
{
    /// <summary>
    /// Renders a (.ascx) user control
    /// </summary>
    public class UserControlHandler : IHttpHandler, IRequiresSessionState
    {
        private const string BASE_DIRECTORY = "~/controls/";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //get name from GET or POST parameter
            string controlName = context.Server.UrlDecode(context.Request.Params["name"]);
            if (!string.IsNullOrEmpty(controlName))
            {
                try
                {
                    //define full virtual path
                    var fullPath = BASE_DIRECTORY + controlName;

                    //initialize a new page to host the control
                    Page page = new Page();
                    //disable event validation (this is a workaround to handle the "RegisterForEventValidation can only be called during Render()" exception)
                    page.EnableEventValidation = false;

                    //create the runat="server" from that must host asp.net controls
                    HtmlForm form = new HtmlForm();
                    form.Name = "form1";
                    page.Controls.Add(form);

                    //load the control and add it to the page's form
                    Control control = page.LoadControl(fullPath);
                    form.Controls.Add(control);

                    //call RenderControl method to get the generated HTML
                    string html = RenderControl(page);

                    //output it to the response stream
                    context.Response.Write(html);
                }
                catch (Exception ex)
                {
                    //output error messege to the response stream
                    context.Response.Write("Error: " + ex.Message);
                }

                //end the response
                context.Response.End();
            }

        }


        /// <summary>
        /// Returns the generated HTML markup for a Control object
        /// </summary>
        private string RenderControl(Control control)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            control.RenderControl(writer);
            return sb.ToString();
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}