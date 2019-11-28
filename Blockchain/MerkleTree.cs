using System.Collections.Generic;
using System.Linq;

namespace Floweum_Node.Blockchain
{
    class MerkleTree
    {
        public static string CreateHash(IList<string> merkelLeaves)
        {
            if (merkelLeaves == null || !merkelLeaves.Any())

                return string.Empty;

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
            return CreateHash(merkleBranches);
        }
    }
}
