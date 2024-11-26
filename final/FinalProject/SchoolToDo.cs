public class SchoolToDo : ToDo
{
    private string _forClass;
    public SchoolToDo(string name, DateTime completeBy, int dependsOn) : base(name, completeBy, dependsOn)
    {
        Console.WriteLine("Is this an assignment for a specific class? y/n");
        var response = Console.ReadLine();
        if (response == "y" || response == "yes")
        {
            Console.WriteLine("What class is this for?");
            var c = Console.ReadLine();
            _forClass = c;
        }
        else
        {
            _forClass = "";
        }

    }
    public SchoolToDo(string name, DateTime completeBy, int dependsOn, string forClass, string id, bool completed) : base(name, completeBy, dependsOn, id, completed)
    {
        _forClass = forClass;
    }
    public override void ListToDoItem()
    {
        if (_forClass != "")
        {
            Console.WriteLine($"Todo: {_name} \nFor class: {_forClass}");
        }
        else
        {
            base.ListToDoItem();
        }
    }
    public override void MarkAsDone()
    {
        if (_forClass != "")
        {
            Console.WriteLine($"Did you turn in assignment for {_forClass}? y/n");
            var response = Console.ReadLine();
            if (response == "y")
            {
                _completed = true;
            }
        }
        else
        {
            _completed = true;
        }

    }
}