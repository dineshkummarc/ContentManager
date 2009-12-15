<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage"  %>
<%--Inherits="System.Web.Mvc.ViewPage<IQueryable<Content.Web.Code.Entities.HtmlContent>>"--%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                ContentData
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>
<%--
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.ContentData) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ModifiedDate)) %>
            </td>
        </tr>
    
    <% } %>--%>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

