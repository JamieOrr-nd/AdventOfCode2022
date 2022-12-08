using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day3
    {
        // ascii value of character is found by casting it as an int
        // lowercase letters have priority 1-26, which means we need to subtract 96 from the ascii
        // uppercase letters have priority 27-52, which means we need to subtract 38 from the ascii

        internal int TotalPriorities(string input)
        {
            var inputList = input.Split("\r\n");
            var priorityTotal = 0;

            foreach (var rucksack in inputList)
            {
                string compartment1 = rucksack[..(rucksack.Length / 2)];
                string compartment2 = rucksack.Substring(rucksack.Length / 2);
                var overlap = compartment1.Intersect(compartment2).ToList();

                foreach (char item in overlap)
                {
                    priorityTotal += item == char.ToUpper(item) ? item - 38 : item - 96;
                }
            }

            return priorityTotal;
        }

        internal int TotalPrioritiesByGroup(string input)
        {
            var inputList = input.Split("\r\n");
            var priorityTotal = 0;

            for (int i = 0; i < inputList.Length; i += 3)
            {
                var overlap = inputList[i].Intersect(inputList[i + 1]).ToList();

                foreach (char letter in overlap)
                {
                    if (inputList[i + 2].Contains(letter))
                    {
                        priorityTotal += letter == char.ToUpper(letter) ? letter - 38 : letter - 96;
                    }
                }
            }

            return priorityTotal;
        }
    }
}
