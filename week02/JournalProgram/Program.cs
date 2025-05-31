using System;

/// <summary>
/// Main entry point for the Journal Program. Presents a simple console menu
/// allowing the user to write, display, save, load, delete, and quit.
/// </summary>
public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool exit = false;
        string filename = "journal.txt";

        Console.WriteLine("=== Welcome to Your Personal Journal ===\n");

        while (!exit)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Delete an entry");
            Console.WriteLine("6. Quit");
            Console.Write("Please choose an option (1–6): ");
            string choice = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    // Case 1: Write a new entry
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"--- Prompt: {prompt} ---");
                    journal.WriteEntry(prompt);
                    Console.WriteLine("Entry saved in memory.\n");
                    break;

                case "2":
                    // Case 2: Display all entries
                    Console.WriteLine("----- Your Journal Entries -----");
                    journal.Display();
                    break;

                case "3":
                    // Case 3: Save to file
                    journal.SaveToFile(filename);
                    Console.WriteLine($"All entries have been saved to '{filename}'.\n");
                    break;

                case "4":
                    // Case 4: Load from file
                    journal.LoadFromFile(filename);
                    Console.WriteLine($"Journal loaded from '{filename}'.\n");
                    break;

                case "5":
                    // Case 5: Delete an entry (only if there are entries)
                    if (journalHasEntries(journal))
                    {
                        Console.WriteLine("Select the index of the entry you wish to delete:");
                        journal.Display();
                        Console.Write("Index: ");
                        string indexInput = Console.ReadLine() ?? "";
                        if (int.TryParse(indexInput, out int idx))
                        {
                            if (idx >= 0 && idx < journal.EntryCount)
                            {
                                journal.DeleteEntry(idx);
                                Console.WriteLine("Entry deleted.\n");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index. No entry deleted.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. No entry deleted.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no entries to delete.\n");
                    }
                    break;

                case "6":
                    // Case 6: Quit the program
                    Console.WriteLine("Goodbye! Thanks for using the Journal Program.");
                    exit = true;
                    break;

                default:
                    // Handle invalid menu choice
                    Console.WriteLine("Invalid option. Please enter a number from 1 to 6.\n");
                    break;
            }
        }
    }

    /// <summary>
    /// Helper method: returns true if the journal currently has at least one entry.
    /// Simplifies checking before delete or display calls.
    /// </summary>
    /// <param name="journal">The Journal instance to inspect.</param>
    /// <returns>True if there is at least one entry; otherwise, false.</returns>
    static bool journalHasEntries(Journal journal)
    {
        return journal.EntryCount > 0;
    }
}
