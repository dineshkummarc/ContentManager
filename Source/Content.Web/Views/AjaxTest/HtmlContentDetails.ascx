<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<fieldset> 
    <legend>Fields</legend>
    <p>Id: <%= Html.Encode(Model.Id) %></p>
    <p>Name: <%= Html.Encode(Model.Name)%></p>
    <p>ContentData: <%= Html.Encode(Model.ContentData) %></p>
    <p>ActiveDate: <%= Html.Encode(Model.ActiveDate) %></p>
    <p>ModifiedBy: <%= Html.Encode(Model.ModifiedBy) %></p> 
    <p>ModifiedDate: <%= Html.Encode(Model.ModifiedDate) %></p> 
</fieldset>