using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Configuration
{
    public interface ICacheHandle
    {
        T Get<T>(string key) where T : class;
        bool Add<T>(string key, T value);
    }
}
