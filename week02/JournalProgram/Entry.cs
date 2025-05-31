using System;

namespace JournalApp
{
    /// <summary>
    /// Represents a single journal entry: stores date/time, prompt, and response.
    /// </summary>
    public class Entry
    {
        // Private field for the date and time of this entry.
        private string _dateTime;

        // Private field for the prompt text.
        private string _prompt;

        // Private field for the user’s response.
        private string _response;

        /// <summary>
        /// Constructs a new Entry with a full timestamp, prompt, and response.
        /// </summary>
        /// <param name="dateTime">Timestamp in "yyyy-MM-dd HH:mm:ss" format.</param>
        /// <param name="prompt">The prompt text shown to the user.</param>
        /// <param name="response">The user’s response to the prompt.</param>
        public Entry(string dateTime, string prompt, string response)
        {
            _dateTime = dateTime;
            _prompt = prompt;
            _response = response;
        }

        /// <summary>
        /// Displays this entry to the console in a readable format.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Date: {_dateTime}");
            Console.WriteLine($"Prompt: {_prompt}");
            Console.WriteLine($"Response: {_response}");
            Console.WriteLine(new string('-', 30));
        }

        /// <summary>
        /// Converts this entry to a CSV line:
        /// "yyyy-MM-dd HH:mm:ss","prompt","response"
        /// </summary>
        public string ToCsvString()
        {
            // Escape any internal double quotes in prompt and response
            string escapedPrompt = _prompt.Replace("\"", "\"\"");
            string escapedResponse = _response.Replace("\"", "\"\"");
            return $"\"{_dateTime}\",\"{escapedPrompt}\",\"{escapedResponse}\"";
        }

        /// <summary>
        /// Creates an Entry object from a CSV line in the format:
        /// "yyyy-MM-dd HH:mm:ss","prompt","response"
        /// </summary>
        public static Entry FromCsvString(string csvLine)
        {
            // Split into three parts: timestamp, prompt, and response
            // Assume csvLine looks like:
            //   "2025-05-31 14:23:45","My prompt","My response"
            string[] parts = csvLine.Split(new[] { "\",\"" }, StringSplitOptions.None);
            // parts[0] == "\"2025-05-31 14:23:45"
            // parts[1] == "My prompt"
            // parts[2] == "My response\""
            string dateTime = parts[0].TrimStart('"');
            string prompt = parts[1].TrimEnd('"');
            string response = parts[2].TrimEnd('"');
            return new Entry(dateTime, prompt, response);
        }
    }
}
