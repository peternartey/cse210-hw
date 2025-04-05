public abstract class Goal
{
    public abstract int RecordEvent();
    public abstract string GetDetailsString();
}

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;
    private int _points;

    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted >= _target)
        {
            return _bonus + _points;
        }
        return _points;
    }

    public override string GetDetailsString()
    {
        return $"Checklist Goal - Completed {_timesCompleted}/{_target} times";
    }
}
List<Goal> goals = new List<Goal>
{
    new SimpleGoal(),
    new EternalGoal(),
    new ChecklistGoal()
};

foreach (Goal goal in goals)
{
    Console.WriteLine(goal.GetDetailsString());
    int earned = goal.RecordEvent();  // Polymorphism: same method, different behavior
    Console.WriteLine($"You earned {earned} points!");
}