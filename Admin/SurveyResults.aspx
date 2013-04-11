<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true"
    CodeFile="SurveyResults.aspx.cs" Inherits="Admin_Default2" %>

<%-- Anja's Admin Side for the Surevy Feature --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
a 
{
   color:Black;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" runat="Server">
    <div style="width:55em; margin:0 auto; margin-top:2em; margin-bottom:10em;">
    <asp:Label ID="lbl_head" runat="server" SkinID="head" Text="Results from the Feedback Survey" />
        <table class="tablered" style="margin-top:1em;">
            <thead>
                <tr>
                    <th style="width: 120px;">
                       Response ID
                        <asp:LinkButton ID="lkb_srDown" runat="server" OnClick="srDown_Click">Down</asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="lkb_srUp" runat="server" OnClick="srUp_Click">UP</asp:LinkButton>
                    </th>
                    <th>
                        Survey Title &nbsp;
                        <asp:LinkButton ID="lkb_titleDown" runat="server" OnClick="titleDown_Click">Down</asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="lkb_titleUp" runat="server" OnClick="titleUp_Click">UP</asp:LinkButton>
                    </th>
                    <th>
                        SurveyQuestion
                        <asp:LinkButton ID="lkb_questionDown" runat="server" OnClick="questionDown_Click">Down</asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="lkb_questionUp" runat="server" OnClick="questionUp_Click">UP</asp:LinkButton>
                    </th>
                    <th>
                        Response
                    </th>
                </tr>
            </thead>
             <tbody style="border: 1px solid black; border-collapse: collapse;">
            <asp:Repeater ID="ltv_results" runat="server" OnItemDataBound="subBound">
                <ItemTemplate>
                        <tr>
                            <td style="width: 120px">
                                <asp:HiddenField ID="hdfID" runat="server" Value='<%#Eval("ID") %>' />
                                <asp:Label ID="lbl_surveyresponseid" runat="server" Text='<%#Eval("ID") %>' />
                            </td>
                            <td>
                                <asp:Repeater ID="rpt_surveytitle" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:HiddenField ID="hdf_SID" runat="server" Value='<%#Eval("SurveyID") %>' />
                            </td>
                            <td>
                                <asp:Repeater ID="rpt_question" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion" runat="server" Text='<%#Eval("Text")%>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:HiddenField ID="hdf_QID" runat="server" Value='<%#Eval("QuestionID") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lbl_value" runat="server" Text='<%#Eval("Value") %>' />
                            </td>
                        </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
        </table>
  
    </div>
</asp:Content>
