<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/adminSubPage.master" AutoEventWireup="true" CodeFile="adminrequestappointment.aspx.cs" Inherits="Admin_Default" %>
  <%--Default Admin Page --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_admin_main" Runat="Server">

<asp:Label ID="lbl_info" runat="server" Text="This is a listing of the people that have contacted the hospital requesting an appointment with a Doctor.<br/><b>Note:</b> People awaiting a response are 'waiting to hear back' and patients whose appointments have been approved are marked as confirmed. " />
        <br />
        <br />
        <asp:Label ID="lbl_msg" runat="server" />
        <br />
        <br />
        <%-- Gridview of visitors table --%>
        <asp:GridView ID="grv_appointments" runat="server" AutoGenerateColumns="false" CellPadding="5"
            HeaderStyle-BackColor="red">
            <Columns>
                <%-- ID Column --%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_appointment_id" runat="server" Text="ID" OnCommand="subSort" CommandName="id" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_appointment_id" runat="server" Text='<%#Eval("appointment_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Name Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_appointment_name" runat="server" Text="Name" OnCommand="subSort" CommandName="name" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_appointment_name" runat="server" Text='<%#Eval("appointment_name")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Email Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_apppointment_email" runat="server" Text="Email" OnCommand="subSort" CommandName="email" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_appointment_email" runat="server" Text='<%#Eval("appointment_email")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                
                
               
                <%--Date of Appointment Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_appointment_date" runat="server" Text="Date of Appointment" OnCommand="subSort"
                            CommandName="date" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_appointment_date" runat="server" Text='<%#Eval("appointment_date", "{0:dd/MM/yyyy}")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Appointment Time column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_appointment_time" runat="server" Text="Appointment Time" OnCommand="subSort"
                            CommandName="duration" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_appointment_time" runat="server" Text='<%#Eval("appointment_time")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Appointment Confirmation Column--%>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnk_appointment_confirmation" runat="server" Text="Appointment Confirmation Status" OnCommand="subSort"
                            CommandName="status" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_appointment_confirmation" runat="server" Text='<%#Eval("appointment_confirmation")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Notify Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_notify" runat="server" CommandArgument='<%#Eval("appointment_id") + "^" + Eval("appointment_name") + "^" + Eval("appointment_email")%>'
                            Text="Confirmed" OnClientClick="return confirm('Change status to confirmed, and email appointment details?')"
                            OnClick="Confirmed" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Pending Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_pending" runat="server" CommandArgument='<%#Eval("appointment_id") %>'
                            Text="Waiting" OnClientClick="return confirm('Change status to pending?')" OnClick="Waiting" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Delete Button--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnk_delete" runat="server" CommandArgument='<%#Eval("appointment_id") %>'
                            Text="Delete" OnClientClick="return confirm('Delete this record?')" OnClick="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%-- End gridview --%>
    </div>


    </div>


</asp:Content>

