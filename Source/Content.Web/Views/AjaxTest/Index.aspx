<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <div>
        <%
            using (Ajax.BeginForm("Details",
            new AjaxOptions { UpdateTargetId = "HtmlContentDetails" }))
            { %>
                <p>Customer: <%= Html.DropDownList("id") %></p>
                <p><input type="submit" value="Details" /></p>
             <%} %>
    </div>
    <div id="HtmlContentDetails"></div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
