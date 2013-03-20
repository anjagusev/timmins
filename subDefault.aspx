<%@ Page Title="" Language="C#" MasterPageFile="~/subMasterPage.master" AutoEventWireup="true" CodeFile="subDefault.aspx.cs" Inherits="subDefault" Theme="Theme1" %>
<%@ MasterType VirtualPath="~/subMasterPage.master" %> <%-- required if trying to access exposed eleemtns from a master page and override them on the content page --%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_subcontent" Runat="Server">EAT MEEAT
</asp:Content>



