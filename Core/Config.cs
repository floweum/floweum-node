using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Floweum_Node.Core
{
    class Config
    {
        public static string CoinName                       = "Floweum";         // Coin name
        public static string CoinTicker                     = "FLOW";            // Coin ticker
        public static string CoinNetworkId                  = "FLOWV100NET";     // Network ID
        public static string BuildVersion                   = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string BuildName                      = "RedAmazon";       // Build name
        public static int    DifficultTarget                = 600;               // 10 Minute block time
        public static int    MoneySupply                    = 11000000;          // 10 Million Coins
        public static int    Decimals                       = 8;                 // 8 Decimals
        public static int    AtomicUnits                    = 100000000;         // 1 FLOW 
        public static bool   Halvening                      = true;              // Enable or disable halvening
        public static int    HalveningBlocks                = 105120;            // Halvening ever 105120 block. Approx 2 years
        public static long   BlockReward                    = 5000000000;        // 50.00000000 FLOW reward
        public static int    GenesisBlockReward             = 11000;             // 0,10% premine
        public static int    GenesisBlockTimestamp          = 1545261161;        // First block timestamp
        public static string GenesisBlockWallet             = "FLOWf826ee21e3fb1087adb747dbedfc8de0";
        public static int    WalletLength                   = 64;                // Wallet lenght including prefix
        public static string WalletPrefix                   = "FLOW";            // Begin on the wallet 'FLOW...'
        public static int    BlockUnlock                    = 3;                 // Block unlocked after 3 confirmations
        public static int    Port                           = 4222;              // Port of the node
        public static string BlockchainTransactionsDatabase = "transactions.flowdb";
        public static string BlockchainBlocksDatabase       = "blocks.flowdb";
        public static string[] SeedNodes = {
            "127.0.0.1:4222"
        };
    }
}
