<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="DonationCompleted.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">

</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
 <div>
       
        <asp:Label ID="lbl_message" runat="server">We appreciate your donation of </asp:Label> <asp:Label ID="lbl_amount" runat="server" /> <asp:Label ID="lbl_messagecontinued" runat="server" > to Timmins and District Hospital! </asp:Label>
        <br />

        <asp:Label ID="lbl_received" runat="server" />
      
    </div>
</asp:Content>

