using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSuite
{
    internal class Day2
    {   
        // For function 1, this represents Rock, Paper then Scissors.
        // For function 2, this represnts, Lose, Draw, then Win.
        private string YourChoices = "XYZ";
        
        // This dictionary is for the first function. Keys are your moves, and the letters in the values are their moves.
        // The index of 'their' move times by 3 gives you the result.
        // i.e. if you choose X (Rock) and they choose C (Scissors), then you win.
        // The resulting points is the index (2) times by 3, giving you 6 points
        private Dictionary<string, string> YourChoiceToOpponentChoice = new Dictionary<string, string>()
        {
            { "X", "BAC" },
            { "Y", "CBA" },
            { "Z", "ACB" }
        };

        // This dictionary is for the second function. Keys are their moves, and the letters in the values are your moves.
        // The index of 'your' move plus 1 gives you the points you make.
        // i.e. if you choose X (Rock) and they choose C (Scissors), then you win.
        // The resulting points is the index (2) times by 3, giving you 6 points
        private Dictionary<string, string> OpponentChoiceToYourChoice = new Dictionary<string, string>()
        {
            { "A", "ZXY" },
            { "B", "XYZ" },
            { "C", "YZX" }
        };
        
        // XYZ corresponds to which move you should make. X being Rock, and so on.
        public int RockPaperScissorsPointsCalculator(string input)
        {
            int totalScore = 0;

            for (int i = 2; i < input.Length; i += 5)
            {
                int resultPoints = YourChoiceToOpponentChoice[input[i].ToString()].IndexOf(input[i - 2]) * 3;
                int choicePoints = YourChoices.IndexOf(input[i]) + 1;
                totalScore += choicePoints + resultPoints;
            }

            return totalScore;
        }

        // XYZ correspond to which outcomes of the game you need to create.
        // X means win, so if they choose Rock, you pick Paper, and so on.
        public int RockPaperScissorsPointsCalculator2(string input)
        {
            int totalScore = 0;

            for (int i = 2; i < input.Length; i += 5)
            {
                int resultPoints = YourChoices.IndexOf(input[i]) * 3;
                // Index of the outcome (in YourChoices) is the same as the index of the move you must make to achieve that outcome, 
                // given the opponents choice (in OpponentChoiceToYourChoice).
                // I.e. Let's say your strategy sheet gives you X (Lose), and the opponent's choice is A (Rock). 
                // The index of X in YourChoices is 0. The letter at the 0th position in the value for key A, is Y (Paper).
                // Paper gives you 2 points (as per its index in YourChoices + 1)
                int choicePoints = YourChoices.IndexOf(OpponentChoiceToYourChoice[input[i - 2].ToString()][YourChoices.IndexOf(input[i])]) + 1;
                totalScore += choicePoints + resultPoints;
            }

            return totalScore;
        }


    }
}
