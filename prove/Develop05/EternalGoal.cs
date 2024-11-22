public class EternalGoal : Goal
{
    private int _completedCount;
    public EternalGoal(string name, string description, int points, int completedCount = 0) : base(name, description, points)
    {
        _completedCount = completedCount;
    }
    public override void DisplayGoal()
    {
        Console.WriteLine($"[] {_name} Completed: {_completedCount} times");
    }
    public override int CompleteGoal()
    {
        _completedCount++;
        return _points;
    }

    public override string SaveGoal()
    {
        return $"EG::{_name}::{_description}::{_points}::{_completedCount}\n";
    }
}