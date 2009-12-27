using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Service.SystemServices;

namespace ContentNamespace.Web.Code.Service.Base
{
    public abstract class ContentManagerBaseService
    {
        protected Settings _settings;
        protected CacheService _service = new CacheService();
    }
}
