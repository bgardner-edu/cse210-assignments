using System;

class Entry
{
    public string prompt { get; set; }
    public string entry { get; set; }
    public DateTime date { get; set; }

    public void DisplayPrompt()
    {
        prompt = Prompts.GetRandomPrompt();
        Console.WriteLine(prompt);
    }
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"Entry: {entry}\n");
    }
}