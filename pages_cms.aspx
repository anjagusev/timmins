<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pages_cms.aspx.cs" Inherits="pages_cms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_message" runat="server" />
        <br />
        <br />
        <asp:Label ID="lbl_insert" runat="server" Text="Insert a new Page" />
        <br />
        <asp:Label ID="lbl_subjectidI" runat="server" Text="Subject ID" AssociatedControlID="ddl_subject" />
          <asp:DropDownList ID="ddl_subject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" />
        <!--<asp:TextBox ID="txt_subjectidI" runat="server" />-->
        <br />
        <asp:Label ID="lbl_menunameI" runat="server" Text="Menu Name" AssociatedControlID="txt_menunameI" />
        <asp:TextBox ID="txt_menunameI" runat="server" />
        <br />
        <asp:Label ID="lbl_titleI" runat="server" Text="Page Title " AssociatedControlID="txt_titleI" />
        <asp:TextBox ID="txt_titleI" runat="server" />
        <br />
        <asp:Label ID="lbl_pagecontentI" runat="server" Text="Content" AssociatedControlID="txt_pagecontentI" />
        <asp:TextBox ID="txt_pagecontentI" runat="server" />
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" CommandName="Insert" OnCommand="subAdmin" />
        <br />
        <br />
        <asp:Panel ID="pnl_all" runat="server" GroupingText="All Products">
            <table>
                <thead>
                    <tr>
                        <th>
                            <asp:Label ID="lbl_subjectid" runat="server" Text="Subject ID" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_menuname" runat="server" Text="Menu Name" />
                        </th>
                        <th>
                            <asp:Label ID="lbl_title" runat="server" Text="Title " />
                        </th>
                        <th>
                            <asp:Label ID="lbl_pagecontent" runat="server" Text="Page Content" />
                        </th>
                        <th>
                            Option
                        </th>
                        <th>
                            Option
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_all" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("subject_id")%>
                                </td>
                                <td>
                                    <%#Eval("menu_name")%>
                                </td>
                                <td>
                                    <%#Eval("title")%>
                                </td>
                                <td>
                                    <%#Eval("page_content")%>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lkb_update" runat="server" Text="Update" CommandName="Update"
                                        CommandArgument='<%#Eval("id")%>' OnCommand="subAdmin" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" CommandName="Delete"
                                        CommandArgument='<%#Eval("id")%>' OnCommand="subAdmin" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnl_update" runat="server" GroupingText="Update Page">
            <table>
                <thead>
                    <tr>
                        <th class="style1">
                            <asp:Label ID="lbl_subjectidU" runat="server" Text="Subject ID " />
                        </th>
                        <th class="style1">
                            <asp:Label ID="lbl_menunameU" runat="server" Text="Menu Name" />
                        </th>
                        <th class="style1">
                            <asp:Label ID="lbl_titleU" runat="server" Text="Title" />
                        </th>
                        <th class="style1">
                            <asp:Label ID="lbl_pagecontentU" runat="server" Text="Page Content" />
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="rpt_update" runat="server" OnItemDataBound="repeater_ItemDataBound" OnItemCommand="subUpDel">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("id") %>' />
                            <td>
                            
           <asp:DropDownList ID="ddl_subjectU" runat="server" DataSourceID="SubjectClass" 
                    DataTextField="menu_name" DataValueField="id" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" EnableViewState="false">
                   
                </asp:DropDownList>
               <!-- <asp:LinqDataSource ID="SubjectClass" runat="server" 
                    ContextTypeName="subjectDataContext" EntityTypeName="" 
                    Select="new (id, menu_name)" TableName="subjects">
                </asp:LinqDataSource>-->
                              
                            </td>
                            <td>
                                <asp:TextBox ID="txt_menunameU" runat="server" Text='<%#Eval("menu_name") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_titleU" runat="server" Text='<%#Eval("title") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="txt_pagecontentU" runat="server" Text='<%#Eval("page_content")%>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btn_doUpdate" runat="server" Text="Update" CommandName="Update" />
                                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
               
            </table>
        </asp:Panel>
        <asp:Panel ID="pnl_delete" runat="server" GroupingText="Delete Page">
            <table>
                <thead>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_delete" runat="server" Text="Are you sure yo uwant to delete this item?" />
                        </td>
                    </tr>
                    <tr>
                    <th>
                    <asp:Label ID="lbl_subjectidD" runat="server" Text="Subject ID" /></th>
                    <th><asp:Label ID="lbl_menunameD" runat="server" Text="Menu Name " /></th>
                    <th><asp:Label ID="lbl_titleD" runat="server" Text="Title " /></th>
                    <th><asp:Label ID="lbl_pagecontentD" runat="server" Text="Page Content " /></th>
                    </tr>
                    </thead>
                    <tbody>
                    <asp:Repeater ID="rpt_delete" runat="server" OnItemCommand="subUpDel">
                    <ItemTemplate>
                    <tr>
                    <asp:HiddenField ID="hdf_if" runat="server" Value='<%#Eval("id") %>' />
                    <td>
                    <asp:Label ID="txt_subjectidDe" runat="server" Text='<%#Eval("subject_id") %>' />
                    </td><td>
                    <asp:Label ID="txt_menunameDe" runat="server" Text='<%#Eval("menu_name") %>' /></td>
                    <td><asp:Label ID="txt_titleDe" runat="server" Text='<%#Eval("title") %>' /></td>
                     <td><asp:Label ID="txt_pagecontentDe" runat="server" Text='<%#Eval("page_content") %>' /></td>
                    </tr>
                    </ItemTemplate>
                    
                    </asp:Repeater></tbody>
                   
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
