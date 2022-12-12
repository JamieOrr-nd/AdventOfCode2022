// See https://aka.ms/new-console-template for more information

// input (if any)
using AdventOfCode;
using System;

//InputVariables inputVariables = new InputVariables();
string input = File.ReadAllText("C:\\repos\\AdventOfCode2022\\AdventOfCode\\Day8Input.txt");

// My code
string[] inputList = input.Split("\r\n");
int[,] visibleTrees = new int[inputList.Length, inputList[0].Length];

int result = 0;
result += (2 * inputList.Length) + (2 * inputList[0].Length) - 4;

// each row, right and left to the highest tree
for (int row = 0; row < inputList.Length; row++)
{
    var rowList = inputList[row].Select(x => int.Parse(x.ToString())).ToList();
    int indexOfMax = rowList.IndexOf(rowList.Max()); // store this value and which row it is, for going left 
    int currentMax = rowList[0];

    // from left side to highest in-row value
    for (int i = 0; i <= indexOfMax; i++)
    {
        visibleTrees[row, i] = rowList[i] > currentMax ? 1 : 0;
        currentMax = rowList[i] > currentMax ? rowList[i] : currentMax;
    }

    // reset currentMax to first element from the right
    currentMax = rowList[rowList.Count() - 1];

    // from right side to highest in-row value
    for (int i = rowList.Count() - 1; i > indexOfMax; i--)
    {
        visibleTrees[row, i] = rowList[i] > currentMax ? 1 : 0;
        currentMax = rowList[i] > currentMax ? rowList[i] : currentMax;
    }
}

// each column, up and down
for (int col = 0; col < inputList[0].Length; col++)
{
    int currentMax = 0;

    // from top to bottom
    for (int i = 0; i < inputList.Length; i++)
    {
        int currentTree = int.Parse(inputList[i][col].ToString());
        visibleTrees[i, col] = currentTree > currentMax ? 1 : visibleTrees[i, col];
        currentMax = inputList[i][col] > currentMax ? inputList[i][col] : currentMax;
    }

    // reset currentMax to first element from the bottom
    currentMax = int.Parse(inputList[inputList.Length - 1][col].ToString());

    // from bottom to top
    for (int i = inputList.Length - 1; i >= 0; i--)
    {
        int currentTree = int.Parse(inputList[i][col].ToString());
        visibleTrees[i, col] = inputList[i][col] > currentMax ? 1 : visibleTrees[i, col];
        currentMax = inputList[i][col] > currentMax ? inputList[i][col] : currentMax;
    }
}

foreach (int tree in visibleTrees)
{
    result += tree == 1 ? 1 : 0;
}

// write answer to console
Console.WriteLine(result);
