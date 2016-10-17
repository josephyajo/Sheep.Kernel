using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sheep.Kernel.Net
{
    public class HttpsRequest : IRequest
    {
        private HttpMetadata metadata;
        private IResponse response;

        public HttpsRequest(HttpMetadata metadata)
        {
            this.metadata = metadata;
            response = new HttpsResponse(metadata);
        }

        public string Call(HttpMethod method, Socket clientSocket)
        {
            using (SslStream ssl = new SslStream(new NetworkStream(clientSocket), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null))
            {
                ssl.AuthenticateAsClient("Name", metadata.Certificates, SslProtocols.Tls, false);
                if (ssl.IsAuthenticated)
                {
                    byte[] buff = metadata.CompositeRequestHeader(method);
                    ssl.Write(buff);
                    ssl.Flush();
                    return response.ParseResponse(metadata.endpoint, ssl);
                }
            }
            return string.Empty;
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
