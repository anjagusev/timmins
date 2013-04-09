<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="Donation.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>

      <%-- Anja's Donation Feature --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">

</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
   <div>
    <asp:HiddenField ID="username" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblFname" runat="server" Text="First Name: " />
                </td>
                <td>
                    <asp:TextBox ID="txtFname" runat="server" />
           <%--         <uc:required ID="uc_r" runat="server" />--%>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_fname" runat="server" Text="*Required" ControlToValidate="txtFname"
                        Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Lname" runat="server" Text="Last Name: " />
                </td>
                <td>
                    <asp:TextBox ID="txtLname" runat="server" />
                 <%--   <uc:required ID="uc_r2" runat="server" />--%>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_lname" runat="server" Text="*Required" ControlToValidate="txtLname"
                        Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_email" runat="server" Text="Email: " />
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" />
                    <%--<uc:required ID="uc_r3" runat="server" />--%>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="*Required" ControlToValidate="txtEmail"
                        Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_amount" runat="server" Text="Amount: " />
                </td>
          

            </tr>
        </table>
         <asp:LinkButton ID="paypalDonate" runat="server" Target="_blank"  OnClientClick="window.document.forms[0].target='_blank';"  OnClick="subClick">
            <asp:Image ID="Image1" runat="server" AlternateText="Donate to Timmins" ImageUrl="https://www.sandbox.paypal.com/en_US/i/btn/btn_donateCC_LG.gif" />
        </asp:LinkButton>

<%--        <asp:HyperLink ID="paypalDonate" Target="_blank" runat="server" NavigateUrl="https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XRQ633HENA86C&return=http://timmins.sidhusweb.com/DonationCompleted.aspx&notify_url=http://www.anja-gusev.com/test3.aspx&custom=moo&cm=moo&on0=moop&cancel_return=http://timmins.sidhusweb.com/DonationCancel.aspx" >
            <asp:Image ID="payPalImage" runat="server" AlternateText="Donate to Timmins" ImageUrl="https://www.sandbox.paypal.com/en_US/i/btn/btn_donateCC_LG.gif" />
        </asp:HyperLink>--%>
<%--     <a id="paypalDonate" target="_blank" href="https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XRQ633HENA86C"><img src="https://www.sandbox.paypal.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" id="payPalImage" alt="Donate to Timmins" /></a>--%>
     

        <asp:Label ID="lbl_output" runat="server" />
    </div>
</asp:Content>

