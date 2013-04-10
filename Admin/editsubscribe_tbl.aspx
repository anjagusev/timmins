<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="editsubscribe_tbl.aspx.cs" Inherits="Admin_editsubscribe_tbl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
    <%--have to fix styling--%>
    <div>
        <asp:Label ID="lbl_message" runat="server" />
   
                <table cellpadding="6">
                    <tr>
                        <td>&nbsp;</td>
                        <tb><asp:Label id="lbl_header" runat="server" text="Insert New subscribe" /></tb>
                    </tr>
                    <tr>
                        <td>
                            <strong><asp:label ID="lbl_nameI" runat="server" Text="Name" /></strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_nameI" runat="server" />
                            <asp:RequiredFieldValidator ID="rfv_nameI" runat="server" Text="Required" ControlToValidate="txt_nameI"
                                validationGroup="Insert" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong><asp:label ID="lbl_emialI" runat="server" Text="email" /></strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_emailI" runat="server" />
                            <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="Required" ControlToValidate="txt_emailI"
                                validationGroup="Insert" />
                        </td>
                        
                    </tr>
                    <tr>
                    <td><asp:Label ID="lbl_reaI" runat="server" Text="Comment" /></td>
                    <td><asp:TextBox ID="txt_reaI" runat="server" /></td>
                    </tr>
                    <tr>
                            <td>
                                <strong><asp:label ID="lbl_validI" runat="server" Text="Validation" /></strong>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_list" runat="server">
                                
                                        <asp:ListItem value="" Text="Select" />
                                        <asp:ListItem value="no" Text="NO" />
                                        <asp:ListItem value="yes" Text="YES" />
                                </asp:DropDownList>
                                <asp:Button ID="btn_insert" runat="server" Text="insert" OnClick="subInsert" />
                            </td>
                    </tr>
                    
                       
                </table>


        <%--?????????????????????????? DATAList Update and DELETE??????????????????--%>

        <asp:DataList ID="dt_main" runat="server" RepeatColumns="2" CellSpacing="2" GridLines="Both" DataKeyField="subscriber_id"
            OnEditCommand="subShowEditTemplate" OrnUpdateCommand="subCommitUpdate" OnDeleteCommand="subCommitDelete" OnCancelCommand="subCancel">
            <ItemTemplate>
                <table>
                <tbody>
                <tr>
                <th>Name|</th>
                <th>Email|</th>
                <th>Validation</th>
                <th>Comment</th>
                </tr>
                    <tr>
                        
                        <asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval("subscriber_id") %>' /> 
                     
                        <td><asp:Label ID="lbl_name2" runat="server" Text='<%#Eval("name") %>' />|</td>
                   
                        <td><asp:Label ID="lbl_emial2" runat="server" Text='<%#Eval("email") %>' />|</td>
                   
                        <td><asp:Label ID="lbl_valid2" runat="server" Text='<%#Eval("valid") %>' /></td>
                        <td><asp:Label ID="lbl_reason" runat="server" Text='<%#Eval("reasonOfunsub") %>' /></td>
                 
               
                        <td><asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="Edit" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Confirm Delete?');" /></td>
                    </tr>
                    </tbody>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table>
                    <tr>
                        <td><asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval("subscriber_id") %>' /></td>
                    
                        <td><asp:Label ID="lbl_nameE" runat="server" Text="name" /></td>
                        <td><asp:TextBox ID="txt_nameE" runat="server" Text='<%# Bind("name") %>' /></td>
                   
                        <td><asp:Label ID="lbl_emailE" runat="server" Text="email" /></td>
                        <td><asp:TextBox ID="txt_emailE" runat="server" Text='<%#Bind("email") %>' /></td>
                    
                        <td><asp:Label ID="lbl_validE" runat="server" Text="Validate" /></td>
                        <td><asp:label ID="lbl_valid" runat="server" Text='<%#Bind("valid") %>' /></td>

                        <td><asp:DropDownList ID="ddl_listE" runat="server"> 
                                    <asp:ListItem value="no" Text="NO" />
                                    <asp:ListItem value="yes" Text="YES" />
                            </asp:DropDownList>
                          <asp:Label ID="lbl_reasonE" runat="server" Text="Comment:" />
                       <asp:TextBox ID="txt_reasonE" runat="server" Text='<%#Bind("reasonOfunsub") %>' /></td>

                    </tr>
                    
                    <tr>
                        <td><asp:Button ID="btn_updateE" runat="server" Text="Update" CommandName="update" /></td>
                        <td><asp:Button ID="btn_cancelE" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" /></td>
                    </tr>
                </table>
            </EditItemTemplate>
            
                   </asp:DataList>


    </div>




</asp:Content>

