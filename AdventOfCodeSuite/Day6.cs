using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day6
    {
        internal int FindfirstBlockOfFour(string input)
        {
            int index = 2;
            bool blockFound = false;

            while (blockFound == false)
            {
                ++index;
                blockFound = new string(input.Substring(index - 3, 4).ToCharArray().Distinct().ToArray()).Length == 4;
            }

            return index + 1;
        }

        internal int FindfirstBlockOfFourteen(string input)
        {
            int index = 2;
            bool blockFound = false;

            while (blockFound == false)
            {
                ++index;
                blockFound = new string(input.Substring(index - 13, 14).ToCharArray().Distinct().ToArray()).Length == 14;
            }

            return index + 1;
        }
    }
}
