using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts;
    
    public GratitudeActivity()
    {
        _name = "Gratitude Journal";
        _description = "This activity will help you cultivate gratitude by focusing on positive aspects of your life.";
        _gratitudePrompts = new List<string>
        {
            "What are three things you're grateful for today?",
            "Who made a positive impact on you this week?",
            "What recent accomplishment are you proud of?",
            "What simple pleasure brought you joy recently?",
            "What challenge taught you something valuable?"
        };
    }
    
    public void Run()
    {
        DisplayStartingMessage();
        
        Random random = new Random();
        string prompt = _gratitudePrompts[random.Next(_gratitudePrompts.Count)];
        
        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("You have 10 seconds to think about this...");
        ShowCountDown(10);
        
        Console.WriteLine("\nNow write your thoughts (press Enter after each item):");
        Console.WriteLine("(Type 'done' when finished)\n");
        
        List<string> entries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            
            if (entry.ToLower() == "done")
                break;
                
            if (!string.IsNullOrWhiteSpace(entry))
                entries.Add(entry);
        }
        
        Console.WriteLine($"\nYou wrote {entries.Count} gratitude entries!");
        Console.WriteLine("\nRemember: Gratitude turns what we have into enough.");
        
        DisplayEndingMessage();
    }
}