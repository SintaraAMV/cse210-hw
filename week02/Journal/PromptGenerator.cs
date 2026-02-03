using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "What was the best part of my day?",
        "What did I learn today?",
        "Who did I help today and how?",
        "What challenge did I face today and how did I respond?",
        "What am I grateful for today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
