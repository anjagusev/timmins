﻿<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="JobPostings.aspx.cs" Inherits="subPage1" %>

<%-- Access exposed elements from the master page--%>
<%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">
</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
    <%--Search Bar--%>
    <asp:TextBox ID="txt_search" runat="server" Text="" placeholder="Search Job Title" />
    <%-- checking if value entered is text format  --%>
    <asp:RegularExpressionValidator ID="rev_search" runat="server" Text="Invalid search keywords"
        ErrorMessage="Please enter your search correctly." ControlToValidate="txt_search"
        Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$" />
    <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="subSearch" />
    <asp:LinkButton ID="lnk_advancedsearch" runat="server" PostBackUrl="~/JobPostingsAdvancedSearch.aspx"
        Text="Advanced Search" />
    <br />
    <br />
    <br />
    <%-- Sort by Department --%>
    <asp:Label ID="lbl_department" runat="server" Text="Filter by Department" />
    <asp:DropDownList ID="ddl_department" runat="server" OnSelectedIndexChanged="subDDLChange"
        AutoPostBack="true" CausesValidation="true">
        <asp:ListItem></asp:ListItem>
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
    <asp:LinkButton ID="lnk_viewall" runat="server" Text="View All Jobs" OnClick="subViewAll" />
    <br />
    <br />
    <%-- Grid view of Job Postings --%>
    <asp:GridView ID="grv_jobpostings" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="SteelBlue"
        CellPadding="5">
        <Columns>
            <%--Title Column--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:LinkButton ID="lnk_titleH" runat="server" Text="Job Title" OnCommand="subSort"
                        CommandName="title" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnk_title" runat="server" Text='<%#Eval("title")%>' PostBackUrl='<%#"DetailedJobPosting.aspx?id="+Eval("jobposting_id") %>' />
                    <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("jobposting_id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--Hours Column--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:LinkButton ID="lnk_hoursH" runat="server" Text="Hours" OnCommand="subSort" CommandName="hours" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_hours" runat="server" Text='<%#Eval("hours")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--Department Column--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:LinkButton ID="lnk_departmentH" runat="server" Text="Department" OnCommand="subSort"
                        CommandName="department" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_department" runat="server" Text='<%#Eval("department")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--Date Posted Column--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:LinkButton ID="lnk_datepostedH" runat="server" Text="Date Posted" OnCommand="subSort"
                        CommandName="dateposted" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_dateposted" runat="server" Text='<%#Eval("date_posted", "{0:dd/MM/yyyy}")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--Deadline Column--%>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:LinkButton ID="lnk_deadlineH" runat="server" Text="Deadline" OnCommand="subSort"
                        CommandName="deadline" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_deadline" runat="server" Text='<%#Eval("deadline", "{0:dd/MM/yyyy}")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h3>
        <asp:Label ID="lbl_error" runat="server" /></h3>
    </div>
</asp:Content>
