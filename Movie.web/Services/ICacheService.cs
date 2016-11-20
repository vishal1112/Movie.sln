using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.web.Services
{
    public interface ICacheService
    {
        void WriteCache(string CacheKey, object item, int expirationTimeInMinute);
        T ReadCache<T>(string CacheKey) where T : class;
        void DeleteCache(string CacheKey);
        bool IsCached(string CacheKey);
    }
}