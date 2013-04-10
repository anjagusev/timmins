<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="DetailedJobPosting.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">

</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
 <div>
        <asp:LinkButton ID="lnk_back" runat="server" PostBackUrl="~/JobPostings.aspx" Text="Back to Job Postings" />
        <br />
        <br />
        <asp:Label ID="lbl_error" runat="server" />
        <%--Repeater showing details of selected job posting--%>
        <asp:Repeater ID="rpt_detailed" runat="server">
            <ItemTemplate>
                <asp:Label ID="lbl_title" runat="server" Text="Job Title: " Font-Bold="true" />
                <%#Eval("title") %>
                <br />
                <asp:Label ID="lbl_dateposted" runat="server" Text="Date Posted: " Font-Bold="true" /><%#Eval("date_posted", "{0:dd/MM/yyyy}")%>
                <br />
                <asp:Label ID="lbl_hours" runat="server" Text="Hours: " Font-Bold="true" /><%#Eval("hours") %>
                <br />
                <asp:Label ID="lbl_department" runat="server" Text="Department: " Font-Bold="true" /><%#Eval("department") %>
                <br />
                <asp:Label ID="lbl_description" runat="server" Text="Description: " Font-Bold="true" /><%#Eval("description") %>
                <br />
                <asp:Label ID="lbl_qualifications" runat="server" Text="Qualifications: " Font-Bold="true" /><%#Eval("qualifications") %>
                <br />
                <asp:Label ID="lbl_salary" runat="server" Text="Salary: " Font-Bold="true" /><%#Eval("salary") %>
                <br />
                <asp:Label ID="lbl_deadline" runat="server" Text="Deadline: " Font-Bold="true" /><%#Eval("deadline", "{0:dd/MM/yyyy}")%>
                <br />
                <br />
                <asp:Button ID="lnk_apply" runat="server" Text="Apply to Job" OnClick="subApply" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

