<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="DonationCancel.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">

</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
Oops, something seems to have gone wrong with your donation. Please try again!


<asp:LinkButton ID="lkb_donate" runat="server" Text="Donate Now!" OnClick="subClick" />
</asp:Content>

