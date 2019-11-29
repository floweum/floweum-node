using System;
using System.IO;
using System.Text;
using Floweum_Node.Core;

namespace Floweum_Node.Blockchain
{
    class DatabaseHandler
    {
        public static void BlockchainCheckData()
        {
            // Check if database directory exists
            if (!Directory.Exists("Blockchain"))
            {
                // If not, create it
                Directory.CreateDirectory("Blockchain");
                ClassConsole.WriteLine("Blockchain directory has been created", "BLOCKCHAIN", ConsoleColor.DarkGreen, ConsoleColor.Yellow);
            }
            else
            {
                // If it is, message and next step
                ClassConsole.WriteLine("Blockchain directory exists", "BLOCKCHAIN", ConsoleColor.DarkGreen, ConsoleColor.Yellow);

                if (File.Exists("Blockchain/" + Config.BlockchainBlocksDatabase))
                {
                    ClassConsole.WriteLine("Database file '" + Config.BlockchainBlocksDatabase + "' exists", "BLOCKCHAIN", ConsoleColor.Green, ConsoleColor.Yellow);
                }
                else
                {
                    using (var blocksFile = new StreamWriter("Blockchain/" + Config.BlockchainBlocksDatabase, true))
                    {
                        StringBuilder kevin = new StringBuilder();
                        kevin.Append("{ \"1\": \"BLOCKNO1\" }");
                        blocksFile.WriteLine(kevin.ToString());
                    }
                }

                if (File.Exists("Blockchain/" + Config.BlockchainTransactionsDatabase))
                {
                    ClassConsole.WriteLine("Database file '" + Config.BlockchainTransactionsDatabase + "' exists", "BLOCKCHAIN", ConsoleColor.Green, ConsoleColor.Yellow);
                }
                else
                {
                    using (var transactionsFile = new StreamWriter("Blockchain/" + Config.BlockchainTransactionsDatabase, true))
                    {
                        transactionsFile.WriteLine("The next line!");
                    }
                }
            }
        }
    }
}
