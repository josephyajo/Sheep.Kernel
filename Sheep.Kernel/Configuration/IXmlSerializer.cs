using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Configuration
{
    public interface IXmlSerializer
    {
        T DeserializeXml<T>(string value);

        T DeserializeXmlFile<T>(string path);
    }
}
