using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Floweum_Node.Api;
using Floweum_Node.Core;
using Newtonsoft.Json;

namespace Floweum_Node.API
{
    class ApiConnection
    {
        public static Encoding enc = Encoding.UTF8;
        public static TcpListener listener;

        public static void Connection()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, Config.ApiPort);
                listener.Start();
                ClassConsole.WriteLine("Starting API server on " + IPAddress.Any + ":" + Config.ApiPort, "API", ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta);
            }
            catch(Exception)
            {
                ClassConsole.WriteLine("Could not start server, port " + Config.ApiPort + " is already used!", "API", ConsoleColor.Red, ConsoleColor.DarkMagenta);
                return;
            }

            ClassConsole.WriteLine("API server started", "API", ConsoleColor.Green, ConsoleColor.DarkMagenta);

            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                NetworkStream networkStream = tcpClient.GetStream();
                
                string request = ToString(networkStream);
                string[] requestLines = Regex.Split(request, "\r\n");
                string getRequest = requestLines[0].Split(' ')[1];
                
                // Send Request Header
                StringBuilder responseBuilder = new StringBuilder();
                responseBuilder.AppendLine(@"HTTP/1.1 200 OK");
                responseBuilder.AppendLine(@"Content-Type: application/json");
                responseBuilder.AppendLine(@"");

                // Api Requests
                if (getRequest == ApiRequests.GET_STATUS)
                {
                    ApiStatus getStatus = new ApiStatus();
                    getStatus.version = Config.CoinNetworkVersion;
                    getStatus.result = "error";
                    responseBuilder.AppendLine(JsonConvert.SerializeObject(getStatus));
                }
                else if(getRequest == "/favicon.ico") { }
                else
                {
                    ApiError apiError = new ApiError();
                    apiError.version = Config.CoinNetworkVersion;
                    apiError.result = "error";
                    responseBuilder.AppendLine(JsonConvert.SerializeObject(apiError));
                }

                byte[] sendBytes = enc.GetBytes(responseBuilder.ToString());
                networkStream.Write(sendBytes, 0, sendBytes.Length);

                networkStream.Close();
                tcpClient.Close();
            }
        }

        public static string ToString(NetworkStream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            byte[] data = new byte[256];
            int size;
            do
            {
                size = stream.Read(data, 0, data.Length);
                if (size == 0)
                {
                    Console.WriteLine("client disconnected...");
                    Console.ReadLine();
                    return null;
                }
                memoryStream.Write(data, 0, size);
            } while (stream.DataAvailable);
            return enc.GetString(memoryStream.ToArray());
        }
    }
}
