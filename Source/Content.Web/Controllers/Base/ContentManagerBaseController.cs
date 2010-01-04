using System.Web.Mvc;
//
using ContentNamespace.Web.Code.DataAccess.Object;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service;
using ContentNamespace.Web.Code.Service.ConfigurationServices;
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

                // If there isn't a settings object in the DB at all, create the initial default settings instance and store it
                if (Equals(settings, null))
                {
                    var configurationService = new ConfigurationService(new ObjectRepository<Settings>());
                    var newSettings = new Settings
                                          {
                                              AllowExpiredContentReActivation = true,
                                              AllowRejectedContentReActivation = false,
                                              ContentExtractLength = 15,
                                              GridPageSize = 10,
                                              SettingsCacheTimeInMinutes = 5,
                                              ShowContentEllipsis = true
                                          };

                    settings = configurationService.Save(newSettings);
                }

                // Otherwise, a settings instance was retrieved from the DB; place it into the cache
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
