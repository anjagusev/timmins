<%@ Page Language="C#" AutoEventWireup="true" CodeFile="confirm_email.aspx.cs" Inherits="confirm_email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <%-- this will direct automatic to timmins--%>
   <meta http-equiv="Refresh" content="5; url=http://timmins.sidhusweb.com/" />
    <link href="App_Themes/con_firm_h/style_harry.css" rel="stylesheet" type="text/css" />
    
    <title>Confirm for subscribe</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="header">
            <%--&&&&&&&&&&& This page is to verify user's email ********--%>
            <asp:Label ID="lbl_header" runat="server" Text="<strong>Tadh.com</strong>" />
            <asp:ImageMap ID="header_logo" runat="server" ImageUrl="img/logo_ft.png" ImageAlign="Left" />
        </div>
        <div id="content">
            <br />
            <asp:Label ID="lbl_text" runat="server" Text="Thanks for subscribe" />
            <div id="sec_div">

                <asp:Label ID="mess" runat="server" Text="By subscribe to our website you will get new news from Timmins and District hospital" />

            </div>

        </div>
        <div id="footer">
            <asp:Label ID="lbl_id" runat="server" Text="You will be redirected to Timmins website in 5 second" />
        </div>
    </div>
    </form>
</body>
</html>
