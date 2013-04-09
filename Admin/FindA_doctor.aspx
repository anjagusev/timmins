<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="FindA_doctor.aspx.cs" Inherits="Admin_FindA_doctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
    <div>
        
         <asp:Label ID="lbl_message" runat="server" />
        
        <%--This insert is for Specialty table--%>
        <br />
        <asp:Label ID="lbl_specialtyI" runat="server" Text="Enter specialty" AssociatedControlID="txt_specialtyI" />
        <asp:TextBox ID="txt_specialtyI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_specialty" runat="server" ControlToValidate="txt_specialtyI" SetFocusOnError="true" Display="Dynamic" ValidationGroup="req" >*</asp:RequiredFieldValidator>
         <asp:Button ID="Button1" runat="server" Text="Insert" onClick="subInsertInSP" ValidationGroup="req" />
        <br />
        <br />
        <asp:Label ID="note" runat="server" Text="<strong><h2>Note</h2> You can only delete specialty if it is not used in doctor's data table</strong>" />
         <br />
       <asp:Repeater ID="all_rpt" runat="server" OnItemCommand="subAdminForSP">
           <HeaderTemplate>
                <table cellpadding="3" width="30%"   border="1" >
                    <tbody >
                        <tr >
                            <th>Specialty</th>
                        </tr>
                  
           </HeaderTemplate>
               <ItemTemplate >     
           
                            <tr>
                                <td >
                                    <asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval("specialty_id") %>' />
                                    <asp:TextBox ID="txt_specialtyE" runat="server" Text='<%#Bind("specialty") %>' TextMode="MultiLine"  />
                                </td>
                         
                                <td>
                                    <asp:LinkButton ID="lkb_update" runat="server" Text="Update" CommandName="subUpdate"  />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" CommandName="subDelete" />  
                                </td>
                            </tr>
               
                </ItemTemplate>
          
            <FooterTemplate>
                  </tbody>
                </table>
            </FooterTemplate>
           </asp:Repeater>
          
       
        
        <br />
        <asp:Label ID="lbl_insert" runat="server" Text="Insert New Doctor's Information" Font-Bold="true" />
        <br />
         <asp:Label ID="lbl_sp" runat="server" Text="Select specialty" />
        <asp:DropDownList ID="ddl_sp" runat="server" />
        <br />
        <br />
        <asp:Label ID="lbl_fnameI" runat="server" Text="First Name: " AssociatedControlID="txt_fnameI" />
        <asp:TextBox ID="txt_fnameI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_fnameI" runat="server" ControlToValidate="txt_fnameI" SetFocusOnError="true" 
         Display="Dynamic" ErrorMessage="Required" ValidationGroup="required">*</asp:RequiredFieldValidator>

        <br />

        <asp:Label ID="lbl_lnameI" runat="server" Text="Last Name" AssociatedControlID="txt_lnameI" />
        <asp:TextBox ID="txt_lnameI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_lnameI" runat="server" ControlToValidate="txt_lnameI" SetFocusOnError="true" 
        Display="Dynamic" ErrorMessage="Required" ValidationGroup="required">*</asp:RequiredFieldValidator>


        <br />

        <asp:Label ID="lbl_genderI" runat="server" Text="Gender" AssociatedControlID="txt_genderI" />
        <asp:TextBox ID="txt_genderI" runat="server" />
         <asp:RequiredFieldValidator ID="rfv_genderI" runat="server" ControlToValidate="txt_genderI" SetFocusOnError="true" 
        Display="Dynamic" ErrorMessage="Required" ValidationGroup="required">*</asp:RequiredFieldValidator>

        <br />
         <asp:Label ID="lbl_email" runat="server" Text="Email:" AssociatedControlID="txt_emailI" />
        <asp:TextBox ID="txt_emailI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="txt_emailI" SetFocusOnError="true" Display="Dynamic" ErrorMessage="E-mail is required" ValidationGroup="required">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="rev_email" runat="server" ControlToValidate="txt_emailI" ValidationGroup="required" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,6}$" >*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lbl_bio1" runat="server" Text="Bio:" /><br />
        <asp:TextBox ID="txt_bioI" Columns="40" Rows="5" TextMode="MultiLine" runat="server" />

        <br />
        
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" onClick="subInsertInDC" ValidationGroup="required"  />
        <br />
        


        <%--This dropdown is to upadte doctor' description and admin can select doctors by specialty--%>
         <asp:DropDownList ID="ddl_main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" />
        <br />
         <asp:ListView ID="ltv_main" runat="server" OnItemCommand="subAdminForDC">
            <LayoutTemplate>
                <table cellpadding="2" width="50%" border="1" cellspacing="3">
                     <tbody>
                        <tr>
                            <th>First Name</th>
                            <th>Last name</th>
                            <th>Gender</th>
                            <th>Email</th>
                            <th>Bio</th>
                        </tr>
                   
                   
                       <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdf_id_E" runat="server" Value='<%#Eval("specialty_id") %>' />
                        <asp:TextBox ID="txt_fnameE" runat="server" Text='<%#Bind("first_name") %>'  />

                    </td>
                    <td>
                        <asp:TextBox ID="txt_lnameE" runat="server" Text='<%#Bind("last_name") %>'  />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_genderE" runat="server" Text='<%#Bind("Gender") %>'  />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_emailE" runat="server" Text='<%#Bind("email") %>'  />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_bioE" runat="server" Text='<%#Bind("Bio") %>' TextMode="MultiLine" Columns="40" Rows="4" />
                    </td>
                  
                    <td>
                        <asp:LinkButton ID="lkb_update" runat="server" Text="Update" CommandName="subUpdate" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdf_doc" runat="server" Value='<%# Eval("doctor_id") %>' />
                        <asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" CommandName="subDelete" /> 
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>




    </div>

</asp:Content>

