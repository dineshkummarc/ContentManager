<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.Setting>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Settings
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Settings</h2>
    These settings are being pulled from the database.

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Caching</legend>
            <p>
                <label for="Id">Settings cache time (in minutes): <b><%= Html.Encode(Model.SettingsCacheTimeInMinutes) %></b></label>
            </p>
        </fieldset>
       <fieldset>
            <legend>Rendering</legend>
            <p>
                <label for="Id">Show this many records per page: <b><%= Html.Encode(Model.GridPageSize) %></b></label> 
            </p>
            <p>
                <label for="Id">Show content extract ellipsis: <b><%= Html.Encode(Model.ShowContentEllipsis) %></b></label>
            </p>
            <p>
                <label for="Id">Length of content to show before ellipsis: <b><%= Html.Encode(Model.ContentExtractLength) %></b></label> 
            </p>
        </fieldset>
        <fieldset>
            <legend>Workflow</legend>
            <p>
                <label for="Id">Allow rejected content to be reactivated: <b><%= Html.Encode(Model.AllowRejectedContentReActivation) %></b></label>
            </p>
            <p>
                <label for="Id">Allow expired content to be reactivated: <b><%= Html.Encode(Model.AllowExpiredContentReActivation) %></b></label>
            </p>
        </fieldset>
        <p>
            <%=Html.ActionLink("Edit", "Edit", new { }) %>
        </p>
        
    <% } %>

</asp:Content>

