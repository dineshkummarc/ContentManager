<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Controllers.HtmlContentViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
 
            <p class="hidden"  >
                <label for="Id">Id:</label>
                <%= Html.TextBox("Id", "-2") %>
                <%= Html.ValidationMessage("Id", "*") %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.HtmlContent.Name)%>
                <%= Html.ValidationMessage("Name", "*")%>
            </p> 
            
            <p>
                <label for="Name">Application:</label>
                <%= Html.DropDownList("Application", Model.Applications)%>  
            </p> 
            
            
            
            
            
            <p>
                <input type="submit" value="Create" />
            </p> 

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

