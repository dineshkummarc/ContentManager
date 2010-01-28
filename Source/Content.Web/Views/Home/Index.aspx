<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
    <p>
        <a href="AjaxTest.mvc/Index">AjaxTest/Index</a>
    </p>
    <p>
        <a href="Account.mvc/AdminOnly">Account/AdminOnly</a>
    </p>
    <p>
        <a href="Application.mvc/Index">Application.mvc/Index</a>
    </p>
    
    
    <ul>
        <li>
            <%= Html.ActionLink("Admin", "Index", "Test", new { Area = "Admin" }, new { })%>
            &lt;%= Html.ActionLink("Admin", "Index", "Test", new { Area = "Admin" }, new { }) %&gt;
        </li> 
        <li>
            <%= Html.ActionLink("Client", "Index", "Test", new { Area = "Client" }, new { })%>
            &lt;%= Html.ActionLink("Client", "Index", "Test", new { Area = "Client" }, new { }) %&gt;
        </li>  
    </ul>
    
</asp:Content>
