using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Net
{
    public class EncodingUtils
    {
        public static string TransferEncoding(Encoding srcEncoding, Encoding dstEncoding, string str)
        {
            byte[] strBytes = srcEncoding.GetBytes(str);
            byte[] bytes = Encoding.Convert(srcEncoding, dstEncoding, strBytes);
            return dstEncoding.GetString(bytes);
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
