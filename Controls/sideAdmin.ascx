<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sideAdmin.ascx.cs" Inherits="Controls_sideAdmin" %>

  <%--  User Control for the side navigation Public Side By Anja--%>
<asp:Menu ID="sideMenu" Orientation="Vertical" runat="server" DataSourceID="SiteMapDataSource4" CssClass="sideNav" StaticDisplayLevels="3" StaticEnableDefaultPopOutImage="false" >
<StaticMenuItemStyle CssClass="sideNav" HorizontalPadding="1em"></StaticMenuItemStyle>
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource4" SiteMapProvider="AdminSiteMapProvider" runat="server" ShowStartingNode="false" StartFromCurrentNode="true" />