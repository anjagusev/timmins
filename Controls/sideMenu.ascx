<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sideMenu.ascx.cs" Inherits="Controls_sideMenu" EnableViewState="false" %>

<asp:Menu ID="sideMenu" Orientation="Vertical" runat="server" DataSourceID="SiteMapDataSource1" taticDisplayLevels="3" StaticEnableDefaultPopOutImage="false" >
<StaticMenuItemStyle CssClass="menuItem" HorizontalPadding="1em"></StaticMenuItemStyle>
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="false" StartFromCurrentNode="true" />