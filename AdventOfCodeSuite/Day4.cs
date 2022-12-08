using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day4
    {
        internal int FullyContainedSections(string input)
        {
            int result = 0;
            var inputList = input.Split("\r\n");

            foreach (var pair in inputList)
            {
                string range1 = pair.Substring(0, pair.IndexOf(','));
                string range2 = pair.Substring(pair.IndexOf(',') + 1);

                int range11 = int.Parse(range1.Substring(0, range1.IndexOf('-')));
                int range12 = int.Parse(range1.Substring(range1.IndexOf('-') + 1));
                int range21 = int.Parse(range2.Substring(0, range2.IndexOf('-')));
                int range22 = int.Parse(range2.Substring(range2.IndexOf('-') + 1));

                result += (range11 <= range21 && range12 >= range22) 
                    || (range21 <= range11 && range22 >= range12) ? 1 : 0;
            }

            return result;
        }

        internal int OverlappingSections(string input) 
        {
            int result = 0;
            var inputList = input.Split("\r\n");

            foreach (var pair in inputList)
            {
                string range1 = pair.Substring(0, pair.IndexOf(','));
                string range2 = pair.Substring(pair.IndexOf(',') + 1);

                int range11 = int.Parse(range1.Substring(0, range1.IndexOf('-')));
                int range12 = int.Parse(range1.Substring(range1.IndexOf('-') + 1));
                int range21 = int.Parse(range2.Substring(0, range2.IndexOf('-')));
                int range22 = int.Parse(range2.Substring(range2.IndexOf('-') + 1));

                result += range12 < range21 || range22 < range11 ? 0 : 1;
            }

            return result;
        }

    }
}
