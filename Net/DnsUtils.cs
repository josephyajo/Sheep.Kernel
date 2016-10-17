using System.Net;
using System;

namespace Sheep.Kernel.Net
{
    public class DnsUtils
    {
        public static IPAddress[] GetIPAddress(string address)
        {
            return Dns.GetHostEntry(address).AddressList;
        }

        public static IPAddress GetFirstIPAddress(string address)
        {
            return Dns.GetHostEntry(address).AddressList[0];
        }
    }
}
