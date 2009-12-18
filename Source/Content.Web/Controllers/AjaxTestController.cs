using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Controllers
{
    //ref: http://davidhayden.com/blog/dave/archive/2009/05/19/ASPNETMVCAjaxBeginForm.aspx
    //ref: http://channel9.msdn.com/shows/The+Knowledge+Chamber/Phil-Haack-ASPNET-MVC-and-Ninjas-On-Fire/
    public class AjaxTestController : Controller
    {
        
        private readonly IContentService _service;

        public AjaxTestController(IContentService serv)
        {
            this._service = serv;
        }

        public ActionResult Details(string id)
        { 
            var c = this._service.Get(Convert.ToInt32(id)); 
            return PartialView("HtmlContentDetails", c); 
        }


        // GET: /AjaxTest/
        public ActionResult Index()
        { 
            ViewData["id"] = new SelectList(this._service.Get(), "Id", "Name"); 
            return View();
        }

    }
}
