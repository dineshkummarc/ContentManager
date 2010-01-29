<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.Setting>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Settings - Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Settings - Edit</h2>
    If you make changes and save, the new settings will be saved to the database and placed into cache, where they will take effect immediately.

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Caching</legend>
            <p>
                <label for="Id">Settings cache time (in minutes): <%= Html.TextBox("CacheTimeInMinutes", Model.SettingsCacheTimeInMinutes)%>
                <%= Html.ValidationMessage("CacheTimeInMinutes", "*")%></label>
            </p>
        </fieldset>
       <fieldset>
            <legend>Rendering</legend>
            <p>
                <label for="Id">Show this many records per page: <%= Html.TextBox("GridPageSize", Model.GridPageSize)%>
                <%= Html.ValidationMessage("GridPageSize", "*")%></label> 
            </p>
            <p>
                <label for="Id">Show content extract ellipsis: <%= Html.RadioButton("ShowContentEllipsis", "True", Model.ShowContentEllipsis)%> True
                <%= Html.RadioButton("ShowContentEllipsis", "False", !Model.ShowContentEllipsis)%> False</label>
            </p>
            <p>
                <label for="Id">Length of content to show before ellipsis: <%= Html.TextBox("ContentExtractLength", Model.ContentExtractLength)%>
                <%= Html.ValidationMessage("ContentExtractLength", "*")%></label>
            </p>
        </fieldset>
        <fieldset>
            <legend>Workflow</legend>
            <p>
                <label for="Id">Allow rejected content to be reactivated: <%= Html.RadioButton("AllowRejectedContentReactivation", "True", Model.AllowRejectedContentReActivation)%> True
                <%= Html.RadioButton("AllowRejectedContentReactivation", "False", !Model.AllowRejectedContentReActivation)%> False</label>
            </p>
            <p>
                <label for="Id">Allow expired content to be reactivated: <%= Html.RadioButton("AllowExpiredContentReactivation", "True", Model.AllowExpiredContentReActivation)%> True
                <%= Html.RadioButton("AllowExpiredContentReactivation", "False", !Model.AllowExpiredContentReActivation)%> False</label>
            </p>
        </fieldset>
        <p>
            <input type="submit" value="Save" />&nbsp;<%=Html.ActionLink("Cancel", "Index") %>
        </p>
        
    <% } %>

</asp:Content>

