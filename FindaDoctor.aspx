<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindaDoctor.aspx.cs" Inherits="FindaDoctor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:label ID="lbl_Sspecialty" runat="server" Text="Search by specialty:" />
        <br />
        <asp:Label ID="lbl_speciality" runat="server" Text="Select Specialty: " />
        <asp:DropDownList ID="ddl_sp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" >
        <asp:ListItem Text="select Speciality" Value="0" />    
        </asp:DropDownList>
        <br />
        <br />
        <asp:label ID="lbl_Sname" runat="server" Text="Search by Name" />
        <br />
        <asp:Label ID="lbl_fname" runat="server" Text="Enter First Name: " AssociatedControlID="txt_fname" />
        <asp:TextBox ID="txt_fname" runat="server" />
        <br />
        <asp:Label ID="lbl_lname" runat="server" Text="Enter Last Name: " AssociatedControlID="txt_lname" />
        <asp:TextBox ID="txt_lname" runat="server" />
        <br />
        <asp:Button ID="btn" runat="server" Text="Search"  OnClick="search"/>
       
      <br />
        <asp:Label ID="no_result" runat="server" />
        <br />

      <%--  ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++--%>

         <asp:GridView ID="grd_doc" Runat="server" 
          AutoGenerateColumns="False"
            AllowSorting="True" BorderWidth="2px" BackColor="White" 
            GridLines="None" CellPadding="3"
            CellSpacing="1" BorderStyle="Ridge" BorderColor="White"
            AllowPaging="True">
            <FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
            <PagerStyle ForeColor="Black" HorizontalAlign="Right"  BackColor="#C6C3C6"></PagerStyle>
            <HeaderStyle ForeColor="#E7E7FF" Font-Bold="True" BackColor="#4A3C8C"></HeaderStyle>
            <Columns>
                <asp:BoundField HeaderText="First Name"  DataField="first_name" SortExpression="Name"/>
                
                <asp:BoundField HeaderText="Last_Name"  DataField="last_name" SortExpression="UnitPrice">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Gender"  DataField="gender" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
               <asp:hyperlinkField DataTextField="email" 
                         HeaderText="email" 
                        SortExpression="ProductName" 
                        DataNavigateUrlFields="doctor_id" 
                         DataNavigateUrlFormatString="" />
                <asp:BoundField HeaderText="bio" DataField="bio"></asp:BoundField>
            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" 
                 BackColor="#9471DE"></SelectedRowStyle>
            <RowStyle ForeColor="Black" BackColor="#DEDFDE"></RowStyle>
        </asp:GridView>
        <i>You are viewing page
        <%=grd_doc.PageIndex + 1%>
        of
        <%=grd_doc.PageCount%>
        </i>
    </div>
    </form>
</body>
</html>
