using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    // Extra (para "exceeds core"): mood/score
    private int _mood; // 1-5

    public Entry(string date, string promptText, string entryText, int mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} — Mood: {_mood}/5");
        Console.WriteLine(_promptText);
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    // Guardado simple con delimitador poco común
    public string ToFileString()
    {
        string safePrompt = _promptText.Replace("\n", "\\n").Replace("\r", "");
        string safeText = _entryText.Replace("\n", "\\n").Replace("\r", "");
        return $"{_date}~|~{_mood}~|~{safePrompt}~|~{safeText}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
        // parts: date, mood, prompt, text
        string date = parts[0];
        int mood = int.Parse(parts[1]);
        string prompt = parts[2].Replace("\\n", "\n");
        string text = parts[3].Replace("\\n", "\n");
        return new Entry(date, prompt, text, mood);
    }
}
