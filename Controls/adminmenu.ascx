<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="adminmenu.ascx.cs"
    Inherits="adminMenu" %>
<asp:Menu ID="menu" Orientation="Horizontal" CssClass="top-nav-bar" runat="server"
    DataSourceID="SiteMapDataSource1" StaticEnableDefaultPopOutImage="false" StaticMenuStyle-CssClass="top-nav-bar">
    <DynamicMenuStyle CssClass="dynamicMenu" />
    <DynamicMenuItemStyle CssClass="dynamicMenu"></DynamicMenuItemStyle>
    <StaticMenuItemStyle CssClass="menuItem" HorizontalPadding="1em"></StaticMenuItemStyle>
</asp:Menu>
<asp:DropDownList ID="ddl_menu" runat="server" DataSourceID="SiteMapDataSource1"
    CssClass="mobilemenu" />
<asp:SiteMapDataSource ID="AdminSiteMapDataSource1" runat="server" ShowStartingNode="false" />
<%-- <asp:Menu ID="menu1" Orientation="Horizontal"  runat="server"
                    StaticMenuStyle-CssClass="top-nav-bar" DataSourceID="main_nav" >
                    <DynamicMenuItemStyle CssClass="menuItem"></DynamicMenuItemStyle>
                    <StaticMenuItemStyle CssClass="menuItem" HorizontalPadding="1em"></StaticMenuItemStyle>
                </asp:Menu>--%>
<%--
 <asp:Menu ID="menu" Orientation="Vertical" runat="server"
                    DataSourceID="SiteMapDataSource1" StaticDisplayLevels="3" StaticEnableDefaultPopOutImage="false" >
                    
                    <StaticMenuItemStyle CssClass="menuItem" HorizontalPadding="1em"></StaticMenuItemStyle>
                </asp:Menu>
                <asp:DropDownList ID="ddl_menu" runat="server" DataSourceID="SiteMapDataSource1"
                    CssClass="mobilemenu" />
                <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="true"/>--%>