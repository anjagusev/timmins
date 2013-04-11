<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true"
    CodeFile="adminGreetingCard.aspx.cs" Inherits="Admin_Default" %>

<%-- Anja's Admin Feature for the Greeting Card Maker --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" runat="Server">
<div style="width:55em; margin:0 auto;">
    <asp:GridView ID="rpt_imgs" runat="server" Width="550px" AutoGenerateColumns="false"
        Font-Names="Arial" Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B" HeaderStyle-BackColor="green"
        ShowFooter="true" OnRowEditing="EditCustomer" DataKeyNames="id" OnRowUpdating="UpdateCustomer"
        OnRowCancelingEdit="CancelEdit" PageSize="10">
        <Columns>
            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Image ID">
                <ItemTemplate>
                    <asp:Label ID="lblImageID" runat="server" Text='<%# Eval("id")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:HiddenField ID="hdfID" Value='<%#Eval("id") %>' runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="100px" HeaderText="Src">
                <ItemTemplate>
                    <asp:Label ID="lblSrc" runat="server" Text='<%# Eval("src")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="UploaderE" runat="server" Height="24px" Width="472px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <%--<asp:TextBox ID="txtSrc" runat="server"></asp:TextBox>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="150px" HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("name")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("name")%>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <%-- <asp:TextBox ID="txtName" runat="server"></asp:TextBox>--%>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="lnkRemove" runat="server" OnClientClick="return confirm('Do you want to delete?')"
                        Text="Delete" CommandArgument='<%#Eval("id") %>' OnClick="DeleteCustomer" />
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField>
                <EditItemTemplate>
                </EditItemTemplate>
            </asp:TemplateField>
            <%--  <asp:CommandField ShowDeleteButton="True"  />--%>
        </Columns>
        <AlternatingRowStyle BackColor="#C2D69B" />
    </asp:GridView>
    <br />
    <table>
        <tr>
            <td>
                <asp:FileUpload ID="Uploader" runat="server" Height="24px" Width="272px" />
            </td>
            <td>
                <asp:TextBox ID="txtNameI" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" CommandName="Insert" OnCommand="subAdmin"
                    Text="Add" OnClick="cmdUpload_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblInfo" runat="server" />
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cph_main" runat="Server">
</asp:Content>--%>
