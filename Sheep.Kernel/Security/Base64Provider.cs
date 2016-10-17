using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Security
{
    public class Base64Provider
    {
        public static string Encode(string source)
        {
            return Encode(Encoding.UTF8, source);
        }

        public static string Encode(Encoding encoding, string source)
        {
            byte[] bytes = encoding.GetBytes(source);
            return Convert.ToBase64String(bytes);
        }

        public static string Decode(string result)
        {
            return Decode(Encoding.UTF8, result);
        }

        public static string Decode(Encoding encoding, string result)
        {
            byte[] bytes = Convert.FromBase64String(result);
            return encoding.GetString(bytes);
        }
    }
}
