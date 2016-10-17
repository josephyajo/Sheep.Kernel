using System;

namespace Sheep.Kernel.Serialization
{
    public class JsonSerializerFactory : SerializerFactory
    {
        public override IStringSerializer GetStringSerializer()
        {
            return new JsonStringSerializer();
        }

        public override IByteSerializer GetByteSerializer()
        {
            throw new NotImplementedException();
        }
    }
}
