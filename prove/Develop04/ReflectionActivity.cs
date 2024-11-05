public class ReflectionActivity : Activity
{
    private List<string> _initialPrompts;
    private List<string> _secondaryPrompts;

    const string name = "Reflecting";
    const string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    public ReflectionActivity() : base(name, description)
    {
        _initialPrompts = ["Think of a time when you stood up for someone else.",
                        "Think of a time when you did something really difficult.",
                        "Think of a time when you helped someone in need.",
                        "Think of a time when you did something truly selfless.",];
        _secondaryPrompts = ["Why was this experience meaningful to you?",
                            "Have you ever done anything like this before?",
                            "How did you get started?",
                            "How did you feel when it was complete?",
                            "What made this time different than other times when you were not as successful?",
                            "What is your favorite thing about this experience?",
                            "What could you learn from this experience that applies to other situations?",
                            "What did you learn about yourself through this experience?",
                            "How can you keep this experience in mind in the future?"];

        ShufflePrompts();                    
    }
    public void StartReflection()
    {
        ShowWelcomeMsg();

        Console.WriteLine("Consider the following prompt: \n");
        Console.WriteLine($"---{GetInitialPrompt()}---\n");
        Console.WriteLine($"press Enter when ready...");
        Console.ReadLine();

        var endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now <= endTime)
        {
            Console.WriteLine($"--- {GetSecondaryPrompt(count)} ---\n");
            if(count >= _secondaryPrompts.Count - 1)
            {
                ShufflePrompts();
                count = 0;
            }
            else 
            {
                count ++;
            }
            ShowLoading(10);
        }
        ShowEndMsg();
    }
    private string GetInitialPrompt()
    {
        Random random = new Random();
        var index = random.Next(0, _initialPrompts.Count);
        return _initialPrompts[index];
    }
    private string GetSecondaryPrompt(int index)
    {
        return _secondaryPrompts[index];
    }
    private void ShufflePrompts()
    {
        Random random = new Random();
        _secondaryPrompts = _secondaryPrompts.OrderBy(_ => random.Next()).ToList();
    }
}