public class CheckListGoal : Goal
{
    private int _bonusPoints;
    private int _count;
    private int _completedCount;
    public CheckListGoal(string name, string description, int points, int bonusPoints, int count) : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _count = count;
        _completedCount = 0;
    }
    public override void DisplayGoal()
    {
        //TODO finish this...
        Console.WriteLine($"{_name} completed {_completedCount}/{_count}");
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
}