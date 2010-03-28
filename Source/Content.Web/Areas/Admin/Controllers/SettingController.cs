using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        //
        // GET: /Page/ 
        public SettingController(ISettingService service)
        {
            this._settingService = service;
        }

        public ActionResult Index()
        {
            return View(_settingService.Get());
        }

        public ActionResult Edit()
        {
            var editConfiguration = _settingService.Get();

            return View(editConfiguration);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                var s = _settingService.Get();

                if (s != null)
                {
                    s.SettingsCacheTimeInMinutes = int.Parse(collection["CacheTimeInMinutes"]);
                    s.GridPageSize = int.Parse(collection["GridPageSize"]);
                    s.ShowContentEllipsis = bool.Parse(collection["ShowContentEllipsis"]);
                    s.ContentExtractLength = int.Parse(collection["ContentExtractLength"]);
                    s.AllowRejectedContentReActivation = bool.Parse(collection["AllowRejectedContentReactivation"]);
                    s.AllowExpiredContentReActivation = bool.Parse(collection["AllowExpiredContentReactivation"]);
                    s.ModifiedBy = "XXXX";

                    _settingService.Save(s);
                }

                // Remove the existing cached settings item; it will be re-added back automatically by the BaseController
                var cacheService = new CacheService();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
