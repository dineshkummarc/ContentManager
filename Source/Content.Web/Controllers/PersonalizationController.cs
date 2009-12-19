using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.PersonalizationServices;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Controllers
{
    public class PersonalizationController : Controller
    {
        private IPersonalizationService _pService;

        public PersonalizationController(IPersonalizationService pService)
        {
            _pService = pService;
        }


        public ActionResult Summary()
        {

            UserProfile user = _pService.GetProfile(this.GetUserName());
            return View(user);
        }

        public ActionResult AddressBook()
        {
            UserProfile user = _pService.GetProfile(this.GetUserName());
            return View(user.AddressBook);
        }

        public ActionResult Favorites()
        {
            UserProfile user = _pService.GetProfile(this.GetUserName());
            return View(user);
        }

    }
}
