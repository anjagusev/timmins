<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true"
    CodeFile="CreateSurvey.aspx.cs" Inherits="CreateSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" runat="Server">
    <h1>
        <asp:Label ID="lbl_header" runat="server" Text="Add A Survey" /></h1>
    <table cellpadding="2" class="style1">
        <tr>
            <td style="width: 2em; text-align: left;">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 2em; text-align: left;">
                Title
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="40%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_title" runat="server" ControlToValidate="txtTitle"
                    Display="Dynamic" Text="Required" ErrorMessage="*required" />
            </td>
        </tr>
        <tr>
            <td style="width: 2em; text-align: left;">
                Description
            </td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Width="40%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_desc" runat="server" ControlToValidate="txtDesc"
                    Display="Dynamic" Text="Required" ErrorMessage="*required" />
            </td>
        </tr>
        <tr>
            <td style="width: 2em; text-align: left;">
                Expires On
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" Width="40%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_datre" runat="server" ControlToValidate="txtDate"
                    Display="Dynamic" Text="Required" ErrorMessage="*required" />
            </td>
        </tr>
        <tr>
            <td style="width: 2em; text-align: left;">
                Select Questions
            </td>
            <td>
                <table cellpadding="2" class="style1">
                    <tr>
                        <td style="">
                            Source
                        </td>
                        <td style="width: 20%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <div id="listboxSource">
                                <asp:ListBox ID="lbSource" runat="server" Rows="6"></asp:ListBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; width: 5px;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddAll" runat="server" CausesValidation="False" OnClick="btnAddAll_Click"
                                            Text="&gt;&gt;" />
                                    </td>
                                    <td>
                                        Add All
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAddOne" runat="server" CausesValidation="False" OnClick="btnAddOne_Click"
                                            Text=" &gt; " />
                                    </td>
                                    <td>
                                        Add One
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnRemoveOne" runat="server" CausesValidation="False" OnClick="btnRemoveOne_Click"
                                            Text=" &lt; " />
                                    </td>
                                    <td>
                                        Remove One
                                    </td>
                                </tr>
                                <br />
                                <tr>
                                    <td>
                                        <asp:Button ID="btnRemoveAll" runat="server" CausesValidation="False" OnClick="btnRemoveAll_Click"
                                            Text="&lt;&lt;" />
                                    </td>
                                    <td>
                                        Remove All
                                    </td>
                                </tr>
                            </table>
                            <td>
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 100%:">
                            Target
                        </td>
                    </tr>
                <td class="style2">
                    <asp:ListBox ID="lbTarget" runat="server" Rows="6" Width="100%"></asp:ListBox>
                    <%--<asp:RequiredFieldValidator ID="rfv_target" runat="server" ControlToValidate="lbTarget" Text="*Required" InitalValue="-1" Display="Dynamic" />--%>
                    <asp:CustomValidator ID="ctv_target" runat="server" Text="*You must add at least 3 questions"
                        ControlToValidate="lbTarget" ValidateEmptyText="true" ClientValidationFunction="subCheck"
                        OnServerValidate="subCheck" />
                </td>
        </tr>
        </td> </tr>
    </table>
    </tr><tr>
        <td style="width: 25%; text-align: left;">
            &nbsp;
        </td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td style="width: 25%; text-align: left;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    </table>
    <div>
        <asp:Label ID="lbl_output" runat="server" />
        <asp:Label ID="lblTest" runat="server" />
        <asp:HiddenField ID="hdf_sq_id" runat="server" />
        <h2>
            <asp:Label ID="lbl_active" runat="server" Text="Select a Feedback Survey to make active" /></h2>
        <asp:DropDownList ID="ddlSurveys" runat="server" AutoPostBack="false" ValidationGroup="status"
            Width="21%">
        </asp:DropDownList>
        <asp:Button ID="btn_status" runat="server" ValidationGroup="status" OnClick="subStatus"
            Text="Make Active" />
    </div>
</asp:Content>
