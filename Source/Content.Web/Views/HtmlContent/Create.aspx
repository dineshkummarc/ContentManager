<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p class="hidden"  >
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", "-2") %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name")%>
                <%= Html.ValidationMessage("Name", "*")%>
            </p>
            <p>
                <label for="ContentData">ContentData:</label>
                <%= Html.TextBox("ContentData") %>
                <%= Html.ValidationMessage("ContentData", "*") %>
            </p>
            <p>
                <label for="ModifiedDate">ModifiedDate:</label>
                <%= Html.TextBox("ModifiedDate") %>
                <%= Html.ValidationMessage("ModifiedDate", "*") %>
            </p>
            <p>
                <label for="ExpireDate">ExpireDate:</label>
                <%= Html.TextBox("ExpireDate") %>
                <%= Html.ValidationMessage("ExpireDate", "*") %>
            </p>
            <p>
                <label for="ActiveDate">ActiveDate:</label>
                <%= Html.TextBox("ActiveDate") %>
                <%= Html.ValidationMessage("ActiveDate", "*") %>
            </p>
            <p>
                <label for="ModifiedBy">ModifiedBy:</label>
                <%= Html.TextBox("ModifiedBy") %>
                <%= Html.ValidationMessage("ModifiedBy", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

