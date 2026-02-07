/*
EXCEEDING REQUIREMENTS - CREATIVITY FEATURES:
1. Added a "Gratitude Journal" activity as a 4th option
2. Implemented activity logging to track user progress
3. Added color coding for different activities
4. Created a progress spinner that shows percentage completion
5. Added motivational quotes after each activity completion
6. Implemented input validation for duration
7. Added ASCII art for activity transitions
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
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Journal");  // NUEVO
            Console.WriteLine("5. Exit");
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