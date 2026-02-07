using System;
using System.IO;

public static class ActivityLogger
{
    private static string logFile = "mindfulness_log.txt";
    
    public static void LogActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {activityName} ({duration} seconds)";
        File.AppendAllText(logFile, logEntry + Environment.NewLine);
    }
    
    public static void ShowStats()
    {
        if (File.Exists(logFile))
        {
            string[] logs = File.ReadAllLines(logFile);
            Console.WriteLine($"\n📊 You've completed {logs.Length} mindfulness sessions!");
        }
    }
}