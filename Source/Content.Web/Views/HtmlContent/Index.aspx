<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ContentNamespace.Web.Code.Entities.HtmlContent>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
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
            <th>
                Status
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <a href="/Page/Page/<%= Html.Encode(item.Id) %> " >View </a>  |
                <%= Html.ActionLink("Details", "Details", new { id = item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
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
            <td>
                <%= Html.Encode(item.ContentState) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

