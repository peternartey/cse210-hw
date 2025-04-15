using System;
using System.Threading;

public abstract class Activity
{
    public string Name { get; }
    public string Description { get; }

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity(duration);
        EndActivity(duration);
    }

    protected abstract void RunActivity(int duration);

    protected void EndActivity(int duration)
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {Name} activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
