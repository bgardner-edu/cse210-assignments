public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _userList;
    const string name = "Listing";
    const string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    public ListingActivity() : base(name, description)
    {
        _prompts = ["Who are people that you appreciate?",
                    "What are personal strengths of yours?",
                    "Who are people that you have helped this week?",
                    "When have you felt the Holy Ghost this month?",
                    "Who are some of your personal heroes?"];
        _userList = [];
    }
    public void StartListing()
    {
        ShowWelcomeMsg();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"---{GetPrompt()}---\n");
        ShowCountDown(5);
        Console.WriteLine("Start Listing! ");
        var endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now <= endTime)
        {
            var input = Console.ReadLine();
            _userList.Add(input);
        }
        Console.WriteLine($"Your listed {_userList.Count} items.");
        ShowEndMsg();
    }
    private string GetPrompt()
    {
        Random random = new Random();
        var index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}