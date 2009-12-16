<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ContentNamespace.Web.Code.Entities.HtmlContent>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>

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
            <th>
                ExpireDate
            </th>
            <th>
                ActiveDate
            </th>
            <th>
                ModifiedBy
            </th>
        </tr>

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
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ExpireDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ActiveDate)) %>
            </td>
            <td>
                <%= Html.Encode(item.ModifiedBy) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

