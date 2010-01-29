<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Import Namespace="ContentNamespace.Web.Code.Util" %>


<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Account.UserDisplayName(Page.User.Identity.Name))%></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account", new { Area = "Admin" }, new { }) %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", "LogOn", "Account", new { Area = "Admin" }, new { })%> ]
<%
    }
%>
