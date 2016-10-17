using System;

namespace Sheep.Kernel.Configuration
{
    public interface IConfigurator
    {
        T Get<T>(ConfiguratorProvider configurator) where T : class;
    }
}
