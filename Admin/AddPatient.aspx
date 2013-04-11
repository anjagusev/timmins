<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="AddPatient.aspx.cs" Inherits="Admin_Default3" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
    <div>
        <asp:Label ID="lbl_message" runat="server" />

        <table>
        <th><asp:Label ID="lbl_insert" runat="server" Text="Add Patient Info" /></th>
        <tr>
            <td><asp:Label ID="lbl_nameI" runat="server" Text="Name: " AssociatedControlID="txt_nameI" /></td>
            <td>
                <asp:TextBox ID="txt_nameI" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_nameI" runat="server" Text="*Required" ControlToValidate="txt_nameI" ValidationGroup="insert" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_emailI" runat="server" Text="Email: " AssociatedControlID="txt_emailI" /></td>
            <td>
                <asp:TextBox ID="txt_emailI" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_emailI" runat="server" Text="*Required" ControlToValidate="txt_emailI" ValidationGroup="insert" />
            </td>
        </tr>
        </table>
        <br />
        <asp:CheckBox ID="chk_newsletter" runat="server" Text="Send email to subscribers"  />
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" CommandName="Insert" OnCommand="subAdmin" ValidationGroup="insert" />
        <br />
        <asp:Label ID="sent_success" runat="server" />
        <br />
        
        <br />
        <asp:Panel ID="pnl_all" runat="server" GroupingText="All Patients">
            <table cellpadding="3" cellspacing="5">
                <thead style="font-weight:bolder;background-color:#d3d3d3;">
                    <tr>
                        <th><asp:Label ID="lbl_name" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_option" runat="server" Text="Option" /></th>
                        <th><asp:Label ID="lbl_option2" runat="server" Text="Option" /></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_all" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("name") %></td>
                                <td><asp:LinkButton ID="btn_update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("id") %>' OnCommand="subAdmin" /></td>
                                <td><asp:LinkButton ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("id") %>' OnCommand="subAdmin" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>

        <asp:Panel ID="pnl_update" runat="server" GroupingText="Update Patient Information">
            <table cellpadding="2" cellspacing="3">
                 <thead style="font-weight:bolder;">
                    <tr>
                        <th><asp:Label ID="lbl_nameU" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_emailU" runat="server" Text="Email" /></th>
                    </tr>
                 </thead>
                 <tbody>
                    <asp:Repeater ID="rpt_update" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("id") %>' />
                                <td><asp:TextBox ID="txt_nameU" runat="server" Text='<%#Eval("name") %>' /></td>
                                <td><asp:TextBox ID="txt_emailU" runat="server" Text='<%#Eval("email") %>' />
                            </tr>
                            <tr>
                                <td><asp:RequiredFieldValidator ID="rfv_nameU" runat="server" Text="*Required" ControlToValidate="txt_nameU" ValidationGroup="update" /></td>
                                <td><asp:RequiredFieldValidator ID="rfv_emailU" runat="server" Text="*Required" ControlToValidate="txt_emailU" ValidationGroup="update" /></td>
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
                            <asp:Label ID="lbl_delete" runat="server" Text="Are you sure you want to delete this patient from the database?" />
                        </td>
                    </tr>
                    <tr>
                        <th><asp:Label ID="lbl_nameD" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_emailD" runat="server" Text="Email" /></th>
                    </tr>
                 </thead>
                 <tbody>
                    <asp:Repeater ID="rpt_delete" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("id") %>' />
                                <td><asp:TextBox ID="txt_nameDe" runat="server" Text='<%#Eval("name") %>' /></td>
                                <td><asp:TextBox ID="txt_emailDe" runat="server" Text='<%#Eval("email") %>' /></td>
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

