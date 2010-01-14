<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentNamespace.Web.Code.Entities.HtmlContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Id">Id:</label>
                <%= Html.Encode(Model.Id) %> 
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name)%>
                <%= Html.ValidationMessage("Name", "*")%>
            </p>
            <p>
                <label for="ContentData">ContentData:</label>
                <%= Html.TextArea("ContentData", Model.ContentData) %> 
                        
		        <textarea class="jquery_ckeditor" cols="80" id="editor1" name="editor1" rows="10">&lt;p&gt;This is some &lt;strong&gt;sample text&lt;/strong&gt;. You are using &lt;a href="http://ckeditor.com/"&gt;CKEditor&lt;/a&gt;.&lt;/p&gt;</textarea>
		        
            </p>  
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="JavaScript" ID="contentJavaScript">
<%--
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>--%>
	<script type="text/javascript" src="<%= Url.Content("~/Content/CkEditor/ckeditor.js") %>"></script>
	<script type="text/javascript" src="<%= Url.Content("~/Content/CkEditor/jquery.js") %>"></script>
	<script type="text/javascript" src="<%= Url.Content("~/Content/CkEditor/sample.js") %>"></script>
	<script type="text/javascript">
	//<![CDATA[

$(function()
{
	var config = {
		toolbar:
		[ 
		    ['Source', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
            ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
            ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
            ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
            '/',
            ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
            ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
            ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
            ['Link', 'Unlink', 'Anchor'],
            ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
            '/',
            ['Styles', 'Format', 'Font', 'FontSize'],
            ['TextColor', 'BGColor'],
            ['Maximize', 'ShowBlocks', '-', 'About']
		]
	};

	// Initialize the editor.
	// Callback function can be passed and executed after full instance creation.
	$('.jquery_ckeditor').ckeditor(config);
});

	//]]>
	</script>
</asp:Content>
