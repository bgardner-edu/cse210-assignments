public class VehicleToDo : ToDo
{
    private List<string> _parts;
    public VehicleToDo(string name, DateTime completeBy, int dependsOn) : base(name, completeBy, dependsOn)
    {
        Console.WriteLine("Do you need to order any parts? y/n");
        var response = Console.ReadLine();
        if (response == "y" || response == "yes")
        {
            while(true)
            {
                Console.WriteLine("Enter part or done to finish:");
                var r = Console.ReadLine();
                if(r.ToLower() == "done")
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
    }
    public VehicleToDo(string name, DateTime completeBy, int dependsOn, List<string> parts, string id, bool completed) : base(name, completeBy, dependsOn, id, completed)
    {
        _parts = parts;
    }
    public override void ListToDoItem()
    {
        if (_parts.Count > 0)
        {
            Console.WriteLine($"Todo: {_name} \nParts: ");
            foreach(string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
        else
        {
            base.ListToDoItem();
        }
    }
}