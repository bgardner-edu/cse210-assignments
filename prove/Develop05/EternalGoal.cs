public class EternalGoal : Goal
{
    private int _completedCount;
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _completedCount = 0;
    }
    public override void DisplayGoal()
    {
        //TODO finish this...
        Console.WriteLine($"{_name} Completed {_completedCount}");
    }
    public override int CompleteGoal()
    {
        _completedCount++;
        return _points;
    }
}