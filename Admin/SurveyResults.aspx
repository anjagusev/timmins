<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="SurveyResults.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">
 <div>
        <table cellpadding="3" cellspacing="5" style="border: 1px solid black; border-collapse: collapse;">
            <thead>
                <tr>
                    <th style="width: 120px;">
                       Survey Response ID
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
            <asp:Repeater ID="ltv_results" runat="server" OnItemDataBound="subBound">
                <ItemTemplate>
                    <table cellpadding="3" cellspacing="5" style="border: 1px solid black; border-collapse: collapse;">
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
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Literal ID="lbl_surveyid" runat="server" />
    </div>
</asp:Content>

