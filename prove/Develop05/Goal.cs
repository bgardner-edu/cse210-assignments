public abstract class Goal
{
    protected string _name { get; set; }
    protected string _description { get; set; }
    protected int _points { get; set; }
    protected bool _completed{ get; set; }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public abstract void DisplayGoal();
    public abstract int CompleteGoal();
    public abstract string SaveGoal();
}