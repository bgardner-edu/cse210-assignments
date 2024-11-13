// //www.plantuml.com/plantuml/png/jPB1QiCm38RlUWeTMzAyGDYXa8rTDYZi0OQIcCxCiOAj34RMTr-SrLJDBOTT0lylyUkpb6CK2ZBs3fwP73xyb2M-sNvm9cbbFea9djpAhJzC-_bYeom-r8vYn5FWSw0U9dWbwtVx2h_OTd01Q9VwqZj1-UwfDnL62TQVPzcPs0OxY6Mlt86jbrZX_9rLoubDJ5TXm-oWI64x7NH0bNCpLSmUYecQkK2jN1vj71nzfvXCgilrTLwk9uhy4Bse2OgRsivpHt65k1-zsg4-HrfbRkvg7htySHQgwV-HrB-GeHhsOpojxfVn5g6XeT09MuaFk9vsm3niutkEndTZxtu1
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int points = 0;
        bool running = true;
        while (running)
        {
            Console.WriteLine($"You have {points} points.\n");

            Console.WriteLine($"Menu Options");
            Console.WriteLine($"    1. Create New Goal");
            Console.WriteLine($"    2. List Goals");
            Console.WriteLine($"    3. Save Goals");
            Console.WriteLine($"    4. Load Goals");
            Console.WriteLine($"    5. Record Event");
            Console.WriteLine($"    6. Quit");
            Console.WriteLine($"Select a choice from the menu: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var goal = CreateNewGoal();
                    goals.Add(goal);
                    //Console.Clear();
                    break;
                case "2":
                    ListGoals(goals);
                    //Console.Clear();
                    break;
                case "3":
                    SaveGoals();
                    Console.Clear();
                    break;
                case "4":
                    LoadGoals();
                    Console.Clear();
                    break;
                case "5":
                    RecordEvent();
                    Console.Clear();
                    break;
                case "6":
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
    public static Goal CreateNewGoal()
    {

        Console.Write("Name:  ");
        var name = Console.ReadLine();

        Console.Write("Description: ");
        var description = Console.ReadLine();

        Console.Write("Points: ");
        var points = int.Parse(Console.ReadLine());

        Console.WriteLine($"What type of goal do you want to create");
        Console.WriteLine($"    1. Simple Goal");
        Console.WriteLine($"    2. Eternal Goal");
        Console.WriteLine($"    3. Checklist Goal");
        Console.WriteLine($"    4. Back");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                SimpleGoal sg = new SimpleGoal(name, description, points);
                return sg;
            case "2":
                EternalGoal eg = new EternalGoal(name, description, points);
                return eg;
            case "3":
                Console.Write("Bonus for Finishing:   ");
                var bonus = int.Parse(Console.ReadLine());

                Console.Write("Number of times to complete: ");
                var count = int.Parse(Console.ReadLine());

                CheckListGoal clg = new CheckListGoal(name, description, points, bonus, count);
                return clg;
            default:
                return null;
        }
    }
    public static void ListGoals(List<Goal> goals)
    {
        foreach (Goal goal in goals)
        {
            goal.DisplayGoal();
        }
    }
    public static void SaveGoals()
    {

    }
    public static void LoadGoals()
    {

    }
    public static void RecordEvent()
    {

    }
}