using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int input = int.Parse(Console.ReadLine());
        string grade = GetLetterGrade(input);
        Console.WriteLine($"Letter Grade: {grade}");
        if (input > 70)
        {
            Console.WriteLine("Congradulations you've passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }
        
    }
    private static string GetLetterGrade(float percentage)
    {
        if (percentage >= 90)
        {
            return "A";
        }
        else if (percentage >= 80)
        {
            return "B";
        }
        else if (percentage >= 70)
        {
            return "C";
        }
        else if (percentage >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}