public class CheckInActivity : Activity
{
    private int _physical;
    private int _mental;
    private int _spiritual;
    const string name = "Check-In";
    const string description = "This activity will help you check in with yourself and see how you are doing physically, mentally, and spiritually.";
    public CheckInActivity() : base(name, description)
    {
        _physical = 0;
        _mental = 0;
        _spiritual = 0;
    }
    public void StartCheckin()
    {
        ShowWelcomeMsg(false);

        Console.WriteLine("On a scale from 1 to 5 - 1 being not good and 5 your doing great. ");

        Console.WriteLine("How are you doing Physically? ");
        _physical = int.Parse(Console.ReadLine());

        Console.WriteLine("How are you doing Mentally? ");
        _mental = int.Parse(Console.ReadLine());

        Console.WriteLine("How are you doing Spiritually? ");
        _spiritual = int.Parse(Console.ReadLine());

        RecommendActivity();
    }
    private void RecommendActivity()
    {
        Console.WriteLine("Thank you for checking in! ");
        if(_mental <= _physical && _mental <= _spiritual)
        {
            Console.WriteLine("Based on your check-in, we recommend you try the Reflection Activity");
        }
        else if(_physical <= _mental && _physical <= _spiritual)
        {
            Console.WriteLine("Based on your check-in, we recommend you try the Breathing Activity");
        }
        else
        {
            Console.WriteLine("Based on your check-in, we recommend you try the Listing Activity");
        }
        
    }
}