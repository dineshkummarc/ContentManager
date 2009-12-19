<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm(new { Controller = "Account", Action = "OpenIdLogon" }))
       { %>
    <fieldset>
        <div class="containercontent">
            <div class="labelheaderblock">
                Log on using OpenId:</div>
            <input id="openid_identifier" name="openid_identifier" />
            <input id="btnOpenIdLogin" type="submit" value="Login" />
            <img id="imgOpenIdLoginProgress" src="<%= ResolveUrl("~/css/images/loading_small.gif") %>"
                style="display: none" />
            <div id="divOpenIdIcons">
                <img src="<%= ResolveUrl("~/images/openid-icon.png") %>" onclick="openIdUrl('openid')"
                    title="myopenid.com" class="hoverbutton" />
                <img src="<%= ResolveUrl("~/images/google-icon.png") %>" onclick="openIdUrl('google')"
                    title="Google" class="hoverbutton" />
                <img src="<%= ResolveUrl("~/images/yahoo-icon.png") %>" onclick="openIdUrl('yahoo')"
                    title="Yahoo" class="hoverbutton" />
            </div>
        </div>
    </fieldset>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
