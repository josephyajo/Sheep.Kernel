using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Serialization
{
    public class SoapSerializerFactory : SerializerFactory
    {
        public override IByteSerializer GetByteSerializer()
        {
            throw new NotImplementedException();
        }

        public override IStringSerializer GetStringSerializer()
        {
            return new SoapStringSerializer();
        }
    }
}
