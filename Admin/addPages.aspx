<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="addPages.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
<asp:Label ID="lbl_message" runat="server" />
        <asp:Label ID="lbl_insert" runat="server" Text="Insert a new Page" />
        <br />
     <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_subjectidI" runat="server" Text="Category" AssociatedControlID="ddl_subject" />
                </td>
                <td>
                    <asp:DropDownList ID="ddl_subject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" />
                </td>
                <!--<asp:TextBox ID="txt_subjectidI" runat="server" />-->
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_menunameI" runat="server" Text="Menu Title" AssociatedControlID="txt_menunameI" />
                </td>
                <td>
                    <asp:TextBox ID="txt_menunameI" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_titleI" runat="server" Text="Page Title " AssociatedControlID="txt_titleI" />
                </td>
                <td>
                    <asp:TextBox ID="txt_titleI" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_pagecontentI" runat="server" Text="Content" AssociatedControlID="txt_pagecontentI" />
                </td>
                <td>
                    <asp:TextBox ID="txt_pagecontentI" TextMode="MultiLine" Rows="20" Columns="80" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_insert" runat="server" Text="Insert" CommandName="Insert" OnCommand="subAdmin" />
                </td>
            </tr>
        </table>
</asp:Content>

