using System;

class Program
{
    static void Main(string[] args)
    {
        Fractions defaultFractions = new Fractions();
        Fractions wholeNumberFractions = new Fractions(6);
        Fractions topBottomFractions = new Fractions(3, 4);
        Console.WriteLine($"First number: {defaultFractions.GetTop()}/{defaultFractions.GetBottom()}");
        Console.WriteLine($"Second number: {wholeNumberFractions.GetTop()}/{wholeNumberFractions.GetBottom()}");
        Console.WriteLine($"Third number: {topBottomFractions.GetTop()}/{topBottomFractions.GetBottom()}");

        Console.WriteLine($"String number: {topBottomFractions.GetFractionString()}");
        Console.WriteLine($"Decimal number: {topBottomFractions.GetDecimalValue()}");
    }
}