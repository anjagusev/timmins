<%@ Page Language="C#" AutoEventWireup="true" CodeFile="unsubscribe_news.aspx.cs" Inherits="unsubscribe_news" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<meta http-equiv="Refresh" content="5; url=http://timmins.sidhusweb.com/" />--%>
    <title>Timmins Hospital</title>
    <link href="App_Themes/con_firm_h/style_harry.css" rel="stylesheet" type="text/css" />
   </head> 
    
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="header">
            <asp:Label ID="lbl_header" runat="server" Text="<strong>Tadh.com</strong>" />
            <asp:ImageMap ID="header_logo" runat="server" ImageUrl="img/logo_ft.png" ImageAlign="Left" />
        </div>
        <div id="content">
            <br />
            <asp:Label ID="lbl_text" runat="server" Text="Thanks for using our server" />
            <div id="sec_div">
                <asp:Label ID="mess" runat="server" Text="Reason of Unsubscribe" /><br/>
                 <asp:TextBox ID="txt_comment" TextMode="MultiLine" runat="server" Columns="15" Rows="2" />
                <br />
                <asp:Button ID="btn_submit" runat="server" Text="submit" />
      
            </div>

        </div>
        <div id="footer">
            <asp:Label ID="lbl_id" runat="server" Text="Thanks For your time and comment" Visible="false" />
        </div>
    </form>
</body>
</html>
