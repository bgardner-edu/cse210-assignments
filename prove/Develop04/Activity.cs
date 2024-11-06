using System.Runtime.InteropServices;
using System.Security.Principal;

public class Activity
{
    private string _name;
    private string _discription;
    protected int _duration;

    public Activity(string name, string discription)
    {
        _name = name;
        _discription = discription;
        _duration = 0;
    }

    public void ShowLoading(int duration)
    {
        List<string> dots = ["|", "/", "-", "\\"];
        var dotsIndex = 0;
        for(int i = 0; i < duration; i++)
        {
            Console.Write(dots[dotsIndex]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            if(dotsIndex == 3)
            {
                dotsIndex = 0;
            }
            else
            {
                dotsIndex++;
            }
        }
    }
    public void ShowCountDown(int count)
    {
        for(int i = 1; i <= count; i++)
        {
            Console.Write($"\b \b{count - i + 1}");
            Thread.Sleep(1000);
        }
        Console.Write($"\b \b");
    }
    public void ShowWelcomeMsg(bool duration = true)
    {
        Console.WriteLine($"Welcome to the {_name} activity!\n");
        Console.WriteLine(_discription);
        if (duration)
        {
            Console.WriteLine($"\nHow long would you like to do this activity in seconds? ");
            _duration = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Get Ready...");
        ShowLoading(5);
    }
    public void ShowEndMsg()
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine($"You have completed {_duration} seconds of {_name} activity.");
        ShowLoading(5);
        Console.Clear();
    }
}