using System;
using System.Web;
using System.Web.Caching;

namespace ContentNamespace.Web.Code.Service.SystemServices
{
    public class CacheService : ICacheService
    {

        #region Methods...



        /// <summary>
        /// Attempts to retrieve an object from the cache identified by the key. 
        /// </summary>
        /// <param name="cacheKey">Key of the object to attempt to retrieve from the cache.</param>
        /// <returns>The object, if found; null otherwise.</returns>
        public object Get(string cacheKey)
        { 
            object cacheObject = null;
            if (cacheKey.Trim().Length > 0)
            {
                if (HttpContext.Current != null) { cacheObject = HttpContext.Current.Cache.Get(cacheKey); }
            }
            return cacheObject;
        }

        public void Remove(string cacheKey)
        {
            if (!Equals(Get(cacheKey), null))
            {
                if (HttpContext.Current != null) { HttpContext.Current.Cache.Remove(cacheKey); }
            }
        }

        private void Cache(string cacheKey, 
            object cacheObject,
            int cacheTimeInMinutes)
        {
            if (cacheTimeInMinutes > 0 && cacheKey.Trim().Length > 0)
            {
                if (HttpContext.Current != null)
                {
                    Remove(cacheKey); 
                    HttpContext.Current.Cache.Add(cacheKey,
                                                  cacheObject,
                                                  null,
                                                  DateTime.Now.AddMinutes(cacheTimeInMinutes),
                                                  System.Web.Caching.Cache.NoSlidingExpiration,
                                                  CacheItemPriority.Normal,
                                                  null);
                }
            }
        }

        #endregion

    }

}
