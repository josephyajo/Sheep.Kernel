using System;

namespace Sheep.Kernel.Serialization
{
    public class XMLSerializerFactory : SerializerFactory
    {
        public override IStringSerializer GetStringSerializer()
        {
            return new XmlStringSerializer();
        }

        public override IByteSerializer GetByteSerializer()
        {
            throw new NotImplementedException();
        }
    }
}
