// week02/JournalProgram/Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool exit = false;
        string filename = "journal.txt";

        while (!exit)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    journal.WriteEntry(prompt);
                    Console.WriteLine("Entry written.\n");
                    break;

                case "2":
                    Console.WriteLine("Your Journal Entries:\n");
                    journal.Display();
                    break;

                case "3":
                    journal.SaveToFile(filename);
                    Console.WriteLine($"Journal saved to {filename}.\n");
                    break;

                case "4":
                    journal.LoadFromFile(filename);
                    Console.WriteLine($"Journal loaded from {filename}.\n");
                    break;

                case "5":
                    Console.WriteLine("Select the index of the entry to delete:");
                    journal.Display();
                    Console.Write("Index: ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                    {
                        journal.DeleteEntry(idx);
                        Console.WriteLine("Entry deleted.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.\n");
                    }
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }
}
