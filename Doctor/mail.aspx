<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mail.aspx.cs" Inherits="Doctor_mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Email a Patient</title>
    <link rel="Stylesheet" href="../App_Themes/Theme1/StyleSheet.css" type="text/css" />
    <link rel="Stylesheet" href="StyleSheet.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
            <div id="header-container">
                <div id="logo">
                    <asp:ImageButton ID="img_logo" runat="server" CssClass="img-logo" ImageUrl="~/img/timminslogo.png" OnClick="imgClick" />
                </div>
                <div id="header-right">
                    <div id="textsize">
                        <asp:LoginStatus ID="lgs_main" runat="server" LogoutAction="Redirect" LogoutPageUrl="../Default.aspx" CssClass="login" />
                        <br /><br />
                        <asp:Label ID="lbl_bigt" runat="server" Text="A++ | " />
                        <asp:Label ID="lbl_smallt" runat="server" Text="--A" />
                    </div>
                    <div  id="search">
                        <asp:TextBox ID="searchbox" CssClass="search-bar" runat="server" />
                        <asp:Button ID="btn_search" runat="server" CssClass="search-button" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="clearfloat">
            </div>
            <div id="top-nav-bar">
                <%--<asp:Menu ID="menu" Orientation="Horizontal" CssClass="top-nav-bar" runat="server"
                    StaticMenuStyle-CssClass="top-nav-bar" DataSourceID="../main_nav" StaticEnableDefaultPopOutImage="false">
                    <DynamicMenuItemStyle CssClass="menuItem"></DynamicMenuItemStyle>
                    <StaticMenuItemStyle CssClass="menuItem" HorizontalPadding="1em"></StaticMenuItemStyle>
                </asp:Menu>--%>
            </div>
        <div id="content">
            <p><asp:Label ID="lbl_name" runat="server" Text="Your Name: " CssClass="label" /></p>
            <p>
                <asp:TextBox ID="txt_name" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="txt_name" Text="*Enter your name please" />
            </p>

            <br />
            <p><asp:Label ID="lbl_email" runat="server" Text="Receiver's Email: " CssClass="label" /></p>
            <p><asp:DropDownList ID="ddl" runat="server" DataValueField="id" /></p>

            <br />
            <p><asp:Label ID="lbl_subj" runat="server" Text="Subject: " CssClass="label" /></p>
            <p>
                <asp:TextBox ID="txt_reason" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_reason" runat="server" ControlToValidate="txt_reason" Text="*Subject required" />
            </p>

            <br />
            <p><asp:Label ID="lbl_body" runat="server" Text="Body: " CssClass="label" /></p>
            <p>
                <asp:TextBox ID="txt_message" runat="server" TextMode="MultiLine" CssClass="msg" />
                <asp:RequiredFieldValidator ID="rfv_message" runat="server" ControlToValidate="txt_message" Text="*Your email cannot be empty" />
            </p>
            
            <br />
            <asp:LinkButton ID="btn" OnClick="subClick" runat="server" Text="Send" CssClass="msgbtn" />
            <br /><br />
            <asp:Label ID="lbl" runat="server" />
        </div>

        <div id="footer">
                <div id="logo_f">
                    <%-- <asp:Image ID="logo_ft" CssClass="logo_ft" runat="server" ImageUrl="~/img/logo_ft.png" />
                <asp:Label ID="phone_ft" CssClass="phone_ft" runat="server" Text="705-267-2131"/>
                <br />
                <asp:Label ID="address" CssClass="address_ft" runat="server" Text="700 Ross Avenue East Timmins, ON P4N 8P2" />
                    --%>
                </div>
                 <div id="icons_f">
                        <asp:Label ID="ico_ft" runat="server" CssClass="ic_txt_ft" Text="Follow us on:" />
                        <asp:ImageButton ID="fb_ft" runat="server" ImageUrl="~/img/facebook.png" ImageAlign="AbsBottom" />
                        <asp:ImageButton ID="rss_ft" runat="server" ImageUrl="~/img/RSS.png" ImageAlign="AbsBottom" />
                        <asp:ImageButton ID="twitter_ft" runat="server" ImageUrl="~/img/twitter.png" ImageAlign="AbsBottom" />
                     </div>


              
                <div id="navi_bar_f">
                     
                    <asp:Menu ID="menu1" Orientation="Horizontal" StaticMenuItemStyle-HorizontalPadding="5"
                        CssClass="nav_f" runat="server" DataSourceID="nav_ft">
                    </asp:Menu>
                    <asp:SiteMapDataSource ID="nav_ft" runat="server" SiteMapProvider="footer_nav" ShowStartingNode="false" />
                </div>
            </div>
            <div id="copy_ft">
                <asp:Label ID="copyright" runat="server" CssClass="copy_ft" Text="Copyright(c)2012 Timmins and District Hospital" />
            </div>
    </div>
    </form>
</body>
</html>
