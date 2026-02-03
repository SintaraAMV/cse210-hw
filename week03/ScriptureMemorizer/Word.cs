using System;
namespace ScriptureMemorizer;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Underscores match number of letters/digits; punctuation remains visible.
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] chars = _text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLetterOrDigit(chars[i]))
            {
                chars[i] = '_';
            }
        }
        return new string(chars);
    }
}
