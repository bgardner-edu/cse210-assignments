using System;
using System.IO.IsolatedStorage;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResults(name, square);
    }
    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    public static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    public static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    public static int SquareNumber(int number)
    {
        return number * number;
    }
    public static void DisplayResults(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}