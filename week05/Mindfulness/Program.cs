/*
Exceeding Requirements:
1. Added a fourth activity: Gratitude Activity. This activity prompts the user to reflect on things they are grateful for and offers to save their reflection to a gratitude journal file.
2. Implemented an activity log that records each completed activity with a timestamp in a file named "activity_log.txt".
3. Enhanced user interaction by allowing the user to save their gratitude reflection to a file.
4. The program now handles basic file I/O operations for persistence.
*/
using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Create a log file if it doesn't exist
        if (!File.Exists("activity_log.txt"))
        {
            File.Create("activity_log.txt").Close();
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");  // New activity
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            string activityName = "";
            try
            {
                switch (choice)
                {
                    case "1":
                        BreathingActivity breathing = new BreathingActivity();
                        activityName = "Breathing Activity";
                        breathing.Run();
                        break;
                    case "2":
                        ReflectingActivity reflecting = new ReflectingActivity();
                        activityName = "Reflecting Activity";
                        reflecting.Run();
                        break;
                    case "3":
                        ListingActivity listing = new ListingActivity();
                        activityName = "Listing Activity";
                        listing.Run();
                        break;
                    case "4":
                        GratitudeActivity gratitude = new GratitudeActivity();
                        activityName = "Gratitude Activity";
                        gratitude.Run();
                        break;
                    case "5":
                        Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        Thread.Sleep(2000);
                        continue;
                }

                // Log the activity
                File.AppendAllText("activity_log.txt", $"{DateTime.Now}: Completed {activityName}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}