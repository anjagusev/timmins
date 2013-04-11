<%--Phong Huynh - 810194340, hnhp0025
Timmins Hospital Website
Job Postings Feature--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true"
    CodeFile="ApplicationForm_admin.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" runat="Server">
    <div>
        <h1>
            Applications - Admin</h1>
        <asp:Label ID="lbl_msg" runat="server" />
        <br />
        <br />
        <%-- Gridview of applications table --%>
        <asp:GridView ID="grv_applications" runat="server" AutoGenerateColumns="false" CellPadding="5"
            HeaderStyle-BackColor="SteelBlue">
            <Columns>
                <%-- ID Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_id" runat="server" Text="ID" OnCommand="subSort" CommandName="id" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("application_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Job ID Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_jobid" runat="server" Text="Job ID" OnCommand="subSort" CommandName="jobid" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_jobid" runat="server" Text='<%#Eval("jobposting_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Job Title Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_title" runat="server" Text="Job Title" OnCommand="subSort"
                            CommandName="title" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("title") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Date Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_date" runat="server" Text="Date" OnCommand="subSort" CommandName="date" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("app_date", "{0:dd/MM/yyyy}") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Name Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_name" runat="server" Text="Name" OnCommand="subSort" CommandName="name" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_name" runat="server" Text='<%#Eval("name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Email Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_email" runat="server" Text="Email" OnCommand="subSort" CommandName="email" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_email" runat="server" Text='<%#Eval("email") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Phone Number Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_number" runat="server" Text="Phone Number" OnCommand="subSort"
                            CommandName="phonenumber" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_number" runat="server" Text='<%#Eval("phonenumber") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Address Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_address" runat="server" Text="Address" OnCommand="subSort"
                            CommandName="address" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_address" runat="server" Text='<%#Eval("address") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- City Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_city" runat="server" Text="City" OnCommand="subSort" CommandName="city" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_city" runat="server" Text='<%#Eval("city") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Postal Code Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_postalcode" runat="server" Text="Postal Code" OnCommand="subSort"
                            CommandName="postalcode" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_postalcode" runat="server" Text='<%#Eval("postalcode") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- Resume Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_resume" runat="server" Text="Resume" OnCommand="subSort"
                            CommandName="resume" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%--Link to open resume--%>
                        <asp:HyperLink ID="hlk_resume" runat="server" Text='<%#Eval("resume") %>' NavigateUrl='<%#"../Resumes/"+Eval("resume") %>'
                            Target="_blank" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Delete Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_delete" runat="server" CommandArgument='<%#Eval("application_id") + "^" + Eval("resume") %>'
                            Text="Delete" OnClientClick="return confirm('Delete this record?')" OnClick="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%-- End gridview --%>
    </div>
</asp:Content>
