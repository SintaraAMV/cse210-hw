using System;

Console.Write("Enter your grade percentage: ");
bool ok = int.TryParse(Console.ReadLine(), out int grade);
if (!ok || grade < 0 || grade > 100)
{
    Console.WriteLine("Invalid input. Use 0-100.");
    return;
}

char letter;
if (grade >= 90) letter = 'A';
else if (grade >= 80) letter = 'B';
else if (grade >= 70) letter = 'C';
else if (grade >= 60) letter = 'D';
else letter = 'F';

string sign = "";
int last = grade % 10;
if (letter != 'A' && letter != 'F')   // no A±, F±
{
    if (last >= 7) sign = "+";
    else if (last < 3) sign = "-";
}

Console.WriteLine($"Your grade is {letter}{sign}.");
Console.WriteLine(grade >= 70 ? "You passed." : "Better luck next time.");
