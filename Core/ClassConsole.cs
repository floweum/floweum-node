using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Floweum_Node.Core;
using Floweum_Node.Node;

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
                    ClassConsole.WriteLine("(" + ConsoleKey.CommandStatus + ") Show status - (" + ConsoleKey.CommandHelp + ") This help message - (" + ConsoleKey.CommandExit + ") Exit", "KEYCOMMAND", ConsoleColor.Blue, ConsoleColor.Blue);
                    break;
                case "t":
                    NodeServer.sentToAll("test");
                    break;
                case ConsoleKey.CommandExit:
                    Environment.Exit(0);
                    break;
            }
        }
        
        public static void WriteLine(string text, string type, ConsoleColor color, ConsoleColor color2)
        {
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[" + DateTime.Now + "] ");
            Console.ForegroundColor = color2;
            Console.Write("[" + type + "]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" - ");
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.Write(Environment.NewLine);

        }
    }
}
