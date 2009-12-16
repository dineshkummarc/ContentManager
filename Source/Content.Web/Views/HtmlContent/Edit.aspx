<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

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
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id) %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="ContentData">ContentData:</label>
                <%= Html.TextArea("ContentData", Model.ContentData) %> 
            </p>
            <p>
                <label for="ModifiedDate">ModifiedDate:</label>
                <%= Html.TextBox("ModifiedDate", String.Format("{0:g}", Model.ModifiedDate)) %>
                <%= Html.ValidationMessage("ModifiedDate", "*") %>
            </p>
            <p>
                <label for="ExpireDate">ExpireDate:</label>
                <%= Html.TextBox("ExpireDate", String.Format("{0:g}", Model.ExpireDate)) %>
                <%= Html.ValidationMessage("ExpireDate", "*") %>
            </p>
            <p>
                <label for="ActiveDate">ActiveDate:</label>
                <%= Html.TextBox("ActiveDate", String.Format("{0:g}", Model.ActiveDate)) %>
                <%= Html.ValidationMessage("ActiveDate", "*") %>
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

