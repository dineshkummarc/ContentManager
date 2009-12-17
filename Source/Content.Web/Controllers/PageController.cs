using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IContentService _service;

        public PageController(IContentService serv)
        {
            this._service = serv;
        }

        //
        // GET: /Page/ 
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Page/Page/5 
        public ActionResult Page(int id)
        {
            return View(this._service.Get(id));
        }

    }
}
