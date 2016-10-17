using Sheep.Kernel.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Configuration
{
    public class CacheHandle : ConfiguratorProvider, ICacheHandle
    {
        private ICacheClient client;

        public CacheHandle(IConfigurator configurator) : base(configurator)
        {
            client = new CacheClient();
        }

        #region Accepter
        public T Get<T>(string key) where T : class
        {
            return client.Get<T>(key);
        }

        public bool Add<T>(string key, T value)
        {
            return client.Add<T>(key, value);
        }
        #endregion
    }
}
