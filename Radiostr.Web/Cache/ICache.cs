using System;

namespace Radiostr.Web.Cache
{
    public interface ICache
    {
        void Add(string key, object value, DateTime absoluteExpiration);
        object Get(string key);
    }
}
