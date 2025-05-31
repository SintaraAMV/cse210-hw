using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    /// <summary>
    /// Represents the entire journal, holding an internal list of Entry objects
    /// and providing methods to manipulate them.
    /// </summary>
    public class Journal
    {
        // Private list of entries; outside code cannot modify it directly.
        private List<Entry> _entries = new List<Entry>();

        /// <summary>
        /// Adds a new Entry to the journal.
        /// (Functionality: “Journal Writing” – 10 pts)
        /// </summary>
        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        /// <summary>
        /// Displays all entries in the journal, printing date, prompt, and response.
        /// (Functionality: “Journal Display” – 10 pts)
        /// </summary>
        public void Display()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("Journal is empty.");
                return;
            }

            for (int i = 0; i < _entries.Count; i++)
            {
                Console.WriteLine($"Entry #{i}");
                _entries[i].Display();
            }
        }

        /// <summary>
        /// Saves the entire journal to a CSV file (one line per Entry).
        /// (Functionality: “Saving” – 10 pts)
        /// </summary>
        public void SaveToFile(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    outputFile.WriteLine(entry.ToCsvString());
                }
            }
        }

        /// <summary>
        /// Loads the journal from a CSV file, replacing the current list of entries.
        /// (Functionality: “Loading” – 10 pts)
        /// </summary>
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File \"{filename}\" does not exist.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                Entry entry = Entry.FromCsvString(line);
                _entries.Add(entry);
            }
        }

        /// <summary>
        /// Deletes the entry at the given index. Returns true if successful.
        /// (Creative extension, not in core requirements.)
        /// </summary>
        public bool DeleteEntry(int index)
        {
            if (index < 0 || index >= _entries.Count)
            {
                return false;
            }
            _entries.RemoveAt(index);
            return true;
        }
    }
}
