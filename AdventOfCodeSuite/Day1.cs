using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day1
    {
        public int TopCalorieCounter(string input)
        {
            int currentHighest = 0;
            int currentTotal = 0;

            var elves = input.Split("\r\n\r\n");

            foreach (var elf in elves)
            {
                var calories = elf.Split("\r\n");
                foreach (string cal in calories)
                {
                    currentTotal += Int32.Parse(cal);
                }

                currentHighest = currentTotal > currentHighest ? currentTotal : currentHighest;
                currentTotal = 0;
            }

            return currentHighest;
        }

        public int Top3CalorieCounter(string input)
        {
            int currentHighest = 0;
            var allHighest = new List<int>() { currentHighest };
            int currentTotal = 0;
            int top3Total = 0;

            var elves = input.Split("\r\n\r\n");

            
            foreach (var elf in elves)
            {
                var calories = elf.Split("\r\n");
                foreach (string cal in calories)
                {
                    currentTotal += Int32.Parse(cal);
                }

                allHighest.Add(currentTotal);
                
                currentTotal = 0;
            }

            var orderedElves = allHighest.OrderByDescending(x => x).Take(3);
            foreach (var total in orderedElves)
            {
                top3Total += total;
            }

            return top3Total;
        }
    }
}

