<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="Card.aspx.cs" Inherits="subPage1" %>

<%-- Access exposed elements from the master page--%>
<%@ MasterType VirtualPath="~/subPage.master" %>
<%-- Anja's Greeting Card Feature -- Currently In Use --%>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">
</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="lbl_emailmessage" runat="server"></asp:Label>
    <div id="greetingcard" style="float: left; border-right: thin ridge; padding-right: 1em;
        border-top: thin ridge; padding-left: 2em; font-size: .6em; padding-bottom: 2em;
        border-left: thin ridge; width: 293px; padding-top: 10px; border-bottom: thin ridge;
        font-family: Verdana; height: 408px; background-color: #99CCFF">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_name" runat="server">Enter your name:
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_name" AutoPostBack="True" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="txt_name"
                        Text="*Required*" AutoPostBack="true" ValidationGroup="email" Display="Dynamic" />
                    <asp:CompareValidator ID="cpv_name" runat="server" ControlToValidate="txt_name" Type="String"
                        Operator="DataTypeCheck" Text="*Invalid Name*" AutoPostBack="true" ValidationGroup="email"
                        Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_sender" runat="server">Enter your email:
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_sender" AutoPostBack="True" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_sender" runat="server" ControlToValidate="txt_sender"
                        Text="*Required*" AutoPostBack="true" ValidationGroup="email" />
                    <%-- regular express check for e-mail, making sure it is a valid e-mail that has been entered --%>
                    <asp:RegularExpressionValidator ID="reg_sender" runat="server" Text="Invalid Email"
                        ControlToValidate="txt_sender" Display="Dynamic" ValidationGroup="email" ErrorMessage="Please enter a valid e-mail"
                        ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_patient" runat="server">Enter the patient's email:
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_patient" AutoPostBack="True" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_patient" runat="server" ControlToValidate="txt_patient"
                        Text="*Required*" AutoPostBack="true" ValidationGroup="email" />
                    <%-- regular express check for e-mail, making sure it is a valid e-mail that has been entered --%>
                    <asp:RegularExpressionValidator ID="rev_email" runat="server" Text="Invalid Email"
                        ControlToValidate="txt_patient" Display="Dynamic" ValidationGroup="email" ErrorMessage="Please enter a valid e-mail"
                        ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_bckground" runat="server">Choose 
		 a background Image:
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="lstBackColor" runat="server" Height="22px" Width="194px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_backgroundColor" runat="server">Background Color:</asp:Label>
                <td>
                    <asp:DropDownList ID="BackgroundColour" runat="server" Height="2em" Width="13em"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_color" runat="server">
            Choose a foreground (text) color:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="lstForeColor" runat="server" Height="22px" Width="194px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_font" runat="server">Choose a font name:</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="lstFontName" runat="server" Height="22px" Width="194px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_fontsize" runat="server">
            Specify a font size:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFontSize" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_border" runat="server">
            Choose a border style:</asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="lstBorder" runat="server" CellPadding="0" Height="59px"
                        Width="177px" Font-Size="X-Small" AutoPostBack="True" RepeatColumns="5">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_message" runat="server">
            Enter your message:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGreeting" runat="server" Width="220px" Rows="4" TextMode="MultiLine"
                        AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_email" runat="server" CausesValidation="true" ValidationGroup="email"
                        Text="Send Email" OnClick="subClick" />
                </td>
            </tr>
        </table>
        <%-- <asp:CheckBox ID="chkPicture" runat="server" Text="Add the Default Picture" AutoPostBack="True">
            </asp:CheckBox><br />--%>
        <br />
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlCard" Style="float: left; position: relative; z-index: 101; top: 15px;
                height: 400px; width: 368px;" runat="server" HorizontalAlign="Center">
                <asp:Image ID="img_background" runat="server" Style="height: 3em; width: 4em;" /><br />
                &nbsp;
                <div id="mail_header">
                    <asp:Label ID="lblSubject" runat="server" />
                    <br />
                    <asp:Label ID="lbl_from" runat="server">From: </asp:Label>
                    <asp:Label ID="lblName" runat="server" />
                    <asp:Label ID="lblSender" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lbl_to" runat="server">To: </asp:Label>
                    <asp:Label ID="lblPatient" runat="server"></asp:Label>
                    <div id="card_message">
                        <br />
                        <br />
                        <asp:Label ID="lblGreeting" runat="server"></asp:Label>
                        <br />
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lstBackColor" />
            <asp:AsyncPostBackTrigger ControlID="BackgroundColour" />
            <asp:AsyncPostBackTrigger ControlID="lstForeColor" />
            <asp:AsyncPostBackTrigger ControlID="lstFontName" />
            <asp:AsyncPostBackTrigger ControlID="txtFontSize" />
            <asp:AsyncPostBackTrigger ControlID="lstBorder" />
            <asp:AsyncPostBackTrigger ControlID="txt_patient" />
            <asp:AsyncPostBackTrigger ControlID="txt_sender" />
            <asp:AsyncPostBackTrigger ControlID="txt_name" />
            <%--<asp:AsyncPostBackTrigger ControlID="chkPicture" />--%>
            <asp:AsyncPostBackTrigger ControlID="txtGreeting" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
