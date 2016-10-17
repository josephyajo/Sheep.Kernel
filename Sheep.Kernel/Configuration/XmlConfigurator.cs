using Sheep.Kernel.Serialization;
using System;
using System.Configuration;
using System.Xml;

namespace Sheep.Kernel.Configuration
{
    public class XmlConfigurator : ConfiguratorProvider, IXmlConfigurator
    {
        public XmlConfigurator(IConfigurator configurator) : base(configurator)
        {
        }

        #region Accepter
        string IXmlConfigurator.ConfigureSection()
        {
            object section = ConfigurationManager.GetSection("sheep");
            if (section == null)
                throw new ArgumentNullException("section");
            return (section as XmlElement).OuterXml;
        }
        #endregion
    }
}
