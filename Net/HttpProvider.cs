using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Net
{
    public class HttpProvider : IRequest
    {
        private IRequest invoker;

        public HttpProvider(IRequest invoker)
        {
            this.invoker = invoker;
        }

        public string Call(HttpMethod method, Socket clientSocket)
        {
            return invoker.Call(method, clientSocket);
        }
    }
}
