<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #someDiv { width:800px; height:200px;  overflow:scroll; border:solid 1px black; }
    </style>
    <h2>Index</h2>
    
    <div id="Loading"><img src="../../Content/Images/loading.gif" /></div>
    <div id="someDiv" >
        dsfsdffsdsd
        <div id="ContentSpot1" data="http://docs.google.com/View?id=ds3rkps_29dcts8dcj">
        </div>
    </div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Header" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {  
            GetData();
        });

        function GetData() {
            var cms = $('div#ContentSpot1'); 
            var loc = cms.attr('data');
            $.ajax({
              type: "GET",
              url: "http://plainformatblog.blogspot.com/2010/03/test.html", //loc,//http://localhost:2537   
              dataType: "html",
              error: function() {
                  alert('Error loading document');
              },
              success: function(data) {
                  $('#Loading').remove();
                  cms.append($(data).find('div.post-body'));  
              }
          });
        }
  </script>
</asp:Content>
