<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= (Model.ContentData) %>
</asp:Content>
