<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="Donations.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
 <div>
<%-- 
    Donation Feature by Anja Gusev--
    Donations Gridview On Admin
    
--%>
      <asp:GridView ID="grd_donations" runat="server" AutoGenerateColumns="False" CellPadding="10" DataKeyNames="id"
            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" AllowPaging="True">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <PagerSettings Mode="NextPrevious" PreviousPageText="< Back" NextPageText="Forward >" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />            
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
              <%#Eval("id") %>
            </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Surname">
            <ItemTemplate>
              <%#Eval("lName") %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
            <ItemTemplate>
              <%#Eval("fName") %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
            <ItemTemplate>
              <%#Eval("email") %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
              $<%#Eval("amount") %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Donation Date">
            <ItemTemplate>
              <%#Eval("date") %>
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>



  <%--  <asp:GridView ID="grd_donations" DataKeyNames="id" CellSpacing="6" CellPadding="6" runat="server">
    <asp:PagerStyle Horizontal
    </asp:GridView>--%>
    
    </div>
</asp:Content>

