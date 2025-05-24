// week01/Exercise5/Program.cs
using System;

class Program
{
    static void Main()
    {
        DisplayWelcome();
        string name = PromptUserName();
        int    num  = PromptUserNumber();
        int    sq   = SquareNumber(num);
        DisplayResult(name, sq);
    }

    static void DisplayWelcome() =>
        Console.WriteLine("Welcome to the program!");

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine() ?? "";
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine() ?? "0");
    }

    static int SquareNumber(int n) => n * n;

    static void DisplayResult(string name, int square) =>
        Console.WriteLine($"{name}, the square of your number is {square}");
}
