using System.Web.Mvc;
//
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Controllers
{
    public abstract class ContentManagerBaseController<TService> : Controller 
        where TService : IContentManagerBaseService
    {
        #region Fields...

        protected TService _service;

        #endregion

        #region Constructors...

        protected ContentManagerBaseController(TService service)
        {
            _service = service;
        }

        #endregion

        #region Methods...

        protected void GetContentManagerSettings()
        {
            var cacheService = new CacheService();
            var cachedSettingsObject = cacheService.GetFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey);

            if (Equals(cachedSettingsObject, null))
            {
                var settings = _service.GetData() as Settings;

                if (settings != null)
                { 
                    cacheService.InsertIntoCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey,
                                                 settings,
                                                 settings.SettingsCacheTimeInMinutes);
                }
            }
        }

        #endregion
    }
}
