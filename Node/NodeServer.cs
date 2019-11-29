using Floweum_Node.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Floweum_Node.Node
{
    class NodeServer
    {
        public static List<Socket> clientSockets = new List<Socket>();
        public static int connections = 0;
        public static void Open()
        {
            int backlog = -1, port = Config.Port;

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ReceiveTimeout = -1;

            // Start listening.
            try
            {
                ClassConsole.WriteLine("Starting node server on address " + IPAddress.Any + ":" + Config.Port, "NODE_SRV", ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);
                server.Bind(new IPEndPoint(IPAddress.Any, port));
                server.Listen(backlog);
            }
            catch (Exception)
            {
                ClassConsole.WriteLine("Could not start server, port " + Config.Port + " is already used!", "NODE_SRV", ConsoleColor.Red, ConsoleColor.DarkCyan);
                return;
            }

            ClassConsole.WriteLine("Node server started", "NODE_SRV", ConsoleColor.Green, ConsoleColor.DarkCyan);

            while (true)
            {
                // If connection is made with client
                Socket client = server.Accept();
                new System.Threading.Thread(() => {
                    try
                    {
                        clientSockets.Add(client); connections = (connections + 1);
                        Process(client);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "An existing connection was forcibly closed by the remote host.")
                        {
                            connections = (connections - 1);
                            ClassConsole.SetTitle(connections);
                            ClassConsole.WriteLine("Node disconnected from address " + client.RemoteEndPoint, "NODE_SRV", ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);
                        }
                        else
                        {
                            ClassConsole.WriteLine("Client connection processing error: " + ex.Message, "NODE_SRV", ConsoleColor.Red, ConsoleColor.DarkCyan);
                        }
                    }
                }).Start();
            }
        }

        public static void sentToAll(string s)
        {
            foreach (Socket socket in clientSockets)
            {
                byte[] data = Encoding.ASCII.GetBytes(s);
                socket.Send(data);
            }
        }

        static void Process(Socket client)
        {
            ClassConsole.SetTitle(connections);
            ClassConsole.WriteLine("Node connected from address " + client.RemoteEndPoint, "NODE_SRV", ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);

            const int maxMessageSize = 1024;
            byte[] response;
            int received;

            //client.Send(Encoding.ASCII.GetBytes("FromServer7"));

            while (true)
            {
                // Receive message from the server:
                response = new byte[maxMessageSize];
                received = client.Receive(response);

                List<byte> respBytesList = new List<byte>(response);
                respBytesList.RemoveRange(received, maxMessageSize - received); // truncate zero end
                if(Encoding.ASCII.GetString(respBytesList.ToArray()) == "")
                {
                    connections = (connections - 1);
                    ClassConsole.SetTitle(connections);
                    ClassConsole.WriteLine("Node disconnected from address " + client.RemoteEndPoint, "NODE_SRV", ConsoleColor.DarkGreen, ConsoleColor.DarkCyan);
                    client.Close();
                    return;
                } else
                {
                    ClassConsole.WriteLine("[" + client.RemoteEndPoint + "] " + Encoding.ASCII.GetString(respBytesList.ToArray()), "NODE_SRV", ConsoleColor.DarkBlue, ConsoleColor.DarkCyan);
                }
            }

            /*while (true)
            {

                // Send message to the client:
                client.Send(Encoding.ASCII.GetBytes("FromServer"));

                // Receive message from the server:
                response = new byte[maxMessageSize];
                received = client.Receive(response);
                
                List<byte> respBytesList = new List<byte>(response);
                respBytesList.RemoveRange(received, maxMessageSize - received); // truncate zero end
                Console.WriteLine("[SRV] [" + client.RemoteEndPoint + "] Client->Server: " + Encoding.ASCII.GetString(respBytesList.ToArray()));
            }*/
        }
    }
}
