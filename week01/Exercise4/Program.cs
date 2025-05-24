// week01/Exercise4/Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            if (n == 0) break;
            numbers.Add(n);
        }

        int    sum = numbers.Sum();
        double avg = numbers.Average();
        int    max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch 1 – smallest positive
        int minPos = numbers.Where(x => x > 0).DefaultIfEmpty().Min();
        Console.WriteLine($"The smallest positive number is: {minPos}");

        // Stretch 2 – sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        numbers.ForEach(Console.WriteLine);
    }
}
