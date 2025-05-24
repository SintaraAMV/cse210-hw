// week01/Exercise3/Program.cs
using System;

class Program
{
    static void Main()
    {
        bool playAgain = true;
        Random rng = new Random();

        while (playAgain)
        {
            int magic   = rng.Next(1, 101); // 1-100
            int guesses = 0;
            int guess;

            Console.WriteLine("== Guess My Number ==");

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine() ?? "0");
                guesses++;

                if (guess < magic)      Console.WriteLine("Higher");
                else if (guess > magic) Console.WriteLine("Lower");
            }
            while (guess != magic);

            Console.WriteLine($"You guessed it in {guesses} tries!");

            Console.Write("Play again? (yes/no) ");
            playAgain = Console.ReadLine()?.Trim().ToLower() == "yes";
            Console.WriteLine();
        }
    }
}
