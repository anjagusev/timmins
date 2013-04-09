<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mail.aspx.cs" Inherits="Doctor_mail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
        <asp:Label ID="lbl_name" runat="server" Text="Your Name: " />
        <asp:TextBox ID="txt_name" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="txt_name" Text="*Enter your name please" />
        </p>

        <br />
        <p><asp:Label ID="lbl_email" runat="server" Text="Receiver's Email: " />
        <asp:TextBox ID="txt_email" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="txt_email" Text="*Enter a destination mail address" />
        <%--Need to add the regular expression validator--%>
        </p>

        <br />
        <p><asp:Label ID="lbl_subj" runat="server" Text="Subject: " />
        <asp:TextBox ID="txt_reason" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_reason" runat="server" ControlToValidate="txt_reason" Text="*Subject required" />
        <%--Need to add the regular expression validator--%>
        </p>

        <br />
        <p><asp:Label ID="lbl_body" runat="server" Text="Body: " />
        <asp:TextBox ID="txt_message" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator ID="rfv_message" runat="server" ControlToValidate="txt_message" Text="*Your email cannot be empty" />
        </p>
            
        <br />
        <asp:LinkButton ID="btn" OnClick="subClick" runat="server" Text="Send" />
        <br /><br />
        <asp:Label ID="lbl" runat="server" />
    </div>
    </form>
</body>
</html>
