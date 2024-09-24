using System;

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        do{
            Console.Write("Enter number:");
            number = int.Parse(Console.ReadLine());
            numbers.Add(number);
        }
        while (number != 0);
        Console.WriteLine($"The sum is: {GetSum(numbers)}");
        Console.WriteLine($"The average is: {GetAverage(numbers)}");
        Console.WriteLine($"The largest number is: {GetLargest(numbers)}");
    }
    public static double GetSum(List<int> numbers)
    {
        return numbers.Sum();
    }
    public static double GetAverage(List<int> numbers)
    {
        return numbers.Average();
    }
        public static double GetLargest(List<int> numbers)
    {
        return numbers.Max();
    }
}