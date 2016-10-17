using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Security
{
    public class MD5Provider
    {
        public static string Encode(string source)
        {
            return Encode(Encoding.UTF8, source);
        }

        public static string Encode(Encoding encoding, string source)
        {
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(encoding.GetBytes(source));
            return encoding.GetString(result);
        }
    }
}
