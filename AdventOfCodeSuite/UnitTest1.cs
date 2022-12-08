namespace AdventOfCodeSuite
{
    public class Days1To5
    {
        [Theory]
        [InlineData("1\r\n2\r\n\r\n3\r\n4\r\n\r\n5\r\n6", 11)]
        [InlineData("99\r\n1\r\n\r\n3\r\n4\r\n\r\n5\r\n6", 100)]
        public void Day1Puzzle1(string input, int result)
        {
            // Arrange
            Day1 day1 = new Day1();

            // Act 
            int expected = result;
            int actual = day1.TopCalorieCounter(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\r\n2\r\n\r\n3\r\n4\r\n\r\n5\r\n6", 21)]
        [InlineData("99\r\n1\r\n\r\n3\r\n4\r\n\r\n5\r\n6", 118)]
        [InlineData("99\r\n1\r\n\r\n3\r\n4\r\n\r\n5\r\n6\r\n\r\n99\r\n2\r\n\r\n3\r\n4\r\n\r\n5\r\n7", 213)]
        public void Day1Puzzle2(string input, int result)
        {
            // Arrange
            Day1 day1 = new Day1();

            // Act 
            int expected = result;
            int actual = day1.Top3CalorieCounter(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("A X\r\nA X\r\nA Z\r\nB X\r\nA X\r\nB Z", 25)]
        public void Day2Puzzle1(string input, int result)
        {
            // Arrange
            Day2 day2 = new Day2();

            // Act 
            int expected = result;
            int actual = day2.RockPaperScissorsPointsCalculator(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("A X\r\nA X\r\nA Z\r\nB X\r\nA X\r\nB Z", 27)]
        public void Day2Puzzle2(string input, int result)
        {
            // Arrange
            Day2 day2 = new Day2();

            // Act 
            int expected = result;
            int actual = day2.RockPaperScissorsPointsCalculator2(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("hqBqJsqHhHvhHHqlBvlfpHQQwLVzVwtVzjzttjQVSjMjwL\r\ngRTRnCRsFNGbTzLjwcSTMmSz", 89)]
        public void Day3Puzzle1(string input, int result)
        {
            // Arrange
            Day3 day3 = new Day3();

            // Act 
            int expected = result;
            int actual = day3.TotalPriorities(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("jamie\r\nsarah\r\ngary\r\nbobby\r\ndaisy\r\nflossy", 26)]
        public void Day3Puzzle2(string input, int result)
        {
            // Arrange
            Day3 day3 = new Day3();

            // Act 
            int expected = result;
            int actual = day3.TotalPrioritiesByGroup(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("15-60,14-59\r\n32-80,17-79\r\n47-80,79-80\r\n64-64,12-63\r\n93-93,8-92\r\n35-41,34-41", 2)]
        public void Day4Puzzle1(string input, int result)
        {
            // Arrange
            Day4 day4 = new Day4();

            // Act 
            int expected = result;
            int actual = day4.FullyContainedSections(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("15-60,14-59\r\n32-80,17-79\r\n47-80,79-80\r\n64-64,12-63\r\n93-93,8-92\r\n35-41,34-41", 4)]
        public void Day4Puzzle2(string input, int result)
        {
            // Arrange
            Day4 day4 = new Day4();

            // Act 
            int expected = result;
            int actual = day4.OverlappingSections(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        // p f m q w g r t
        // h p b f w g
        // p z r v g h s d
        // q h
        // p s m j h
        // m z t h s p r l
        // p t h m l
        // f f r
        // d s c n l p h d q r

        [Theory]
        [InlineData("[T]     [D]         [L]            \r\n[R]     [S] [G]     [P]         [H]" +
            "\r\n[G]     [H] [W]     [R] [L]     [P]\r\n[W]     [G] [F] [H] [S] [M]     [L]\r\n[Q]     " +
            "[V] [B] [J] [H] [N] [R] [N]\r\n[M] [R] [R] [P] [M] [T] [H] [Q] [C]\r\n[F] [F] [Z] [H] [S] " +
            "[Z] [T] [D] [S]\r\n[P] [H] [P] [Q] [P] [M] [P] [F] [D]\r\n 1   2   3   4   5   6   7   8   9 " +
            "\r\n\r\nmove 3 from 8 to 9\r\nmove 2 from 2 to 8\r\nmove 5 from 4 to 2", "TGDHHLLRR")]
        public void Day5Puzzle1(string input, string result)
        {
            // Arrange
            Day5 day5 = new Day5();

            // Act 
            string expected = result;
            string actual = day5.TrackStacks9000(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}