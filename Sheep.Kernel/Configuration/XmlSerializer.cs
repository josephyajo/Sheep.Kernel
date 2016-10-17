using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheep.Kernel.Serialization;

namespace Sheep.Kernel.Configuration
{
    public class XmlSerializer : ConfiguratorProvider, IXmlSerializer
    {
        private IXmlSerializer xmlSerializer;

        public XmlSerializer(IConfigurator configurator) : base(configurator)
        {
            xmlSerializer = new XmlSerializerAdapter();
        }

        #region Accepter
        T IXmlSerializer.DeserializeXml<T>(string value)
        {
            return xmlSerializer.DeserializeXml<T>(value);
        }

        T IXmlSerializer.DeserializeXmlFile<T>(string path)
        {
            return xmlSerializer.DeserializeXmlFile<T>(path);
        }
        #endregion
    }
}
