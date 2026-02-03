using System;
using System.Collections.Generic;
using ScriptureMemorizer;

namespace ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDS CORE REQUIREMENTS:
        // 1) Library of scriptures: the program selects one scripture randomly.
        // 2) User can choose how many words to hide per round (difficulty).
        // 3) Word hiding preserves punctuation while underscores match letters/digits only.
        // 4) Only hides words that are not already hidden.

        List<(Reference reference, string text)> library = new List<(Reference, string)>
        {
            (new Reference("Proverbs", 3, 5, 6),
             "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."),

            (new Reference("John", 3, 16),
             "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            (new Reference("2 Nephi", 2, 25),
             "Adam fell that men might be; and men are, that they might have joy.")
        };

        Random rnd = new Random();
        var chosen = library[rnd.Next(library.Count)];

        Scripture scripture = new Scripture(chosen.reference, chosen.text);

        int wordsPerRound = PromptWordsPerRound();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(wordsPerRound);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Program finished.");
                break;
            }
        }
    }

    static int PromptWordsPerRound()
    {
        while (true)
        {
            Console.Write("How many words should be hidden per round (1-5)? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int n) && n >= 1 && n <= 5)
            {
                return n;
            }

            Console.WriteLine("Please enter a number between 1 and 5.");
        }
    }
}
