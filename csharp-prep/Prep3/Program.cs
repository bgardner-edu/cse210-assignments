using System;

class Program
{
    static void Main(string[] args)
    {

        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 11);
        int count = 1;
        int numOfTries = 10;

        Console.WriteLine("Guess what number");
        var guessNumber = int.Parse(Console.ReadLine());

        while (randomNumber != guessNumber && count < numOfTries)
        {
            if (randomNumber > guessNumber)
            {
                Console.WriteLine("Higher");
                guessNumber = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Lower");
                guessNumber = int.Parse(Console.ReadLine());
            }
            count++;
        }
        if (count < 10)
        {
            Console.WriteLine($"You are correct! It took you {count} tries.");
        }
        else
        {
            Console.WriteLine("You ran out of tries...");
        }
        
    }
}