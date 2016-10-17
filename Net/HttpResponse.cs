using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sheep.Kernel.Net
{
    public class HttpResponse : IResponse
    {
        private HttpMetadata metadata;

        public HttpResponse(HttpMetadata metadata)
        {
            this.metadata = metadata;
        }

        public string ParseResponse(IPEndPoint endpoint, object client)
        {
            Socket clientSocket = (Socket)client;
            CancellationTokenSource source = new CancellationTokenSource();
            Task<string> myTask = Task.Factory.StartNew<string>(new Func<object, string>(ReadResponseHeader), client, source.Token);
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
                    //    return ParseResponse(endpoint, socket, metadata);
                    //}
                }
                else if (header.StartsWith("HTTP/1.1 200"))
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
                            if (clientSocket.Receive(bytes) > 0)
                            {
                                return metadata.Response_Charset.GetString(bytes);
                            }
                        }
                    }
                    else
                    {
                        return metadata.Response_Charset.GetString(ParseResponseBody(clientSocket));
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

        private string ReadResponseHeader(object socket)
        {
            Socket clientSocket = (Socket)socket;
            StringBuilder bulider = new StringBuilder();
            while (true)
            {
                byte[] buff = new byte[1];
                int read = clientSocket.Receive(buff, SocketFlags.None);
                if (read > 0)
                {
                    bulider.Append((char)buff[0]);
                }
                string temp = bulider.ToString();
                if (temp.Contains("\r\n\r\n"))
                {
                    break;
                }
            }
            return bulider.ToString();
        }

        private byte[] ParseResponseBody(Socket clientSocket)
        {
            ArrayList array = new ArrayList();
            StringBuilder bulider = new StringBuilder();
            int length = 0;
            while (true)
            {
                byte[] buff = new byte[1024];
                int len = clientSocket.Receive(buff);
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
                Array.Copy(temp, 0, bytes, index, temp.Length); //Buffer.BlockCopy(temp, 0, bytes, index, temp.Length);
                index += temp.Length;
            }
            return bytes;
        }
    }
}
