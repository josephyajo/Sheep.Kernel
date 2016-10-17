using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sheep.Kernel.Net
{
    public class HttpsResponse : IResponse
    {
        private HttpMetadata metadata;

        public HttpsResponse(HttpMetadata metadata)
        {
            this.metadata = metadata;
        }

        public string ParseResponse(IPEndPoint endpoint, object stream)
        {
            SslStream ssl = (SslStream)stream;
            CancellationTokenSource source = new CancellationTokenSource();
            Task<string> myTask = Task.Factory.StartNew<string>(new Func<object, string>(ReadSslHeaderProcess), stream, source.Token);
            if (myTask.Wait(metadata.TimeOut))
            {
                string header = myTask.Result;
                if (header.StartsWith("HTTP/1.1 302"))
                {
                    //int start = header.ToUpper().IndexOf("LOCATION");
                    //if (start > 0)
                    //{
                    //    string temp = header.Substring(start, header.Length - start);
                    //    string[] sArry = Regex.Split(temp, "\r\n");
                    //    metadata.uri = new Uri(sArry[0].Remove(0, 10));
                    //    return ParseSslResponse(endpoint, stream, metadata, certificates);
                    //}
                }
                else if (header.StartsWith("HTTP/1.1 200"))  //继续读取内容
                {
                    int start = header.ToUpper().IndexOf("CONTENT-LENGTH");
                    int content_length = 0;
                    if (start > 0)
                    {
                        string temp = header.Substring(start, header.Length - start);
                        string[] sArry = Regex.Split(temp, "\r\n");
                        content_length = Convert.ToInt32(sArry[0].Split(':')[1]);
                        if (content_length > 0)
                        {
                            byte[] bytes = new byte[content_length];
                            if (ssl.Read(bytes, 0, bytes.Length) > 0)
                            {
                                return metadata.Response_Charset.GetString(bytes);
                            }
                        }
                    }
                    else
                    {
                        return metadata.Response_Charset.GetString(ParseSslResponse(ssl));
                    }
                }
                else
                {
                    return header;
                }
            }
            else
            {
                source.Cancel();
            }
            return null;
        }

        private string ReadSslHeaderProcess(object stream)
        {
            SslStream ssl = (SslStream)stream;
            StringBuilder bulider = new StringBuilder();
            while (true)
            {
                int read = ssl.ReadByte();
                if (read != -1)
                {
                    byte b = (byte)read;
                    bulider.Append((char)b);
                }
                string temp = bulider.ToString();
                if (temp.Contains("\r\n\r\n"))
                {
                    break;
                }
            }
            return bulider.ToString();
        }

        private byte[] ParseSslResponse(SslStream ssl)
        {
            ArrayList array = new ArrayList();
            StringBuilder bulider = new StringBuilder();
            int length = 0;
            while (true)
            {
                byte[] buff = new byte[1024];
                int len = ssl.Read(buff, 0, buff.Length);
                if (len > 0)
                {
                    length += len;
                    byte[] reads = new byte[len];
                    Array.Copy(buff, 0, reads, 0, len);
                    array.Add(reads);
                    bulider.Append(metadata.Response_Charset.GetString(reads));
                }
                string temp = bulider.ToString();
                if (temp.ToUpper().Contains("</HTML>"))
                {
                    break;
                }
            }
            byte[] bytes = new byte[length];
            int index = 0;
            for (int i = 0; i < array.Count; i++)
            {
                byte[] temp = (byte[])array[i];
                Array.Copy(temp, 0, bytes, index, temp.Length);
                index += temp.Length;
            }
            return bytes;
        }
    }
}
