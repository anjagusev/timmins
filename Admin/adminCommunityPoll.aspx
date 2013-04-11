<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="adminCommunityPoll.aspx.cs" Inherits="Admin_Default" %>
  <%--Default Admin Page --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">


<div>
    
    <h1><asp:Label ID="lbl_title" runat="server" Text="Hospital Patient Satisfaction Survey" /></h1>
    <br />
    <asp:Label ID="lbl_new" runat="server" Text="Insert New Question" />
    <br />
    <br />
    <asp:Label ID="lbl_questionI" runat="server" Text="Question: " />
    <br />
    <asp:TextBox ID="txt_questionI" runat="server" TextMode="MultiLine" />
    <asp:RequiredFieldValidator ID="rfv_questionI" runat="server" Text="*Required" ControlToValidate="txt_questionI" ValidationGroup="new" />
    <br />
    <asp:Button ID="btn_new" runat="server" Text="Insert" CommandName="Insert" OnCommand="Admin" ValidationGroup="new" />
    <br />
    <br />
    <asp:DropDownList ID="ddl_main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" />
    <br />
    <br />
    <asp:Label ID="lbl_message" runat="server" />
    
    <asp:Panel ID="pnl_all" runat="server" GroupingText="All Questions">
        <table cellpadding="2" cellspacing="3">
            <thead style="font-weight:bolder;background-color:#d4d4d4;">
                <tr>
                    <th><asp:Label ID="lbl_name" runat="server" Text="Poll Question" /></th>
                    <th><asp:Label ID="lbl_option" runat="server" Text="Option" /></th>
                    <th><asp:Label ID="lbl_option2" runat="server" Text="Option" /></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpt_all" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval ("question") %></td>
                            <td>
                                <asp:LinkButton ID="btn_update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval ("IDq") %>' OnCommand="Admin" />
                            </td>
                            <td>
                                <asp:LinkButton ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval ("IDq") %>' OnCommand="Admin" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnl_update" runat="server" GroupingText="Update Question">
        <table celling="2" cellspacing="3">
            <thead style="font-weight:bolder;">
                <tr>
                    <th><asp:Label ID="lbl_questionU" runat="server" Text="Question" /></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpt_update" runat="server" OnItemCommand="AdminUpDel">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval ("IDq") %>' />
                            <td><asp:TextBox ID="txt_questionU" runat="server" Text='<%#Eval ("question") %>' TextMode="MultiLine" /></td>

                            <td><asp:RequiredFieldValidator ID="rfv_questionU" runat="server" Text="*Required" ControlToValidate="txt_questionU" ValidationGroup="update" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btn_doUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="update" />
                                &nbsp;&nbsp;&nbsp
                                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnl_delete" runat="server" GroupingText="Delete Question">
        <table cellpadding="2" cellspacing="3">
            <thead style="font-weight:bolder;">
                <tr>
                    <td colspan="4" align="center" style="color:Red;">
                        <asp:Label ID="lbl_delete" runat="server" Text="Are you sure you want to delete this question?" />
                    </td>
                </tr>
                <tr>
                    <th><asp:Label ID="lbl_questionD" runat="server" Text="Question" /></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpt_delete" runat="server" OnItemCommand="AdminUpDel">
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval ("IDq") %>' />
                            <td><asp:Label ID="txt_questionD" runat="server" Text='<%#Eval ("question") %>' /></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btn_doDelete" runat="server" Text="Delete" CommandName="Delete" />
                                &nbsp;&nbsp;&nbsp
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

