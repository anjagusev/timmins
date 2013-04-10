<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="services" %>

<%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_sideNav" Runat="Server">

      <asp:linkbutton ID="btn_date" runat="server"  OnClick="btn_date_Click" Text="Sort by New Services" />

        <br /><br />

     <asp:LinkButton ID="lnb_alphabetically" runat="server" OnClick="lnb_alphabetically_Click" Text="Sort by Alphabetically" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" Runat="Server">

    <script>
        $(function () {
            $("#accordion").accordion({
                header: "h3",

                collapsible: true,

                active: false

            });
        });
  </script>



   <%-- listview of services--%>
    <asp:ListView ID="lv_services" data-roles="listview"  runat="server" SortExpressionDefault="title" SortDirectionDefault="Descending">
        <LayoutTemplate>
           
              <div id="accordion">
                   <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
              </div>
        </LayoutTemplate>
      
        <ItemTemplate>
            <h3><a href="#"><%# Eval("title")%></a></h3>
                 <div style="border: solid 1px #336699;">
                             <%# Eval("description")%>
                  </div>
         </ItemTemplate>
  </asp:ListView>


</asp:Content>

