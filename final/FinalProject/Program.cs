class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your username: ");
        var name = Console.ReadLine().ToLower();
        User user = SetupUser(name);

        Console.WriteLine($"Welcome {name}!");
        bool running = true;
        while (running)
        {
            //Display menu
            Console.WriteLine($"Menu");
            Console.WriteLine($"    1. Add New To Do Item");
            Console.WriteLine($"    2. List To Do's by Category");
            Console.WriteLine($"    3. List To Do's by Priority");
            Console.WriteLine($"    4. Mark To Do Completed");
            Console.WriteLine($"    5. Quit");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    user.CreateNewItem();
                    break;
                case "2":
                    user.ListItemsByType();
                    break;
                case "3":
                    user.ListItemsByDate();
                    break;
                case "4":
                    user.MarkItemCompleted();
                    break;
                case "5":
                    Console.WriteLine("GoodBye");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Not a valid input, please choose an option below.\n");
                    continue;
            }
        }
    }
    public static User SetupUser(string name)
    {
        var surveyFile = $"{name}_survey.txt";
        var toDoFile = $"{name}_todo.txt";
        if (File.Exists(surveyFile))
        {
            var survey = File.ReadAllText(surveyFile);

            if (File.Exists(toDoFile))
            {
                var toDo = File.ReadAllText(toDoFile);
                return new User(name, survey, toDo);
            }

            return new User(name, survey);
        }

        return new User(name);
    }
}