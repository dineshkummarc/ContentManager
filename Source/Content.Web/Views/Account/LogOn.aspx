<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>


<asp:Content ID="Content2"  ContentPlaceHolderID="Header" runat="server">

	<link rel="stylesheet" href="/content/openid.css" />
	
</asp:Content>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
 	<!-- Simple OpenID Selector -->
	<link rel="stylesheet" href="/content/openid.css" />
	<script type="text/javascript" src="/scripts/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" src="/scripts/openid-jquery.js"></script>
	<script type="text/javascript">
	    $(document).ready(function() {
	        openid.init('openid_identifier');
	    });
	</script>
	<!-- /Simple OpenID Selector -->
	
	<style type="text/css">
		/* Basic page formatting. */
		body {
			font-family:"Helvetica Neue", Helvetica, Arial, sans-serif;
		}
	</style>
 
 
 
    <h2>Log On</h2> 
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="username">Username:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password">Password:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Remember me?</label>
                </p>
                <p>
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>





<asp:Content ID="Content1"  ContentPlaceHolderID="Javascript" runat="server">

	<script type="text/javascript" src="/scripts/openid-jquery.js"></script>
	<script type="text/javascript">
//	    $(document).ready(function() {
//	        openid.init('openid_identifier');
//	    });
	</script>
	
</asp:Content>

	
	