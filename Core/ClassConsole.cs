using System;
using System.Drawing;
using System.Threading;
using Floweum_Node.Core;
using Floweum_Node.Node;
using Pastel;

namespace Floweum_Node
{
    public class ConsoleKey
    {
        public const string CommandHelp = "h";
        public const string CommandStatus = "s";
        public const string CommandExit = "e";
        public const string CommandTest = "t";

    }

    public class ClassConsole
    {
        public static void SetTitle(int connections)
        {
            Console.Title = Config.CoinName + " v" + Config.BuildVersion + " " + Config.BuildName + " | Connections: " + connections;
        }

        public static void CommandLine(string command)
        {
            switch (command.ToLower())
            {
                case ConsoleKey.CommandHelp:
                    ClassConsole.WriteLine("(" + ConsoleKey.CommandStatus + ") Show status - (" + ConsoleKey.CommandHelp + ") This help message - (" + ConsoleKey.CommandExit + ") Exit", "KEYCOMMAND", Color.Blue, Color.Blue);
                    break;
                case "t":
                    NodeServer.sentToAll("test");
                    break;
                case ConsoleKey.CommandExit:
                    Environment.Exit(0);
                    break;
            }
        }
        
        public static void WriteLine(string text, string type, Color color, Color color2)
        {
            string newType = "[" + type + "]";
            string newDate = "[" + DateTime.Now + "]";

            Console.WriteLine(newDate + $" {newType.Pastel(color2)} - {text.Pastel(color)}");
        }
    }
}
