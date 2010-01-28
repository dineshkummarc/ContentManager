<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>
<%@ Import Namespace="ContentNamespace.Web.Code.Entities"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= (Model.ContentData) %>
    <div class="clear"></div>
    <p>
        Admin functions:
        <% if (Model.AvailableTransitions.Contains(Enums.ContentTransition.RequireEdit))
           { %> <%=Html.ActionLink("Require Edit", "RequireEdit", new { id = Model.Id })%> | <% } %> 
        <% if (Model.AvailableTransitions.Contains(Enums.ContentTransition.Accept))
           { %> <%=Html.ActionLink("Accept", "Accept", new { id = Model.Id })%> | <% } %> 
        <% if (Model.AvailableTransitions.Contains(Enums.ContentTransition.Reject))
           { %> <%=Html.ActionLink("Reject", "Reject", new { id = Model.Id })%> <% } %> 
        <%--There's got to be a better way than this...--%>
        <% if (!Model.AvailableTransitions.Contains(Enums.ContentTransition.RequireEdit) &&
               !Model.AvailableTransitions.Contains(Enums.ContentTransition.Accept) &&
               !Model.AvailableTransitions.Contains(Enums.ContentTransition.Reject))
           { %> <i>None available</i> <% } %> 
    </p>
</asp:Content>
