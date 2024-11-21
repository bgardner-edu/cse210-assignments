using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Person
{
    public string Name { get; set; }
    public int Points { get; set; }
    private List<Goal> _goals;

    public Person(string name)
    {
        Name = name;
        Points = 0;
        _goals = [];
    }
    public void CreateNewGoal()
    {
        Console.WriteLine($"What type of goal do you want to create");
        Console.WriteLine($"    1. Simple Goal");
        Console.WriteLine($"    2. Eternal Goal");
        Console.WriteLine($"    3. Checklist Goal");
        Console.WriteLine($"    4. Back");

        var option = Console.ReadLine();

        Console.Write("Name:  ");
        var name = Console.ReadLine();

        Console.Write("Description: ");
        var description = Console.ReadLine();

        Console.Write("Points: ");
        var points = int.Parse(Console.ReadLine());

        switch (option)
        {
            case "1":
                SimpleGoal sg = new SimpleGoal(name, description, points);
                _goals.Add(sg);
                break;
            case "2":
                EternalGoal eg = new EternalGoal(name, description, points);
                _goals.Add(eg);
                break;
            case "3":
                Console.Write("Bonus for Finishing:   ");
                var bonus = int.Parse(Console.ReadLine());

                Console.Write("Number of times to complete: ");
                var count = int.Parse(Console.ReadLine());

                CheckListGoal clg = new CheckListGoal(name, description, points, bonus, count);
                _goals.Add(clg);
                break;
            default:
                break;
        }
    }
    public void ListGoals()
    {
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{count} ");
            goal.DisplayGoal();
            count++;
        }
        Console.WriteLine();
    }
    public void RecordEvent()
    {
        ListGoals();
        Console.WriteLine("\nWhich goal did you complete? ");
        var goal = int.Parse(Console.ReadLine()) - 1;
        Points = +_goals[goal].CompleteGoal();
    }
    public string SavePerson()
    {
        var personText = $"{Name}\n{Points}\n";

        foreach (Goal goal in _goals)
        {
            personText = personText + goal.SaveGoal();
        }
        return personText;
    }
    public void LoadPerson(string person)
    {
        var goals = person.Split("\n");
        Points = int.Parse(goals[1]);

        foreach (string goal in goals)
        {
            var details = goal.Split("::");
            switch (details[0])
            {
                case "SG":
                    Goal sg = new SimpleGoal(details[1], details[2], int.Parse(details[3]), bool.Parse(details[4]));
                    _goals.Add(sg);
                    break;
                case "EG":
                    Goal eg = new EternalGoal(details[1], details[2], int.Parse(details[3]), int.Parse(details[4]));
                    _goals.Add(eg);
                    break;
                case "CLG":
                    Goal clg = new CheckListGoal(details[1], details[2], int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5]), int.Parse(details[6]), bool.Parse(details[7]));
                    _goals.Add(clg);
                    break;
                default:
                    break;
            }
        }
    }
}