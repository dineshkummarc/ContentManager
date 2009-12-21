using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.UserProfileServices;

namespace ContentNamespace.Web.Controllers
{
    public class UserProfileController : Controller
    {

        private readonly IUserProfileService _service;

        public UserProfileController(IUserProfileService serv)
        {
            this._service = serv;
        }

        // GET: /HtmlContent/
        public ActionResult Index()
        {
            return View(this._service.Get());
        }
    }
}
