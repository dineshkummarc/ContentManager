using System.Web.Mvc;
//
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Controllers
{
    [HandleError]
    public class HomeController : ContentManagerBaseController 
    {
        private readonly ISettingService _service;

        public HomeController(ISettingService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
