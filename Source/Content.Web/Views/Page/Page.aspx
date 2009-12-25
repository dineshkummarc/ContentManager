<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= (Model.ContentData) %>
    <p>
        Admin functions (visibility should be controlled):
        <%=Html.ActionLink("Require Edit", "RequireEdit", new { id = Model.Id })%> |
        <%=Html.ActionLink("Accept", "Accept", new { id = Model.Id })%> |
        <%=Html.ActionLink("Reject", "Reject", new { id = Model.Id })%>
    </p>
</asp:Content>
