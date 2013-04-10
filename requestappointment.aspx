<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="requestappointment.aspx.cs" Inherits="subPage1" %>

<%-- Access exposed elements from the master page--%>
<%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">
</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                // alert user
                document.getElementById('<%= lbl_calerror.ClientID %>').innerHTML = 'Cannot select a date earlier than today.';
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
            else {
                document.getElementById('<%= lbl_calerror.ClientID %>').innerHTML = '';
            }
        }
    </script>
    <AJAX:ToolkitScriptManager ID="tsm_main" runat="server" />
    
    <asp:Panel ID="pnl_appointment" runat="server">
        <asp:Label ID="lbl_info" runat="server" Text="Enter your Information Below and we'll get back to you as soon as possible" />
        <br />
        <br />
        <asp:Label ID="lbl_required" runat="server" Text="*Note all fields are Required"
            ForeColor="blue" />
        <br />
        <%--Name--%>
        <asp:Label ID="lbl_name" runat="server" Text="Name: " AssociatedControlID="txt_name" />
        <asp:TextBox ID="txt_name" runat="server" />
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_name" runat="server" Text="Empty value" ErrorMessage="Please enter your full name."
            ControlToValidate="txt_name" Display="Dynamic" SetFocusOnError="true" ValidationGroup="appointment_form" />
        <%-- checking if value entered is text format  --%>
        <asp:RegularExpressionValidator ID="rev_name" runat="server" Text="Invalid name"
            ErrorMessage="Please enter your name correctly." ControlToValidate="txt_name"
            Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"
            ValidationGroup="appointment_form" />
        <br />
        <%--Email--%>
        <asp:Label ID="lbl_email" runat="server" Text="Email: " AssociatedControlID="txt_email" />
        <asp:TextBox ID="txt_email" runat="server" />
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="Empty value" ErrorMessage="Please enter your email."
            ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="appointment_form" />
        <%-- checking if value entered is email format  --%>
        <asp:RegularExpressionValidator ID="rev_email" runat="server" Text="Invalid email format"
            ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
            ErrorMessage="Please enter a correct email address." ValidationGroup="appointment_form" />
        <br />
        <%--Date of Appointment--%>
        <asp:Label ID="lbl_appointmentdate" runat="server" Text="Date of Appointment: " AssociatedControlID="txt_appointmentdate" />
        <asp:TextBox ID="txt_appointmentdate" runat="server" />
        <asp:Label ID="lbl_calerror" runat="server" />
        <%-- checking if Appointment date is empty --%>
        <asp:RequiredFieldValidator ID="rfv_appointmentdate" runat="server" Text="Empty value"
            ErrorMessage="Please enter the date." ControlToValidate="txt_appointmentdate"
            Display="Dynamic" SetFocusOnError="true" ValidationGroup="appointment_form" />
        <%-- checking if Appointment value entered is in propers date format  --%>
        <asp:RegularExpressionValidator ID="rev_appointmentdate" runat="server" Text="Invalid date, Format: day/month/year"
            ErrorMessage="Please enter the correct date." ControlToValidate="txt_appointmentdate"
            Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$"
            ValidationGroup="appointment_form" />
        <%--Uses AJAX for calendar--%>
        <AJAX:CalendarExtender ID="ce_appointmentdate" runat="server" TargetControlID="txt_appointmentdate"
            Format="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
        <br />
        <%--Time of Appointment--%>
        <asp:Label ID="lbl_time" runat="server" Text="Time of Appointment: " AssociatedControlID="ddl_time" />
        <asp:DropDownList ID="ddl_time" runat="server">
        </asp:DropDownList>
        <%--<asp:TextBox ID="txt_time" runat="server" />--%>
        <br />
        <br />
        <br />
        <%-- Validation Summary for plan a appointment form --%>
        <asp:ValidationSummary ID="vds_appointment" runat="server" HeaderText="Form Errors:"
            DisplayMode="List" ValidationGroup="appointment_form" />
        <br />
        <%-- Submit and Clear Buttons --%>
        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" ValidationGroup="appointment_form" />
        <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="subClear" />
    </asp:Panel>
    <%-- Output Label --%>
    <asp:Label ID="lbl_output" runat="server" />
</asp:Content>
