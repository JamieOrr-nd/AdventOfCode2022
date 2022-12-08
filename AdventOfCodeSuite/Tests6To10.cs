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
    }
}
