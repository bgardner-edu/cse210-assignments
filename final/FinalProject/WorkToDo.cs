public class WorkToDo : ToDo
{
    private string _reportBackTo;
    public WorkToDo(string name, DateTime completeBy, int dependsOn) : base(name, completeBy, dependsOn)
    {
        Console.WriteLine("Do you need report back to someone? y/n");
        var response = Console.ReadLine();
        if (response == "y" || response == "yes")
        {
            Console.WriteLine("Who do you need to report back to?");
            var r = Console.ReadLine();
            _reportBackTo = r;
        }
        else
        {
            _reportBackTo = "";
        }
    }
    public WorkToDo(string id, string name, DateTime completeBy, int dependsOn, bool completed, string reportBackTo) : base(id, name, completeBy, dependsOn, completed)
    {
        _reportBackTo = reportBackTo;
    }
    public override void ListToDoItem()
    {
        if (_reportBackTo != "")
        {
            Console.WriteLine($"Todo: {_name} \nReport back to: {_reportBackTo}");
        }
        else
        {
            base.ListToDoItem();
        }
    }
    public override void MarkAsDone()
    {
        if (_reportBackTo != "")
        {
            Console.WriteLine($"Did you report back to {_reportBackTo}? y/n");
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
    public override string Save()
    {
        return $"wtd||{_id}||{_name}||{_completeBy}||{_dependsOn}||{_completed}||{_reportBackTo}";
    }
}