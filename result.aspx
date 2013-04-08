<%@ Page Title="" Language="C#" MasterPageFile="~/subPage.master" AutoEventWireup="true" CodeFile="result.aspx.cs" Inherits="result" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" Runat="Server">
    <div>
        <br /><br />
        <asp:Label ID="lbl" runat="server" />

        <br /><br />
        <asp:Gridview ID="gtv" runat="server">
        </asp:Gridview>
    </div>
</asp:Content>

