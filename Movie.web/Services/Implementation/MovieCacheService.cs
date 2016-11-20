using Movie.web.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.web.Services.Implementation
{
    public class MovieCacheService : ICacheService
    {
        //public T Get<T>(string cacheID, Func<T> getItemCallback) where T : class
        //{
        //    T item = HttpRuntime.Cache.Get(cacheID) as T;
        //    double minutes = MovieConfig.CacheExpirationMinute;
        //    if (item == null)
        //    {
        //        item = getItemCallback();
        //        HttpRuntime.Cache.Insert(cacheID, item, null, DateTime.Now.AddMinutes(minutes), System.Web.Caching.Cache.NoSlidingExpiration);
        //    }
        //    return item;
        //}

        //public void Clear()
        //{
        //    IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
        //    while (enumerator.MoveNext())
        //        HttpRuntime.Cache.Remove(enumerator.Key.ToString());
        //}

        public void WriteCache(string cacheKey, object item, int expirationTimeInMinute)
        {
            if (IsCached(cacheKey))
            {
                HttpContext.Current.Cache.Remove(cacheKey);
            }

            HttpContext.Current.Cache.Add(cacheKey, item, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, expirationTimeInMinute, 0), System.Web.Caching.CacheItemPriority.Default, null);
        }

        public T ReadCache<T>(string cacheKey) where T : class
        {
            return HttpContext.Current.Cache[cacheKey] as T;
        }

        public void DeleteCache(string cacheKey)
        {
            HttpContext.Current.Cache.Remove(cacheKey);
        }

        public bool IsCached(string cacheKey)
        {
            return HttpContext.Current.Cache[cacheKey] != null;

        }
    }
}