<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="ContentNamespace.Web.Helpers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="checkout">
        <%=Html.DisplayError() %>
        <div class="open-id">
            <h2>
                Use Your Open ID</h2>
            <div class="wrap">
                <form method="post" action="<%=Url.Action("OpenIdLogin","Authentication")%>?ReturnUrl=<%=Url.Action("Shipping"%>">
                <%Html.RenderCommerceControl(ContentControls.OpenIDLogin, null);%>
                </form>
                <p class="hint">
                    Open ID is an identity system that allows you to sign in to websites like ours with
                    a single account. Your username and password are secure with Open ID - and you don't
                    have to remember yet another password.
                </p>
                <a class="rpxnow" onclick="return false;" 
                    href="https://contentmanager.rpxnow.com/openid/v2/signin?token_url=localhost%3A2537%2FAuthentication%FOpenIDLogin">
                    Sign In </a>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
    <script src="https://rpxnow.com/openid/v2/widget"
            type="text/javascript"></script>
    <script type="text/javascript">
      RPXNOW.overlay = true;
      RPXNOW.language_preference = 'en';
    </script>

</asp:Content>