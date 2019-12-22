using Floweum_Node.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Floweum_Node.Node
{
    class NodeClient
    {
        public static int seedNodeListNo = 0;
        public static void Connect(string ip)
        {
            IPEndPoint serverEp = new IPEndPoint(IPAddress.Parse(ip), Config.Port);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ReceiveTimeout = -1;

            ClassConsole.WriteLine("Connecting to seed node " + (seedNodeListNo +1) + " on address " + Config.SeedNodes[seedNodeListNo] + ":" + Config.Port, "NODE_CLI", Colors.DarkYellow, Colors.Cyan);
            

            // Connect to the server.
            try { server.Connect(serverEp); }
            catch (Exception)
            {
                // Error connecing to server
                ClassConsole.WriteLine("Could not connect to " + serverEp + "!", "NODE_CLI", Colors.Red, Colors.Cyan);
                if (seedNodeListNo == Config.SeedNodes.Length - 1) { seedNodeListNo = 0; } else { seedNodeListNo = seedNodeListNo+1; }
                Connect(Config.SeedNodes[seedNodeListNo]);
                return;
            }

            // Connected
            ClassConsole.WriteLine("Connected to seed node " + (seedNodeListNo + 1) + " on address " + serverEp, "NODE_CLI", Colors.Green, Colors.Cyan);
            WorkWithServer(server);
        }

        static void WorkWithServer(Socket server)
        {

            const int maxMessageSize = 1024;
            byte[] response;
            int received;

            // Send message
            //server.Send(Encoding.ASCII.GetBytes("FromClient"));

            while (true)
            {
                try
                {
                    // Receive message from the server:
                    response = new byte[maxMessageSize];
                    received = server.Receive(response);

                    List<byte> respBytesList = new List<byte>(response);
                    respBytesList.RemoveRange(received, maxMessageSize - received); // truncate zero end
                    Console.WriteLine("[NODE_CLI] Server->Client: " + Encoding.ASCII.GetString(respBytesList.ToArray()));

                    // Send message to the server:
                    server.Send(Encoding.ASCII.GetBytes("FromClient"));
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[NODE_CLI] Error: " + ex.Message);
                    seedNodeListNo = 0;
                    Connect(Config.SeedNodes[seedNodeListNo]);
                    return;
                }
            }
        }
    }
}
