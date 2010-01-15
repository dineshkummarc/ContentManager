<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Contents
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Area1</h2>
    <div class="ContentArea" contentId="1"> 
    </div>
    <h2>Area0</h2>
    <div class="ContentArea" contentId="0"> 
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
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
