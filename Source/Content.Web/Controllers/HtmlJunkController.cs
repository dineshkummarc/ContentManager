using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NinjectIntegration.Models;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Controllers
{
    public class HtmlJunkController : Controller
    {
        private readonly IContentService _service;

        public HtmlJunkController(IContentService _service)
        {
            this._service = _service;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "asdfasfasadfafsdaasd";
            return View();
        }

    }
}
