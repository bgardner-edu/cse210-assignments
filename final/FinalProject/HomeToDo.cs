public class HomeToDo : ToDo
{
    private List<string> _parts;
    private bool _outside;
    public HomeToDo(string name, DateTime completeBy, string dependsOn) : base(name, completeBy, dependsOn)
    {
        Console.WriteLine("Do you need to order any parts? y/n");
        var response = Console.ReadLine();
        if (response == "y" || response == "yes")
        {
            while (true)
            {
                Console.WriteLine("Enter part or done to finish:");
                var r = Console.ReadLine();
                if (r.ToLower() == "done")
                {
                    return;
                }
                _parts.Add(r);
            }
        }
        else
        {
            _parts = [];
        }
        Console.WriteLine("Does this require nice weather? y/n");
        response = Console.ReadLine();
        if (response == "y" || response == "yes")
        {
            _outside = true;
        }
        else
        {
            _outside = false;
        }
    }
    public HomeToDo(string id, string name, DateTime completeBy, string dependsOn, bool completed, List<string> parts, bool outside) : base(id, name, completeBy, dependsOn, completed)
    {
        _parts = parts;
        _outside = outside;
    }
    public override void ListToDoItem()
    {
        if (_parts.Count > 0)
        {
            Console.WriteLine($"Home To Do: {_name}");
            if (_outside)
            {
                Console.WriteLine("Make sure the weather is nice.");
            }
            Console.WriteLine($"Parts:");
            foreach (string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
        else
        {
            Console.WriteLine($"Home To Do: {_name}");
            if (_outside)
            {
                Console.WriteLine("Make sure the weather is nice.");
            }
        }
    }
    public override string Save()
    {
        return $"htd||{_id}||{_name}||{_completeBy}||{_dependsOn}||{_completed}||{_parts}||{_outside}";
    }
}