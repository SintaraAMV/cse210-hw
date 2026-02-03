using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding core requirements:
        // I added a mood rating (1–5) for each entry, and it is saved/loaded and displayed.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    int mood = PromptMood();
                    string date = DateTime.Now.ToShortDateString();

                    Entry entry = new Entry(date, prompt, response, mood);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added.\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.\n");
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.\n");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }
        }
    }

    static int PromptMood()
    {
        while (true)
        {
            Console.Write("Mood (1-5): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int mood) && mood >= 1 && mood <= 5)
            {
                return mood;
            }
            Console.WriteLine("Please enter a number from 1 to 5.");
        }
    }
}
