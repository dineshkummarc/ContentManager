<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%@ Import Namespace="ContentNamespace.Web.Code.Util" %>


<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Account.UserDisplayName(Page.User.Identity.Name))%></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>
