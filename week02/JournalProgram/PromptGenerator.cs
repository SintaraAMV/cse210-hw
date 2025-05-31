using System;
using System.Collections.Generic;

namespace JournalApp
{
    /// <summary>
    /// Maintains a private list of prompts and returns one at random.
    /// </summary>
    public class PromptGenerator
    {
        // Private list of writing prompts.
        private List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
            // You can add more prompts here for extra creativity.
        };

        // Random instance to select a prompt index.
        private Random _random = new Random();

        /// <summary>
        /// Returns a random prompt from the internal list.
        /// </summary>
        public string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}
