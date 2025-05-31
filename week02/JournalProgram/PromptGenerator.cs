using System;
using System.Collections.Generic;

/// <summary>
/// Generates a random writing prompt from a preset list.
/// </summary>
public class PromptGenerator
{
    // Internal list of prompts.
    private List<string> _prompts = new List<string>()
    {
        "What is one meaningful goal you want to achieve this year?",
        "Describe a moment when you felt truly inspired.",
        "Write about someone you admire and why.",
        "What are three things you are grateful for today?",
        "How would you spend a perfect day off?",
        "Discuss a challenge you overcame and what you learned.",
        "If you could travel anywhere, where would you go and why?"
    };

    private Random _random = new Random();

    /// <summary>
    /// Returns a single random prompt from the internal list.
    /// </summary>
    /// <returns>A prompt string for the user to respond to.</returns>
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
