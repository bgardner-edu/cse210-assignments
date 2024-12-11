using System.Xml.Linq;

public class ToDo
{
    protected string _id;
    protected string _name;
    protected DateTime _completeBy;
    protected int _dependsOn;
    protected bool _completed;

    public ToDo(string name, DateTime completeBy, int dependsOn)
    {
        _id = Guid.NewGuid().ToString();
        _name = name;
        _completeBy = completeBy;
        _dependsOn = dependsOn;
        _completed = false;
    }
    public ToDo(string id, string name, DateTime completeBy, int dependsOn, bool completed)
    {
        _id = id;
        _name = name;
        _completeBy = completeBy;
        _dependsOn = dependsOn;
        _completed = completed;
    }
    public string GetId()
    {
        return _id;
    }
    public DateTime GetDateTime()
    {
        return _completeBy;
    }
    public bool GetCompleted()
    {
        return _completed;
    }
    public virtual void ListToDoItem()
    {
        Console.WriteLine($"Todo: {_name}");
    }
    public virtual void MarkAsDone()
    {
        _completed = true;
    }
    public virtual string Save()
    {
        return $"td||{_id}||{_name}||{_completeBy}||{_dependsOn}||{_completed}";
    }
}