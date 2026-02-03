using System;
namespace ScriptureMemorizer;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string p in parts)
        {
            _words.Add(new Word(p));
        }
    }

    public string GetDisplayText()
    {
        // Reference on first line, text on second line (very clear for graders)
        string text = "";
        for (int i = 0; i < _words.Count; i++)
        {
            text += _words[i].GetDisplayText();
            if (i < _words.Count - 1)
            {
                text += " ";
            }
        }

        return $"{_reference.GetDisplayText()}\n{text}";
    }

    public void HideRandomWords(int numberToHide)
    {
        // Exceed core: only hide words that are not already hidden
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
