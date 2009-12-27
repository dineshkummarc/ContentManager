using System;
using System.Web;
using System.Web.Caching;

namespace ContentNamespace.Web.Code.Service.SystemServices
{
    public class CacheService : ICacheService
    {
        #region Fields...

        private string _cacheKey;

        #endregion

        #region Methods...

        /// <summary>
        /// Inserts the object identified by they key into the cache where it will remain for the specified length of
        /// time in minutes.
        /// </summary>
        /// <param name="cacheKey">Key used to identify the object.</param>
        /// <param name="cacheObject">The object to cache.</param>
        /// <param name="cacheTimeInMinutes">Number of minutes the object will remain in the cache.</param>
        public void InsertIntoCache(string cacheKey, 
            object cacheObject, 
            int cacheTimeInMinutes)
        {
            CacheThisObject(cacheKey, 
                cacheObject,
                cacheTimeInMinutes);
        }

        /// <summary>
        /// Attempts to retrieve an object from the cache identified by the key. 
        /// </summary>
        /// <param name="cacheKey">Key of the object to attempt to retrieve from the cache.</param>
        /// <returns>The object, if found; null otherwise.</returns>
        public object GetFromCache(string cacheKey)
        {
            _cacheKey = cacheKey;

            return GetData();
        }

        private static void CacheThisObject(string cacheKey, 
            object cacheObject,
            int cacheTimeInMinutes)
        {
            if (cacheTimeInMinutes > 0 && cacheKey.Trim().Length > 0)
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Cache.Remove(cacheKey);
                    HttpContext.Current.Cache.Add(cacheKey,
                                                  cacheObject,
                                                  null,
                                                  DateTime.Now.AddMinutes(cacheTimeInMinutes),
                                                  Cache.NoSlidingExpiration,
                                                  CacheItemPriority.Normal,
                                                  null);
                }
            }
        }

        #endregion

        #region IContentManagerBaseService Members...

        public object GetData()
        {
            object cacheObject = null;

            if (_cacheKey.Trim().Length > 0)
            {
                if (HttpContext.Current != null) { cacheObject = HttpContext.Current.Cache.Get(_cacheKey); }
            }

            return cacheObject;
        }

        #endregion
    }

}
