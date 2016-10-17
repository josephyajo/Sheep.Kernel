using Sheep.Kernel.Serialization;
using System;
using System.Configuration;
using System.Xml;

namespace Sheep.Kernel.Configuration
{
    public class XmlConfigurator : ConfiguratorProvider, IXmlConfigurator
    {
        private string sectionName;

        public XmlConfigurator(IConfigurator configurator) : base(configurator)
        {
        }

        public XmlConfigurator(IConfigurator configurator, string sectionName)
            : this(configurator)
        {
            if (string.IsNullOrEmpty(sectionName))
                throw new ArgumentNullException("sectionName");
            this.sectionName = sectionName;
        }

        #region Invoker
        public T GetSection<T>(string sectionName) where T : class
        {
            return Configurator.Get<T>(this);
        }
        #endregion

        #region Accepter
        string IXmlConfigurator.ConfigureSection()
        {
            object section = ConfigurationManager.GetSection(sectionName);
            if (section == null)
                throw new ArgumentNullException("section");
            return (section as XmlElement).OuterXml;
        }
        #endregion
    }
}
