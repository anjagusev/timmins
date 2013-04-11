<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true"
    CodeFile="communitypoll.aspx.cs" Inherits="subPage1" %>
   <%-- Access exposed elements from the master page--%>
    <%@ MasterType VirtualPath="~/subPage.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_sideNav" runat="Server">

</asp:Content>
<asp:Content ID="cnt_main" ContentPlaceHolderID="cph_main" runat="server">

<asp:Repeater ID="rpt_all" runat="server"   OnItemDataBound="RepDataBind">
      <ItemTemplate>
                <tr>
                <asp:HiddenField ID="hdf" runat="server" Value='<%#Eval ("IDq") %>' />
                <td><asp:Label ID="lbl_title" runat="server" Text='<%#Eval("question") %>' /></td>
                    <td><br /></td>
                <td><asp:RequiredFieldValidator ID="rfv_answer" runat="server" Text="*Required" ControlToValidate="rbl_list" Display="Dynamic" 
        SetFocusOnError="true" ValidationGroup="form" Font-Bold="True"/></td>
                <td><asp:RadioButtonList ID="rbl_list" runat="server" RepeatDirection="Horizontal" AutoPostBack="false">
                    </asp:RadioButtonList></td>    
            </tr>
      </ItemTemplate>
  </asp:Repeater> 
    <br />
    <br />
    
    <asp:Button ID="btn_submit" runat="server" Text="Submit" CommandName="Insert" OnCommand="subInsert" ValidationGroup="form" />
    <br />
    <asp:Label ID="lbl_message" runat="server" />

</asp:Content>

