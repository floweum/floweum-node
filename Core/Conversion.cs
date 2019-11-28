using System;
using System.Collections.Generic;
using System.Text;

namespace Floweum_Node.Core
{
    class Conversion
    {
        public static string Hex(string text)
        {
            StringBuilder hex = new StringBuilder();
            foreach (char c in text)
            {
                hex.Append(BitConverter.ToString(new byte[] { Convert.ToByte(c) }));
            }
            return hex.ToString();
        }
    }
}
