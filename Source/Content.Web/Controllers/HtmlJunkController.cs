using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NinjectIntegration.Models;
using Content.Web.Code.Service.Interfaces;

namespace Content.Web.Controllers
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
            var items = this._service.Get();

            ViewData["Message"] = "asdfasfasadfafsdaasd";
            return View();
        }

    }
}
