public abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public abstract int RecordEvent();  // Returns the points earned
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();
}
public class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        completed = false;
    }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return points;
        }
        return 0;
    }

    public override bool IsComplete() => completed;

    public override string GetStatus() => completed ? "[X]" : "[ ]";

    public override string GetStringRepresentation() =>
        $"SimpleGoal:{name},{description},{points},{completed}";
}
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => points;

    public override bool IsComplete() => false;

    public override string GetStatus() => "[8]";

    public override string GetStringRepresentation() =>
        $"EternalGoal:{name},{description},{points}";
}
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonus = bonus;
        currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
                return points + bonus;
            return points;
        }
        return 0;
    }

    public override bool IsComplete() => currentCount >= targetCount;

    public override string GetStatus() =>
        $"[{(IsComplete() ? "X" : " ")}] Completed {currentCount}/{targetCount}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal:{name},{description},{points},{bonus},{targetCount},{currentCount}";
}