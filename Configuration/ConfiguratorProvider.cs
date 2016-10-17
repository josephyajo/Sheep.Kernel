using Sheep.Kernel.Serialization;
using System;

namespace Sheep.Kernel.Configuration
{
    public abstract class ConfiguratorProvider
    {
        protected IConfigurator Configurator { get; private set; }

        protected ConfiguratorProvider(IConfigurator configurator)
        {
            if (configurator == null)
                throw new ArgumentNullException("configurator");
            Configurator = configurator;
        }
    }
}
