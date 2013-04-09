<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sideMenu.ascx.cs" Inherits="Controls_sideMenu" EnableViewState="false" %>
  <%--  User Control for the side navigation Public Side By Anja--%>
<asp:Menu ID="sideMenu" Orientation="Vertical" runat="server" DataSourceID="SiteMapDataSource3" taticDisplayLevels="3" StaticEnableDefaultPopOutImage="false" >
<StaticMenuItemStyle CssClass="menuItem" HorizontalPadding="1em"></StaticMenuItemStyle>
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource3" SiteMapProvider="SqlSiteMapProvider" runat="server" ShowStartingNode="false" StartFromCurrentNode="true" />