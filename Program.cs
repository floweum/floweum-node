using System;
using System.Text;
using System.Threading;

using Floweum_Node.Core;

namespace Floweum_Node
{
    class Program
    {
        private static Thread ConsoleReadLine;

        static void Main(string[] args)
        {
            ClassConsole.SetTitle();
            ConsoleKeyCommand();
        }

        private static void ConsoleKeyCommand()
        {
            ConsoleReadLine = new Thread(delegate ()
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
