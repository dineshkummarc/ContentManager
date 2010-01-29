using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.DataAccess.Db4o;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Code.Service.ConfigurationServices
{
    public class ConfigurationService : ISettingService
    {
        #region Fields...

        private CacheService _cacheService;
        private readonly ISettingRepository _repository;
        
        #endregion

        #region Constructors...

        public ConfigurationService(ISettingRepository repository, CacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        #endregion

        #region IConfigurationService Members...

        public Settings Get()
        {
            return ((IContentManagerBaseService)this).GetData() as Settings;
        }

        public Settings Save(Settings settings)
        {
            _cacheService.RemoveFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey);

            return _repository.Save(settings);
        }

        #endregion

        #region IContentManagerBaseService Members...

        object IContentManagerBaseService.GetData()
        {
            return GetContentManagerSettings();
        }

        #endregion

        protected Settings GetContentManagerSettings()
        {
            var settings = _cacheService.GetFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey) as Settings;

            // If not found in cache, try get from DB
            if (Equals(settings, null))
            {
                settings = _repository.Get().First() as Settings;

                // If there isn't a settings object in the DB, create the initial default settings instance and store it
                if (Equals(settings, null))
                {
                    var newSettings = new Settings
                    {
                        AllowExpiredContentReActivation = true,
                        AllowRejectedContentReActivation = false,
                        ContentExtractLength = 15,
                        GridPageSize = 10,
                        SettingsCacheTimeInMinutes = 5,
                        ShowContentEllipsis = true
                    };

                    settings = this.Save(newSettings);
                }

                // Otherwise, a settings instance was retrieved from the DB; place it into the cache
                if (settings != null)
                {
                    _cacheService.InsertIntoCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey,
                                                 settings,
                                                 settings.SettingsCacheTimeInMinutes);
                }
            }

            return settings;
        }
    }
}
