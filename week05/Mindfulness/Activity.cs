using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(5);
    }
    
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n\nGreat job!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }
    
    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int animationIndex = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(animation[animationIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            animationIndex = (animationIndex + 1) % animation.Count;
        }
    }
    
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}