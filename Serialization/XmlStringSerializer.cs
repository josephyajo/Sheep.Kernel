using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Sheep.Kernel.Serialization
{
    public class XmlStringSerializer : IStringSerializer
    {
        public string Serialize<T>(T target)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter write = new StreamWriter(ms))
                {
                    ser.Serialize(write, target);
                    return Encoding.UTF8.GetString(ms.GetBuffer());
                }
            }
        }

        public T Deserialize<T>(string value)
        {
            XmlSerializer deser = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                using (StreamReader reader = new StreamReader(ms, true))
                {
                    return (T)deser.Deserialize(reader);
                }
            }
        }

        public T DeserializeFile<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            string xml = File.ReadAllText(path);
            return Deserialize<T>(xml);
        }
    }
}
