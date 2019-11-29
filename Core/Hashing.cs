using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Floweum_Node
{
    class Hashing
    {
        public static string Sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        public static string MerkleTree(IList<string> merkelLeaves)
        {
            if (merkelLeaves == null || !merkelLeaves.Any())
            {
                return string.Empty;
            }

            if (merkelLeaves.Count() == 1)
            {
                return merkelLeaves.First();
            }

            if (merkelLeaves.Count() % 2 > 0)
            {
                merkelLeaves.Add(merkelLeaves.Last());
            }

            var merkleBranches = new List<string>();

            for (int i = 0; i < merkelLeaves.Count(); i += 2)
            {
                var leafPair = string.Concat(merkelLeaves[i], merkelLeaves[i + 1]);
                merkleBranches.Add(Hashing.Sha256(Hashing.Sha256(leafPair)));
            }
            return MerkleTree(merkleBranches);
        }
    }
}
