using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sheep.Kernel.Net
{
    public class HttpMetadata
    {
        public Uri uri { get; internal set; }

        public IPEndPoint endpoint { get; internal set; }

        public string ContentType { get; set; } = "application/x-www-form-urlencoded";

        public string Referer { get; set; }

        public string Accept { get; set; } = "text/html,text/xml,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

        public Encoding Accept_Charset { get; set; } = Encoding.Default;

        public string Cookie { get; set; } = new Cookie().Value;

        public int TimeOut { get; set; } = 10000;

        public Encoding Response_Charset { get; set; } = Encoding.UTF8;

        public X509CertificateCollection Certificates { get; set; } = new X509CertificateCollection();

        internal HttpMetadata GetMetadata()
        {
            return this;
        }

        internal byte[] CompositeRequestHeader(HttpMethod method)
        {
            StringBuilder bulider = new StringBuilder();
            if (method.Equals(HttpMethod.Post))
            {
                bulider.AppendLine(string.Format("POST {0} HTTP/1.1", uri.LocalPath));
                bulider.AppendLine(string.Format("Content-Type: {0}", ContentType));
            }
            else
            {
                bulider.AppendLine(string.Format("GET {0} HTTP/1.1", uri.PathAndQuery));
            }
            //bulider.AppendLine("Accept-Encoding: gzip, deflate");
            //bulider.AppendLine("Accept-Language: zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3");
            bulider.AppendLine(string.Format("Accept: {0}", Accept));
            bulider.AppendLine(string.Format("Accept-Charset: {0}", Accept_Charset.ToString()));
            bulider.AppendLine("Connection: keep-alive");
            bulider.AppendLine(string.Format("Cookie: {0}", Cookie));
            bulider.AppendLine(string.Format("Host: {0}", uri.Host));
            bulider.AppendLine("User-Agent: Mozilla/5.0(Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0");
            if (!string.IsNullOrEmpty(Referer))
                bulider.AppendLine(string.Format("Referer: {0}", Referer));
            if (method.Equals(HttpMethod.Post))
            {
                string original = uri.OriginalString;
                int index = original.IndexOf("?");
                string body = original.Substring(index + 1, original.Length - index - 1);
                bulider.AppendLine(string.Format("Content-Length: {0}\r\n", Accept_Charset.GetBytes(body).Length));
                bulider.Append(body);
            }
            else
            {
                bulider.Append("\r\n");
            }
            string header = bulider.ToString();
            return Accept_Charset.GetBytes(header);
        }
    }
}
