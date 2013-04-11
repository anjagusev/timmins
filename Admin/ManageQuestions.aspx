<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true"
    CodeFile="ManageQuestions.aspx.cs" Inherits="Admin_Default2" %>

<%-- Anja's Admin for the Survey Feature as well --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" runat="Server">
    <div style="width: 55em; margin-bottom:2em; margin: 0 auto;">

       
        <div style="float: left; margin-top:1em; height:25em; ">
        <asp:Label ID="lbl_output" runat="server" />
         <h1>
                <asp:Label ID="lbl_header" runat="server" ForeColor="Maroon" Text="Add a Question" /></h1>
            <table cellpadding="2" style="float:right;" class="style1">
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
                        <asp:Label ID="lbl_questiontype" runat="server" Text="Question Type" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypes" runat="server" Width="41%" OnSelectedIndexChanged="subCheck"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_type" runat="server" ControlToValidate="ddlTypes"
                            InitialValue="-" Display="Dynamic" Text="error" ErrorMessage="Required!" />
                    </td>
                </tr>
                <%--  <tr>
                <td style="width: 25%; text-align: left;">
                    <asp:Label ID="lbl_question" runat="server" Text="Question" />
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width="40%" />
                    <asp:RequiredFieldValidator ID="rfv_title" runat="server" ControlToValidate="txtTitle"
                        Display="Dynamic" Text="Required" ErrorMessage="*required" />
                </td>
            </tr>--%>
                <tr>
                    <td style="width: 25%; text-align: left;">
                        <asp:Label ID="lbl_question" runat="server" Text="Question" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuestion" runat="server" Rows="3" TextMode="MultiLine" Width="40%" />
                        <asp:RequiredFieldValidator ID="rfv_question" runat="server" ControlToValidate="txtQuestion"
                            Display="Dynamic" Text="Required" ErrorMessage="*required" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left;">
                        <asp:Label ID="lbl_values" runat="server" Text="Values" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtValues" runat="server" Rows="3" TextMode="MultiLine" Width="40%" />
                        <%--<asp:RequiredFieldValidator ID="rfv_values" runat="server" ControlToValidate="txtValues"
                        Display="Dynamic" Text="Required" ErrorMessage="*required" />--%><br />
                        <asp:Label ID="lbl_valueinfo" runat="server" Text="(Enter values as comma seperated)" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: left;">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                            ValidationGroup="question" />
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
         <div style="float: right; width:25em; margin-top:3em; ">
           
            <asp:Label ID="literal_instructions" runat="server" Style="width: 100px;" Text="<b>1. Select a Question Type.</b><br/>The options are: <ul><li>single select (the user can only choose one value from a list)</li><li> multi-select (the user can use many values from a list)</li><li> single line textbox (a short textbox)</li><li> multi line textbox (a large text area)</li><li>yes or no which should be chosen if a question has a yes or no answer</li></ul> <b>2 .Write your question as you would like to have it displayed to users.</b><br/><br/><b>3. If you choose a single select or multi-select question type enter the values that the user will be choosing from</b>" />
        </div>
     <div style="float:left; width:55em; margin-top:3em;"> 
        <asp:Label ID="lbl_gridheader" runat="server" SkinID="head" Text="Existing Questions" Style="font-size: 26px;
            font-weight: bold; text-align: center; padding: 15px;" />
            <br />
        <asp:GridView ID="lv_questions" CellPadding="4" runat="server" Style=" margin:0 auto; padding:.4em; width: 50em;">
                <AlternatingRowStyle BackColor="AliceBlue"/>
        </asp:GridView>
        <%--   <asp:ListView ID="lv_questions" runat="server" ItemPlaceholderID="itemPlaceHolder">
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </asp:ListView>--%>
    </div>
    </div>
</asp:Content>
