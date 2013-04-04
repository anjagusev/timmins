<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="subPage1.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">
    CPH_NEWS_LIST
</asp:Content>

