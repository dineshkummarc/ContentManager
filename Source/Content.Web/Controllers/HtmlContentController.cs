using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Entities; 

namespace ContentNamespace.Web.Controllers
{
    public class HtmlContentController : Controller
    {
        private readonly IContentService _service;

        public HtmlContentController(IContentService serv)
        {
            this._service = serv;
        }
         
        public ActionResult Index()
        {
            return View(this._service.Get()); 
        }
 
    }
}
