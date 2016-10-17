using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Sheep.Kernel.Net
{
    public interface IResponse
    {
        string ParseResponse(IPEndPoint endpoint, object client);
    }
}
