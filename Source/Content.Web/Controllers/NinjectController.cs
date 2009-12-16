using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;
using NinjectIntegration.Models;

namespace ContentNamespace.Web.Controllers
{
    public class NinjectController : Controller
    { 
        private readonly IGreetingService _service;

        public NinjectController(IGreetingService _service)
        {
            this._service = _service;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = _service.GetGreeting();
            return View();
        }

    }
}
