using System;
using System.Reflection;

namespace Floweum_Node.Core
{
    class Config
    {
        public static void LogoText()
        {
            Console.WriteLine(@"  ______ _                                   ");
            Console.WriteLine(@" |  ____| |                                  ");
            Console.WriteLine(@" | |__  | | _____      _____ _   _ _ __ ___  ");
            Console.WriteLine(@" |  __| | |/ _ \ \ /\ / / _ \ | | | '_ ` _ \ ");
            Console.WriteLine(@" | |    | | (_) \ V  V /  __/ |_| | | | | | |");
            Console.WriteLine(@" |_|    |_|\___/ \_/\_/ \___|\__,_|_| |_| |_|" + Environment.NewLine);
            Console.WriteLine(@" v" + BuildVersion + " BUILD " + BuildName + Environment.NewLine);
        }

        public static string CoinName                       = "Floweum";         // Coin name
        public static string CoinTicker                     = "FLOW";            // Coin ticker
        public static string CoinNetworkId                  = "FLW10NET";        // Network ID - Must be 8 chars
        public static int    CoinNetworkVersion             = 1000;              // Network Version - Must be 4 chars
        public static string BuildVersion                   = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string BuildName                      = "RedAmazon";       // Build name
        /*public static int    DifficultTarget                = 600;               // 10 Minute block time
        public static int    MoneySupply                    = 11000000;          // 11 Million Coins - Not in atomic units
        public static int    AtomicUnits                    = 100000000;         // 1 FLOW
        public static int[]  HalveningBlocks = {                                 // Halvening of the block reward
            105120,                                                              // Halvening from 50 FLOW -> 25 FLOW at block 105120 blocks. Approx 2 years from creation
            210240                                                               // Halvening from 25 FLOW -> 12.5 FLOW at block 210240 blocks. Approx 4 years from creation
        };
        public static long   BlockReward                    = 5000000000;        // 50.00000000 FLOW reward - In atomic units */
        public static long   GenesisBlockReward             = 5500000000000;     // 0,50% premine - 55000.00000000 FLOW - In atomic units
        public static string GenesisBlockWallet             = "FLOWajELTh4wpmLCCWTP3Ky02MH4D7Yx2Rc2YEEHLw4YGDo9p8OgIc7AMCtfAfAq";
        /*public static string WalletPrefix                   = "FLOW";            // Begin of the wallet address, 'FLOW...'
        public static int    BlockUnlock                    = 3;                 // Block unlocked after 3 confirmations */
        public static int    Port                           = 4222;              // Port of the node
        public static int    ApiPort                        = 4223;              // Port of the api
        public static string BlockchainTransactionsDatabase = "transactions.flowdb";
        public static string BlockchainBlocksDatabase       = "blocks.flowdb";
        public static string[] SeedNodes = {
            "127.0.0.1",
            "192.168.178.1"
        };
    }
}
