using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyChatroom
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 3009;

            Console.WriteLine("====================================");
            var listener = new TcpListener(IPAddress.Any, port);

            try
            {
                Console.WriteLine("Server start at port {0}", port);
                listener.Start();
                Console.WriteLine("Waiting for a connection");
                var client = listener.AcceptTcpClient();

                var address = client.Client.RemoteEndPoint.ToString();
                Console.WriteLine("Client has connected from {0}", address);

                client.Close();
                Console.WriteLine("Disconnect client {0}", address);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException:{0}", e);
            }
            finally
            {
                listener.Stop();
                Console.WriteLine("Server shutdown");
            }
        }
    }
}
