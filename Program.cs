using System;
using System.Text;
using System.Threading;

using Floweum_Node.API;
using Floweum_Node.Blockchain;
using Floweum_Node.Core;
using Floweum_Node.Node;

namespace Floweum_Node
{
    class Program
    {
        public static Thread ApiThread;
        public static Thread NodeServerConnection;
        public static Thread NodeClientConnection;
        
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            ClassConsole.SetTitle(0);

            Config.LogoText();

            // Blockchain check
            DatabaseHandler.BlockchainCheckData();

            // Start node server
            StartNodeServer();

            // Start node client
            StartNodeClient();

            // Start api server
            StartApiConnection();

            //BlockHandler.CreateBlock();
            
            // Console key commands
            ConsoleKeyCommand();
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
        }

        public static void StartApiConnection()
        {
            ApiThread = new Thread(delegate ()
            {
                Thread.Sleep(1250);
                ApiConnection.Connection();
            });
            ApiThread.Start();
        }

        public static void StartNodeServer()
        {
            NodeServerConnection = new Thread(delegate ()
            {
                NodeServer.Open();
            });
            NodeServerConnection.Start();
        }

        public static void StartNodeClient()
        {
            NodeClientConnection = new Thread(delegate ()
            {
                Thread.Sleep(750);
                NodeClient.Connect(Config.SeedNodes[0]);
            });
            NodeClientConnection.Start();
        }

        private static void ConsoleKeyCommand()
        {
            Thread ConsoleReadLine = new Thread(delegate ()
            {
                while (true)
                {
                    try
                    {
                        StringBuilder input = new StringBuilder();
                        var key = Console.ReadKey(true);
                        input.Append(key.KeyChar);
                        ClassConsole.CommandLine(input.ToString());
                        input.Clear();
                    } catch { }
                }
            });
            ConsoleReadLine.Start();
        }
    }
}
