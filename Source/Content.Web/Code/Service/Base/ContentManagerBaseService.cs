using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Entities.Base;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Code.Service.Base
{
    public abstract class ContentManagerBaseService<TRepository, TBaseItem>
        where TRepository : IRepository<TBaseItem>
        where TBaseItem : ContentManagerBaseItem
    {
        protected TRepository _repository;
        protected Settings _settings;
        protected CacheService _service = new CacheService();

        protected ContentManagerBaseService(TRepository repository)
        {
            _repository = repository;
            _settings = _service.GetFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey) as Settings;
        }
    }
}
