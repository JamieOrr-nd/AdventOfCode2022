using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day5
    {
        internal string TrackStacks9000(string input)
        {
            var inputList = input.Split("\r\n");
            var stackList = new List<Stack<string>>()
            {
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
            };
            string result = "";

            List<Stack<string>> PopAndPush(int amount, int from, int to)
            {
                string toBePushed = "";

                for (int i = 0; i < amount; i++)
                {
                    toBePushed = toBePushed + stackList[from - 1].Peek();
                    stackList[from - 1].Pop();
                }
                
                foreach (char item in toBePushed)
                {
                    stackList[to - 1].Push(item.ToString());
                }

                return stackList;
            }

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (inputList[i][(4 * j) + 1] != ' ')
                    {
                        stackList[j].Push(inputList[i][(4 * j) + 1].ToString());
                    }
                } 
            }

            for (int i = 10; i < inputList.Count(); i++)
            {
                var movingInfo = inputList[i].Split(' ');
                int amount = int.Parse(movingInfo[1]);
                int from = int.Parse(movingInfo[3]);
                int to = int.Parse(movingInfo[5]);

                PopAndPush(amount, from, to);
            }

            foreach (var stack in stackList)
            {
                result += stack.Count == 0 ? "" : stack.Peek();
            }

            return result;
        }

        internal string TrackStacks9001(string input)
        {
            var inputList = input.Split("\r\n");
            var stackList = new List<Stack<string>>()
            {
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
                new Stack<string>(),
            };
            string result = "";

            List<Stack<string>> PopAndPush(int amount, int from, int to)
            {
                string toBePushed = "";

                for (int i = 0; i < amount; i++)
                {
                    toBePushed = stackList[from - 1].Peek() + toBePushed;
                    stackList[from - 1].Pop();
                }

                foreach (char item in toBePushed)
                {
                    stackList[to - 1].Push(item.ToString());
                }

                return stackList;
            }

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (inputList[i][(4 * j) + 1] != ' ')
                    {
                        stackList[j].Push(inputList[i][(4 * j) + 1].ToString());
                    }
                }
            }

            for (int i = 10; i < inputList.Count(); i++)
            {
                var movingInfo = inputList[i].Split(' ');
                int amount = int.Parse(movingInfo[1]);
                int from = int.Parse(movingInfo[3]);
                int to = int.Parse(movingInfo[5]);

                PopAndPush(amount, from, to);
            }

            foreach (var stack in stackList)
            {
                result += stack.Count == 0 ? "" : stack.Peek();
            }

            return result;
        }
    }
}
