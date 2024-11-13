public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {

    }
    public override void DisplayGoal()
    {
        //TODO finish this...
        Console.WriteLine(_name);
    }
    public override int CompleteGoal()
    {
        _completed = true;
        return _points;
    }
}