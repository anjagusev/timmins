<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="imagegallery.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">

</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">

<%-- javascript for image gallery --%>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.18/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/jquery.timers-1.2.js"></script>
    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="js/jquery.galleryview-3.0-dev.js"></script>
    <link type="text/css" rel="stylesheet" href="css/gallerystyling.css" />
    <script type="text/javascript">
        $(function () {
            $('#myGallery').galleryView();
        });
</script>

    <div style="margin-left:25%;">
    <div id="container" style="padding:125px,125px,125px,125px;">
    <div id="divgallery" runat="server"></div>
    
    </div>
    </div>
</asp:Content>

