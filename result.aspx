<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="result" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" Runat="Server">
    <div>
        <br /><br />
        <asp:Label ID="lbl" runat="server" />

        <br /><br />
        <asp:Repeater ID="gtv" runat="server">
            <ItemTemplate>
                <h2><%#Eval("heading") %></h2>
                <p><%#Eval("paragraph") %></p>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

