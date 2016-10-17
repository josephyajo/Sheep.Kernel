using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Security.AccessControl;
using System.Text;

namespace Sheep.Kernel.Cache
{
    public class CacheClient : ICacheClient
    {
        private static ObjectCache cache = CacheContext.Default;
        private CacheItemPolicy policy;

        public bool Add<T>(string key, T value)
        {
            if (IsExist(key))
            {
                return cache.Add(key, value, policy);
            }
            return false;
        }

        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            if (IsExist(key))
            {
                return cache.Add(key, value, expiresAt);
            }
            return false;
        }

        public void AddALL<T>(IDictionary<string, T> values)
        {
            foreach (KeyValuePair<string, T> value in values)
            {
                cache.Add(value.Key, value.Value, policy);
            }
        }

        public T Get<T>(string key) where T : class
        {
            if (IsExist(key))
            {
                return cache.Get(key) as T;
            }
            return default(T);
        }

        public IEnumerable<KeyValuePair<string, T>> GetAll<T>(IEnumerable<string> keys)
        {
            foreach (string key in keys)
            {
                if (IsExist(key))
                {
                    yield return (KeyValuePair<string, T>)cache.Get(key);
                }
            }
        }

        public bool Remove(string key)
        {
            return cache.Remove(key) == null ? false : true;
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            foreach (string key in keys)
            {
                if (IsExist(key))
                {
                    cache.Remove(key);
                }
            }
        }

        public void Set<T>(string key, T value)
        {
            if (IsExist(key))
            {
                cache.Set(key, value, Policy);
            }
        }

        public void Set<T>(string key, T value, DateTime expiresAt)
        {
            if (IsExist(key))
            {
                cache.Set(key, value, expiresAt);
            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            foreach (KeyValuePair<string, T> value in values)
            {
                if (IsExist(value.Key))
                {
                    cache.Set(value.Key, value.Value, Policy);
                }
            }
        }

        public bool IsExist(string key)
        {
            return cache.Contains(key);
        }

        public CacheItemPolicy Policy
        {
            private get
            {
                return policy != null ? policy : new CacheItemPolicy();
            }
            set
            {
                policy = value;
            }
        }
    }
}
