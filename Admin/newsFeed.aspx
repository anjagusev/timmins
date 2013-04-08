<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="newsFeed.aspx.cs" Inherits="Admin_newsFeed" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
    
    <div>
        
        
        <asp:Label ID="lbl_message" runat="server" />

        <table>
        <th><asp:Label ID="lbl_insert" runat="server" Text="Insert New Product" /></th>
        <tr>
            <td><asp:Label ID="lbl_headI" runat="server" Text="Heading: " AssociatedControlID="txt_headI" /></td>
            <td>
                <asp:TextBox ID="txt_headI" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_headI" runat="server" Text="*Required" ControlToValidate="txt_headI" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_introI" runat="server" Text="Intro: " AssociatedControlID="txt_introI" /></td>
            <td>
                <asp:TextBox ID="txt_introI" runat="server" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfv_introI" runat="server" Text="*Required" ControlToValidate="txt_introI" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_paraI" runat="server" Text="Paragraph: " AssociatedControlID="txt_paraI" /></td>
            <td>
                <asp:TextBox ID="txt_paraI" runat="server" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="rfv_paraI" runat="server" ControlToValidate="txt_paraI" Text="*Required" Display="Dynamic" ValidationGroup="insert" />
            </td>
        </tr>
        </table>
        <br /><br />
        
        
        <asp:Button ID="btn_insert" runat="server" Text="Insert" CommandName="Insert" OnCommand="subAdmin" ValidationGroup="insert" />
        <br /><br />
        <asp:Panel ID="pnl_all" runat="server" GroupingText="All Products">
            <table cellpadding="3" cellspacing="5">
                <thead style="font-weight:bolder;background-color:#d3d3d3;">
                    <tr>
                        <th><asp:Label ID="lbl_heading" runat="server" Text="Heading" /></th>
                        <th><asp:Label ID="lbl_option" runat="server" Text="Option" /></th>
                        <th><asp:Label ID="lbl_option2" runat="server" Text="Option" /></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_all" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("heading") %></td>
                                <td><asp:LinkButton ID="btn_update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("id") %>' OnCommand="subAdmin" /></td>
                                <td><asp:LinkButton ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' OnCommand="subAdmin" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>

        <asp:Panel ID="pnl_update" runat="server" GroupingText="Update Product">
            <table cellpadding="2" cellspacing="3">
                 <thead style="font-weight:bolder;">
                    <tr>
                        <th><asp:Label ID="lbl_headingU" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_introU" runat="server" Text="Description" /></th>
                        <th><asp:Label ID="lbl_paraU" runat="server" Text="Price" /></th>
                    </tr>
                 </thead>
                 <tbody>
                    <asp:Repeater ID="rpt_update" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("id") %>' />
                                <td><asp:TextBox ID="txt_headingU" runat="server" Text='<%#Eval("heading") %>' /></td>
                                <td><asp:TextBox ID="txt_introU" runat="server" Text='<%#Eval("intro") %>' TextMode="MultiLine" /></td>
                                <td><asp:TextBox ID="txt_paraU" runat="server" Text='<%#Eval("paragraph") %>' /></td>
                            </tr>
                            <tr>
                                <td><asp:RequiredFieldValidator ID="rfv_headingU" runat="server" Text="*Required" ControlToValidate="txt_headingU" ValidationGroup="update" /></td>
                                <td><asp:RequiredFieldValidator ID="rfv_introU" runat="server" Text="*Required" ControlToValidate="txt_introU" ValidationGroup="update" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfv_paraU" runat="server" Text="*Required" ControlToValidate="txt_paraU" ValidationGroup="update" Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btn_doUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="update" Display="Dynamic" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 </tbody>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnl_delete" runat="server" GroupingText="Delete Product">
            <table cellpadding="2" cellspacing="3">
                 <thead style="font-weight:bolder;">
                    <tr>
                        <td colspan="4" align="center" style="color:Red;">
                            <asp:Label ID="lbl_delete" runat="server" Text="Are you sure you want to delete this item?" />
                        </td>
                    </tr>
                    <tr>
                        <th><asp:Label ID="lbl_headD" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_introD" runat="server" Text="Description" /></th>
                        <th><asp:Label ID="lbl_paraD" runat="server" Text="Price" /></th>
                    </tr>
                 </thead>
                 <tbody>
                    <asp:Repeater ID="rpt_delete" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("id") %>' />
                                <td><asp:TextBox ID="txt_proHeadDe" runat="server" Text='<%#Eval("heading") %>' /></td>
                                <td><asp:TextBox ID="txt_proIntroDe" runat="server" Text='<%#Eval("intro") %>' /></td>
                                <td><asp:TextBox ID="txt_proParaDe" runat="server" Text='<%#Eval("paragraph") %>' /></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btn_doDelete" runat="server" Text="Delete" CommandName="Delete" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_doCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                 </tbody>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main" Runat="Server">
</asp:Content>

