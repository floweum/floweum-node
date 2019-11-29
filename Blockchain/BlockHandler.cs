using System;
using System.Collections.Generic;

using Floweum_Node.Core;

namespace Floweum_Node.Blockchain
{
    class BlockHandler
    {
        public static void CreateBlock()
        {
            int StandardSize = 266;
            int Difficulty = 1;
            int Nonce = 2;
            string ToAddress;
            string FromAddress;
            string Amount;
            string Fee;
            string Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString().PadLeft(16, '0');

            List<String> Block = new List<String>();
            List<String> BlockHeader = new List<String>();
            List<String> Transactions = new List<String>();
            List<String> TransactionHashes = new List<String>();

            // Block
            Block.Add(Conversion.Hex(Config.CoinNetworkId));        // Network ID
            Block.Add(StandardSize.ToString().PadLeft(8, '0'));     // Block Size
            Block.Add("");                                          // Block Header
            Block.Add(Conversion.Hex("0001"));                      // Total Transactions
            Block.Add("");                                          // Transactions

            // Block Header
            BlockHeader.Add(Config.CoinNetworkVersion.ToString().PadLeft(4, '0'));  // Network Version 
            BlockHeader.Add("".PadLeft(64, '0'));                                   // Last block
            BlockHeader.Add("");                                                    // Merkle Root
            BlockHeader.Add(Timestamp);                                             // Block timestamp
            BlockHeader.Add(Difficulty.ToString().PadLeft(16, '0'));                // Difficulty
            BlockHeader.Add(Nonce.ToString().PadLeft(16, '0'));                     // Nonce

            // Transaction 1
            ToAddress = Conversion.Hex(Config.GenesisBlockWallet);
            FromAddress = Conversion.Hex(Config.CoinTicker.PadRight(64, 'a'));
            Amount = Conversion.Hex(Config.GenesisBlockReward.ToString().PadLeft(16, '0'));
            Fee = Conversion.Hex("0".PadLeft(16, '0'));
            Transactions.Add(ToAddress);    // To Address
            Transactions.Add(FromAddress);  // From Address
            Transactions.Add(Amount);       // Amount
            Transactions.Add(Fee);          // Fee
            TransactionHashes.Add(Hashing.Sha256(ToAddress + FromAddress + Amount + Fee));

            BlockHeader[2] = Hashing.MerkleTree(TransactionHashes); // Add Merkle Tree to Block Header
            Block[2] = string.Join("", BlockHeader);                // Add Block Header to Block
            Block[4] = string.Join("", Transactions);               // Add Transactions to Block

            Console.WriteLine(string.Join("", Block));
        }
    }
}
