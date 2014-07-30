using System;
using System.Web;
using Radiostr.Cache;

namespace Radiostr.Web.Cache
{
    public class HttpContextCache : ICache
    {
        private readonly System.Web.Caching.Cache _cache;

        public HttpContextCache(HttpContextBase httpContext)
        {
            _cache = httpContext.Cache;
        }

        public void Add(string key, object value, DateTime absoluteExpiration)
        {
            _cache.Insert(key, value, null, absoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }
    }
}