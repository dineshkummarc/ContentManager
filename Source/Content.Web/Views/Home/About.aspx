<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>
        Put content here.
    </p>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript">
        $(function() {
            $('.ContentArea').each(function() { 
                $(this).load('/HtmlContent/ContentPage/' + $(this).attr('contentId'));
                //$(this).load('<%= Url.Action("ContentPage", new {id = 0}) %>');
            });  
        });  
    </script>
</asp:Content>

