<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.Application>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Name:
            <span><%= Html.Encode(Model.Name) %></span>
        </p>
        <p>
            UserProfilesString:
            <span><%= Html.Encode(Model.UserProfilesString) %></span>
        </p>
        <p>
            Id:
            <span><%= Html.Encode(Model.Id) %></span>
        </p>
        <p>
            CreatedDate:
            <span><%= Html.Encode(String.Format("{0:g}", Model.CreatedDate)) %></span>
        </p>
        <p>
            CreatedBy:
            <span><%= Html.Encode(Model.CreatedBy) %></span>
        </p>
        <p>
            ModifiedDate:
            <span><%= Html.Encode(String.Format("{0:g}", Model.ModifiedDate)) %></span>
        </p>
        <p>
            ModifiedBy:
            <span><%= Html.Encode(Model.ModifiedBy) %></span>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new {   id=Model.Id   }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server"> 
    <script   type="text/javascript">
        $(document).ready(function() {
            $('p span').css('font-weight', 'bold');
        });
    </script>


</asp:Content>

