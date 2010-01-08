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
    public class ConfigurationController : ContentManagerBaseController
    {
        private readonly IConfigurationService _service;
        //
        // GET: /Page/ 
        public ConfigurationController(IConfigurationService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetData());
        }

        public ActionResult Edit()
        {
            var editConfiguration = _service.GetData();

            return View(editConfiguration);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                var s = _service.GetData() as Settings;

                if (s != null)
                {
                    s.SettingsCacheTimeInMinutes = int.Parse(collection["CacheTimeInMinutes"]);
                    s.GridPageSize = int.Parse(collection["GridPageSize"]);
                    s.ShowContentEllipsis = bool.Parse(collection["ShowContentEllipsis"]);
                    s.ContentExtractLength = int.Parse(collection["ContentExtractLength"]);
                    s.AllowRejectedContentReActivation = bool.Parse(collection["AllowRejectedContentReactivation"]);
                    s.AllowExpiredContentReActivation = bool.Parse(collection["AllowExpiredContentReactivation"]);

                    _service.Save(s);
                }

                // Remove the existing cached settings item; it will be re-added back automatically by the BaseController
                var cacheService = new CacheService();

                cacheService.RemoveFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
