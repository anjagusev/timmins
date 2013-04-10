﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sideMenu.ascx.cs" Inherits="Controls_sideMenu" EnableViewState="false" %>
  <%--  User Control for the side navigation Public Side By Anja--%>
<asp:Menu ID="sideMenu" Orientation="Vertical" runat="server" DataSourceID="main_nav" CssClass="sideNav" StaticDisplayLevels="4" StaticEnableDefaultPopOutImage="false" >
<StaticMenuItemStyle CssClass="sideNav" HorizontalPadding="1em"></StaticMenuItemStyle>
</asp:Menu>
<%--<asp:SiteMapDataSource ID="SiteMapDataSource3" SiteMapProvider="SqlSiteMapProvider" runat="server" ShowStartingNode="false" StartFromCurrentNode="true" />--%>

<asp:SiteMapDataSource ID="main_nav" StartFromCurrentNode="true" runat="server" SiteMapProvider="main_nav" ShowStartingNode="false" />