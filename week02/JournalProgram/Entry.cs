using System;

/// <summary>
/// Represents a single journal entry with a timestamp, prompt, and response.
/// </summary>
public class Entry
{
    // Private fields store the internal data.
    private string _dateTime;
    private string _prompt;
    private string _response;

    /// <summary>
    /// Constructor for an Entry. Users of this class only see these three pieces of information.
    /// </summary>
    /// <param name="dateTime">When the entry was created (formatted string).</param>
    /// <param name="prompt">The writing prompt text.</param>
    /// <param name="response">The user’s written response.</param>
    public Entry(string dateTime, string prompt, string response)
    {
        _dateTime = dateTime;
        _prompt = prompt;
        _response = response;
    }

    /// <summary>
    /// Create an Entry from a CSV-formatted line (DateTime,Prompt,Response).
    /// </summary>
    /// <param name="csvLine">A single line from the saved file.</param>
    /// <returns>A new Entry object.</returns>
    public static Entry FromCsvString(string csvLine)
    {
        // Expecting CSV like: "2023-05-31 14:23:45","My prompt","My response"
        string[] parts = csvLine.Split(new[] { ',' }, 3);

        // Remove surrounding quotes, if any
        string dateTime = parts[0].TrimStart('"').TrimEnd('"');
        string prompt    = parts[1].TrimStart('"').TrimEnd('"');
        string response  = parts[2].TrimStart('"').TrimEnd('"');

        return new Entry(dateTime, prompt, response);
    }

    /// <summary>
    /// Convert this Entry to a CSV line (including quotes to handle commas).
    /// </summary>
    /// <returns>A CSV-formatted string representing this entry.</returns>
    public string ToCsvString()
    {
        // Surround each field with quotes in case they contain commas
        return $"\"{_dateTime}\",\"{_prompt}\",\"{_response}\"";
    }

    /// <summary>
    /// Display the entry on the console: date/time, prompt, and response.
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Date:    {_dateTime}");
        Console.WriteLine($"Prompt:  {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
}
