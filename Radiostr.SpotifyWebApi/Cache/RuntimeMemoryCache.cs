using System;
using System.Diagnostics;
using System.Runtime.Caching;

namespace Radiostr.SpotifyWebApi.Cache
{
    /// <summary>
    /// A Cache service based on <see cref="ObjectCache"/>
    /// </summary>
    public class RuntimeMemoryCache : ICache
    {
        private readonly ObjectCache _cache;

        public RuntimeMemoryCache(ObjectCache objectCache)
        {
            _cache = objectCache;
        }

        /// <summary>
        /// Adds a value to the Cache.
        /// </summary>
        public void Add(string key, object value, DateTime absoluteExpiration)
        {
            _cache.Add(key, value, absoluteExpiration);
            Trace.TraceInformation("Added cache item " + key);
        }

        /// <summary>
        /// Gets a value from the Cache by key.
        /// </summary>
        public object Get(string key)
        {
            var value = _cache.Get(key);
            Trace.TraceInformation("Got cache value " + key);
            return value;
        }
    }
}