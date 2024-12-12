public class VehicleToDo : ToDo
{
    private List<string> _parts = [];
    public VehicleToDo(string name, DateTime completeBy, string dependsOn) : base(name, completeBy, dependsOn)
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
                    break;
                }
                _parts.Add(r);
            }
        }
    }
    public VehicleToDo(string id, string name, DateTime completeBy, string dependsOn, bool completed, List<string> parts) : base(id, name, completeBy, dependsOn, completed)
    {
        _parts = parts;
    }
    public override void ListToDoItem()
    {
        if (_parts.Count > 0 && _parts[0] != "")
        {
            Console.WriteLine($"Car To Do: {_name} \nParts: ");
            foreach (string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
        else
        {
            base.ListToDoItem();
        }
    }
    public override string Save()
    {
        string parts = "";
        foreach(string p in _parts)
        {
            parts += $"{p}:";
        }
        return $"vtd||{_id}||{_name}||{_completeBy}||{_dependsOn}||{_completed}||{parts}";
    }
}