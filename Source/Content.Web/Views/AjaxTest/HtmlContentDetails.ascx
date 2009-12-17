<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<fieldset> 
    <legend>Fields</legend>
    <p><%= Html.Encode(Model.Id) %></p>
    <p><%= Html.Encode(Model.ContentData) %></p>
    <p><%= Html.Encode(Model.ActiveDate) %></p>
    <p><%= Html.Encode(Model.ContentData) %></p> 
</fieldset>