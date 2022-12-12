using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day7
    {
        internal int DirectoriesUnder100000(string input)
        {
            string[] inputList = input.Split("\r\n");

            Stack<string> currentDirectory = new Stack<string>();
            currentDirectory.Push("/");

            int maxDepth = 1;
            int depthTracker = 1;

            List<string> directoryTracker = new List<string>() { "/" };
            List<List<dynamic>> directoryInfo = new List<List<dynamic>>();

            int result = 0;

            foreach (string line in inputList)
            {
                string lineStart = line[0].ToString();
                switch (lineStart)
                {
                    case "$":
                        if (line[2] == 'c' && line.Substring(5) != ".." && line.Substring(5) == "/")
                        {
                            string folder = line.Substring(5);

                            // directoryInfo elements go 'folder name', 'parent folder', 'depth', 'visits', 'size total'
                            directoryInfo.Add(new List<dynamic>() { folder, "root", depthTracker, 0, 0, "" });

                            directoryInfo[0][3]++;
                        }
                        if (line[2] == 'c' && line.Substring(5) != ".." && line.Substring(5) != "/")
                        {
                            string folder = line.Substring(5);
                            depthTracker++;
                            maxDepth = depthTracker > maxDepth ? depthTracker : maxDepth;

                            // directoryInfo elements go 'folder name', 'parent folder', 'depth', 'visits', 'size total'
                            directoryInfo.Add(new List<dynamic>() { folder, currentDirectory.Peek(), depthTracker, 0, 0, "" });
                            currentDirectory.Push(folder);
                            directoryTracker.Add(folder);

                            // find index of current directory in directoryInfo by its name, parent, and depth
                            int index = directoryInfo.FindIndex(a => a[0] == currentDirectory.Peek() &&
                            a[1] == directoryTracker[directoryTracker.Count() - 2] &&
                            a[2] == depthTracker);

                            // if folder is found. add 1 to amount of times it's been visited
                            if (index != -1)
                            {
                                directoryInfo[index][3]++;
                            }
                        }
                        if (line[2] == 'c' && line.Substring(5) == "..")
                        {
                            currentDirectory.Pop();
                            directoryTracker.RemoveAt(directoryTracker.Count() - 1);
                            depthTracker--;

                            if (depthTracker == 1)
                            {
                                directoryInfo[0][3]++;
                                break;
                            }

                            // find index of current directory in directoryInfo by its name, parent, and depth
                            int index1 = directoryInfo.FindIndex(a => a[0] == currentDirectory.Peek() &&
                            a[1] == directoryTracker[directoryTracker.Count() - 2] &&
                            a[2] == depthTracker);

                            // if folder is found. add 1 to amount of times it's been visited
                            if (index1 != -1)
                            {
                                directoryInfo[index1][3]++;
                            }

                        }
                        break;
                    case "d":
                        if (depthTracker == 1)
                        {
                            directoryInfo[0][5] += line.Substring(4) + " ";
                            break;
                        }

                        int index2 = directoryInfo.FindIndex(a => a[0] == currentDirectory.Peek() &&
                            a[1] == directoryTracker[directoryTracker.Count() - 2] &&
                            a[2] == depthTracker);

                        // if folder is found and it has not been visited before, add the file size
                        if (index2 != -1 && directoryInfo[index2][3] < 2)
                        {
                            directoryInfo[index2][5] += line.Substring(4) + " ";
                        }
                        break;
                    default:
                        // split line by the space. Fisrt element is size, second is file name
                        var fileAndSize = line.Trim().Split(' ');

                        if (depthTracker == 1)
                        {
                            break;
                        }

                        // find index of current directory in directoryInfo by its name, parent, and depth
                        int index3 = directoryInfo.FindIndex(a => a[0] == currentDirectory.Peek() &&
                            a[1] == directoryTracker[directoryTracker.Count() - 2] &&
                            a[2] == depthTracker);

                        // if folder is found and it has not been visited before, add the file size
                        if (index3 != -1 && directoryInfo[index3][3] < 2)
                        {
                            directoryInfo[index3][4] += int.Parse(fileAndSize[0]);
                        }

                        break;
                }

            }
            // store a value on each folder for how 'deep' it is in file system
            // store a running value for 'deepest' level of folder
            // use directTotal to store value of file sizes in the immediate parent

            int FindFolderSize(string name, string parent, int depth)
            {
                int folderIndex = directoryInfo.FindIndex(a => a[0] == name &&
                            a[1] == parent &&
                            a[2] == depth);

                int folderTotal = directoryInfo[folderIndex][4];

                string children = directoryInfo[folderIndex][5];

                if (children.Length > 0)
                {
                    foreach (var child in children.Trim().Split(" "))
                    {
                        folderTotal += FindFolderSize(child, name, depth + 1);
                    }
                }

                directoryInfo[folderIndex][4] = folderTotal;

                return folderTotal;
            }

            int fullTotal = FindFolderSize("/", "root", 1);

            int minimumToUpdate = 30000000 - (70000000 - fullTotal);
            int currentSmallest = fullTotal;

            foreach (var folder in directoryInfo)
            {
                // Look for total of directories under 100000
                result += folder[4] <= 100000 ? folder[4] : 0;

                // Look for smallest folder that, if deleted, would make total free space >= 30000000
                // currentSmallest = folder[4] >= minimumToUpdate && folder[4] < currentSmallest ? folder[4] : currentSmallest;
            }

            return result;
        }
    }
}
