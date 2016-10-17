using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Net
{
    public class HttpUtils
    {
        public static string UrlEncode(string url)
        {
            return WebUtility.UrlEncode(url);
        }

        public static string UrlEncode(string url, Encoding encoding)
        {
            byte[] buffer = EncodingUtils.GetBytes(url);
            byte[] encodeBuffer = WebUtility.UrlEncodeToBytes(buffer, 0, buffer.Length);
            return encoding.GetString(encodeBuffer);
        }

        public static string UrlDecode(string url)
        {
            return WebUtility.UrlDecode(url);
        }

        public static string UrlDecode(string url, Encoding encoding)
        {
            byte[] buffer = EncodingUtils.GetBytes(url);
            byte[] decodeBuffer = WebUtility.UrlDecodeToBytes(buffer, 0, buffer.Length);
            return encoding.GetString(decodeBuffer);
        }
    }
}
