<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true"
    CodeFile="adminGreetingCard.aspx.cs" Inherits="Admin_Default" %>

<%-- Anja's Admin Feature for the Greeting Card Maker --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" runat="Server">
    <div style="width: 40em; margin: 1em auto;">
        <h1>
            Add A New Image</h1>
        <table style="width: 25em;">
            <tr>
                <td>
                    <asp:Label ID="lbl_newupload" runat="server" Text="Select an Image: " />
                </td>
                <td>
                    <asp:FileUpload ID="Uploader" runat="server" Height="24px" Width="272px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_namenew" runat="server" Text="Name the Image: " />
                </td>
                <td>
                    <asp:TextBox ID="txtNameI" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" CommandName="Insert" OnCommand="subAdmin"
                        Text="Add" OnClick="cmdUpload_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblInfo" runat="server" />
        <asp:GridView ID="rpt_imgs" CellPadding="3" Width="35em" runat="server" AutoGenerateColumns="false"
            Font-Names="Arial" RowStyle-BackColor="#F0F8FF" HeaderStyle-BackColor="#5D8AA8"
            ShowFooter="true" OnRowEditing="EditCustomer" DataKeyNames="id" OnRowUpdating="UpdateCustomer"
            OnRowCancelingEdit="CancelEdit">
            <Columns>
                <asp:TemplateField ItemStyle-Width="30px" HeaderText="Image ID">
                    <ItemTemplate>
                        <asp:Label ID="lblImageID" runat="server" Text='<%# Eval("id")%>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:HiddenField ID="hdfID" Value='<%#Eval("id") %>' runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="8em" HeaderText="Image Link">
                    <ItemTemplate>
                        <asp:Label ID="lblSrc" runat="server" Text='<%# Eval("src")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:FileUpload ID="UploaderE" runat="server" Height="2em" Width="10em" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="12em" HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("name")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="6em" HeaderText="Option">
                    <ItemTemplate>
                        <asp:Button ID="lnkRemove" runat="server" OnClientClick="return confirm('Do you want to delete?')"
                            Text="Delete" CommandArgument='<%#Eval("id") %>' OnClick="DeleteCustomer" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <%--  <asp:CommandField ShowDeleteButton="True"  />--%>
            </Columns>
            <AlternatingRowStyle BackColor="#FFFfFf" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cph_main" runat="Server">
</asp:Content>--%>
