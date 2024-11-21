public class CheckListGoal : Goal
{
    private int _bonusPoints;
    private int _count;
    private int _completedCount;
    public CheckListGoal(string name, string description, int points, int bonusPoints, int count, int completedCount = 0, bool completed = false) : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _count = count;
        _completedCount = completedCount;
        _completed = completed;
    }
    public override void DisplayGoal()
    {
        if (_completed)
        {
            Console.WriteLine($"[X] {_name} completed {_completedCount}/{_count}");
        }
        else
        {
            Console.WriteLine($"[] {_name} completed {_completedCount}/{_count}");
        }
    }
    public override int CompleteGoal()
    {
        _completedCount++;
        if(_completedCount == _count){
            _completed = true;
            return _bonusPoints + _points;
        }
        return _points;
    }
        public override string SaveGoal()
    {
        return $"CLG::{_name}::{_description}::{_points}::{_bonusPoints}::{_count}::{_completedCount}::{_completed}\n";
    }
}