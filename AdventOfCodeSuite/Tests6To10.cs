using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    public class Tests6To10
    {
        [Theory]
        [InlineData("abcabcabcd", 10)]
        public void Day6Puzzle1(string input, int result)
        {
            // Arrange
            Day6 day6 = new Day6();

            // Act 
            int expected = result;
            int actual = day6.FindfirstBlockOfFour(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcabcabcd", 10)]
        public void Day7Puzzle1(string input, int result)
        {
            // Arrange
            Day6 day6 = new Day6();

            // Act 
            int expected = result;
            int actual = day6.FindfirstBlockOfFour(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        // 12345
        // 54321
        // 13524
        // 12345
        // 54321

        [Theory]
        [InlineData("12345\r\n54321\r\n13524", 15)]
        [InlineData("12345\r\n54321\r\n13524\r\n12345\r\n54321\r\n13524", 31)]
        [InlineData("55555\r\n55555\r\n55555\r\n55555\r\n55555", 16)]
        public void Day8Puzzle1(string input, int result)
        {
            // Arrange
            Day8 day8 = new Day8();

            // Act 
            int expected = result;
            int actual = day8.FindVisibleTrees(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
