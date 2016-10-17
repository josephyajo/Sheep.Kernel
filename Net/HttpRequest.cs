using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace Sheep.Kernel.Net
{
    public class HttpRequest : IRequest
    {
        private HttpMetadata metadata;
        private IResponse response;

        public HttpRequest(HttpMetadata metadataa)
        {
            this.metadata = metadataa;
            response = new HttpResponse(metadata);
        }

        public string Call(HttpMethod method, Socket clientSocket)
        {
            byte[] buff = metadata.CompositeRequestHeader(method);
            if (clientSocket.Send(buff) > 0)
            {
                return response.ParseResponse(metadata.endpoint, clientSocket);
            }
            return string.Empty;
        }
    }
}
