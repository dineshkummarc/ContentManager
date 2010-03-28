using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentNamespace.Web.Code.Service.SystemServices
{
    public interface ICacheService
    {
        void Cache(string cacheKey,
            object cacheObject,
            int cacheTimeInMinutes);
        object Get(string cacheKey);
        void Remove(string cacheKey);
    }
}
