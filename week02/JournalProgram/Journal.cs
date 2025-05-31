using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Represents a journal that holds multiple entries and allows writing, displaying,
/// saving, loading, and deleting entries.
/// </summary>
public class Journal
{
    // Private list holds all Entry objects.
    private List<Entry> _entries = new List<Entry>();

    /// <summary>
    /// Public property exposing how many entries are currently stored.
    /// This helps other classes check if the journal has any entries.
    /// </summary>
    public int EntryCount => _entries.Count;

    /// <summary>
    /// Write a new entry given a prompt. Prompts are provided externally.
    /// </summary>
    /// <param name="prompt">The writing prompt to show to the user.</param>
    public void WriteEntry(string prompt)
    {
        Console.Write("Your Response: ");
        string response = Console.ReadLine() ?? "";
        string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _entries.Add(new Entry(dateTime, prompt, response));
    }

    /// <summary>
    /// Display every current entry in the journal by calling Entry.Display().
    /// </summary>
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("— No entries in the journal —\n");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"[{i}] ---------------------");
            _entries[i].Display();
        }
    }

    /// <summary>
    /// Save all entries to a text file, one CSV line per entry.
    /// </summary>
    /// <param name="filename">The target filename (e.g., "journal.txt").</param>
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToCsvString());
            }
        }
    }

    /// <summary>
    /// Load entries from a file. Clears existing entries, reads each line,
    /// and builds Entry objects via Entry.FromCsvString().
    /// </summary>
    /// <param name="filename">The filename to load from (e.g., "journal.txt").</param>
    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found. Starting with an empty journal.\n");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            _entries.Add(Entry.FromCsvString(line));
        }
    }

    /// <summary>
    /// Remove an entry by its zero-based index, if valid.
    /// </summary>
    /// <param name="index">Index of the entry to remove.</param>
    public void DeleteEntry(int index)
    {
        if (index >= 0 && index < _entries.Count)
        {
            _entries.RemoveAt(index);
        }
    }
}
