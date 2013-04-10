<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="loginview">
        <asp:Login ID="lgn_main" runat="server" />
    </div>
    </form>
</body>
</html>
