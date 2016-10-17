using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace Sheep.Kernel.Net
{
    public class HttpContext : HttpMetadata
    {
        public HttpContext(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");

            uri = new Uri(url);
            IPAddress ip = DnsUtils.GetFirstIPAddress(uri.Host);
            endpoint = new IPEndPoint(ip, uri.Port);
        }

        public string Post()
        {
            return Access(HttpMethod.Post);
        }

        public string Get()
        {
            return Access(HttpMethod.Get);
        }

        private string Access(HttpMethod method)
        {
            string result = string.Empty;
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(endpoint);
                if (clientSocket.Connected)
                {
                    IRequest invoker;
                    if (uri.Scheme.Equals("https"))
                        invoker = new HttpsRequest(GetMetadata());
                    else
                        invoker = new HttpRequest(GetMetadata());
                    result = new HttpProvider(invoker).Call(method, clientSocket);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            return result;
        }
    }
}
