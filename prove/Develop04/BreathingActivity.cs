public class BreathingActivity : Activity
{
    private int _lengthOfBreath;
    const string name = "Breathing";
    const string description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    public BreathingActivity() : base(name, description)
    {
        _lengthOfBreath = 5;
    }
    public void StartBreathing()
    {
        ShowWelcomeMsg();
        var endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now <= endTime)
        {
            Console.Write($"\nBreath In... ");
            ShowCountDown(_lengthOfBreath);

            Console.Write($"\nBreath out... ");
            ShowCountDown(_lengthOfBreath);
        }
        ShowEndMsg();
    }
}