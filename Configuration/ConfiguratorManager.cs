using System;

namespace Sheep.Kernel.Configuration
{
    public class ConfiguratorManager : IConfigurator
    {
        private IXmlConfigurator xmlConfigurator;

        private IXmlSerializer xmlSerializer;

        private ICacheHandle cacheHandle;

        public ConfiguratorManager()
        {
            xmlConfigurator = new XmlConfigurator(this);
            xmlSerializer = new XmlSerializer(this);
            cacheHandle = new CacheHandle(this);
        }

        public T Get<T>(ConfiguratorProvider currentProvider) where T : class
        {
            if (currentProvider.GetType() == xmlConfigurator.GetType())
            {
                string key = typeof(T).Name;
                T value = cacheHandle.Get<T>(key);
                if (value == null)
                {
                    string section = (currentProvider as IXmlConfigurator).ConfigureSection();

                    if (string.IsNullOrEmpty(section))
                        throw new ArgumentNullException("section");

                    SheepConfig config = xmlSerializer.DeserializeXml<SheepConfig>(section);
                    string path = AppDomain.CurrentDomain.BaseDirectory + config.Path + typeof(T).Name + ".xml";
                    value = xmlSerializer.DeserializeXmlFile<T>(path);

                    cacheHandle.Add<T>(key, value);
                }
                return value;
            }
            else
                return default(T);
        }
    }
}
