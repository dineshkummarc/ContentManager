<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditExtra
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditExtra</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <div class="hidden" >
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", Model.Id) %>  
                <%--<label for="ContentData">ContentData:</label>
                 Html.TextBox("ContentData", Model.ContentData)  --%>
            </div>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
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
                <label for="OwnerUserId">OwnerUserId:</label>
                <%= Html.TextBox("OwnerUserId", Model.OwnerUserId) %>
                <%= Html.ValidationMessage("OwnerUserId", "*") %>
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

