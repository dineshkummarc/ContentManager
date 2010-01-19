using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;

namespace ContentNamespace.Web.Controllers
{
    public class PageController : ContentManagerBaseController
    {
        private readonly IContentService _contentService;
        //
        // GET: /Page/ 
        public PageController(IContentService contentService, ISettingService settingService)
        {
            this._contentService = contentService;
            this._settingService = settingService;

            GetContentManagerSettings();
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Page/Page/5 
        public ActionResult Page(int id)
        {
            var c = this._contentService.Get(id);

            return View(c);
        }

        public ActionResult RequireEdit(int id)
        {
            var c = _contentService.Get(id);

            c.RequireEdit(); // Change workflow state

            _contentService.Save(c);

            return RedirectToAction("../HtmlContent/Details", new { id });
        }

        public ActionResult Accept(int id)
        {
            var c = _contentService.Get(id);

            c.Accept(); // Change workflow state

            _contentService.Save(c);

            return RedirectToAction("../HtmlContent/Details", new { id });
        }

        public ActionResult Reject(int id)
        {
            var c = _contentService.Get(id);

            c.Reject(); // Change workflow state

            _contentService.Save(c);

            return RedirectToAction("../HtmlContent/Details", new { id });
        }
    }
}
