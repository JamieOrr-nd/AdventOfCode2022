using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day8
    {
        internal int FindVisibleTrees(string input)
        {
            string[] inputList = input.Split("\r\n");
            int[,] visibleTrees = new int[inputList.Length, inputList[0].Length];

            int result = 0;
            result += (2 * inputList.Length) + (2 * inputList[0].Length) - 4;

            // each row, right and left to the highest tree
            for (int row = 1; row < inputList.Length - 1; row++)
            {
                var rowList = inputList[row].Select(x => int.Parse(x.ToString())).ToList();
                int indexOfMax = rowList.IndexOf(rowList.Max()); // store this value and which row it is, for going left 
                int currentMax = rowList[0];

                // from left side to highest in-row value
                for (int i = 1; i <= indexOfMax; i++)
                {
                    visibleTrees[row, i] = rowList[i] > currentMax ? 1 : 0;
                    currentMax = rowList[i] > currentMax ? rowList[i] : currentMax;
                }

                // reset currentMax to first element from the right
                currentMax = rowList[rowList.Count() - 1];

                // from right side to highest in-row value
                for (int i = rowList.Count() - 2; i > indexOfMax; i--)
                {
                    visibleTrees[row, i] = rowList[i] > currentMax ? 1 : 0;
                    currentMax = rowList[i] > currentMax ? rowList[i] : currentMax;
                }
            }

            // each column, up and down
            for (int col = 1; col < inputList[0].Length - 1; col++)
            {
                int currentMax = int.Parse(inputList[0][col].ToString());

                // from top to bottom
                for (int i = 1; i < inputList.Length - 1; i++)
                {
                    int currentTree = int.Parse(inputList[i][col].ToString());
                    visibleTrees[i, col] = currentTree > currentMax ? 1 : visibleTrees[i, col];
                    currentMax = currentTree > currentMax ? currentTree : currentMax;
                }

                // reset currentMax to first element from the bottom
                currentMax = int.Parse(inputList[inputList.Length - 1][col].ToString());

                // from bottom to top
                for (int i = inputList.Length - 2; i > 0; i--)
                {
                    int currentTree = int.Parse(inputList[i][col].ToString());
                    visibleTrees[i, col] = currentTree > currentMax ? 1 : visibleTrees[i, col];
                    currentMax = currentTree > currentMax ? currentTree : currentMax;
                }
            }

            foreach (int tree in visibleTrees)
            {
                result += tree == 1 ? 1 : 0;
            }

            return result;
        }
    }
}
