// week01/Exercise2/Program.cs
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int percent = int.Parse(Console.ReadLine() ?? "0");

        string letter = GetLetter(percent);
        string sign   = GetSign(percent, letter);

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70)
            Console.WriteLine("Congratulations, you passed the course!");
        else
            Console.WriteLine("Keep trying—you’ll get it next time!");
    }

    static string GetLetter(int p) =>
        p switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _     => "F"
        };

    static string GetSign(int p, string letter)
    {
        int last = p % 10;
        bool plus  = last >= 7;
        bool minus = last < 3;

        if (letter == "A" && plus) return ""; // no A+
        if (letter == "F")         return ""; // no F+ or F-
        if (plus)  return "+";
        if (minus) return "-";
        return "";
    }
}
