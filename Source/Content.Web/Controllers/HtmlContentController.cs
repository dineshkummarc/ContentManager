using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Entities;
using NinjectIntegration.Models;

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
            ViewData["Message"] = "NICK YOU ARE COOL";
            return View();
            //return View(this._service.Get()); 
        }


        public ActionResult List()
        {
            return View(this._service.Get()); 
        }
 
    }
}
