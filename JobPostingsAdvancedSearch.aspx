<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature: Advanced Search--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="JobPostingsAdvancedSearch.aspx.cs" Inherits="subPage1" %>

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
    <div>
        <ajax:toolkitscriptmanager id="tsm_main" runat="server" />
        <asp:Label ID="lbl_required" runat="server" Text="* = Required" ForeColor="Maroon" />
        <br /><br />
        <asp:Label ID="lbl_department" runat="server" Text="Department" />
        <br />
        <%--Default dropdownlist for department--%>
        <asp:DropDownList ID="ddl_department" runat="server">
            <asp:ListItem>Any</asp:ListItem>
            <asp:ListItem>Finance</asp:ListItem>
            <asp:ListItem>General</asp:ListItem>
            <asp:ListItem>Human Resources</asp:ListItem>
            <asp:ListItem>IT</asp:ListItem>
            <asp:ListItem>Management</asp:ListItem>
            <asp:ListItem>Media</asp:ListItem>
            <asp:ListItem>Medicine</asp:ListItem>
            <asp:ListItem>Nursing</asp:ListItem>
            <asp:ListItem>Psychiatry</asp:ListItem>
            <asp:ListItem>Research</asp:ListItem>
            <asp:ListItem>Services</asp:ListItem>
            <asp:ListItem>Support</asp:ListItem>
            <asp:ListItem>Surgery</asp:ListItem>
            <asp:ListItem>Volunteer</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbl_hours" runat="server" Text="Hours" />
        <br />
        <%--Default dropdownlist for hours--%>
        <asp:DropDownList ID="ddl_hours" runat="server">
            <asp:ListItem>Any</asp:ListItem>
            <asp:ListItem>Full-Time</asp:ListItem>
            <asp:ListItem>Part-Time</asp:ListItem>
            <asp:ListItem>Contract</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbl_deadline" runat="server" Text="*Deadline" />
        <br />
        <asp:TextBox ID="txt_deadline" runat="server" />
        <asp:Label ID="lbl_calerror" runat="server" />
        <%-- checking if empty --%>
        <asp:RequiredFieldValidator ID="rfv_deadline" runat="server" Text="Empty value" ErrorMessage="Please enter the job deadline"
            ControlToValidate="txt_deadline" Display="Dynamic" SetFocusOnError="true" />
        <%-- checking if value entered is date format  --%>
        <asp:RegularExpressionValidator ID="rev_deadline" runat="server" Text="Invalid date, Format: dd/mm/yyyy"
            ErrorMessage="Please enter the correct date." ControlToValidate="txt_deadline"
            Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\d{1,2}\/\d{1,2}\/\d{4}$" />
        <%--Uses AJAX for calendar--%>
        <ajax:calendarextender id="ce_deadline" runat="server" targetcontrolid="txt_deadline"
            format="dd/MM/yyyy" onclientdateselectionchanged="checkDate" />
        <br />
        <br />
        <%--Search Bar--%>
        <asp:TextBox ID="txt_search" runat="server" Text="" placeholder="Search Job Title" />
        <br /><br />
        <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="subSearch" />
    </div>
</asp:Content>
