using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Floweum_Node.Core
{
    class Config
    {
        /* This will be the name of your coin */
        public static string CoinName = "Floweum";
        /* This will be the coin's ticker. Maximum of 5 characters */
        public static string CoinTicker = "FLOW";
        /* This will get the build version of the node. You can edit this in 'Floweum Node.csproj' */
        public static string BuildVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /* This will be the build name of the node. U can change this to anything u want */
        public static string BuildName = "RedAmazon";
        /* Kanker */

    }
}
