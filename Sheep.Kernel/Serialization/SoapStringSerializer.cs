using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Serialization
{
    public class SoapStringSerializer : IStringSerializer
    {
        public T Deserialize<T>(string value)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        public T DeserializeFile<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            string xml = File.ReadAllText(path);
            return Deserialize<T>(xml);
        }

        public string Serialize<T>(T target)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, target);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }
    }
}
