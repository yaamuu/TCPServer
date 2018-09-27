using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        private static readonly int PORT = 8080;
        static void Main(string[] args)
        {
            IPAddress localAddress = IPAddress.Loopback;
            // ip and port of server
            TcpListener serverSocket = new TcpListener(localAddress, PORT);
            //starting server
            serverSocket.Start();
            Console.WriteLine("TCP Server running on port " + PORT);
            while (true) // server loop keeps it running
            {
                try
                {
                    // waiting for incoming client
                    TcpClient client = serverSocket.AcceptTcpClient();
                    Console.WriteLine("incoming client");

                    //allows multiple clients
                    Task.Run(() => ClientAction.DoIt(client));
                }
                catch (IOException ex)
                {
                    Console.WriteLine("exception. will continue");

                }

            }
        }
    }
}
