﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
    <p>
        <a href="HtmlContent/Index">HtmlContent/Index</a>
    </p>  
    <p>
        <a href="HtmlJunk/Index">HtmlJunk/Index</a>
    </p>
    <p>
        <a href="AjaxTest/Index">AjaxTest/Index</a>
    </p>
</asp:Content>
