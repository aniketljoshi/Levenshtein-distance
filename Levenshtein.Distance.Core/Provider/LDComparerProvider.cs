using System;
using System.Threading.Tasks;

namespace Levenshtein.Distance.Core
{
    public class LDComparerProvider : IComparerProvider
    {
        public Task<int> CompareAsync(string firstString, string secondString)
        {
            int fsLength = firstString.Length;
            int ssLength = secondString.Length;
            int[,] d = new int[fsLength + 1, ssLength + 1];

            // Step 1
            if (fsLength == 0)
            {
                return Task.FromResult(ssLength);
            }

            if (ssLength == 0)
            {
                return Task.FromResult(fsLength);
            }

            // Step 2
            for (int i = 0; i <= fsLength; i++)
                d[i, 0] = i;

            for (int j = 0; j <= ssLength; j++)
                d[0, j] = j;

            // Step 3
            for (int i = 1; i <= fsLength; i++)
            {
                //Step 4
                for (int j = 1; j <= ssLength; j++)
                {
                    // Step 5
                    int cost = (secondString[j - 1] == firstString[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return Task.FromResult(d[fsLength, ssLength]);
        }
    }
}