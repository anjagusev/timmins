<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sideMenu.ascx.cs" Inherits="Controls_sideMenu" EnableViewState="false" %>
  <%--  User Control for the side navigation Public Side By Anja--%>
<asp:Menu ID="sideMenu" Orientation="Vertical" runat="server" DataSourceID="SiteMapDataSource4" CssClass="sideNav" StaticDisplayLevels="3" StaticEnableDefaultPopOutImage="false" >
<StaticMenuItemStyle CssClass="sideNav" HorizontalPadding="1em"></StaticMenuItemStyle>
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource4" SiteMapProvider="AdminSiteMapProvider" runat="server" ShowStartingNode="false" StartFromCurrentNode="true" />

  <%-- <asp:DropDownList ID="ddl_sideMenu" runat="server" 
    CssClass="mobilemenu mobileSide" AutoPostBack="true" DataSourceID="SiteMapDataSource3" OnSelectedIndexChanged="subMobile"/>
    <asp:SiteMapDataSource ID="SiteMapDataSource3" SiteMapProvider="SqlSiteMapProvider" runat="server" ShowStartingNode="false" StartFromCurrentNode="true" />--%>