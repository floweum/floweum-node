using System;
using System.Collections.Generic;
using System.Text;

using Floweum_Node.Core;

namespace Floweum_Node
{
    public class ConsoleKey
    {
        public const string CommandHelp = "h";
        public const string CommandStatus = "s";
        public const string CommandExit = "e";

    }

    public class ClassConsole
    {
        public static void SetTitle()
        {
            Console.Title = Config.CoinName + " v" + Config.BuildVersion + " " + Config.BuildName + " | Connections: 0";
        }

        public static void CommandLine(string command)
        {
            switch (command.ToLower())
            {
                case ConsoleKey.CommandHelp:
                    ClassConsole.WriteLine("(" + ConsoleKey.CommandStatus + ") Show status - (" + ConsoleKey.CommandHelp + ") This message - (" + ConsoleKey.CommandExit + ") Exit", ConsoleColor.Blue, false);
                    break;
                case ConsoleKey.CommandExit:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void WriteLine(string text, ConsoleColor color, bool emptyTime)
        {
            if (emptyTime)
            {
                int totalLenght = DateTime.Now.ToString().Length +5;
                string totalEmpty = new String(' ', totalLenght);
                Console.Write(totalEmpty);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + DateTime.Now + "]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" - ");
            }
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.Write(Environment.NewLine);
        }
    }
}
