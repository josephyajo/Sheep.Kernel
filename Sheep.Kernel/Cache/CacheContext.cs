using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Cache
{
    public class CacheContext : MemoryCache
    {
        public CacheContext(string name, NameValueCollection config = null) : base(name, config)
        {
        }
    }
}
