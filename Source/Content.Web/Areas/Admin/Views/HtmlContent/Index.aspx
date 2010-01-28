<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
         Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Controllers.HtmlContentIndexViewModel>" %>

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
    <% using (Html.BeginForm()) {%>

    <% foreach (var item in Model.HtmlContentList)
       { %>
    
        <tr>
            <td>
                <a href="/Page/Page/<%= Html.Encode(item.Id) %> " >View</a>  |
                <%= Html.ActionLink("Details", "Details", new { id = item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Id)%>
            </td>
            <td>
                <%= Html.Encode(item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.ContentData)%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ModifiedDate))%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ExpireDate))%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ActiveDate))%>
            </td>
            <td>
                <%= Html.Encode(item.ModifiedBy)%>
            </td>
            <td>
                <%= Html.Encode(item.ItemStateMachineState)%>
            </td>
        </tr>
    
    <% } %>

    </table>
    <p style="text-align: center;">
        <%= Html.ActionLink("First", "Index", new { targetPage = 0 })%> || 
        <%= Html.ActionLink("Back", "Index", new { targetPage = (Model.CurrentPage == 0) ? 0 : (Model.CurrentPage - 1) })%> | 
        <%= Html.ActionLink("Next", "Index", new { targetPage = (Model.CurrentPage == Model.MaximumPage) ? Model.MaximumPage : (Model.CurrentPage + 1) })%> || 
        <%= Html.ActionLink("Last", "Index", new { targetPage = Model.MaximumPage })%>
    </p>

    <p> 
        <%= Html.ActionLink("Create New", "Create") %> |
        <%= Html.ActionLink("TestPage", "TestContents") %>  
    </p>
    
    <% } %>

</asp:Content>

