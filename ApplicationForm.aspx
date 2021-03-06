﻿<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="ApplicationForm.aspx.cs" Inherits="subPage1" %>

<%-- Access exposed elements from the master page--%>
<%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">
</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">
    <div>
        <%-- Job title --%>
        <asp:Repeater ID="rpt_jobtitle" runat="server">
            <ItemTemplate>
                <asp:Label ID="lbl_jobtitle" runat="server" Text='<%#"Job Application for: "+ Eval("title") %>'
                    Font-Bold="true" />
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:Panel ID="pnl_appform" runat="server">
            <asp:Label ID="lbl_info" runat="server" Text="Please fill out the form below to apply for this job opportunity." />
            <br />
            <br />
            <asp:Label ID="lbl_required" runat="server" Text="* = Required" ForeColor="Maroon" />
            <br /><br />
            <%--Name--%>
            <asp:Label ID="lbl_name" runat="server" Text="*Name: " AssociatedControlID="txt_name" />
            <br />
            <asp:TextBox ID="txt_name" runat="server" CssClass="textbox" />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_name" runat="server" Text="Empty value" ErrorMessage="Please enter your name."
                ControlToValidate="txt_name" Display="Dynamic" SetFocusOnError="true" ValidationGroup="app_form" />
            <%-- checking if value entered is text format  --%>
            <asp:RegularExpressionValidator ID="rev_name" runat="server" Text="Invalid name"
                ErrorMessage="Please enter your name correctly." ControlToValidate="txt_name"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"
                ValidationGroup="app_form" />
            <br />
            <%--Email--%>
            <asp:Label ID="lbl_email" runat="server" Text="*Email: " AssociatedControlID="txt_email" />
            <br />
            <asp:TextBox ID="txt_email" runat="server" CssClass="textbox"  />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="Empty value" ErrorMessage="Please enter your email."
                ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="app_form" />
            <%-- checking if value entered is email format  --%>
            <asp:RegularExpressionValidator ID="rev_email" runat="server" Text="Invalid email format, Format: name@email.com"
                ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"
                ErrorMessage="Please enter a correct email address." ValidationGroup="app_form" />
            <br />
            <%--Phone Number--%>
            <asp:Label ID="lbl_number" runat="server" Text="*Phone Number: " AssociatedControlID="txt_number"
                EnableTheming="true" />
            <br />
            <asp:TextBox ID="txt_number" runat="server" CssClass="textbox"  />
            <%-- checking if empty --%>
            <asp:RequiredFieldValidator ID="rfv_number" runat="server" Text="Empty value" ErrorMessage="Please enter your phone number."
                ControlToValidate="txt_number" Display="Dynamic" SetFocusOnError="true" ValidationGroup="app_form" />
            <%-- checking if value entered is phone number format  --%>
            <asp:RegularExpressionValidator ID="rev_number" runat="server" Text="Invalid phone number, Format: ***-***-****"
                ErrorMessage="Please enter the correct phone number." ControlToValidate="txt_number"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                ValidationGroup="app_form" />
            <br />
            <%--Address--%>
            <asp:Label ID="lbl_address" runat="server" Text="Address: " AssociatedControlID="txt_address" />
            <br />
            <asp:TextBox ID="txt_address" runat="server" CssClass="textbox"  />
            <%-- checking if value entered is address format  --%>
            <asp:RegularExpressionValidator ID="rfv_address" runat="server" Text="Invalid address, Format: ### Fake Street"
                ErrorMessage="Please enter the correct address." ControlToValidate="txt_address"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="\d{1,3}.?\d{0,3}\s[a-zA-Z]{2,30}\s[a-zA-Z]{2,15}"
                ValidationGroup="app_form" />
            <br />
            <%--City--%>
            <asp:Label ID="lbl_city" runat="server" Text="City: " AssociatedControlID="txt_city" />
            <br />
            <asp:TextBox ID="txt_city" runat="server" CssClass="textbox"  />
            <%-- checking if value entered is text format  --%>
            <asp:RegularExpressionValidator ID="rev_city" runat="server" Text="Invalid city"
                ErrorMessage="Please enter the correct patient name." ControlToValidate="txt_city"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$"
                ValidationGroup="app_form" />
            <br />
            <%--Postal Code--%>
            <asp:Label ID="lbl_postalcode" runat="server" Text="Postal Code: " AssociatedControlID="txt_postalcode" />
            <br />
            <asp:TextBox ID="txt_postalcode" runat="server" CssClass="textbox"  />
            <%-- checking if value entered is postal code format  --%>
            <asp:RegularExpressionValidator ID="rfv_postalcode" runat="server" Text="Invalid postal code, Format: A1A 1A1"
                ErrorMessage="Please enter the correct postal code." ControlToValidate="txt_postalcode"
                Display="Dynamic" SetFocusOnError="true" ValidationExpression="^\d{5}-\d{4}|\d{5}|[A-Z]\d[A-Z] \d[A-Z]\d$"
                ValidationGroup="app_form" />
            <br />
            <br />
            <asp:Label ID="lbl_infomsg" runat="server" Text="For your <strong>resume</strong> please upload a .doc, .docx, or a .pdf file." />
            <br />
            <br />
            <%--Resume--%>
            <asp:Label ID="lbl_resume" runat="server" Text="*Resume: " />
            <br />
            <asp:FileUpload ID="fu_resume" runat="server" />
            <%-- checking if empty --%>
            <asp:Label ID="lbl_rfvresume" runat="server" />
            <br /><br />
            <br />
            <%-- Validation Summary for plan a visit form --%>
            <asp:ValidationSummary ID="vds_application" runat="server" HeaderText="Form Errors:"
                DisplayMode="List" ValidationGroup="app_form" />
            <br />
            <%-- Submit and Clear Buttons --%>
            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" ValidationGroup="app_form" />
            <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="subClear" />
        </asp:Panel>
        <%-- Output Label --%>
        <asp:Label ID="lbl_output" runat="server" />
    </div>
</asp:Content>
