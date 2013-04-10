<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="adminImageGallery.aspx.cs" Inherits="Admin_Default" %>
  <%--Default Admin Page --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
<h1>Image Gallery administration</h1>
<br />
<br />
<asp:GridView ID="rpt_imgs" runat="server" Width="650px" AutoGenerateColumns="false"
        Font-Names="Arial" Font-Size="14pt" HeaderStyle-BackColor="lightblue"
        ShowFooter="true" OnRowEditing="EditCustomer" OnRowUpdating="UpdateCustomer"
        OnRowCancelingEdit="CancelEdit" PageSize="10">
        <Columns>
            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Image ID">
                <ItemTemplate>
                    <asp:Label ID="lblImageID" runat="server" Text='<%# Eval("Id")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:HiddenField ID="hdfID" Value='<%#Eval("Id") %>' runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="200px" HeaderText="Image path">
                <ItemTemplate>
                    <asp:Label ID="lblMainImage" runat="server" Text='<%# Eval("MainImage")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtMainImage" runat="server" Text='<%# Eval("MainImage")%>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="250px" HeaderText="Name of the image">
                <ItemTemplate>
                    <asp:Label ID="lblThumbNail" runat="server" Text='<%# Eval("ThumbNail")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtThumbNail" runat="server" Text='<%# Eval("ThumbNail")%>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="lnkRemove" runat="server" OnClientClick="return confirm('Do you want to delete the image?')"
                        Text="Delete" CommandArgument='<%#Eval("Id") %>' OnClick="DeleteCustomer" />
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            
        </Columns>
        <AlternatingRowStyle BackColor="#b0dce4" />
    </asp:GridView>
    <asp:FileUpload ID="Uploader" runat="server" Height="24px" />
    <br />
    <asp:Label ID="lblThumbNailI" runat="server" Text="Name your file" />
    <asp:TextBox ID="txtThumbNailI" runat="server"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" CommandName="Insert" OnCommand="subAdmin"
        Text="Add" OnClick="cmdUpload_Click" />
        <br />
    <asp:Label ID="lblInfo" runat="server" />


</asp:Content>

