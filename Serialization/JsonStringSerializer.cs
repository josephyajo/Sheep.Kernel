using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Sheep.Kernel.Serialization
{
    internal class JsonStringSerializer : IStringSerializer
    {
        public string Serialize<T>(T target)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, target);
                return Encoding.UTF8.GetString(ms.GetBuffer());
            }
        }

        public T Deserialize<T>(string value)
        {
            DataContractJsonSerializer deser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                return (T)deser.ReadObject(ms);
            }
        }

        public T DeserializeFile<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            string json = File.ReadAllText(path);
            return Deserialize<T>(json);
        }
    }
}
