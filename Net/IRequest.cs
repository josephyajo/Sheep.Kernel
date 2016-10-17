using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Net
{
    public interface IRequest
    {
        string Call(HttpMethod method, Socket clientSocket);
    }
}
