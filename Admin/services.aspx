<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="Admin_services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">

     <div>
        <asp:ScriptManager ID="scm" runat="server" />
        <br />
        <asp:Label ID="lbl_message" runat="server" />
        <br />
        <table>
            <tbody>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Date</th>
                    <th>INSERT</th>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txt_title" runat="server" TextMode="MultiLine" /></td>
                    <td><asp:TextBox ID="txt_desc" runat="server" TextMode="MultiLine" /></td>
                    <td><asp:TextBox ID="txt_date" runat="server"  /></td>
                    <AJAX:CalendarExtender ID="ex_cal" runat="server" Format="dd/MMMM/yy"  TargetControlID="txt_date" />
                    <td><asp:Button ID="txt_submit" runat="server" Text="Submit" OnClick="SubSubmit" /></td>
                  
                </tr>
            </tbody>
        </table>
    <%--????????????????????LISTVIEW???????????????????--%>
        <br />
        <asp:ListView ID="lv_services" runat="server" DataKeyNames="service_id" ItemPlaceholderID="template_holder"
            OnItemEditing="lv_services_ItemEditing" OnItemCanceling="lv_services_ItemCanceling" OnItemDeleting="lv_services_ItemDeleting"
             OnItemUpdating="lv_services_ItemUpdating">
            <LayoutTemplate>
                <table style="border-color: Silver; border-collapse: collapse" border="1" >
                    <tbody>
                        <tr style="background-color:Silver;">
                            <th>Title</th>
                            <th>Decription</th>
                            <th>Date</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                        <asp:PlaceHolder ID="template_holder"  runat="server"></asp:PlaceHolder>
                    
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <asp:hiddenField ID="hdf_service" runat="server" value='<%#Eval ("service_id") %>' /> 
                    <td><asp:Label ID="lbl_title" runat="server" Text='<%#Eval ("title") %>' /></td>
                    <td><asp:Label ID="lbl_desc" runat="server" Text='<%#Eval ("description") %>' /></td>                    
                    <td><asp:Label ID="lbl_date" runat="server" Text='<%#Eval ("date","{0:dd/MM/yyyy}") %>' /></td>
                    <td><asp:Button ID="btn_edit" runat="server" Text="EDIT" CommandName="Edit" /></td>
                    <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure?');" /></td>
                </tr>
            </ItemTemplate>
            
             <EditItemTemplate>
                 <tr>
                     <td> <%--style="width: 150px"--%>
                         <asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval ("service_id")%>' />
                       <asp:TextBox ID="txt_titleU" runat="server" Text='<%#Bind ("title")%>' Width="140px" MaxLength="15" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_titleU"
                         ErrorMessage="Short Name is a required field." Text="*" ForeColor="White" ValidationGroup="Edit">
                        </asp:RequiredFieldValidator>     
                     </td>

                    <td> <%--style="width: 125px">--%>
                        <asp:TextBox ID="txt_descU" runat="server" TextMode="MultiLine" Text='<%#Bind ("description") %>' Width="215px" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_descU"
                         ErrorMessage="Long Name is a required field." Text="*" ForeColor="White" ValidationGroup="Edit">
                         </asp:RequiredFieldValidator>
                    </td>

                  <td> <%--style="width: 165px">--%>
                      <asp:Textbox ID="txt_dateU" runat="server"  Text='<%#Bind ("date","{0:dd/MM/yyyy}") %>' /> 
                      <AJAX:CalendarExtender ID="Ext_celU" runat="server" Format="dd/MM/yy"  TargetControlID="txt_dateU" />       
                  </td>

                  <td> <%--style="width: 240px">--%>
                      <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" ValidationGroup="Edit" />
                 </td>
                  <td>
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                  </td>
            </tr>

         </EditItemTemplate>
        </asp:ListView>
        <br />
        <asp:Label ID="test" runat="server" />
        <br />




        <asp:DataPager runat="server" ID="ItemDataPager" PageSize="10" PagedControlID="lv_services">
            <Fields>
              <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" ShowPreviousPageButton="true"
                            ShowLastPageButton="true" ShowNextPageButton ="true"/>
                <asp:TemplatePagerField>
                        <PagerTemplate>
                            <b>
                            showing
                                <asp:Label runat="server" ID="CurrentPageLabel" Text="<%# Container.StartRowIndex %>" />
                                to
                                <asp:Label runat="server" ID="TotalPagesLabel" Text="<%# Container.StartRowIndex+Container.PageSize %>" />
                                ( of
                                <asp:Label runat="server" ID="TotalItemsLabel" Text="<%# Container.TotalRowCount%>" />
                                records)
                            <br />
                            </b>
                        </PagerTemplate>
                </asp:TemplatePagerField>
 
             </Fields>
        </asp:DataPager>


        <br />
    </div>


</asp:Content>

