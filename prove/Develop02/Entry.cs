using System;

class Entry
{
    private string _prompt;
    private string _entry;
    private string _wellness;
    private DateTime _date;

    public Entry()
    {
        _date = DateTime.Now;
    }

    public void DisplayPrompt()
    {
        _prompt = Prompts.GetRandomPrompt();
        Console.WriteLine(_prompt);
    }
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Wellness: {_wellness}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Entry: {_entry}\n");
    }
    public void AskForWellness()
    {
        Console.WriteLine("How are you doing today? ");
        _wellness = Console.ReadLine();
    }
    public void SetEntry(string entry)
    {
        _entry = entry;
    }
}