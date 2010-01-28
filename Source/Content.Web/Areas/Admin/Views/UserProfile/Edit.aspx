<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.UserProfile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="UserName">UserName:</label>
                <%= Html.TextBox("UserName", Model.UserName) %>
                <%= Html.ValidationMessage("UserName", "*") %>
            </p>
            <p>
                <label for="Email">Email:</label>
                <%= Html.TextBox("Email", Model.Email) %>
                <%= Html.ValidationMessage("Email", "*") %>
            </p>
            <p>
                <label for="LastSignInDate">LastSignInDate:</label>
                <%= Html.TextBox("LastSignInDate", String.Format("{0:g}", Model.LastSignInDate)) %>
                <%= Html.ValidationMessage("LastSignInDate", "*") %>
            </p>
            <p>
                <label for="RegisterDate">RegisterDate:</label>
                <%= Html.TextBox("RegisterDate", String.Format("{0:g}", Model.RegisterDate)) %>
                <%= Html.ValidationMessage("RegisterDate", "*") %>
            </p>
            <p>
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id) %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="CreatedDate">CreatedDate:</label>
                <%= Html.TextBox("CreatedDate", String.Format("{0:g}", Model.CreatedDate)) %>
                <%= Html.ValidationMessage("CreatedDate", "*") %>
            </p>
            <p>
                <label for="CreatedBy">CreatedBy:</label>
                <%= Html.TextBox("CreatedBy", Model.CreatedBy) %>
                <%= Html.ValidationMessage("CreatedBy", "*") %>
            </p>
            <p>
                <label for="ModifiedDate">ModifiedDate:</label>
                <%= Html.TextBox("ModifiedDate", String.Format("{0:g}", Model.ModifiedDate)) %>
                <%= Html.ValidationMessage("ModifiedDate", "*") %>
            </p>
            <p>
                <label for="ModifiedBy">ModifiedBy:</label>
                <%= Html.TextBox("ModifiedBy", Model.ModifiedBy) %>
                <%= Html.ValidationMessage("ModifiedBy", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>

