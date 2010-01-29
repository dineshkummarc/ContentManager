using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.DataAccess.Db4o;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Code.Service.ConfigurationServices
{
    public class SettingService : ISettingService
    {
        #region Fields...

        private CacheService _cacheService;
        private readonly ISettingRepository _repository;
        
        #endregion

        #region Constructors...

        public SettingService(ISettingRepository repository, CacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }

        #endregion

        #region IConfigurationService Members...

        public Setting Get()
        {
            return GetContentManagerSettings();
        }

        public Setting Save(Setting settings)
        {
            _cacheService.RemoveFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey);

            return _repository.Save(settings);
        }

        #endregion

        private Setting GetContentManagerSettings()
        {
            var setting = _cacheService.GetFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey) as Setting;

            // If not found in cache, try get from DB
            if (Equals(setting, null))
            {
                setting = FillSettingFromRepository();

                if (setting != null)
                {
                    // place setting into the cache
                    _cacheService.InsertIntoCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey,
                                                 setting,
                                                 setting.SettingsCacheTimeInMinutes);
                }
            } 
            return setting;
        }

        private Setting FillSettingFromRepository()
        {
            var setting = _repository.Get().FirstOrDefault();

            // If there isn't a setting object in the repository, hardcode a setting instance 
            if (Equals(setting, null))
            {
                var newSettings = new Setting
                {
                    AllowExpiredContentReActivation = true,
                    AllowRejectedContentReActivation = false,
                    ContentExtractLength = 15,
                    GridPageSize = 10,
                    SettingsCacheTimeInMinutes = 5,
                    ShowContentEllipsis = true,
                    ModifiedBy = "XXXX"
                }; 
                setting = this.Save(newSettings);
            }
            return setting;
        }
    }
}
