using System;
using System.Collections.Generic;

namespace Sheep.Kernel.Cache
{
    public interface ICacheClient
    {
        bool Add<T>(string key, T value);
        bool Add<T>(string key, T value, DateTime expiresAt);
        void AddALL<T>(IDictionary<string, T> values);
        T Get<T>(string key) where T : class;
        IEnumerable<KeyValuePair<string, T>> GetAll<T>(IEnumerable<string> keys);
        bool Remove(string key);
        void RemoveAll(IEnumerable<string> keys);
        void Set<T>(string key, T value);
        void Set<T>(string key, T value, DateTime expiresAt);
        void SetAll<T>(IDictionary<string, T> values);
        bool IsExist(string key);
    }
}
