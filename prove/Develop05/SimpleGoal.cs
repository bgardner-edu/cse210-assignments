public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool completed = false) : base(name, description, points)
    {
        _completed = completed;
    }
    public override void DisplayGoal()
    {
        if (_completed)
        {
            Console.WriteLine($"[X] {_name}");
        }
        else
        {
            Console.WriteLine($"[] {_name}");
        }
    }
    public override int CompleteGoal()
    {
        _completed = true;
        return _points;
    }

    public override string SaveGoal()
    {
        return $"SG::{_name}::{_description}::{_points}::{_completed}\n";
    }
}