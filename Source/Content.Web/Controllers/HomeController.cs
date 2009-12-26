using System.Web.Mvc;
//
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Controllers
{
    [HandleError]
    public class HomeController : ContentManagerBaseController<IConfigurationService>
    {
        public HomeController(IConfigurationService service) : base(service) { }

        public ActionResult Index()
        {
            GetContentManagerSettings();

            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
