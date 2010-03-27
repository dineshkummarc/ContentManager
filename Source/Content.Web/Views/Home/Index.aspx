<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p> 
    
    <ul>
        <li>
            <%= Html.ActionLink("Admin", "Index", "Test", new { Area = "Admin" }, new { })%>
            &lt;%= Html.ActionLink("Admin", "Index", "Test", new { Area = "Admin" }, new { }) %&gt;
        </li> 
        <li>
            <%= Html.ActionLink("Client", "Index", "TestClient", new { Area = "Client" }, new { })%>
            &lt;%= Html.ActionLink("Client", "Index", "TestClient", new { Area = "Client" }, new { }) %&gt;
        </li>  
        <li>
            <%= Html.ActionLink("Application", "Index","Application",  new { Area = "Admin" }, new { })%>
            &lt;%= Html.ActionLink("Application",  "Index","Application", new { Area = "Admin" }, new { }) %&gt;
        </li>  
        <li>
            <%= Html.ActionLink("Account-AdminOnly", "AdminOnly","Account",  new { Area = "Admin" }, new { })%>
            &lt;%= Html.ActionLink("Account-AdminOnly", "AdminOnly","Account", new { Area = "Admin" }, new { }) %&gt;
        </li> 
        <li>
            <%= Html.ActionLink("AjaxTest",  "Index","AjaxTest", new { Area = "Admin" }, new { })%>
            &lt;%= Html.ActionLink("AjaxTest", "Index","AjaxTest", new { Area = "Admin" }, new { }) %&gt;
        </li> 
        <li>
            <%= Html.ActionLink("Screen-Admin-Index", "Index", "Admin", new { Area = "Screen" }, new { })%>
            &lt;%= Html.ActionLink("Screen-Admin-Index", "Index", "Admin", new { Area = "Screen" }, new { }) %&gt;
        </li> 
        <li>
            <%= Html.ActionLink("Screen-Admin-Home", "Home", "Admin", new { Area = "Screen" }, new { })%>
            &lt;%= Html.ActionLink("Screen-Admin-Home", "Home", "Admin", new { Area = "Screen" }, new { }) %&gt;
        </li> 
    </ul>
    
</asp:Content>
