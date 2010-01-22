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
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            UserProfilesString:
            <%= Html.Encode(Model.UserProfilesString) %>
        </p>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            CreatedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.CreatedDate)) %>
        </p>
        <p>
            CreatedBy:
            <%= Html.Encode(Model.CreatedBy) %>
        </p>
        <p>
            ModifiedDate:
            <%= Html.Encode(String.Format("{0:g}", Model.ModifiedDate)) %>
        </p>
        <p>
            ModifiedBy:
            <%= Html.Encode(Model.ModifiedBy) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>

