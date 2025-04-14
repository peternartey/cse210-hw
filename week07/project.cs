sing System;
using System.Collections.Generic;

// ABSTRACTION & BASE CLASS
public abstract class Goal
{
    protected string name;
    protected int points;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

    // POLYMORPHISM: Virtual method to be overridden
    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"{name} - {points} points");
    }
}

// INHERITANCE & POLYMORPHISM
public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        isComplete = false;
    }

    public override void RecordEvent()
    {
        isComplete = true;
        Console.WriteLine($"You completed: {name} (+{points} pts)");
    }

    public override bool IsComplete()
    {
        return isComplete;
    }

    public override void DisplayGoal()
    {
        string status = isComplete ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {name} - {points} pts");
    }
}

// INHERITANCE Example 2
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
        this.bonus = bonus;
    }

    public override void RecordEvent()
    {
        currentCount++;
        Console.WriteLine($"Progressed: {name} ({currentCount}/{targetCount})");

        if (currentCount == targetCount)
        {
            Console.WriteLine($"Checklist complete! Bonus: +{bonus} pts");
        }
    }

    public override bool IsComplete()
    {
        return currentCount >= targetCount;
    }

    public override void DisplayGoal()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {name} ({currentCount}/{targetCount}) - {points} pts each, bonus {bonus} pts");
    }
}

// MAIN PROGRAM (TESTING POLYMORPHISM)
class Program
{
    static void Main()
    {
        List<Goal> myGoals = new List<Goal>();

        // ENCAPSULATION: Data is private and only modified through methods
        myGoals.Add(new SimpleGoal("Read Scripture", 50));
        myGoals.Add(new ChecklistGoal("Attend Church", 20, 3, 100));

        foreach (Goal goal in myGoals)
        {
            goal.DisplayGoal();
        }

        Console.WriteLine("\nRecording an event...\n");

        foreach (Goal goal in myGoals)
        {
            goal.RecordEvent();  // POLYMORPHISM: Calls correct method
            goal.DisplayGoal();
        }
    }
}.