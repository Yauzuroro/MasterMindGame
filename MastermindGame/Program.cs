using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string customCode = null;
            int maxAttempts = 10;

            // Check for command-line options like -c 1234 or -t 8
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-c" && i + 1 < args.Length)
                    customCode = args[i + 1];

                if (args[i] == "-t" && i + 1 < args.Length && int.TryParse(args[i + 1], out int tries))
                    maxAttempts = tries;
            }

            // Game loop
            string playAgain;
            do
            {
                Console.Clear();
                 Console.WriteLine("Let's Go0o0o!");
                Console.WriteLine("Last game highest score is:"+ (maxAttempts - 1) + " attempts Can you beat it Champ?");
                Game game = new Game(customCode, maxAttempts);
                game.Play();

                Console.WriteLine("Do you want to play again? (yes/no)");
                playAgain = Console.ReadLine()?.Trim().ToLower();

            } while (playAgain == "yes" || playAgain == "y");

            Console.WriteLine("Thanks for playing! :D");
        }

    }

    class Game
    {
        private string secretCode;
        private int maxAttempts;

        public Game(string code, int attempts)
        {
            maxAttempts = attempts;
            secretCode = string.IsNullOrEmpty(code) ? GenerateCode() : code;
        }

        public void Play()
        {
            Console.WriteLine("Can you break the code? Enter a 4-digit guess using numbers 0–8 (No Duplicates numbers allowed or less than 4-digits).\n");

            for (int i = 1; i <= maxAttempts; i++)
            {
                Console.Write($"Attempt {i}/{maxAttempts}: ");
                string guess = Console.ReadLine();

                // If player presses Ctrl+D or input is null
                if (guess == null)
                    return;

                // Validate guess: must be 4 unique digits from 0 to 8
                if (!IsValid(guess))
                {
                    Console.WriteLine("Invalid input. Use 4 **distinct** digits from 0 to 8.");
                    i--; // doesn't count this attempt
                    continue;
                }

                if (guess == secretCode)
                {
                    Console.WriteLine("Congratz! You did it!");
                    return;
                }

                int wellPlaced = CountWellPlaced(guess);
                int misplaced = CountMisplaced(guess);

                Console.WriteLine($"Well-placed pieces: {wellPlaced}");
                Console.WriteLine($"Misplaced pieces: {misplaced}\n");
            }

            Console.WriteLine("Game Over! You ran out of attempts.");
            Console.WriteLine($"The secret code was: {secretCode}");

        }

        // Generates a random 4-digit code with unique numbers from 0-8
        private string GenerateCode()
        {
            Random rand = new Random();
            List<int> digits = new List<int>();

            while (digits.Count < 4)
            {
                int next = rand.Next(0, 9); // from 0 to 8
                if (!digits.Contains(next))
                    digits.Add(next);
            }

            return string.Concat(digits); // turns [1,3,8,6] into "1386"
        }

        //  Checks if guess is valid
        private bool IsValid(string guess)
        {
            return guess.Length == 4 &&
                   guess.All(char.IsDigit) &&
                   guess.All(c => c >= '0' && c <= '8') &&
                   guess.Distinct().Count() == 4;
        }

        // Count how many digits are in the correct position
        private int CountWellPlaced(string guess)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretCode[i])
                    count++;
            }
            return count;
        }

        // Count how many digits are in the code but in the wrong place
        private int CountMisplaced(string guess)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] != secretCode[i] && secretCode.Contains(guess[i]))
                    count++;
            }
            return count;
        }
    }
}
