using Sheep.Kernel.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Configuration
{
    public class XmlSerializerAdapter : IXmlSerializer
    {
        private IStringSerializer serializer = new XmlStringSerializer();

        public T DeserializeXml<T>(string value)
        {
            return serializer.Deserialize<T>(value);
        }

        public T DeserializeXmlFile<T>(string path)
        {
            return serializer.DeserializeFile<T>(path);
        }
    }
}
