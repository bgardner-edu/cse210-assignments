using System;

class Program
{
    static void Main(string[] args)
    {
        var running = true;
        while (running)
        {
            Console.WriteLine("Welcome to the Mindfullness App\n");
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Check-In Activity");
            Console.WriteLine("2. Breathing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Listing Activity");
            Console.WriteLine("5. quit");

            var option = Console.ReadLine();

            //Add another activity called a checkin. Physically, emotionally, spirituall. 
            //Based on the lowest score, recommend an activity. 

            switch (option)
            {
                case "1":
                    CheckInActivity checkin = new CheckInActivity();
                    checkin.StartCheckin();
                    Console.Clear();
                    break;
                case "2":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.StartBreathing();
                    Console.Clear();
                    break;
                case "3":
                    ReflectionActivity reflecting = new ReflectionActivity();
                    reflecting.StartReflection();
                    Console.Clear();
                    break;
                case "4":
                    ListingActivity listing = new ListingActivity();
                    listing.StartListing();
                    Console.Clear();
                    break;
                case "5":
                    Console.WriteLine("GoodBye");
                    running = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Not a valid input, please choose an option below.\n");
                    continue;
            }
        }

    }
}

//www.plantuml.com/plantuml/png/VPB1JiCm38RlUOeUYwQ-m3JGO9lG9128mXc5nciZKgTAd4qJyEuaongLKhYr_-_V_knsQOaRSgrYrnNj9HspnMTHP3S6E3KIQw_A8F-qds2dm3iQf_qxQMaOPYl5hSqUZQuDRza7Or-CLIVjdFDQyOgyXNbcoVYiVnLWAoExC6QeEiEZ997Oh6pqeUma8fZyOfxjjHHHN6c7jDO7p2rK6eKz1LB9MjfEyMCPrh-tTSxFhFsaSU46nNzb_JxZo_MRkVPX5wt8uJK5M5FJo_qwWIVroCVjfowV-llpjXsb_X8bIQwI6ZxA8b9VUJjUXPlZNmNEWfZs8cMFCi0iRe6smx71YQcJLwQPOpSj60QDhzT5Ykno0j7OeFss0CMp3B_JcXE49pRp02y-iCNEKKAUhHgetZUnEgXlMYkFimGKhbNV