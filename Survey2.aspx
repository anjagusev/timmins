<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true" CodeFile="Survey2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_sideNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" Runat="Server">

 <table cellpadding="2" class="style1">
            <tr>
                <td style="width: 25%; text-align: left;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left;">
                    Select Survey
                </td>
                <td>
                    <asp:DropDownList ID="ddlSurveys" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSurveys_SelectedIndexChanged" 
                        Width="41%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left;">
             <%--   <asp:listview id="ltv" runat="server" >
              <ItemTemplate>
              </ItemTemplate>
                </asp:listview>
             --%>   <asp:Label ID="lblYes" runat="server" />
                    <asp:Panel ID="pnlSurvey" runat="server">
                    
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left;">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Enabled="false" OnClick="btnSubmit_Click"
                        Text="Submit" />
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" />
                </td>
            </tr>
        </table>
</asp:Content>

